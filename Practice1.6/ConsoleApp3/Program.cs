namespace Program2
{
    class Program2
    {
        public static void Main()
        {
            Console.Write("Введите число: ");
            int numUser = int.Parse(Console.ReadLine());

            Console.WriteLine((numUser % 2 == 0 && numUser % 10 == 0) ? "Число четное и кратное 10" : "Число не четное или не кратное 10");
        }
    }
}