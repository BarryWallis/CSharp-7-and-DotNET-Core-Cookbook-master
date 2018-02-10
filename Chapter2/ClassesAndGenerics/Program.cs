using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ClassesAndGenerics
{
    class Program
    {
        public enum MyEnum { Value1, Value2, Value3 }

        static void Main(string[] args)
        {
            #region Abstract Classes
            //Lion lion = new Lion(Lion.ColorSpectrum.White);
            //lion.Hunt();
            //lion.Eat();
            //lion.Sleep();

            //Tiger tiger = new Tiger(Tiger.ColorSpectrum.Blue);
            //tiger.Hunt();
            //tiger.Eat();
            //tiger.Sleep();
            #endregion

            #region Interfaces
            //Cheetah cheetah = new Cheetah();
            //cheetah.Hunt();
            //cheetah.Eat();
            //cheetah.Sleep();
            //cheetah.SoftPurr(60);
            #endregion

            #region Generics
            //PerformAction<int> actionInt = new PerformAction<int>(21);
            //actionInt.IdentifyDataType();

            //PerformAction<decimal> actionDecimal = new PerformAction<decimal>(21.55m);
            //actionDecimal.IdentifyDataType();

            //PerformAction<string> actionString = new PerformAction<string>("Hello Generics");
            //actionString.IdentifyDataType();

            //DataSet dataSet = new DataSet();
            //PerformAction<DataSet> actionDataSet = new PerformAction<DataSet>(dataSet);
            //actionDataSet.IdentifyDataType();

            //MyHelperClass myHelperClass = new MyHelperClass();
            //int intExample = myHelperClass.InspectType(25);
            //WriteLine($"An of this type is {intExample}");

            //decimal decimalExample = myHelperClass.InspectType(11.78m);
            //WriteLine($"An example of this type is {decimalExample}");

            //MyEnum enumExample = myHelperClass.InspectType(MyEnum.Value2);
            //WriteLine($"An example if this type is {enumExample}");
            #endregion

            #region Generic Interfaces
            Invoice invoice = new Invoice();
            InspectClass<Invoice> invoiceClassInspector = new InspectClass<Invoice>(invoice);
            List<string> invoiceProperties = invoiceClassInspector.GetPropertyList();
            foreach (string property in invoiceProperties)
            {
                WriteLine(property);
            }
            Write($"\nPress any key to continue...");
            ReadKey();
            WriteLine();

            SalesOrder salesOrder = new SalesOrder();
            InspectClass<SalesOrder> salesOrderClassInspector = new InspectClass<SalesOrder>(salesOrder);
            List<string> salesOrderProperties = salesOrderClassInspector.GetPropertyList();
            foreach (string property in salesOrderProperties)
            {
                WriteLine(property);
            }
            #endregion

            if (Debugger.IsAttached)
            {
                Write($"\nPress any key to continue...");
                ReadKey();
            }
        }
    }
}
