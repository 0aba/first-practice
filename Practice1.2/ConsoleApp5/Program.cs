namespace Program5
{
    class Program5
    {
        public static Random _rand = new Random();

        public static Dictionary<String, float[]> getRandomFilledDictTemperatureYear()
        {
            Dictionary<String, float[]> dictionaryMonths = new Dictionary<string, float[]>();

            String[] months =
            {
                "January",  "February",     "March",
                  "April",       "May",      "June",
                   "July",    "August", "September",
                "October",  "November",  "December"
            };

            int[] averageTemperature =
            {
                -16,   -15, -7,
                3,   17,   20,
                23,   20,  11,
                0,   -10,   -15
            };

            for (int i = 0; i < months.Length; ++i)
            {
                float[] temperatureMonth = new float[30];

                for (int j = 0; j < temperatureMonth.Length; j++)
                {
                    temperatureMonth[j] = _rand.Next(averageTemperature[i] - 10, averageTemperature[i] + 10);
                }

                dictionaryMonths.Add(months[i], temperatureMonth);
            }

            return dictionaryMonths;
        }

        public static Dictionary<String, float> getDictAverageTemperatureMonths(ref Dictionary<String, float[]> temperatureYear)
        {
            Dictionary<String, float> averageTemperatureYear = new Dictionary<string, float>();

            foreach (var month in temperatureYear)
            {
                float averageTemperatureMonth = 0;

                foreach (float num in month.Value)
                {
                    averageTemperatureMonth += num;
                }

                averageTemperatureYear.Add(month.Key, averageTemperatureMonth / month.Value.Length);
            }

            return averageTemperatureYear;
        }

        public static void Main()
        {
            Dictionary<String, float[]> temperatureYear = getRandomFilledDictTemperatureYear();

            Dictionary<String, float> averageTemperatureMonths = getDictAverageTemperatureMonths(ref temperatureYear);

            float averageTemperaturesYear = 0;

            Console.WriteLine("Средние температуры месяцев: ");
            foreach (var month in averageTemperatureMonths)
            {
                Console.WriteLine($"{month.Key}: {string.Format("{0:N1} °C", month.Value)}" );
                averageTemperaturesYear += month.Value;
            }

            Console.WriteLine(string.Format("Средняя температура года: {0:N1} °C", averageTemperaturesYear / 12));
        }
    }
}
