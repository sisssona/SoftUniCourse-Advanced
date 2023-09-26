using System.Text;

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
            using StreamReader reader = new StreamReader(bytesFilePath);
            byte[] fileBytes = File.ReadAllBytes(binaryFilePath);
            var bytesList = new List<string>();
            StringBuilder sb = new StringBuilder();

            while (!reader.EndOfStream)
            {
               bytesList.Add(reader.ReadLine()); 
            }
            foreach (var bytes in fileBytes)
            {
                sb.AppendLine(bytes.ToString());
            }
            using StreamWriter writer = new System.IO.StreamWriter(outputPath);
            writer.WriteLine(sb.ToString().Trim());

        }
    }
}
