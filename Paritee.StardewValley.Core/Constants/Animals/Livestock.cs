using System.Collections.Generic;
using System.Linq;

namespace Paritee.StardewValley.Core.Constants.Animals
{
    public class Livestock : Models.Livestock
    {
        // Farm Animals
        public static Livestock WhiteChicken => new Livestock("White Chicken", 0d);
        public static Livestock BrownChicken => new Livestock("Brown Chicken", 0d);
        public static Livestock BlueChicken => new Livestock("Blue Chicken", 0d);
        public static Livestock VoidChicken => new Livestock("Void Chicken", 0d);
        public static Livestock WhiteCow => new Livestock("White Cow", 0d);
        public static Livestock BrownCow => new Livestock("Brown Cow", 0d);
        public static Livestock Goat => new Livestock("Goat", 0d);
        public static Livestock Duck => new Livestock("Duck", 0.01d);
        public static Livestock Sheep => new Livestock("Sheep", 0d);
        public static Livestock Rabbit => new Livestock("Rabbit", 0.02d);
        public static Livestock Pig => new Livestock("Pig", 0d);
        public static Livestock Dinosaur => new Livestock("Dinosaur", 0d);

        private Livestock(string name, double deluxeProduceLuck) : base(name, deluxeProduceLuck) { }

        public static bool Exists(string str)
        {
            return Models.PropertyConstant.Exists<Livestock>(str);
        }

        public static List<string> All()
        {
            List<Livestock> all = Models.PropertyConstant.All<Livestock>();

            return all.Select(o => o.ToString()).ToList();
        }
    }
}
