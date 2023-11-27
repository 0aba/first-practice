using System;


namespace Program
{
    class Program
    {
        private static Random _rand = new Random();

        private static int[] getRandomFilledArr10()
        {
            int[] numbers = new int[10];

            for (int i = 0; i < numbers.Length; ++i)
            {
                numbers[i] = _rand.Next();
            }

            return numbers;
        }

        static void Main()
        {

            int[] numbers = getRandomFilledArr10();
            int indexMinEl = 0;

            for (int i = 0; i < numbers.Length; ++i)
            {
                if (numbers[indexMinEl] > numbers[i])
                {
                    indexMinEl = i;
                }
            }

            Console.WriteLine($"Минимальный индекс это {indexMinEl}");
        }
    }
}