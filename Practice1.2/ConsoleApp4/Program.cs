namespace Program4
{
    class Program4
    {
        public static Random _rand = new Random();

        public static float[,] getRandomFilledMatrixTemperatureYear()
        {
            float[,] temperatureYear = new float[12, 30];

            int[] averageTemperature =
            {
                -16,   -15, -7,
                3,   17,   20,
                23,   20,  11,
                0,   -10,   -15
            };

            for (int i = 0; i < temperatureYear.GetLength(0); ++i)
            {
                for (int j = 0; j < temperatureYear.GetLength(1); ++j)
                {
                    temperatureYear[i, j] = _rand.Next(averageTemperature[i] - 10, averageTemperature[i] + 10);
                }
            }

            return temperatureYear;
        }

        public static float[] getArrAverageTemperaturesMonths(ref float[,] matrixYear)
        {
            float[] averageTemperaturesMonths = new float[12];

            for (int i = 0; i < matrixYear.GetLength(0); ++i)
            {
                float averageTemperaturesMonth = 0;

                for (int j = 0; j < matrixYear.GetLength(1); ++j)
                {
                    averageTemperaturesMonth += matrixYear[i, j];
                }

                averageTemperaturesMonths[i] = averageTemperaturesMonth / 30;
            }

            return averageTemperaturesMonths;
        }

        static public void sotrArrFloat(ref float[] arrFloat)
        {
            for (int i = 0; i < arrFloat.Length; ++i)
            {
                for (int j = 0; j < arrFloat.Length - i - 1; ++j)
                {
                    if (arrFloat[j] > arrFloat[j + 1])
                    {
                        float swap = arrFloat[j];
                        arrFloat[j] = arrFloat[j + 1];
                        arrFloat[j + 1] = swap;
                    }
                }
            }
        }

        public static void Main()
        {
            float[,] temperatureYear = getRandomFilledMatrixTemperatureYear();

            float[] averageTemperaturesMonths = getArrAverageTemperaturesMonths(ref temperatureYear);

            sotrArrFloat(ref averageTemperaturesMonths);

            float averageTemperaturesYear = 0;

            Console.WriteLine("Отсортированный массив средних температур месяцев: ");
            foreach (float temperature in averageTemperaturesMonths)
            {
                Console.WriteLine(temperature);
                averageTemperaturesYear += temperature;
            }
            Console.WriteLine($"Средняя температура года: {averageTemperaturesYear / averageTemperaturesMonths.Length}");
        }
    }
}
