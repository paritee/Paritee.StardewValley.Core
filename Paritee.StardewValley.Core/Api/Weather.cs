using StardewValley;

namespace Paritee.StardewValley.Core.Api
{
    public class Weather
    {
        public static bool IsWeather(Constants.Environment.Weather weather, Constants.Environment.Weather target)
        {
            return Api.Weather.IsWeather((int)weather, (int)target);
        }

        public static bool IsWeather(int weather, int target)
        {
            return weather.Equals(target);
        }

        public static int GetToday()
        {
            return Game1.weatherIcon;
        }

        public static bool IsToday(Constants.Environment.Weather weather)
        {
            return Api.Weather.IsToday((int)weather);
        }

        public static bool IsToday(int weather)
        {
            return Api.Weather.IsWeather(Api.Weather.GetToday(), weather);
        }

        public static int GetTomorrow()
        {
            return Game1.weatherForTomorrow;
        }

        public static bool IsTomorrow(Constants.Environment.Weather weather)
        {
            return Api.Weather.IsTomorrow((int)weather);
        }

        public static bool IsTomorrow(int weather)
        {
            return Api.Weather.IsWeather(Api.Weather.GetTomorrow(), weather);
        }

        public static bool IsRaining()
        {
            return Game1.isRaining || Api.Weather.IsToday(Constants.Environment.Weather.Rain);
        }

        public static bool IsSnowing()
        {
            return Game1.isSnowing || Api.Weather.IsToday(Constants.Environment.Weather.Snow);
        }

        public static bool IsLightning()
        {
            return Game1.isLightning || Api.Weather.IsToday(Constants.Environment.Weather.Lightning);
        }

        public static bool IsDebris()
        {
            return Game1.isDebrisWeather || Api.Weather.IsToday(Constants.Environment.Weather.Debris);
        }

        public static bool IsWedding()
        {
            return Game1.weddingToday || Api.Weather.IsToday(Constants.Environment.Weather.Wedding);
        }

        public static bool IsFestival()
        {
            return Game1.isFestival() || Api.Weather.IsToday(Constants.Environment.Weather.Festival);
        }

        public static string GetFestivalLocation()
        {
            return Game1.whereIsTodaysFest;
        }
    }
}
