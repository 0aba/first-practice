using System.Globalization;


namespace Program2
{
    class Program2
    {
        public static void Main()
        {
            Console.WriteLine("Укажите полный путь до файла c данными.\n" +
                              @"например: C:\Users\aba\Desktop\first-practice\for-1.4-work\numsTask3.txt" +
                              "\n путь: \n");

            string pathInput = Console.ReadLine();

            StreamReader readInput = new StreamReader(pathInput);

            string[] stringNumbers = readInput.ReadLine().Split(",");

            readInput.Close();

            int minNum = int.Parse(stringNumbers[0]);
            int maxNum = int.Parse(stringNumbers[0]);

            if (maxNum != 0) // первое число не ноль
            {
                foreach (string stringNumber in stringNumbers)
                {
                    int num = int.Parse(stringNumber, CultureInfo.InvariantCulture);

                    if (num == 0)
                    {
                        break;
                    }

                    if (minNum > num)
                    {
                        minNum = num;
                    }

                    if (maxNum < num)
                    {
                        maxNum = num;
                    }
                }

                Console.WriteLine($"Отношение минимального к максимальному числу {(float)minNum / maxNum}");
            }
            else
            {
                Console.WriteLine("Первое число это 0");
            }
        }
    }
}