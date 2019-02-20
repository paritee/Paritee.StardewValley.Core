using StardewValley;
using System.Collections.Generic;

namespace Paritee.StardewValley.Core.Api
{
    public class Location
    {
        public static IList<GameLocation> All()
        {
            return Game1.locations;
        }

        public static bool IsBuildingConstructed(Farm farm, string name)
        {
            return farm.isBuildingConstructed(name);
        }
    }
}
