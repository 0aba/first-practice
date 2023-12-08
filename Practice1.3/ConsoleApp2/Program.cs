namespace Program2
{
    class Program2
    {
        public static void Main()
        {
            Console.WriteLine("Укажите полный путь до файла c данными.\n" +
                              @"например: C:\Users\aba\Desktop\first-practice\for-1.3-work\nums.txt" +
                              "\n путь: \n");

            string pathInput = Console.ReadLine();

            StreamReader readInput = new StreamReader(pathInput);

            string[] stringNumbers = readInput.ReadLine().Trim().Split(" ");

            readInput.Close(); 

            // Очистка 
            File.WriteAllText(pathInput, string.Empty);

            string write = string.Empty;

            foreach (string num in stringNumbers)
            {
                if (int.Parse(num) % 2 != 0)
                {
                    write += $"{num} ";
                }
            }
            write = write.Substring(0, write.Length - 1); // удаляет лишний пробел еще можно воспользоваться Trim()

            StreamWriter writeFile = new StreamWriter(pathInput);

            writeFile.Write(write);

            writeFile.Close();
        }
    }
}