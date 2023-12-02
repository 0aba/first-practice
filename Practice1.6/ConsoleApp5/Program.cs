namespace Program4
{
    class Program4
    {
        private static Random _rand = new Random();

        private static int[,] getMatrix1and0(int n, int m) 
        {
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = _rand.Next(0,2);
                }
            }

            return matrix;
        }

        private static void addСolumnMakeEvenNumber1(ref int[,] matrix)
        {
            int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool evenAmountOne = true;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrix[i, j];

                    if (matrix[i, j] == 1)
                    {
                        evenAmountOne = !evenAmountOne;
                    }
                }

                if (!evenAmountOne)
                { 
                    newMatrix[i, newMatrix.GetLength(1) - 1] = 1;
                }
            }


            matrix = newMatrix;
        }

        public static void Main()
        {
            Console.Write("Ваведите N: ");
            int n = int.Parse(Console.ReadLine()); 

            Console.Write("Ваведите M: ");
            int m = int.Parse(Console.ReadLine());

            int[,] a = getMatrix1and0(n, m);

            addСolumnMakeEvenNumber1(ref a);

            Console.WriteLine("Измененная матрица: ");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"{a[i, j]} ");
                }
                Console.WriteLine();
            }

        }
    }
}