using StardewValley;
using System;

namespace Paritee.StardewValley.Core.Locations
{
    public class Season
    {
        public enum Name
        {
            Spring,
            Summer,
            Fall,
            Winter
        }

        public static string GetCurrentSeason()
        {
            return Game1.currentSeason;
        }

        public static int ConvertToNumber(string season)
        {
            return global::StardewValley.Utility.getSeasonNumber(season);
        }

        public static bool IsSpring()
        {
            return Game1.IsSpring || Locations.Season.IsCurrentSeason(Locations.Season.Name.Spring);
        }

        public static bool IsSummer()
        {
            return Game1.IsSummer || Locations.Season.IsCurrentSeason(Locations.Season.Name.Summer);
        }

        public static bool IsFall()
        {
            return Game1.IsFall || Locations.Season.IsCurrentSeason(Locations.Season.Name.Fall);
        }

        public static bool IsWinter()
        {
            return Game1.IsWinter || Locations.Season.IsCurrentSeason(Locations.Season.Name.Winter);
        }

        public static bool IsCurrentSeason(Locations.Season.Name season)
        {
            return Locations.Season.IsCurrentSeason(season.ToString());
        }

        public static bool IsCurrentSeason(string season)
        {
            return string.Equals(Locations.Season.GetCurrentSeason(), season, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
