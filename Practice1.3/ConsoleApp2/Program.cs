namespace Program2
{
    class Program2
    {
        public static void Main()
        {
            Console.WriteLine("Укажите полный путь до файла c данными.\n" +
                              @"например: C:\\Users\aba\Desktop\first-practice\for-1.3-work\nums.txt " +
                              "\n путь: \n");

            String pathInput = Console.ReadLine();

            StreamReader readInput = new StreamReader(pathInput);

            string[] stringNumbers = readInput.ReadLine().Split(" ");

            readInput.Close(); 

            // Очистка 
            File.WriteAllText(pathInput, String.Empty);

            String write = String.Empty;

            foreach (string num in stringNumbers)
            {
                if (int.Parse(num) % 2 != 0)
                {
                    write += num + " ";
                }
            }
            write = write.Substring(0, write.Length - 1); // удаляет лишний пробел

            StreamWriter writeFile = new StreamWriter(pathInput);

            writeFile.Write(write);

            writeFile.Close();
        }
    }
}