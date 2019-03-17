using System.Collections.Generic;

namespace Paritee.StardewValley.Core.Objects
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

        public static string GetName(global::StardewValley.Object obj)
        {
            return obj.Name;
        }

        public static bool IsIncubator(global::StardewValley.Object obj)
        {
            return Objects.Object.IsBigCraftable(obj) && Objects.Object.GetName(obj).Contains(Locations.AnimalHouse.Incubator);
        }

        public static bool IsHoldingObject(global::StardewValley.Object obj)
        {
            return obj.heldObject.Value != null;
        }

        public static int GetMinutesUntilReady(global::StardewValley.Object obj)
        {
            return obj.MinutesUntilReady;
        }

        public static bool IsReady(global::StardewValley.Object obj)
        {
            return Objects.Object.GetMinutesUntilReady(obj) <= 0;
        }

        public static bool IsAutoGrabber(global::StardewValley.Object obj)
        {
            return Objects.Object.IsItem(obj, Locations.AnimalHouse.AutoGrabberItemIndex) && Objects.Object.IsBigCraftable(obj);
        }

        public static bool IsItem(global::StardewValley.Object obj, int itemIndex)
        {
            return obj.ParentSheetIndex == itemIndex;
        }

        public static bool IsBigCraftable(global::StardewValley.Object obj)
        {
            return obj.bigCraftable.Value;
        }

        public static bool TryParse(string name, out int index)
        {
            index = Objects.Object.NoIndex;

            Dictionary<int, string> data = Utilities.Content.LoadData<int, string>(Utilities.Content.DataObjectInformationContentPath);

            foreach (KeyValuePair<int, string> entry in data)
            {
                string[] values = Utilities.Content.ParseDataValue(entry.Value);

                if (values[(int)Objects.Object.DataValueIndex.Name] == name)
                {
                    index = entry.Key;

                    return true;
                }
            }

            return false;
        }

        public static bool ObjectExists(int index)
        {
            return Utilities.Content.LoadData<int, string>(Utilities.Content.DataObjectInformationContentPath)
                .ContainsKey(index);
        }
    }
}
