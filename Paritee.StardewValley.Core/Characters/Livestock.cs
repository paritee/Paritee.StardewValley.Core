using System.Collections.Generic;
using System.Linq;

namespace Paritee.StardewValley.Core.Characters
{
    public class Livestock : Characters.Animal
    {
        public double DeluxeProduceLuck;

        public Livestock(string name, double deluxeProduceLuck) : base(name)
        {
            this.DeluxeProduceLuck = deluxeProduceLuck;
        }
    }
}
