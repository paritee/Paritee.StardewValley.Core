﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
