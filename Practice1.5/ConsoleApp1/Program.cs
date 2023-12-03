using System.Globalization;

namespace Program
{
    class Program
    {
        private static int getIndexMinElement(ref int[] numbers)
        {
            int indexMin = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[indexMin] > numbers[i])
                {
                    indexMin = i;
                }
            }

            return indexMin;
        }

        private static int getMulNumbersAfter(ref int[] numbers, int afterIndex)
        {
            int result = 1;

            for (int i = afterIndex + 1; i < numbers.Length; i++)
            {
                result *= numbers[i];
            }

            return result;
        }

        public static void Main()
        {
            Console.WriteLine("Укажите полный путь до файла c данными.\n" +
                              @"например: C:\Users\aba\Desktop\first-practice\for-1.5-work\numsTask1.txt" +
                              "\n путь: \n");

            string pathInput = Console.ReadLine();

            StreamReader input = new StreamReader(pathInput);

            int[] numbers = input.ReadLine().Split(" ")
                                            .Select(stringNumber => int.Parse(stringNumber, CultureInfo.InvariantCulture))
                                            .ToArray();

            input.Close();

            int indexMinNumber = getIndexMinElement(ref numbers);

            int mulNumbersAfter = getMulNumbersAfter(ref numbers, indexMinNumber);


            Console.WriteLine($"Результат: {mulNumbersAfter}");
        }
    }
}