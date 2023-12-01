namespace Program2
{
    class Program2
    {

        static void Main()
        {
            List<int> numbers = new List<int>();
            int sum = 0;
            int mul = 1;
            int average;

            while (true)
            {
                Console.WriteLine("Введите число (0 для остановки):");
                int userNum = 0;
                try
                {
                    userNum = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка: это не целое число! (Число изменено на 0)");
                }

                if (userNum == 0)
                {
                    break;
                }
                numbers.Add(userNum);
            }

            if (numbers.Count != 0)
            {
                foreach (int num in numbers)
                {
                    sum += num;
                    mul *= num;
                }

                average = sum / numbers.Count;

                Console.WriteLine($"среднее = {average} \n сумм = {sum} \n произведение = {mul}");

            }
            else
            {
                Console.WriteLine("список пустой");
            }
        }
    }
}