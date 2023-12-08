using System.Globalization;


namespace Program2
{
    class Program2
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

        private static int getSumBeforeIndex(ref int[] numbers, int beforeIndex)
        {
            int result = 0;

            for (int i = 0; i < beforeIndex; i++)
            {
                result += numbers[i];
            }

            return result;
        }

        public static void Main()
        {
            Console.WriteLine("Укажите полный путь до файла c данными.\n" +
                              @"например: C:\Users\aba\Desktop\first-practice\for-1.5-work\numsTask3.txt" +
                              "\n путь: \n");

            string pathInput = Console.ReadLine();

            StreamReader input = new StreamReader(pathInput);

            int[] numbers = input.ReadLine().Trim()
                                            .Split(" ")
                                            .Select(stringNumber => int.Parse(stringNumber, CultureInfo.InvariantCulture))
                                            .ToArray();

            input.Close();

            int indexMinNumber = getIndexMinElement(ref numbers);

            float verageBeforeIndex = getSumBeforeIndex(ref numbers, indexMinNumber) / (float)indexMinNumber;

            Console.WriteLine($"Результат: {verageBeforeIndex} ");
        }
    }
}