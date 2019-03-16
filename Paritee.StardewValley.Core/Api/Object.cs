using System.Collections.Generic;

namespace Paritee.StardewValley.Core.Api
{
    public class Object
    {
        public static string GetName(global::StardewValley.Object obj)
        {
            return obj.Name;
        }

        public static bool IsIncubator(global::StardewValley.Object obj)
        {
            return Api.Object.IsBigCraftable(obj) && Api.Object.GetName(obj).Contains(Constants.AnimalHouse.Incubator);
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
            return Api.Object.GetMinutesUntilReady(obj) <= 0;
        }

        public static bool IsAutoGrabber(global::StardewValley.Object obj)
        {
            return Api.Object.IsItem(obj, Constants.AnimalHouse.AutoGrabberItemIndex) && Api.Object.IsBigCraftable(obj);
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
            index = Constants.Object.NoIndex;

            Dictionary<int, string> data = Api.Content.LoadData<int, string>(Constants.Content.DataObjectInformationContentPath);

            foreach (KeyValuePair<int, string> entry in data)
            {
                string[] values = Api.Content.ParseDataValue(entry.Value);

                if (values[(int)Constants.Object.DataValueIndex.Name] == name)
                {
                    index = entry.Key;

                    return true;
                }
            }

            return false;
        }

        public static bool ObjectExists(int index)
        {
            return Api.Content.LoadData<int, string>(Constants.Content.DataObjectInformationContentPath)
                .ContainsKey(index);
        }
    }
}
