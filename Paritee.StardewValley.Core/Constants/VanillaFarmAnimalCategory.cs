using Paritee.StardewValley.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Paritee.StardewValley.Core.Constants
{
    public class VanillaFarmAnimalCategory : FarmAnimalCategory
    {
        public static VanillaFarmAnimalCategory DairyCow
        {
            get
            {
                string[] types = new string[]
                {
                    VanillaAnimalType.WhiteCow.ToString(),
                    VanillaAnimalType.BrownCow.ToString()
                };

                string[] buildings = new string[]
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Small),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Big),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Deluxe),
                };

                string displayName = VanillaFarmAnimalCategory.LoadDisplayName("5927");
                string description = VanillaFarmAnimalCategory.LoadDescription("11343");

                return new VanillaFarmAnimalCategory("Dairy Cow", 1, displayName, description, 1500, types, buildings);
            }
        }

        public static VanillaFarmAnimalCategory Chicken
        {
            get
            {
                string[] types = new string[]
                {
                    VanillaAnimalType.WhiteChicken.ToString(),
                    VanillaAnimalType.BrownChicken.ToString(),
                    VanillaAnimalType.BlueChicken.ToString(),
                    VanillaAnimalType.VoidChicken.ToString()
                };

                string[] excludeFromShop = new string[]
                {
                    VanillaAnimalType.VoidChicken.ToString()
                };

                string[] buildings = new string[]
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Small),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Big),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Deluxe),
                };

                string displayName = VanillaFarmAnimalCategory.LoadDisplayName("5922");
                string description = VanillaFarmAnimalCategory.LoadDescription("11334");

                return new VanillaFarmAnimalCategory("Chicken", 0, displayName, description, 800, types, buildings, excludeFromShop);
            }
        }

        public static VanillaFarmAnimalCategory Sheep
        {
            get
            {
                string[] types = new string[]
                {
                    VanillaAnimalType.Sheep.ToString()
                };

                string[] buildings = new string[]
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Deluxe),
                };

                string displayName = VanillaFarmAnimalCategory.LoadDisplayName("5942");
                string description = VanillaFarmAnimalCategory.LoadDescription("11352");

                return new VanillaFarmAnimalCategory("Sheep", 4, displayName, description, 8000, types, buildings);
            }
        }

        public static VanillaFarmAnimalCategory Goat
        {
            get
            {
                string[] types = new string[]
                {
                    VanillaAnimalType.Goat.ToString()
                };

                string[] buildings = new string[]
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Big),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Deluxe),
                };

                string displayName = VanillaFarmAnimalCategory.LoadDisplayName("5933");
                string description = VanillaFarmAnimalCategory.LoadDescription("11349");

                return new VanillaFarmAnimalCategory("Goat", 2, displayName, description, 4000, types, buildings);
            }
        }

        public static VanillaFarmAnimalCategory Pig
        {
            get
            {
                string[] types = new string[]
                {
                    VanillaAnimalType.Pig.ToString()
                };

                string[] buildings = new string[]
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Deluxe),
                };

                string displayName = VanillaFarmAnimalCategory.LoadDisplayName("5948");
                string description = VanillaFarmAnimalCategory.LoadDescription("11346");

                return new VanillaFarmAnimalCategory("Pig", 6, displayName, description, 16000, types, buildings);
            }
        }

        public static VanillaFarmAnimalCategory Duck
        {
            get
            {
                string[] types = new string[]
                {
                    VanillaAnimalType.Duck.ToString()
                };

                string[] buildings = new string[]
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Big),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Deluxe),
                };

                string displayName = VanillaFarmAnimalCategory.LoadDisplayName("5937");
                string description = VanillaFarmAnimalCategory.LoadDescription("11337");

                string[] exclude = new string[] { };
                double deluxeProduceLuck = 0.01;

                return new VanillaFarmAnimalCategory("Duck", 3, displayName, description, 4000, types, buildings, exclude, deluxeProduceLuck);
            }
        }

        public static VanillaFarmAnimalCategory Rabbit
        {
            get
            {
                string[] types = new string[]
                {
                    VanillaAnimalType.Rabbit.ToString()
                };

                string[] buildings = new string[]
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Deluxe),
                };

                string displayName = VanillaFarmAnimalCategory.LoadDisplayName("5945");
                string description = VanillaFarmAnimalCategory.LoadDescription("11340");

                string[] exclude = new string[] { };
                double deluxeProduceLuck = 0.02;

                return new VanillaFarmAnimalCategory("Rabbit", 5, displayName, description, 8000, types, buildings, exclude, deluxeProduceLuck);
            }
        }

        public static VanillaFarmAnimalCategory Dinosaur
        {
            get
            {
                string[] types = new string[]
                {
                    VanillaAnimalType.Dinosaur.ToString()
                };

                string[] buildings = new string[]
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Big),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Deluxe),
                };

                return new VanillaFarmAnimalCategory("Dinosaur", 7, types, buildings);
            }
        }

        private VanillaFarmAnimalCategory(string name, int order, string[] types, string[] buildings) 
            : base(name, order, types, buildings) { }

        private VanillaFarmAnimalCategory(string name, int order, string displayName, string description, int price, string[] types, string[] buildings, string[] excludeFromShop = null, double deluxeProduceLuck = default(double)) 
            : base(name, order, displayName, description, price, types, buildings, excludeFromShop, deluxeProduceLuck) { }


        public static bool Exists(string str)
        {
            return PropertyConstant.Exists<VanillaFarmAnimalCategory>(str);
        }

        public static List<VanillaFarmAnimalCategory> All()
        {
            List<VanillaFarmAnimalCategory> all = PropertyConstant.All<VanillaFarmAnimalCategory>();

            return all.OrderBy(o => o.Order).ToList();
        }

        private static string LoadDisplayName(string id)
        {
            return Api.Content.LoadString($"Strings\\StringsFromCSFiles:Utility.cs.{id}");
        }

        private static string LoadDescription(string id)
        {
            return Api.Content.LoadString($"Strings\\StringsFromCSFiles:PurchaseAnimalsMenu.cs.{id}");
        }
    }
}
