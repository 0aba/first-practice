namespace Program5
{
    class Program5
    {
        static void Main()
        {
            Console.WriteLine("Введите текст ( cлова разделяется одним пробелом ): ");
            string textUser = Console.ReadLine();
            int countWord = 0;

            if (!textUser.Equals(string.Empty))
            {
                textUser += " ";
                foreach (char chr in textUser)
                {
                    if (chr.Equals(' '))
                    {
                        ++countWord;
                    }
                }

                textUser = $"Start {textUser}End";

                Console.WriteLine(textUser);
                Console.WriteLine($"Количество слов = {countWord}");
            }
            else
            {
                Console.WriteLine("Текст это пустая строка");
            }
        }
    }
}
