namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            string[] files = Directory.GetFiles(folderPath);
            long bytes = 0;
            for(int i = 0; i < files.Length;i++)
            {
                FileInfo info = new FileInfo(files[i]);
                bytes += info.Length;
            }
            string[] directories = Directory.GetDirectories(folderPath);
       
            using StreamWriter writer = new StreamWriter(outputFilePath);
            writer.WriteLine($"{bytes/1024}kb");
  
        }
    }
}
