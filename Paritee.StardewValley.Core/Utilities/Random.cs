using StardewValley;

namespace Paritee.StardewValley.Core.Utilities
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

        public static double NextDouble()
        {
            return Utilities.Random.GetNumberGenerator().NextDouble();
        }

        public static int Next()
        {
            return Utilities.Random.GetNumberGenerator().Next();
        }

        public static int Next(int maxValue)
        {
            return Utilities.Random.GetNumberGenerator().Next(maxValue);
        }

        public static int Next(int minValue, int maxValue)
        {
            return Utilities.Random.GetNumberGenerator().Next(minValue, maxValue);
        }
    }
}
