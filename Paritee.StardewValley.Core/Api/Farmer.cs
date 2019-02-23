using StardewValley;
using StardewValley.Buildings;
using System.Linq;

namespace Paritee.StardewValley.Core.Api
{
    public class Farmer
    {
        public static bool CanAfford(global::StardewValley.Farmer farmer, int amount)
        {
            return farmer.Money >= amount;
        }

        public static void SpendMoney(global::StardewValley.Farmer farmer, int amount)
        {
            farmer.Money -= amount;
        }

        public static long GetUniqueId(global::StardewValley.Farmer farmer)
        {
            return farmer.UniqueMultiplayerID;
        }

        public static bool HasSeenEvent(global::StardewValley.Farmer farmer, int eventId)
        {
            return farmer.eventsSeen.Contains(eventId);
        }

        public static bool HasCompletedQuest(global::StardewValley.Farmer farmer, int questId)
        {
            return farmer.questLog.Where(o => o.id.Value.Equals(questId) && o.completed.Value).Any();
        }

        public static int GetLuckLevel(global::StardewValley.Farmer farmer)
        {
            return farmer.LuckLevel;
        }

        public static double GetDailyLuck(global::StardewValley.Farmer farmer)
        {
            return Api.Game.GetDailyLuck() + Api.Farmer.GetLuckLevel(farmer);
        }

        public static GameLocation GetCurrentLocation(global::StardewValley.Farmer farmer)
        {
            return farmer.currentLocation;
        }

        public static bool IsCurrentLocation(global::StardewValley.Farmer farmer, GameLocation location)
        {
            return Api.Location.IsLocation(Api.Farmer.GetCurrentLocation(farmer), location);
        }

        public static global::StardewValley.FarmAnimal CreateFarmAnimal(global::StardewValley.Farmer farmer,  string type, string name = null, Building home = null, long myId = default(long))
        {
            return Api.FarmAnimal.CreateFarmAnimal(type, Api.Farmer.GetUniqueId(farmer), name, home, myId);
        }

    }
}
