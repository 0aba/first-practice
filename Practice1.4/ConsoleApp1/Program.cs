namespace Program
{
    class Program
    {
        public static long getMulNumberMultiples3LessN(int n) 
        {
            // -1 это означает отсутствие такого произведения
            long result = -1;
            long resultFor = 1;

            for (int i = 3; i <= n; i += 3)
            {
                resultFor *= i;

                if (i > n)
                {
                    break;
                }

                result = resultFor;
            }

            return result;
        }

        public static void Main()
        {
            Console.WriteLine("Введите число n: ");
            int n = int.Parse(Console.ReadLine());

            long mulNumberMultiples3LessN = getMulNumberMultiples3LessN(n);

            Console.WriteLine(mulNumberMultiples3LessN);
        }
    }
}