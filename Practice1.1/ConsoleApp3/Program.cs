namespace Program3
{
    class Program3
    {

        static void Main()
        {
            List<string> words = new List<string>();
            string newWords;

            while (true)
            {
                Console.WriteLine("Введите слово ( для остоновки введите пустую строку ):");
                newWords = Console.ReadLine();

                if (newWords.Equals(""))
                {
                    break;
                }

                words.Add(newWords);
            }

            if (words.Count != 0)
            {
                string maxlenWord = words[0];
                string minlenWord = words[0];

                foreach (string word in words)
                {
                    if (word.Length > maxlenWord.Length)
                    {
                        maxlenWord = word;
                    }

                    if (word.Length < minlenWord.Length)
                    {
                        minlenWord = word;
                    }
                }

                Console.WriteLine($"самое длинное: {maxlenWord} \n самое короткое: {minlenWord}");
            }
            else
            {
                Console.WriteLine("Список пуст");
            }
        }
    }
}