using System.Collections.Generic;
using System;


namespace Program3
{
    class Program3
    {

        static void Main()
        {
            List<String> words = new List<String>();

            while (true)
            {
                Console.WriteLine("Введите слово ( для остоновки введите пустую строку ):");
                String newWords = Console.ReadLine();

                if (newWords.Equals(""))
                {
                    break;
                }

                words.Add(newWords);
            }

            if (words.Count != 0)
            {
                String maxlenWord = words[0];
                String minlenWord = words[0];
                foreach (String word in words)
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