namespace Program1
{
    class Program1
    {
        public static void Main()
        {

            Console.WriteLine("Укажите полный путь до файла c данными.\n" +
                              @"например: C:\Users\aba\Desktop\first-practice\for-1.6-work\numsTask2.txt" +
                              "\n путь: \n");

            string pathInput = Console.ReadLine();

            StreamReader input = new StreamReader(pathInput);

            // "\n" - новая строка, а "\r" символ возрата каретки и новый строки ( мешает коректному выводу текста )
            string[] words = input.ReadToEnd().Replace("\r", "").Split("\n");

            input.Close();

            Console.WriteLine("Слова в одну строку: ");

            foreach (string word in words)
            {
                Console.Write($"{word} ");
            }

        }
    }
}
