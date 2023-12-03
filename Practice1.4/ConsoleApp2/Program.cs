using System.Globalization;


namespace Program1
{
    class Program1
    {
        public static void Main()
        {
            Console.WriteLine("Укажите полный путь до файла c данными.\n" +
                              @"например: C:\Users\aba\Desktop\first-practice\for-1.4-work\numsTask2.txt" +
                              "\n путь: \n");

            string pathInput = Console.ReadLine();

            StreamReader readInput = new StreamReader(pathInput);

            string[] stringNumbers = readInput.ReadLine().Split(";");

            readInput.Close();

            float sum = 0;

            foreach (string stringNumber in stringNumbers)
            {
                float num = float.Parse(stringNumber, CultureInfo.InvariantCulture);

                if (num == 0)
                {
                    break;
                }

                sum += (num > 0) ? num : 0;
            }

            Console.WriteLine($"Сумма положительных вечественных чисел = {sum}");
        }
    }
}
