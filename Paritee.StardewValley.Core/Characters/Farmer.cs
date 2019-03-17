using StardewValley;
using StardewValley.Buildings;
using System;
using System.Linq;

namespace Paritee.StardewValley.Core.Characters
{
    public class Farmer
    {
        public enum Profession
        {
            Rancher = global::StardewValley.Farmer.rancher,
            Tiller = global::StardewValley.Farmer.tiller,
            Butcher = global::StardewValley.Farmer.butcher,
            Shepherd = global::StardewValley.Farmer.shepherd,
            Artisan = global::StardewValley.Farmer.artisan,
            Agriculturist = global::StardewValley.Farmer.agriculturist,
            Fisher = global::StardewValley.Farmer.fisher,
            Trapper = global::StardewValley.Farmer.trapper,
            Angler = global::StardewValley.Farmer.angler,
            Pirate = global::StardewValley.Farmer.pirate,
            Baitmaster = global::StardewValley.Farmer.baitmaster,
            Mariner = global::StardewValley.Farmer.mariner,
            Forester = global::StardewValley.Farmer.forester,
            Gatherer = global::StardewValley.Farmer.gatherer,
            Lumberjack = global::StardewValley.Farmer.lumberjack,
            Tapper = global::StardewValley.Farmer.tapper,
            Botanist = global::StardewValley.Farmer.botanist,
            Tracker = global::StardewValley.Farmer.tracker,
            Miner = global::StardewValley.Farmer.miner,
            Geologist = global::StardewValley.Farmer.geologist,
            Blacksmith = global::StardewValley.Farmer.blacksmith,
            Burrower = global::StardewValley.Farmer.burrower,
            Excavator = global::StardewValley.Farmer.excavator,
            Gemologist = global::StardewValley.Farmer.gemologist,
            Fighter = global::StardewValley.Farmer.fighter,
            Scout = global::StardewValley.Farmer.scout,
            Brute = global::StardewValley.Farmer.brute,
            Defender = global::StardewValley.Farmer.defender,
            Acrobat = global::StardewValley.Farmer.acrobat,
            Desperado = global::StardewValley.Farmer.desperado,
        }

        public static bool CanAfford(global::StardewValley.Farmer farmer, int amount, Utilities.Currency.Type currency = Utilities.Currency.Type.Money)
        {
            switch(currency)
            {
                case Utilities.Currency.Type.Money:
                    return farmer.Money >= amount;

                case Utilities.Currency.Type.FestivalScore:
                    return farmer.festivalScore >= amount;

                case Utilities.Currency.Type.ClubCoins:
                    return farmer.clubCoins >= amount;

                default:
                    return false;
            }
        }

        public static void Spend(global::StardewValley.Farmer farmer, int amount, Utilities.Currency.Type currency)
        {
            switch (currency)
            {
                case Utilities.Currency.Type.Money:
                    farmer.Money = Math.Max(Utilities.Currency.MinimumAmount, farmer.Money - amount);
                    break;

                case Utilities.Currency.Type.FestivalScore:
                    farmer.festivalScore = Math.Max(Utilities.Currency.MinimumAmount, farmer.festivalScore - amount);
                    break;

                case Utilities.Currency.Type.ClubCoins:
                    farmer.clubCoins = Math.Max(Utilities.Currency.MinimumAmount, farmer.clubCoins - amount);
                    break;
            }
        }

        public static void SpendMoney(global::StardewValley.Farmer farmer, int amount)
        {
            Characters.Farmer.Spend(farmer, amount, Utilities.Currency.Type.Money);
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
            return Utilities.Game.GetDailyLuck() + Characters.Farmer.GetLuckLevel(farmer);
        }

        public static GameLocation GetCurrentLocation(global::StardewValley.Farmer farmer)
        {
            return farmer.currentLocation;
        }

        public static bool IsCurrentLocation(global::StardewValley.Farmer farmer, GameLocation location)
        {
            return Locations.Location.IsLocation(Characters.Farmer.GetCurrentLocation(farmer), location);
        }

        public static global::StardewValley.FarmAnimal CreateFarmAnimal(global::StardewValley.Farmer farmer,  string type, string name = null, Building home = null, long myId = default(long))
        {
            return Characters.FarmAnimal.CreateFarmAnimal(type, Characters.Farmer.GetUniqueId(farmer), name, home, myId);
        }

        public static bool HasProfession(global::StardewValley.Farmer farmer, Characters.Farmer.Profession profession)
        {
            return farmer.professions.Contains((int)profession);
        }
    }
}
