using System.Collections.Generic;

namespace Paritee.StardewValley.Core.Characters
{
    public class LivestockAnimalShop
    {
        public readonly int Price;
        public string Name;
        public string Description;
        public List<Livestock> Exclude;

        public LivestockAnimalShop(int price, string name, string description, List<Livestock> exclude)
        {
            this.Price = price;
            this.Name = name;
            this.Description = description;
            this.Exclude = exclude;
        }
    }
}
