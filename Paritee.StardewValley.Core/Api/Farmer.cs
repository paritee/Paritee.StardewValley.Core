using StardewValley;
using StardewValley.Buildings;
using System;
using System.Linq;

namespace Paritee.StardewValley.Core.Api
{
    public class Farmer
    {
        public static bool CanAfford(global::StardewValley.Farmer farmer, int amount, Constants.Currency.Type currency = Constants.Currency.Type.Money)
        {
            switch(currency)
            {
                case Constants.Currency.Type.Money:
                    return farmer.Money >= amount;

                case Constants.Currency.Type.FestivalScore:
                    return farmer.festivalScore >= amount;

                case Constants.Currency.Type.ClubCoins:
                    return farmer.clubCoins >= amount;

                default:
                    return false;
            }
        }

        public static void Spend(global::StardewValley.Farmer farmer, int amount, Constants.Currency.Type currency)
        {
            switch (currency)
            {
                case Constants.Currency.Type.Money:
                    farmer.Money = Math.Max(Constants.Currency.MinimumAmount, farmer.Money - amount);
                    break;

                case Constants.Currency.Type.FestivalScore:
                    farmer.festivalScore = Math.Max(Constants.Currency.MinimumAmount, farmer.festivalScore - amount);
                    break;

                case Constants.Currency.Type.ClubCoins:
                    farmer.clubCoins = Math.Max(Constants.Currency.MinimumAmount, farmer.clubCoins - amount);
                    break;
            }
        }

        public static void SpendMoney(global::StardewValley.Farmer farmer, int amount)
        {
            Api.Farmer.Spend(farmer, amount, Constants.Currency.Type.Money);
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
