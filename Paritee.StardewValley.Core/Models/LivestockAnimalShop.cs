using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paritee.StardewValley.Core.Models
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
