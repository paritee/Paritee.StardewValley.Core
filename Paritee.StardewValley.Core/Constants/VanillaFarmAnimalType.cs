using Paritee.StardewValley.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Paritee.StardewValley.Core.Constants
{
    public class VanillaFarmAnimalType : FarmAnimalType
    {
        public static VanillaFarmAnimalType WhiteChicken => new VanillaFarmAnimalType("White Chicken");
        public static VanillaFarmAnimalType BrownChicken => new VanillaFarmAnimalType("Brown Chicken");
        public static VanillaFarmAnimalType BlueChicken => new VanillaFarmAnimalType("Blue Chicken");
        public static VanillaFarmAnimalType VoidChicken => new VanillaFarmAnimalType("Void Chicken");
        public static VanillaFarmAnimalType WhiteCow => new VanillaFarmAnimalType("White Cow");
        public static VanillaFarmAnimalType BrownCow => new VanillaFarmAnimalType("Brown Cow");
        public static VanillaFarmAnimalType Goat => new VanillaFarmAnimalType("Goat");
        public static VanillaFarmAnimalType Duck => new VanillaFarmAnimalType("Duck");
        public static VanillaFarmAnimalType Sheep => new VanillaFarmAnimalType("Sheep");
        public static VanillaFarmAnimalType Rabbit => new VanillaFarmAnimalType("Rabbit");
        public static VanillaFarmAnimalType Pig => new VanillaFarmAnimalType("Pig");
        public static VanillaFarmAnimalType Dinosaur => new VanillaFarmAnimalType("Dinosaur");

        private VanillaFarmAnimalType(string name) : base(name) { }

        public static bool Exists(string str)
        {
            return PropertyConstant.Exists<VanillaFarmAnimalType>(str);
        }

        public static List<string> All()
        {
            List<VanillaFarmAnimalType> all = PropertyConstant.All<VanillaFarmAnimalType>();

            return all.Select(o => o.ToString()).ToList();
        }
    }
}
