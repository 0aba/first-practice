namespace WeatherAPP
{
    internal class Commands
    {
        private Utils _utils = new Utils();

        public void runСommand(string command)
        {
            Console.Clear();

            string[] commandData = command.Split(" ");

            switch (commandData[0])
            {
                case "help":
                    help();
                    break;

                case "help-command":
                    if (commandData.Length != 2)
                    {
                        Console.WriteLine("Ошибка количества аргументов");
                        return;
                    }

                    helpСommand(commandData[1]);
                    break;

                case "exit":
                    exit();
                    break;

                case "set-default-city":
                    if (commandData.Length != 2)
                    {
                        Console.WriteLine("Ошибка количества аргументов");
                        return;
                    }

                    setDefaultCity(commandData[1]);
                    break;

                case "get-city-weather":
                    if (commandData.Length != 2)
                    {
                        Console.WriteLine("Ошибка количества аргументов");
                        return;
                    }

                    printCityWeather(commandData[1]);
                    break;

                default:
                    Console.WriteLine("Ошибка такой команды нету");
                    break;
            }
        }

        private void help()
        {
            Console.WriteLine("Информация о командах :\n\n" +
                              "'help': информация о командах \n\n" +
                              "'help-command': информация о команде и ее синтаксисе \n\n" +
                              "'exit': завершение программы \n\n" +
                              "'set-default-city': установить город по умолчанию \n\n" +
                              "'get-city-weather': узнать погоду в городе \n\n"
                              );
        }

        private void exit()
        {
            Environment.Exit(Utils.EXIT_COMMAND);
        }

        private void helpСommand(string command)
        {
            string commandInfo = _utils.commandsInfo.GetValueOrDefault(command);

            Console.WriteLine("Синтаксис команды: ");

            Console.WriteLine(commandInfo is null ? "Ошибка такой команды нету" : commandInfo);
        }

        private void printCityWeather(string city)
        {
            GeoResponse[] coords = _utils.getСoordinates(city);

            if (coords.Length == 0) 
            {
                Console.WriteLine("Ошибка город не найден");
                return;
            }
            
            WeatherResponse weather = _utils.getCityWeather(coords[0].lat, coords[0].lon);

            _utils.printWeather(city,
                         weather.weather[0].main,
                         weather.weather[0].description,
                         (weather.main.temp - 273.15f),
                         (weather.main.feels_like - 273.15f),
                         weather.wind.speed);
        }

        private void setDefaultCity(string city)
        {
            GeoResponse[] coords = _utils.getСoordinates(city);

            if (coords.Length == 0)
            {
                Console.WriteLine("Ошибка город не найден");
                return;
            }

            _utils.settings.defaultCity = city;

            Console.WriteLine($"Город по умолчанию теперь: {city}");
            _utils.saveSettings();
        }
    }
}
