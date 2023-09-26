namespace EvenLines
{
    using System;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new();
            using StreamReader reader = new StreamReader(inputFilePath);
            string line = string.Empty;
            int count = 0;
            while (line != null)
            {
                line = reader.ReadLine();
                if (count % 2 == 0)
                {
                    string replacedSymbols = ReplaceSymbols(line);
                    string reversedWords = ReversedWords(replacedSymbols);
                    sb.AppendLine(reversedWords);
                }
                count++;
            }
            return sb.ToString().TrimEnd();
        }

        private static string ReversedWords(string replacedSymbols)
        {
            string[] reversedWords = replacedSymbols.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            return string.Join(" ", reversedWords);
        }

        private static string ReplaceSymbols(string line)
        {
            StringBuilder sb = new(line);
            char[] symbolToReplace = { '-', ',', '.', '!', '?' };
            foreach (char symbol in symbolToReplace)
            {
                sb = sb.Replace(symbol, '@');
            }
            return sb.ToString();
        }
    }
}
