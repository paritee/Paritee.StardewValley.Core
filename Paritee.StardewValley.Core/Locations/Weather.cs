using StardewValley;

namespace Paritee.StardewValley.Core.Locations
{
    public class Weather
    {
        public enum Name
        {
            Sunny = Game1.weather_sunny,
            Rain = Game1.weather_rain,
            Debris = Game1.weather_debris,
            Lightning = Game1.weather_lightning,
            Festival = Game1.weather_festival,
            Snow = Game1.weather_snow,
            Wedding = Game1.weather_wedding
        }

        public static bool IsWeather(Locations.Weather.Name weather, Locations.Weather.Name target)
        {
            return Locations.Weather.IsWeather((int)weather, (int)target);
        }

        public static bool IsWeather(int weather, int target)
        {
            return weather == target;
        }

        public static int GetToday()
        {
            return Game1.weatherIcon;
        }

        public static bool IsToday(Locations.Weather.Name weather)
        {
            return Locations.Weather.IsToday((int)weather);
        }

        public static bool IsToday(int weather)
        {
            return Locations.Weather.IsWeather(Locations.Weather.GetToday(), weather);
        }

        public static int GetTomorrow()
        {
            return Game1.weatherForTomorrow;
        }

        public static bool IsTomorrow(Locations.Weather.Name weather)
        {
            return Locations.Weather.IsTomorrow((int)weather);
        }

        public static bool IsTomorrow(int weather)
        {
            return Locations.Weather.IsWeather(Locations.Weather.GetTomorrow(), weather);
        }

        public static bool IsRaining()
        {
            return Game1.isRaining || Locations.Weather.IsToday(Locations.Weather.Name.Rain);
        }

        public static bool IsSnowing()
        {
            return Game1.isSnowing || Locations.Weather.IsToday(Locations.Weather.Name.Snow);
        }

        public static bool IsLightning()
        {
            return Game1.isLightning || Locations.Weather.IsToday(Locations.Weather.Name.Lightning);
        }

        public static bool IsDebris()
        {
            return Game1.isDebrisWeather || Locations.Weather.IsToday(Locations.Weather.Name.Debris);
        }

        public static bool IsWedding()
        {
            return Game1.weddingToday || Locations.Weather.IsToday(Locations.Weather.Name.Wedding);
        }

        public static bool IsFestival()
        {
            return Game1.isFestival() || Locations.Weather.IsToday(Locations.Weather.Name.Festival);
        }

        public static string GetFestivalLocation()
        {
            return Game1.whereIsTodaysFest;
        }
    }
}
