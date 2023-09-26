namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            //create archive - open zipFile and create it
            using ZipArchive archive = ZipFile.Open(zipArchiveFilePath,ZipArchiveMode.Create);
            //take the file name only of the input file
            var fileNameOnly = Path.GetFileName(inputFilePath);
            //put the fileName copy from the input file path in the created zip
            archive.CreateEntryFromFile(inputFilePath, fileNameOnly);
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            //take the archive and open it for reading
            using ZipArchive archive = ZipFile.OpenRead(zipArchiveFilePath);
            //extract the information from it
            ZipArchiveEntry fileForExtraction = archive.GetEntry(fileName);
            //extract it in the output path file
            fileForExtraction.ExtractToFile(outputFilePath);
        }
    }
}
