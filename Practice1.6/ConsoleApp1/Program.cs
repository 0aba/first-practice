namespace Program
{
    class Program 
    {
        private static uint getLenghtWord(string word)
        {
            uint len = 0;

            foreach (char chr in word) 
            {
                uint codeChar = (uint) chr;

                if ((65 <= codeChar && codeChar <= 90) || (97 <= codeChar && codeChar <= 122)) // фильтер: , . ! ? и т.д.
                {
                    ++len;
                }
            }

            return len;
        }

        private static void printWordsOddLength(ref string[] words)
        {
            foreach (string word in words) 
            { 
                uint lenWord = getLenghtWord(word);

                if (lenWord % 2 != 0)
                {
                    Console.WriteLine(word);
                }
            }
        }

        public static void Main() 
        {
            Console.WriteLine("Укажите полный путь до файла c данными.\n" +
                              @"например: C:\Users\aba\Desktop\first-practice\for-1.6-work\numsTask1.txt" +
                              "\n путь: \n");

            string pathInput = Console.ReadLine();


            StreamReader input = new StreamReader(pathInput);

            string[] words = input.ReadLine().Split(" ");

            input.Close();

            Console.WriteLine("Все слова нечетной длины: ");
            printWordsOddLength(ref words);
        }
    }
}