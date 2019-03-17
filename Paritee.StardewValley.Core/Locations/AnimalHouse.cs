using Microsoft.Xna.Framework;
using Netcode;
using StardewValley;
using StardewValley.Buildings;
using StardewValley.Objects;
using System.Collections.Generic;
using System.Linq;

namespace Paritee.StardewValley.Core.Locations
{
    public class AnimalHouse
    {
        public const string Coop = "Coop";
        public const string Barn = "Barn";
        public const string Incubator = "Incubator";
        public const int DefaultIncubatorItemIndex = 101;
        public const int AutoGrabberItemIndex = 165;

        public enum Size
        {
            Small,
            Big,
            Deluxe
        }

        public static string FormatSize(string buildingName, Locations.AnimalHouse.Size size)
        {
            if (size.Equals(Locations.AnimalHouse.Size.Small))
            {
                return buildingName;
            }

            return $"{size.ToString()} {buildingName}";
        }

        public static List<global::StardewValley.Object> GetIncubators(global::StardewValley.AnimalHouse animalHouse)
        {
            return animalHouse.objects.Values.Where(o => Objects.Object.IsIncubator(o)).ToList();
        }

        public static global::StardewValley.Object GetIncubatorWithEggReadyToHatch(global::StardewValley.AnimalHouse animalHouse)
        {
            List<global::StardewValley.Object> incubators = Locations.AnimalHouse.GetIncubators(animalHouse);

            if (!incubators.Any())
            {
                // Can't do anything about it
                return null;
            }

            // Try to get the first incubator that has an egg ready to hatch
            return incubators.FirstOrDefault(o => Objects.Object.IsHoldingObject(o) && Objects.Object.IsReady(o));
        }

        public static string GetRandomTypeFromIncubator(global::StardewValley.Object incubator, Dictionary<string, List<string>> restrictions)
        {
            // Search for a type by the produce
            return incubator.heldObject.Value == null
                ? null
                : Characters.FarmAnimal.GetRandomTypeFromProduce(incubator.heldObject.Value.ParentSheetIndex, restrictions);
        }

        public static void ResetIncubator(global::StardewValley.AnimalHouse animalHouse)
        {
            animalHouse.incubatingEgg.X = 0;
            animalHouse.incubatingEgg.Y = -1;
        }

        public static void ResetIncubator(global::StardewValley.AnimalHouse animalHouse, global::StardewValley.Object incubator)
        {
            incubator.heldObject.Value = null;
            incubator.ParentSheetIndex = Locations.AnimalHouse.DefaultIncubatorItemIndex;

            Locations.AnimalHouse.ResetIncubator(animalHouse);
        }

        public static global::StardewValley.AnimalHouse GetIndoors(Building building)
        {
            NetRef<GameLocation> indoors = Utilities.Reflection.GetFieldValue<NetRef<GameLocation>>(building, "indoors");
            return indoors.Value as global::StardewValley.AnimalHouse;
        }

        public static bool IsFull(global::StardewValley.AnimalHouse animalHouse)
        {
            return animalHouse.isFull();
        }

        public static bool IsFull(Building building)
        {
            return Locations.AnimalHouse.IsFull(Locations.AnimalHouse.GetIndoors(building));
        }

        public static bool IsEggReadyToHatch(global::StardewValley.AnimalHouse animalHouse)
        {
            return animalHouse.incubatingEgg.Y > 0 || (animalHouse.incubatingEgg.X - 1) <= 0;
        }

        public static void AddAnimal(Building building, global::StardewValley.FarmAnimal animal)
        {
            global::StardewValley.AnimalHouse animalHouse = Locations.AnimalHouse.GetIndoors(building);

            Locations.AnimalHouse.AddAnimal(animalHouse, animal);
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
            string str = message ?? Paritee.StardewValley.Core.Utilities.Content.LoadString("Strings\\Locations:AnimalHouse_Incubator_Hatch_RegularEgg");

            return new global::StardewValley.Event("none/-1000 -1000/farmer 2 9 0/pause 250/message \"" + str + "\"/pause 500/animalNaming/pause 500/end");
        }

        public static void SetIncubatorHatchEvent(global::StardewValley.AnimalHouse animalHouse)
        {
            global::StardewValley.Event hatchEvent = Locations.AnimalHouse.GetIncubatorHatchEvent(animalHouse);

            Locations.AnimalHouse.SetCurrentEvent(animalHouse, hatchEvent);
        }

        public static void AutoGrabFromAnimals(global::StardewValley.AnimalHouse animalHouse, global::StardewValley.Object autoGrabber)
        {
            foreach (KeyValuePair<long, global::StardewValley.FarmAnimal> pair in animalHouse.animals.Pairs)
            {
                // Skip non-producers
                if (!Characters.FarmAnimal.IsAProducer(pair.Value))
                {
                    continue;
                }

                // Must require a tool for harvest, ..
                if (!Characters.FarmAnimal.RequiresToolForHarvest(pair.Value))
                {
                    continue;
                }

                // .. be currently producing an item (ex. not a baby) ..
                if (!Characters.FarmAnimal.IsCurrentlyProducing(pair.Value))
                {
                    continue;
                }

                // .. and must not be an animal that finds its produce (ex. Pigs)
                // This is the logic check where previously it validated solely 
                // against Truffles. This may not always be the case.
                if (Characters.FarmAnimal.CanFindProduce(pair.Value))
                {
                    continue;
                }

                if (autoGrabber.heldObject.Value != null && autoGrabber.heldObject.Value is Chest chest)
                {
                    Item item = (Item)new global::StardewValley.Object(Vector2.Zero, Characters.FarmAnimal.GetCurrentProduce(pair.Value), null, false, true, false, false)
                    {
                        Quality = Characters.FarmAnimal.GetProduceQuality(pair.Value)
                    };

                    if (chest.addItem(item) == null)
                    {
                        Characters.FarmAnimal.SetCurrentProduce(pair.Value, Characters.FarmAnimal.NoProduce);

                        if (Characters.FarmAnimal.IsSheared(pair.Value))
                        {
                            Characters.FarmAnimal.ReloadSpriteTexture(pair.Value);
                        }

                        autoGrabber.showNextIndex.Value = true;
                    }
                }
            }
        }

        public static bool AreAnimalDoorsOpen(global::StardewValley.Buildings.Building building)
        {
            return building.animalDoorOpen.Value;
        }
    }
}
