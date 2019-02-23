using StardewValley;
using System;

namespace Paritee.StardewValley.Core.Api
{
    public class Season
    {
        public static string GetCurrentSeason()
        {
            return Game1.currentSeason;
        }

        public static bool IsSpring()
        {
            return Game1.IsSpring || Api.Season.IsCurrentSeason(Constants.Environment.Season.Spring);
        }

        public static bool IsSummer()
        {
            return Game1.IsSummer || Api.Season.IsCurrentSeason(Constants.Environment.Season.Summer);
        }

        public static bool IsFall()
        {
            return Game1.IsFall || Api.Season.IsCurrentSeason(Constants.Environment.Season.Fall);
        }

        public static bool IsWinter()
        {
            return Game1.IsWinter || Api.Season.IsCurrentSeason(Constants.Environment.Season.Winter);
        }

        public static bool IsCurrentSeason(Constants.Environment.Season season)
        {
            return Api.Season.IsCurrentSeason(season.ToString());
        }

        public static bool IsCurrentSeason(string season)
        {
            return string.Equals(Api.Season.GetCurrentSeason(), season, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
