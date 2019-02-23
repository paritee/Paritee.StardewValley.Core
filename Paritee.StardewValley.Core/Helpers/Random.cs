using StardewValley;

namespace Paritee.StardewValley.Core.Helpers
{
    public class Random
    {
        public static System.Random GetNumberGenerator()
        {
            return Game1.random;
        }

        public static System.Random Seed(int seed)
        {
            return new System.Random(seed);
        }

        public static double NextDouble(int seed = default(int))
        {
            return Helpers.Random.GetNumberGenerator().NextDouble();
        }

        public static int Next()
        {
            return Helpers.Random.GetNumberGenerator().Next();
        }

        public static int Next(int maxValue)
        {
            return Helpers.Random.GetNumberGenerator().Next(maxValue);
        }

        public static int Next(int minValue, int maxValue)
        {
            return Helpers.Random.GetNumberGenerator().Next(minValue, maxValue);
        }
    }
}
