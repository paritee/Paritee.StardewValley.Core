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

        public static bool Exists(string str)
        {
            return Utilities.PropertyConstant.Exists<Livestock>(str);
        }

        public static List<string> All()
        {
            List<Livestock> all = Utilities.PropertyConstant.All<Livestock>();

            return all.Select(o => o.ToString()).ToList();
        }
    }
}
