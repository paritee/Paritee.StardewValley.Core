namespace Paritee.StardewValley.Core.Constants
{
    public class FarmAnimal
    {
        // Harvest types
        public const int AutomaticHarvestType = 0;
        public const int RequiresToolHarvestType = 1;
        public const int ItHarvestType = 2; // Only used by Hog in Vanilla

        // Produce
        public const int NoProduce = Constants.Object.NoIndex;
        public static string NonProducerTool => Constants.Object.NoIndex.ToString();
        public const int ShepherdProfessionDaysToLayBonus = -1;
        public const byte MinDaysToLay = byte.MinValue;
        public const byte MaxDaysToLay = byte.MaxValue;
        public const byte MinDaysSinceLastLay = byte.MinValue;
        public const byte MaxDaysSinceLastLay = byte.MaxValue;

        // Health, happiness and fullness
        public const int DefaultHealth = 3;
        public const byte MinHappiness = byte.MinValue;
        public const byte MaxHappiness = byte.MaxValue;
        public const byte MinFullness = byte.MinValue;
        public const byte MaxFullness = byte.MaxValue;

        // Events
        public const double BlueChickenChance = 0.25;
        public const int MinPauseTimer = 0;
        public const int MinHitGlowTimer = 0;

        // Sprites
        public const string BabyPrefix = "Baby";
        public const string ShearedPrefix = "Sheared";

        // Paths
        public static int MaxPathFindingPerTick => global::StardewValley.FarmAnimal.MaxPathfindingPerTick;

        public enum MoodMessage
        {
            NewHome = 0,
            Happy = 1,
            Fine = 2,
            Sad = 3,
            Hungry = 4,
            DisturbedByDog = 5,
            LeftOutsideAtNight = 6,
        }

        public enum DataValueIndex
        {
            DaysToLay = 0,
            AgeWhenMature = 1,
            DefaultProduce = 2,
            DeluxeProduce = 3,
            Sound = 4,
            FrontBackBoundingBoxX = 5,
            FrontBackBoundingBoxY = 6,
            FrontBackBoundingBoxWidth = 7,
            FrontBackBoundingBoxHeight = 8,
            SidewaysBoundingBoxX = 9,
            SidewaysBoundingBoxY = 10,
            SidewaysBoundingBoxWidth = 11,
            SidewaysBoundingBoxHeight = 12,
            HarvestType = 13,
            ShowDifferentTextureWhenReadyForHarvest = 14,
            BuildingTypeILiveIn = 15,
            SpriteWidth = 16,
            SpritHeight = 17,
            SidewaysSourceRectWidth = 18,
            SidewaysSourceRectHeight = 19,
            FullnessDrain = 20,
            HappinessDrain = 21,
            ToolUsedForHarvest = 22,
            MeatIndex = 23,
            Price = 24,
            DisplayType = 25,
            DisplayBuilding = 26,
        }
    }
}
