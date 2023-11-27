using System.Collections.Generic;
using System;


namespace Program4
{
    class Program4
    {
        private static Random _rand = new Random();

        private static int[] getFilledArr10(int startRand, int endRand)
        {
            int[] numbers = new int[10];

            for (int i = 0; i < numbers.Length; ++i)
            {
                numbers[i] = _rand.Next(startRand, endRand);
            }

            return numbers;
        }

        static void Main()
        {
            Console.WriteLine("Введите начала рандомного числа");
            int startRand = 0;

            try
            {
                startRand = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка: Это не число (значение по умолчанию 0)");
            }

            Console.WriteLine("Введите конец рандомного числа");
            int endRand = 100;

            try
            {
                endRand = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка: Это не число (значение по умолчанию 100)");
            }

            int[] numbers = getFilledArr10(startRand, endRand);

            Console.Write("Числа массива:");
            foreach (int num in numbers)
            {
                Console.Write($" {num} ");
            }

        }
    }
}
