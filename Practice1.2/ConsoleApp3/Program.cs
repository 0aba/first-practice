namespace Program3
{
    class Program3
    {
        public static void Main()
        {
            int n = 1;

            try
            {
                Console.Write("Введите числа n: ");
                n = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка: это не целое число ( число по умолчанию 1 )");
            }

            int[,] matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    if (i == 0 || j == 0)
                    {
                        matrix[i, j] = 1;
                        matrix[j, i] = 1;
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
                        matrix[j, i] = matrix[i - 1, j] + matrix[i, j - 1];
                    }

                }
            }

            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write(String.Format("{0,8}", matrix[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}
