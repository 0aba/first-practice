namespace WeatherAPP
{
    internal class Settings
    {
        public Settings()
        {
            urlWeatherAPI = "https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&lang=ru&appid={2}";

            urlGeocodingAPI = "http://api.openweathermap.org/geo/1.0/direct?q={0}&appid={1}";

            keyAPI = "d1ca9a8ad062b0ea0b40a83035880bb8";
        }

        public string urlWeatherAPI { get; set; }

        public string urlGeocodingAPI { get; set; }

        public string defaultCity { get; set; }

        public string keyAPI { get; set; }
    }
}
