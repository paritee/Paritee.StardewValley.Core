using Netcode;
using StardewValley;
using StardewValley.Buildings;
using System.Collections.Generic;

namespace Paritee.StardewValley.Core.Api
{
    public class AnimalHouse
    {
        public static string FormatSize(string buildingName, Constants.AnimalHouse.Size size)
        {
            if (size.Equals(Constants.AnimalHouse.Size.Small))
            {
                return buildingName;
            }

            return $"{size.ToString()} {buildingName}";
        }

        public static Object GetIncubator(global::StardewValley.AnimalHouse animalHouse)
        {
            foreach (Object @object in animalHouse.objects.Values)
            {
                if (@object.bigCraftable.Value && @object.Name.Contains(Constants.AnimalHouse.Incubator) && (@object.heldObject.Value != null && @object.MinutesUntilReady <= 0) && !animalHouse.isFull())
                {
                    return @object;
                }
            }

            return null;
        }

        public static string GetRandomTypeFromIncubator(Object incubator, Dictionary<string, List<string>> restrictions)
        {
            // Search for a type by the produce
            return incubator.heldObject.Value == null
                ? null
                : Api.FarmAnimal.GetRandomTypeFromProduce(incubator.heldObject.Value.ParentSheetIndex, restrictions);
        }

        public static void ResetIncubator(global::StardewValley.AnimalHouse animalHouse)
        {
            animalHouse.incubatingEgg.X = 0;
            animalHouse.incubatingEgg.Y = -1;
        }

        public static void ResetIncubator(global::StardewValley.AnimalHouse animalHouse, Object incubator)
        {
            incubator.heldObject.Value = (Object)null;
            incubator.ParentSheetIndex = Constants.AnimalHouse.DefaultIncubatorItem;

            Api.AnimalHouse.ResetIncubator(animalHouse);
        }

        public static global::StardewValley.AnimalHouse GetIndoors(Building building)
        {
            NetRef<GameLocation> indoors = Helpers.Reflection.GetFieldValue<NetRef<GameLocation>>(building, "indoors");
            return indoors.Value as global::StardewValley.AnimalHouse;
        }

        public static bool IsFull(global::StardewValley.AnimalHouse animalHouse)
        {
            return animalHouse.isFull();
        }

        public static bool IsFull(Building building)
        {
            return Api.AnimalHouse.IsFull(Api.AnimalHouse.GetIndoors(building));
        }

        public static bool IsEggReadyToHatch(global::StardewValley.AnimalHouse animalHouse)
        {
            return animalHouse.incubatingEgg.Y > 0 || (animalHouse.incubatingEgg.X - 1) <= 0;
        }

        public static void AddAnimal(Building building, global::StardewValley.FarmAnimal animal)
        {
            global::StardewValley.AnimalHouse animalHouse = Api.AnimalHouse.GetIndoors(building);

            Api.AnimalHouse.AddAnimal(animalHouse, animal);
        }

        public static void AddAnimal(global::StardewValley.AnimalHouse animalHouse, global::StardewValley.FarmAnimal animal)
        {
            animalHouse.animals.Add(animal.myID.Value, animal);

            if (!animalHouse.animalsThatLiveHere.Contains(animal.myID.Value))
            {
                animalHouse.animalsThatLiveHere.Add(animal.myID.Value);
            }
        }

        public static global::StardewValley.Buildings.Building GetBuilding(global::StardewValley.AnimalHouse animalHouse)
        {
            return animalHouse.getBuilding();
        }

        public static void SetCurrentEvent(global::StardewValley.AnimalHouse animalHouse, global::StardewValley.Event currentEvent)
        {
            animalHouse.currentEvent = currentEvent;
        }

        public static global::StardewValley.Event GetCurrentEvent(global::StardewValley.AnimalHouse animalHouse)
        {
            return animalHouse.currentEvent;
        }

        public static global::StardewValley.Event GetIncubatorHatchEvent(global::StardewValley.AnimalHouse animalHouse, string message = null)
        {
            // Use the same messaging for all types of "eggs"
            string str = message ?? Paritee.StardewValley.Core.Api.Content.LoadString("Strings\\Locations:AnimalHouse_Incubator_Hatch_RegularEgg");

            return new global::StardewValley.Event("none/-1000 -1000/farmer 2 9 0/pause 250/message \"" + str + "\"/pause 500/animalNaming/pause 500/end");
        }

        public static void SetIncubatorHatchEvent(global::StardewValley.AnimalHouse animalHouse)
        {
            global::StardewValley.Event hatchEvent = Api.AnimalHouse.GetIncubatorHatchEvent(animalHouse);

            Api.AnimalHouse.SetCurrentEvent(animalHouse, hatchEvent);
        }
    }
}
