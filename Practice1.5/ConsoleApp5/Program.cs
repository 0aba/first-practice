
using System.Globalization;

namespace Program4
{
    class Program4
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

        private static float getAverageBetween(ref int[] numbers, int startIndex, int endIndex)
        {
            float verage = 0;

            for (int i = startIndex + 1; i < endIndex; i++)
            {
                verage += numbers[i];
            }


            return verage / (endIndex - startIndex - 1);
        }

        public static void Main()
        {
            Console.WriteLine("Укажите полный путь до файла c данными.\n" +
                              @"например: C:\Users\aba\Desktop\first-practice\for-1.5-work\numsTask5.txt" +
                              "\n путь: \n");

            string pathInput = Console.ReadLine();

            StreamReader input = new StreamReader(pathInput);

            int[] numbers = input.ReadLine().Split(" ")
                .Select(stringNumber => int.Parse(stringNumber, CultureInfo.InvariantCulture))
                .ToArray();

            input.Close();

            int indexMaxElement = getIndexMaxElement(ref numbers);

            int indexMinElement = getIndexMinElement(ref numbers);

            float averageBetweenMinMaxElement = getAverageBetween(ref numbers,

                                                             (indexMinElement < indexMaxElement)
                                                                      ? indexMinElement : indexMaxElement,

                                                             (indexMinElement > indexMaxElement)
                                                                     ? indexMinElement : indexMaxElement);

            Console.WriteLine($"Среднее арифметическое между минимальным и максимальным: {averageBetweenMinMaxElement}");
        }
    }
}