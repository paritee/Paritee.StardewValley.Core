using StardewValley;

namespace Paritee.StardewValley.Core.Constants
{
    public class Environment
    {
        public enum Season
        {
            Spring,
            Summer,
            Fall,
            Winter
        }

        public enum Weather
        {
            Sunny = Game1.weather_sunny,
            Rain = Game1.weather_rain,
            Debris = Game1.weather_debris,
            Lightning = Game1.weather_lightning,
            Festival = Game1.weather_festival,
            Snow = Game1.weather_snow,
            Wedding = Game1.weather_wedding
        }
    }
}
