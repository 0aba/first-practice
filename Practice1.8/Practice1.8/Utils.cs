using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WeatherAPP
{
    internal class Utils
    {
        public string pathToSettingsJSON;

        public Settings settings;

        public HttpClient _client = new HttpClient();

        public Dictionary<string, string> commandsInfo = new Dictionary<string, string>()
        {
            {"'help'", "help"},
            {"'set-default-city'", "set-default-city (город)"},
            {"'help-command'",""},
            {"'get-city-weather'", "get-city-weather (город)"},
            {"'exit'", "exit"},
        };

        public Utils()
        {
            pathToSettingsJSON = Directory.GetCurrentDirectory() + "/SettingsJSON.json";

            if (!File.Exists(pathToSettingsJSON))
            {
                File.Create(pathToSettingsJSON).Close(); // Close(), чтобы небыло ошибки несуществующий файл.
            }

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string dataJSON = File.ReadAllText(pathToSettingsJSON);

            settings = JsonConvert.DeserializeObject<Settings>(dataJSON);

            if (settings is null)
            {
                settings = new Settings();
            }

            printCityDefaultWeather();
        }

        private void printCityDefaultWeather()
        {
            if (settings.defaultCity is null)
            {
                Console.WriteLine("Город по умолчанию не устанвлен");
                return;
            }

            GeoResponse[] coords = getСoordinates(settings.defaultCity);

            WeatherResponse weather = getCityWeather(coords[0].lat, coords[0].lon);

            printWeather(settings.defaultCity,
                         weather.weather[0].main,
                         weather.weather[0].description,
                         (weather.main.temp - 273.15f),
                         (weather.main.feels_like - 273.15f),
                         weather.wind.speed);

        }
        public GeoResponse[] getСoordinates(string city)
        {
            var response = _client.GetAsync(string.Format(settings.urlGeocodingAPI, city, settings.keyAPI)).Result;

            string responseString = response.Content.ReadAsStringAsync().Result;

            GeoResponse[] coordinates = JsonConvert.DeserializeObject<GeoResponse[]>(responseString);

            return coordinates;
        }

        public WeatherResponse getCityWeather(float lat, float lon)
        {
            var response = _client.GetAsync(string.Format(settings.urlWeatherAPI, lat, lon, settings.keyAPI)).Result;

            string responseString = response.Content.ReadAsStringAsync().Result;

            WeatherResponse weather = JsonConvert.DeserializeObject<WeatherResponse>(responseString);

            return weather;
        }

        public void printWeather(string city, string weatherMain, string weatherDescription, float temp, float tempFeelsLike, float windSpeed)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------\n" +
                string.Format("|                                город:  {0,18}                                        |\n", city) +
                             "----------------------------------------------------------------------------------------------------\n" +
               string.Format("|   {0,14}   |   {1,71}   |\n", weatherMain, weatherDescription) +
                             "----------------------------------------------------------------------------------------------------\n" +
               string.Format("|       темпратура:  {0,7:N1}°C                   |           осущается как:  {1,7:N1}°C             |\n", temp, tempFeelsLike) +
                             "----------------------------------------------------------------------------------------------------\n" +
               string.Format("|                           скорость ветра:  {0,7:N1} м/c                                           |\n", windSpeed) +
                             "----------------------------------------------------------------------------------------------------" );
        }

        public void saveSettings()
        {
            string serializedTodoTasks = JsonConvert.SerializeObject(settings);

            File.WriteAllText(pathToSettingsJSON, serializedTodoTasks);
        }
    }
}
