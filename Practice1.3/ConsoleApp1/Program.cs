using System;
using System.IO;


namespace Program
{
    class Program
    {
        private static bool isLuckyTicket(ref String[] luckyStringNumbers, ref String[] ticketsStringNumbers )
        {
            byte amountCoincidencesNum = 0;

            for (int i = 0; i < ticketsStringNumbers.Length; i++)
            {
                for (int j = 0; j < luckyStringNumbers.Length; j++)
                {
                    if (ticketsStringNumbers[i].Equals(luckyStringNumbers[j]))
                    {
                        ++amountCoincidencesNum;
                        break;
                    }
                }

                if (amountCoincidencesNum == 3)
                {
                    return true;
                }
            }

            return false;
        }

        private static void printLuckyUnluckyTicket(String pathInput, String pathOutput)
        {
            StreamReader readInput = new StreamReader(pathInput);

            // получаем удачные числа
            String[] luckyNumStr = readInput.ReadLine().Split(" ");

            // получаем количество билетов
            int amountTickets;
            
            amountTickets = int.Parse(readInput.ReadLine());

            // Очистка ( на случай если там мусор )
            File.WriteAllText(pathOutput, String.Empty);

            // открытие output файла
            StreamWriter outputWriter = new StreamWriter(pathOutput);

            for (int i = 0; i < amountTickets; i++)
            {
                String[] ticketNumStr = readInput.ReadLine().Split(" ");

                outputWriter.WriteLine( isLuckyTicket(ref luckyNumStr, ref ticketNumStr) ? "Lucky" : "Unlucky" );
            }

            outputWriter.Close();
            readInput.Close();
        }

        public static void Main()
        {
            Console.WriteLine("Укажите полный путь до файла c данными.\n" + 
                             @"например: C:\\Users\aba\Desktop\first-practice\for-1.3-work\input.txt" +
                             "\n путь: \n");

            String pathInput = Console.ReadLine();

            Console.WriteLine("\n\n");

            Console.WriteLine("Укажите полный путь до файла для записи результата.\n" +
                             @"например: C:\\Users\aba\Desktop\first-practice\for-1.3-work\output.txt" +
                             "\n путь: \n");

            String pathOutput = Console.ReadLine();

            printLuckyUnluckyTicket(pathInput, pathOutput);
        }
    }
}
