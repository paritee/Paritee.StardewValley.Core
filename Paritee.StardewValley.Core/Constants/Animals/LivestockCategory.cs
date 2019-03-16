using System.Collections.Generic;
using System.Linq;

namespace Paritee.StardewValley.Core.Constants.Animals
{
    public class LivestockCategory : Models.LivestockCategory
    {
        public static LivestockCategory DairyCow
        {
            get
            {
                List<Models.Livestock> types = new List<Models.Livestock>()
                {
                    Livestock.WhiteCow,
                    Livestock.BrownCow,
                };

                List<string> buildings = new List<string>()
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Small),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Big),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Deluxe),
                };

                string name = LivestockCategory.LoadDisplayName("5927");
                string description = LivestockCategory.LoadDescription("11343");

                Models.LivestockAnimalShop animalShop = new Models.LivestockAnimalShop(1500, name, description, null);

                return new LivestockCategory("Dairy Cow", 1, types, buildings, animalShop);
            }
        }

        public static LivestockCategory Chicken
        {
            get
            {
                List<Models.Livestock> types = new List<Models.Livestock>()
                {
                    Livestock.WhiteChicken,
                    Livestock.BrownChicken,
                    Livestock.BlueChicken,
                    Livestock.VoidChicken,
                };

                List<string> buildings = new List<string>()
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Small),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Big),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Deluxe),
                };

                List<Models.Livestock> exclude = new List<Models.Livestock>()
                {
                    Livestock.VoidChicken,
                };

                string name = LivestockCategory.LoadDisplayName("5922");
                string description = LivestockCategory.LoadDescription("11334");

                Models.LivestockAnimalShop animalShop = new Models.LivestockAnimalShop(800, name, description, exclude);

                return new LivestockCategory("Chicken", 0, types, buildings, animalShop);
            }
        }

        public static LivestockCategory Sheep
        {
            get
            {
                List<Models.Livestock> types = new List<Models.Livestock>()
                {
                    Livestock.Sheep,
                };

                List<string> buildings = new List<string>()
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Deluxe),
                };

                string name = LivestockCategory.LoadDisplayName("5942");
                string description = LivestockCategory.LoadDescription("11352");

                Models.LivestockAnimalShop animalShop = new Models.LivestockAnimalShop(8000, name, description, null);

                return new LivestockCategory("Sheep", 4, types, buildings, animalShop);
            }
        }

        public static LivestockCategory Goat
        {
            get
            {
                List<Models.Livestock> types = new List<Models.Livestock>()
                {
                    Livestock.Goat,
                };

                List<string> buildings = new List<string>()
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Big),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Deluxe),
                };

                string name = LivestockCategory.LoadDisplayName("5933");
                string description = LivestockCategory.LoadDescription("11349");

                Models.LivestockAnimalShop animalShop = new Models.LivestockAnimalShop(4000, name, description, null);

                return new LivestockCategory("Goat", 2, types, buildings, animalShop);
            }
        }

        public static LivestockCategory Pig
        {
            get
            {
                List<Models.Livestock> types = new List<Models.Livestock>()
                {
                    Livestock.Pig,
                };

                List<string> buildings = new List<string>()
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Barn, AnimalHouse.Size.Deluxe),
                };

                string name = LivestockCategory.LoadDisplayName("5948");
                string description = LivestockCategory.LoadDescription("11346");

                Models.LivestockAnimalShop animalShop = new Models.LivestockAnimalShop(16000, name, description, null);

                return new LivestockCategory("Pig", 6, types, buildings, animalShop);
            }
        }

        public static LivestockCategory Duck
        {
            get
            {
                List<Models.Livestock> types = new List<Models.Livestock>()
                {
                    Livestock.Duck,
                };

                List<string> buildings = new List<string>()
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Big),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Deluxe),
                };

                string name = LivestockCategory.LoadDisplayName("5937");
                string description = LivestockCategory.LoadDescription("11337");

                Models.LivestockAnimalShop animalShop = new Models.LivestockAnimalShop(4000, name, description, null);

                return new LivestockCategory("Duck", 3, types, buildings, animalShop);
            }
        }

        public static LivestockCategory Rabbit
        {
            get
            {
                List<Models.Livestock> types = new List<Models.Livestock>()
                {
                    Livestock.Rabbit,
                };

                List<string> buildings = new List<string>()
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Deluxe),
                };

                string name = LivestockCategory.LoadDisplayName("5945");
                string description = LivestockCategory.LoadDescription("11340");

                Models.LivestockAnimalShop animalShop = new Models.LivestockAnimalShop(8000, name, description, null);

                return new LivestockCategory("Rabbit", 5, types, buildings, animalShop);
            }
        }

        public static LivestockCategory Dinosaur
        {
            get
            {
                List<Models.Livestock> types = new List<Models.Livestock>()
                {
                    Livestock.Dinosaur,
                };

                List<string> buildings = new List<string>()
                {
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Big),
                    Api.AnimalHouse.FormatSize(AnimalHouse.Coop, AnimalHouse.Size.Deluxe),
                };

                return new LivestockCategory("Dinosaur", 7, types, buildings, null);
            }
        }

        private LivestockCategory(string name, int order, List<Models.Livestock> types, List<string> buildings, Models.LivestockAnimalShop animalShop) 
            : base(name, order, types, buildings, animalShop) { }

        public static bool Exists(string str)
        {
            return Models.PropertyConstant.Exists<LivestockCategory>(str);
        }

        public static List<LivestockCategory> All()
        {
            List<LivestockCategory> all = Models.PropertyConstant.All<LivestockCategory>();

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
