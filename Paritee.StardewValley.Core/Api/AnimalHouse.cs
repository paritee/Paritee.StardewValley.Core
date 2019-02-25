using Microsoft.Xna.Framework;
using Netcode;
using StardewValley;
using StardewValley.Buildings;
using StardewValley.Objects;
using System.Collections.Generic;
using System.Linq;

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

        public static List<global::StardewValley.Object> GetIncubators(global::StardewValley.AnimalHouse animalHouse)
        {
            return animalHouse.objects.Values.Where(o => Api.Object.IsIncubator(o)).ToList();
        }

        public static global::StardewValley.Object GetIncubatorWithEggReadyToHatch(global::StardewValley.AnimalHouse animalHouse)
        {
            List<global::StardewValley.Object> incubators = Api.AnimalHouse.GetIncubators(animalHouse);

            if (!incubators.Any())
            {
                // Can't do anything about it
                return null;
            }

            // Try to get the first incubator that has an egg ready to hatch
            return incubators.FirstOrDefault(o => Api.Object.IsHoldingObject(o) && Api.Object.IsReady(o));
        }

        public static string GetRandomTypeFromIncubator(global::StardewValley.Object incubator, Dictionary<string, List<string>> restrictions)
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

        public static void ResetIncubator(global::StardewValley.AnimalHouse animalHouse, global::StardewValley.Object incubator)
        {
            incubator.heldObject.Value = null;
            incubator.ParentSheetIndex = Constants.AnimalHouse.DefaultIncubatorItemIndex;

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

        public static void AutoGrabFromAnimals(global::StardewValley.AnimalHouse animalHouse, global::StardewValley.Object autoGrabber)
        {
            foreach (KeyValuePair<long, global::StardewValley.FarmAnimal> pair in animalHouse.animals.Pairs)
            {
                // Skip non-producers
                if (!Api.FarmAnimal.IsAProducer(pair.Value))
                {
                    continue;
                }

                // Must require a tool for harvest, ..
                if (!Api.FarmAnimal.RequiresToolForHarvest(pair.Value))
                {
                    continue;
                }

                // .. be currently producing an item (ex. not a baby) ..
                if (!Api.FarmAnimal.IsCurrentlyProducing(pair.Value))
                {
                    continue;
                }

                // .. and must not be an animal that finds its produce (ex. Pigs)
                // This is the logic check where previously it validated solely 
                // against Truffles. This may not always be the case.
                if (Api.FarmAnimal.CanFindProduce(pair.Value))
                {
                    continue;
                }

                if (autoGrabber.heldObject.Value != null && autoGrabber.heldObject.Value is Chest chest)
                {
                    Item item = (Item)new global::StardewValley.Object(Vector2.Zero, Api.FarmAnimal.GetCurrentProduce(pair.Value), null, false, true, false, false)
                    {
                        Quality = Api.FarmAnimal.GetProduceQuality(pair.Value)
                    };

                    if (chest.addItem(item) == null)
                    {
                        Api.FarmAnimal.SetCurrentProduce(pair.Value, Constants.FarmAnimal.NoProduce);

                        if (Api.FarmAnimal.IsSheared(pair.Value))
                        {
                            Api.FarmAnimal.ReloadSpriteTexture(pair.Value);
                        }

                        autoGrabber.showNextIndex.Value = true;
                    }
                }
            }
        }
    }
}
