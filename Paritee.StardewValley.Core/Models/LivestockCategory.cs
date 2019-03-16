using System.Collections.Generic;

namespace Paritee.StardewValley.Core.Models
{
    public class LivestockCategory : PropertyConstant
    {
        public readonly int Order;
        public List<Livestock> Types = new List<Livestock>();
        public List<string> Buildings = new List<string>();
        public LivestockAnimalShop AnimalShop;

        public LivestockCategory(string name) : base(name) { }

        public LivestockCategory(string name, int order, List<Livestock> types, List<string> buildings, LivestockAnimalShop animalShop) : base(name)
        {
            this.Order = order;
            this.Types = types;
            this.Buildings = buildings;
            this.AnimalShop = animalShop;
        }

        public bool CanBePurchased()
        {
            return this.AnimalShop != null;
        }
    }
}
