namespace Program3
{
    class Program3
    {
        public static void Main()
        {
            Console.WriteLine("Укажите полный путь до файла c данными.\n" +
                              @"например: C:\Users\aba\Desktop\first-practice\for-1.4-work\numsTask4.txt" +
                              "\n путь: \n");

            string pathInput = Console.ReadLine();

            StreamReader readInput = new StreamReader(pathInput);

            string[] stringNumbers = readInput.ReadLine().Split(" ");

            readInput.Close();

            int count = 0;

            for (int i = 0; i < stringNumbers.Length; i++)
            {
                if (i + 1 < stringNumbers.Length && stringNumbers[i + 1].Equals(""))
                {
                    break;
                }

                if ( i + 1 < stringNumbers.Length && stringNumbers[i].Equals(stringNumbers[i + 1]))
                {
                    ++count;
                } 
                else if ( i - 1 >= 0 && stringNumbers[i].Equals(stringNumbers[i - 1]))
                {
                    ++count;
                }
            }

            Console.WriteLine($"количество совпадений: {count}");
        }
    }
}
