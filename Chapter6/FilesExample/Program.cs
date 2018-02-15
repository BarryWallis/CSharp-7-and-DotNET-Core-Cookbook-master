using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;


namespace FilesExample
{
    class Program
    {
        static void Main()
        {
            #region Creating and extracting ZIP archives
            //ZipIt(@"C:\Users\barry\AppData\Local\Temp\");
            //UnZipIt(@"C:\Users\barry\AppData\Local\Temp\");
            #endregion

            #region In-memory stream compression and decompression
            ExtensionMethods.InMemCompressDecompress();
            #endregion

            if (Debugger.IsAttached)
            {
                Console.Write($"\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        #region Creating and extracting ZIP archives
        private static void ZipIt(string path)
        {
            string sourceDirectory = $"{path}Documents";
            if (Directory.Exists(sourceDirectory))
            {
                string archiveName = $"{path}DocumentsArchive.zip";
                ZipFile.CreateFromDirectory(sourceDirectory, archiveName, CompressionLevel.Optimal, false);
                Console.Error.WriteLine($"{sourceDirectory} has been archived.");
            }
            else
            {
                Console.Error.WriteLine($"source directory: {sourceDirectory} does not exist!");
            }
        }

        private static void UnZipIt(string path)
        {
            string destinationDirectory = $"{path}DocumentsUnzipped";

            if (Directory.Exists(path))
            {
                string archiveName = $"{path}DocumentsArchive.zip";
                ZipFile.ExtractToDirectory(archiveName, destinationDirectory);
                Console.Error.WriteLine($"{archiveName} has been unarchived.");
            }
            else
            {
                Console.Error.WriteLine($"{path} does not exist.");
            }
        }
        #endregion

        #region In-memory stream compression and decompression

        #endregion
    }
}
