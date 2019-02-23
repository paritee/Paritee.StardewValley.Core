namespace Paritee.StardewValley.Core.Constants
{
    public class FarmAnimal
    {
        // Harvest types
        public const int AutomaticHarvestType = 0;
        public const int RequiresToolHarvestType = 1;
        public const int ItHarvestType = 2; // Only used by Hog in Vanilla

        // Produce
        public const int NoProduce = default(int);
        public static string NonProducerTool { get { return default(int).ToString(); } }

        // Events
        public const double BlueChickenChance = 0.25;

        // Sprites
        public const string BabyPrefix = "Baby";
        public const string ShearedPrefix = "Sheared";

        // Paths
        public static int MaxPathFindingPerTick { get { return global::StardewValley.FarmAnimal.MaxPathfindingPerTick; } }

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
            Price = 24
        }
    }
}
