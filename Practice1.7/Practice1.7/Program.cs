namespace TodoAPP
{
    class Program
    {
        private Сommands _commands = new Сommands();
        public static void Main()
        {
            Program program = new Program();

            string command;

            Console.WriteLine("Введите 'help' чтобы узнать какие есть команды");

            while (true)
            {
                Console.Write(">> ");

                command = Console.ReadLine();

                program._commands.runСommand(command);
            }
        }
    }
}
