using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Network;
using System.Collections.Generic;

namespace Paritee.StardewValley.Core.Locations
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

        public static void RemoveAnimal(Farm farm, global::StardewValley.FarmAnimal animal)
        {
            farm.animals.Remove(animal.myID.Value);
        }

        public static bool IsOutdoors(GameLocation location)
        {
            return location.IsOutdoors;
        }

        public static void SpawnObject(GameLocation location, Vector2 tileLocation, global::StardewValley.Object obj)
        {
            Utility.spawnObjectAround(tileLocation, obj, location);
        }

        public static FarmerCollection GetFarmers(GameLocation location)
        {
            return location.farmers;
        }

        public static bool AnyFarmers(GameLocation location)
        {
            return Locations.Location.GetFarmers(location).Any();
        }

        public static bool IsLocation(GameLocation location, GameLocation target)
        {
            return location == target;
        }
    }
}
