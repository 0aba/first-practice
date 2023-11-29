using System;


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

            string stringNumbers = readInput.ReadLine();

            readInput.Close(); /* File нельзя использовать пока открыто соединение, 
                                * поэтому записываю данные в переменную stringNumbers,
                                * закрываю соединение и только потом делаю очистку File.WriteAllText
                                */

            // Очистка 
            File.WriteAllText(pathInput, String.Empty);

            // Запись
            String write = String.Empty;

            foreach (String num in stringNumbers.Split(" "))
            {
                if (num != "" && int.Parse(num) % 2 != 0)
                {
                    write += num + " ";
                }
            }

            StreamWriter writeFile = new StreamWriter(pathInput);
            writeFile.Write(write);

            writeFile.Close();
        }
    }
}