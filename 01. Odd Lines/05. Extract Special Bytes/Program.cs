﻿using System.Text;

namespace ExtractSpecialBytes
{
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            StreamReader binaryFile = new StreamReader(binaryFilePath);
           
            byte[] encodedBytes = Encoding.Unicode.GetBytes(binaryFile);
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                while ()
                {
                    writer.WriteLine(Encoding.Unicode.GetBytes(binaryFile));
                }

            }
        }
    }
}
