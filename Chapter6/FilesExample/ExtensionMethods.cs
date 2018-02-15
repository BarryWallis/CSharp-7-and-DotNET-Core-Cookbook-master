using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesExample
{
    public static class ExtensionMethods
    {
        public static byte[] CompressStream(this byte[] originalSource)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(outStream,
                       CompressionMode.Compress))
                {
                    gzip.Write(originalSource, 0, originalSource.Length);
                }

                return outStream.ToArray();
            }
        }

        public static byte[] DecompressStream(this byte[] originalSource)
        {
            byte[] returnValue;
            using (MemoryStream sourceStream = new MemoryStream(originalSource))
            using (MemoryStream outStream = new MemoryStream())
            using (GZipStream gZipStream = new GZipStream(sourceStream, CompressionMode.Decompress))
            {
                gZipStream.CopyTo(outStream);
                returnValue = outStream.ToArray();
            }

            return returnValue;
        }

        public static void InMemCompressDecompress()
        {
            string largeFile = @"C:\Users\barry\AppData\Local\Temp\Documents\file 3.txt";
            string inputString = File.ReadAllText(largeFile);
            byte[] bytes = Encoding.Default.GetBytes(inputString);

            int originalLength = bytes.Length;
            byte[] compressedStream = bytes.CompressStream();
            int compressedLength = compressedStream.Length;

            byte[] decompressedStrem = compressedStream.DecompressStream();
            int decompressedLength = decompressedStrem.Length;

            Console.WriteLine($"Original string length = {originalLength}");
            Console.WriteLine($"Compressed string length = {compressedLength}");
            Console.WriteLine($"Uncompressed string length {decompressedLength}");

            // To get the original text back do this:
            // byte[] newString = Encoding.Default.GetString(deompressedStream);
        }
    }
}
