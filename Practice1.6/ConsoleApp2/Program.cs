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

            string[] words = File.ReadAllLines(pathInput);

            Console.WriteLine("Слова в одну строку: ");

            foreach (string word in words)
            {
                Console.Write($"{word} ");
            }
        }
    }
}
