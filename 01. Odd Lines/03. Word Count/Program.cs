namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> countOfWords = new Dictionary<string, int>();


            string words = File.ReadAllText(wordsFilePath);
            string[] wordsArray = words.Split(" ",StringSplitOptions.TrimEntries);
            using (StreamReader textReader = new StreamReader(textFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string text = textReader.ReadLine();
                    while (text != null)
                    {

                        for (int j = 0; j < wordsArray.Length; j++)
                        {
                            if (text.ToLower().Contains(wordsArray[j].ToLower()) && !countOfWords.ContainsKey(wordsArray[j]))
                            {
                                countOfWords.Add(wordsArray[j], 1);
                            }

                            else if (text.ToLower().TrimEnd().Contains(wordsArray[j].ToLower()))
                            {
                                countOfWords[wordsArray[j]]++;
                            }
                        
                        }


                        text = textReader.ReadLine();
                    }

                    foreach (var word in countOfWords.OrderByDescending(x=>x.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }

            }

        }

    }
}

