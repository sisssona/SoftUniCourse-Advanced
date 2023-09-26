using System;
using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream sourceFile = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                int fileSize = (int)sourceFile.Length;
                int partSize = fileSize / 2;
                int partOneSize = partSize + (fileSize % 2); // Handle odd-sized files.

                byte[] partOneData = new byte[partOneSize];
                byte[] partTwoData = new byte[fileSize - partOneSize];

                sourceFile.Read(partOneData, 0, partOneSize);
                sourceFile.Read(partTwoData, 0, fileSize - partOneSize);

                File.WriteAllBytes(partOneFilePath, partOneData);
                File.WriteAllBytes(partTwoFilePath, partTwoData);
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream partOneFile = new FileStream(partOneFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream partTwoFile = new FileStream(partTwoFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream joinedFile = new FileStream(joinedFilePath, FileMode.Create, FileAccess.Write))
            using (BinaryReader readerOne = new BinaryReader(partOneFile))
            using (BinaryReader readerTwo = new BinaryReader(partTwoFile))
            using (BinaryWriter writer = new BinaryWriter(joinedFile))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = readerOne.Read(buffer, 0, buffer.Length)) > 0)
                {
                    writer.Write(buffer, 0, bytesRead);
                }

                while ((bytesRead = readerTwo.Read(buffer, 0, buffer.Length)) > 0)
                {
                    writer.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}
