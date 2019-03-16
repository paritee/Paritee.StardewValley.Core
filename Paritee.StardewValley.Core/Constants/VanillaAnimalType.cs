using Paritee.StardewValley.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Paritee.StardewValley.Core.Constants
{
    public class VanillaAnimalType : FarmAnimalType
    {
        // Farm Animals
        public static VanillaAnimalType WhiteChicken => new VanillaAnimalType("White Chicken");
        public static VanillaAnimalType BrownChicken => new VanillaAnimalType("Brown Chicken");
        public static VanillaAnimalType BlueChicken => new VanillaAnimalType("Blue Chicken");
        public static VanillaAnimalType VoidChicken => new VanillaAnimalType("Void Chicken");
        public static VanillaAnimalType WhiteCow => new VanillaAnimalType("White Cow");
        public static VanillaAnimalType BrownCow => new VanillaAnimalType("Brown Cow");
        public static VanillaAnimalType Goat => new VanillaAnimalType("Goat");
        public static VanillaAnimalType Duck => new VanillaAnimalType("Duck");
        public static VanillaAnimalType Sheep => new VanillaAnimalType("Sheep");
        public static VanillaAnimalType Rabbit => new VanillaAnimalType("Rabbit");
        public static VanillaAnimalType Pig => new VanillaAnimalType("Pig");
        public static VanillaAnimalType Dinosaur => new VanillaAnimalType("Dinosaur");

        // Pets
        public static VanillaAnimalType Cat => new VanillaAnimalType("Cat");
        public static VanillaAnimalType Dog => new VanillaAnimalType("Dog");

        // Horse
        public static VanillaAnimalType Horse => new VanillaAnimalType("Horse");


        private VanillaAnimalType(string name) : base(name) { }

        public static bool Exists(string str)
        {
            return PropertyConstant.Exists<VanillaAnimalType>(str);
        }

        public static List<string> All()
        {
            List<VanillaAnimalType> all = PropertyConstant.All<VanillaAnimalType>();

            return all.Select(o => o.ToString()).ToList();
        }
    }
}
