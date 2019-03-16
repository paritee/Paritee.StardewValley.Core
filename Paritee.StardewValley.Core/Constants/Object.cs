namespace Paritee.StardewValley.Core.Constants
{
    public class Object
    {
        public const int NoIndex = -1;

        public enum Quality
        {
            Low = global::StardewValley.Object.lowQuality,
            Medium = global::StardewValley.Object.medQuality,
            High = global::StardewValley.Object.highQuality,
            Best = global::StardewValley.Object.bestQuality,
        }

        public enum DataValueIndex
        {
            Name = 0,
            Price = 1,
            Edibility = 2,
            TypeAndCategory = 3,
            DisplayName = 4,
            SetOutdoors = 5,
            SetIndoors = 6,
            Fragility = 7,
            IsLamp = 8,
        }
    }
}
