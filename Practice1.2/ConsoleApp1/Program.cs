using System;


namespace Program
{
    class Program
    {
        public static void Main()
        {
            int[] numbers = new int[100];

            Console.WriteLine("Массив заполняется (каждое число меньше предыдущего на 3): ");
            for (int i = 0; i < numbers.Length; ++i)
            {
                numbers[i] = -i * 3;
                Console.WriteLine($"numbers[{i}] = {numbers[i]}");
            }
        }
    }
}