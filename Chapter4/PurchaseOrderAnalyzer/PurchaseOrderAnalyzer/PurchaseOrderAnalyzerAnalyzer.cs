using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace PurchaseOrderAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class PurchaseOrderAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "PurchaseOrderAnalyzer";
        public enum ClassTypesToCheck { PurchaseOrder, SalesOrder }
        public enum MandatoryInterfaces { IReceiptable }

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = "Interface Implemenatation Availble";
        private static readonly LocalizableString MessageFormat = "IReceiptable Interface not Implemented";
        private static readonly LocalizableString Description = "You need to implement the IReceiptable interface";
        private const string Category = "Naming";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            // TODO: Replace the following code with your own analysis, generating Diagnostic objects for any issues you find
            bool isInterfaceImplemented = false;
            if (!context.Symbol.IsAbstract)
            {
                INamedTypeSymbol namedTypeSymbol = context.Symbol as INamedTypeSymbol;
                Debug.Assert(namedTypeSymbol != null);
                List<string> classesToCheck = Enum.GetNames(typeof(ClassTypesToCheck)).ToList();

                if (classesToCheck.Any(s => s.Equals(namedTypeSymbol.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    string interfaceName = nameof(MandatoryInterfaces.IReceiptable);
                    if (namedTypeSymbol.AllInterfaces.Any(s => s.Name.Equals(interfaceName, StringComparison.OrdinalIgnoreCase)))
                    {
                        isInterfaceImplemented = true;
                    }

                    if (!isInterfaceImplemented)
                    {
                        // Produce a diagnostic
                        Diagnostic diagnostic = Diagnostic.Create(Rule, namedTypeSymbol.Locations[0], namedTypeSymbol.Name);
                        context.ReportDiagnostic(diagnostic);
                    }
                }
            }
        }
    }
}
