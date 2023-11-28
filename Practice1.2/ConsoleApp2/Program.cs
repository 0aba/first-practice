using System;


namespace Program2
{
    class Program2
    {
        public static void Main()
        {
            int[] numbers = new int[50];

            Console.WriteLine("Массив заполняется нечетными числами: ");
            for (int i = 0; i < numbers.Length; ++i)
            {
                numbers[i] = 1 + i * 2;
                Console.WriteLine($"numbers[{i}] = {numbers[i]}");
            }
        }
    }
}
