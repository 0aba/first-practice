﻿namespace Program3
{
    class Program3
    {
        public static int getMaxVolume(ref int[] numbersInput)
        {
            int result = 0;

            for (int i = numbersInput.Length - 1; i >= 0; --i)
            {
                for (int j = 0; j < i; j++)
                {
                    int minHeight = ( numbersInput[i] < numbersInput[j] ) ? numbersInput[i] : numbersInput[j];

                    int resulFor = (i - j) * minHeight;

                    if (resulFor > result)
                    {
                        result = resulFor;
                    }
                }
            }

            return result;
        }

        public static void Main()
        {
            Console.WriteLine("Укажите полный путь до файла c данными.\n" +
                              @"например: C:\Users\aba\Desktop\first-practice\for-1.3-work\input3.txt" +
                              "\n путь: \n");

            string pathInput = Console.ReadLine();

            int[] numbersInput;

            StreamReader readInput = new StreamReader(pathInput);

            string[] input = readInput.ReadLine().Trim().Split(" ");

            readInput.Close();

            numbersInput = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                numbersInput[i] = int.Parse(input[i]);
            }

            int maxVolume = getMaxVolume(ref numbersInput);

            Console.WriteLine($"Максимальный возможный объем: {maxVolume}");
        }
    }
}