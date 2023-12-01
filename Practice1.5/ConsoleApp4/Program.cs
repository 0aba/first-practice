using System.Globalization;

namespace Program3
{
    class Program3
    {
        private static int getIndexMaxElement(ref int[] numbers)
        {
            int indexMax = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[indexMax] < numbers[i])
                {
                    indexMax = i;
                }
            }

            return indexMax;
        }

        private static int getSumElDifferin1MaxNumber(ref int[] numbers, int indexMax)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[indexMax] - numbers[i] == 1)
                {
                    sum += numbers[i];
                }
            }

            return sum;
        }

        public static void Main()
        {
            Console.WriteLine("Укажите полный путь до файла c данными.\n" +
                              @"например: C:\Users\aba\Desktop\first-practice\for-1.5-work\numsTask4.txt" +
                              "\n путь: \n");

            string pathInput = Console.ReadLine();

            StreamReader input = new StreamReader(pathInput);

            int[] numbers = input.ReadLine().Split(" ")
                .Select(stringNumber => int.Parse(stringNumber, CultureInfo.InvariantCulture))
                .ToArray();

            input.Close();

            int indexMaxNumber = getIndexMaxElement(ref numbers);

            int sumElDifferin1MaxNumber = getSumElDifferin1MaxNumber(ref numbers, indexMaxNumber);

            Console.WriteLine($"Результат: {sumElDifferin1MaxNumber}");

        }
    }
}