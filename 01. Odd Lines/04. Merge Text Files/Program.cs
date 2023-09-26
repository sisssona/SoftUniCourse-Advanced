namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader first = new StreamReader(firstInputFilePath);
            StreamReader second = new StreamReader(secondInputFilePath);
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                while (first.EndOfStream == false && second.EndOfStream == false)
                {

                    string line1 = first.ReadLine();
                    writer.WriteLine(line1);
                    string line2 = second.ReadLine();
                    writer.WriteLine(line2);
                }
                if (first.EndOfStream == true)
                {
                    while (second.EndOfStream == false)
                    {
                        string line2 = second.ReadLine();
                        writer.WriteLine(line2);
                    }

                }
                else if (first.EndOfStream == false)
                {
                    while (first.EndOfStream == false)
                    {
                        string line1 = first.ReadLine();
                        writer.WriteLine(line1);
                    }

                }
            }
        }
    }
}

