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
    }
}
