using System.Globalization;


namespace Program1
{
    class Program1
    {
        public static void sortFloatArray(ref float[] arrayFloat)
        {
            for (int i = 0; i < arrayFloat.Length; ++i)
            {
                for (int j = 0; j < arrayFloat.Length - i - 1; ++j)
                {
                    if (arrayFloat[j] > arrayFloat[j + 1])
                    {
                        float swap = arrayFloat[j];
                        arrayFloat[j] = arrayFloat[j + 1];
                        arrayFloat[j + 1] = swap;
                    }
                }
            }
        }

        public static void Main()
        {
            Console.WriteLine("Укажите полный путь до файла c данными.\n" +
                              @"например: C:\Users\aba\Desktop\first-practice\for-1.5-work\numsTask2.txt" +
                              "\n путь: \n");

            string pathInput = Console.ReadLine();

            StreamReader input = new StreamReader(pathInput);

            float[] numbers = input.ReadLine().Split(";")
                                              .Select(stringNumber => float.Parse(stringNumber, CultureInfo.InvariantCulture))
                                              .ToArray();

            input.Close();

            File.WriteAllText(pathInput, string.Empty);

            sortFloatArray(ref numbers);

            string write = string.Empty;

            for (int i = 0; i < numbers.Length; i++)
            {
                write += ((i != numbers.Length - 1) ? $"{numbers[i]};" : $"{numbers[i]}").Replace(",", ".");
            }

            StreamWriter writer = new StreamWriter(pathInput);
            writer.WriteLine(write);
            
            writer.Close();
        }
    }
}