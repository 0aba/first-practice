namespace Program3
{
    class Program3
    {
        public static void Main()
        {
            Console.Write("Введите положительное число, которое будет делимым: ");
            int divisibleUser = int.Parse(Console.ReadLine());
            int divisorUser;

            int sum = 0;

            if (divisibleUser > 0)
            {
                Console.Write("Введите положительное число, которое будет делимым: ");
                divisorUser = int.Parse(Console.ReadLine());

                while (divisorUser > 0)
                {
                    if (divisibleUser % divisorUser == 0)
                    {
                        sum += divisorUser;
                    }

                    Console.Write("Введите положительное число, которое будет делимым: ");
                    divisorUser = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Остановка: число делителя отрицательное или равно нулю");
            }
            else
            {
                Console.WriteLine("Остановка: число делимое отрицательное или равно нулю");
            }

            Console.WriteLine($"сумма: {sum}");
        }
    }
}
