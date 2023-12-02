namespace Program5
{
    class Program5
    {
        private static Random _rand = new Random();

        private static float[] getRandomFloatArr()
        {
            float[] numbers = new float[_rand.Next(10, 20)];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = (float)_rand.NextDouble() + _rand.Next(-10, 10);
            }
            return numbers;
        }

        private static void separatePositiveNegativeNumbers(ref float[] floatArr, ref float[] positive, ref float[] negative)
        {
            positive = new float[floatArr.Length];
            negative = new float[floatArr.Length];

            int indexAddPositive = 0;
            int indexAddNegative = 0;

            foreach (float num in floatArr)
            {
                if (num < 0)
                {
                    negative[indexAddNegative] = num;
                    ++indexAddNegative;
                }
                else if (num > 0)
                {
                    positive[indexAddPositive] = num;
                    ++indexAddPositive;
                }
            }

            // убирает лишние нули, что поможно было использовать foreach вместо  for (int i = 0;i < indexAddNegative/indexAddNegative; ++i)
            Array.Resize(ref negative, indexAddNegative);
            Array.Resize(ref positive, indexAddPositive);
        }

        public static void Main()
        {
            float[] positive = { }; // чтобы можно было передать в  функцию = { }
            float[] negative = { }; // чтобы можно было передать в  функцию = { }

            float[] floatArr = getRandomFloatArr();

            separatePositiveNegativeNumbers(ref floatArr, ref positive, ref negative);

            Console.WriteLine("Массив отрицательных числел: ");
            foreach (float num in negative)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("+--------------------------------------+");

            Console.WriteLine("Массив положительных числел: ");
            foreach (float num in positive)
            {
                Console.WriteLine(num);
            }
        }
    }
}
