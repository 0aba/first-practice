namespace WeatherAPP
{
    class Program
    {
        private Commands _commands = new Commands();
        public static void Main()
        {
            Program program = new Program();

            string command;

            Console.WriteLine("Введите 'help' чтобы узнать какие есть команды");

            while (true)
            {
                Console.Write(">> ");

                command = Console.ReadLine().Trim();

                program._commands.runСommand(command);
            }
        }
    }
}
