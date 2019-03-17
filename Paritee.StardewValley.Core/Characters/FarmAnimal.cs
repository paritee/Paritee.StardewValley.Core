using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Netcode;
using StardewValley;
using StardewValley.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paritee.StardewValley.Core.Characters
{
    public class FarmAnimal
    {
        // Vanilla types
        public static Livestock WhiteChicken => new Livestock("White Chicken", 0d);
        public static Livestock BrownChicken => new Livestock("Brown Chicken", 0d);
        public static Livestock BlueChicken => new Livestock("Blue Chicken", 0d);
        public static Livestock VoidChicken => new Livestock("Void Chicken", 0d);
        public static Livestock WhiteCow => new Livestock("White Cow", 0d);
        public static Livestock BrownCow => new Livestock("Brown Cow", 0d);
        public static Livestock Goat => new Livestock("Goat", 0d);
        public static Livestock Duck => new Livestock("Duck", 0.01d);
        public static Livestock Sheep => new Livestock("Sheep", 0d);
        public static Livestock Rabbit => new Livestock("Rabbit", 0.02d);
        public static Livestock Pig => new Livestock("Pig", 0d);
        public static Livestock Dinosaur => new Livestock("Dinosaur", 0d);

        // Vanilla categories
        public static LivestockCategory DairyCowCategory
        {
            get
            {
                List<Characters.Livestock> types = new List<Characters.Livestock>()
                {
                    FarmAnimal.WhiteCow,
                    FarmAnimal.BrownCow,
                };

                List<string> buildings = new List<string>()
                {
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Barn, Locations.AnimalHouse.Size.Small),
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Barn, Locations.AnimalHouse.Size.Big),
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Barn, Locations.AnimalHouse.Size.Deluxe),
                };

                string name = LivestockCategory.LoadDisplayName("5927");
                string description = LivestockCategory.LoadDescription("11343");

                Characters.LivestockAnimalShop animalShop = new Characters.LivestockAnimalShop(1500, name, description, null);

                return new LivestockCategory("Dairy Cow", 1, types, buildings, animalShop);
            }
        }
        public static LivestockCategory ChickenCategory
        {
            get
            {
                List<Livestock> types = new List<Livestock>()
                {
                    FarmAnimal.WhiteChicken,
                    FarmAnimal.BrownChicken,
                    FarmAnimal.BlueChicken,
                    FarmAnimal.VoidChicken,
                };

                List<string> buildings = new List<string>()
                {
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Coop, Locations.AnimalHouse.Size.Small),
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Coop, Locations.AnimalHouse.Size.Big),
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Coop, Locations.AnimalHouse.Size.Deluxe),
                };

                List<Characters.Livestock> exclude = new List<Characters.Livestock>()
                {
                    FarmAnimal.VoidChicken,
                };

                string name = LivestockCategory.LoadDisplayName("5922");
                string description = LivestockCategory.LoadDescription("11334");

                Characters.LivestockAnimalShop animalShop = new Characters.LivestockAnimalShop(800, name, description, exclude);

                return new Characters.LivestockCategory("Chicken", 0, types, buildings, animalShop);
            }
        }
        public static LivestockCategory SheepCategory
        {
            get
            {
                List<Characters.Livestock> types = new List<Characters.Livestock>()
                {
                    FarmAnimal.Sheep,
                };

                List<string> buildings = new List<string>()
                {
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Barn, Locations.AnimalHouse.Size.Deluxe),
                };

                string name = LivestockCategory.LoadDisplayName("5942");
                string description = LivestockCategory.LoadDescription("11352");

                Characters.LivestockAnimalShop animalShop = new Characters.LivestockAnimalShop(8000, name, description, null);

                return new LivestockCategory("Sheep", 4, types, buildings, animalShop);
            }
        }
        public static LivestockCategory GoatCategory
        {
            get
            {
                List<Characters.Livestock> types = new List<Characters.Livestock>()
                {
                    FarmAnimal.Goat,
                };

                List<string> buildings = new List<string>()
                {
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Barn, Locations.AnimalHouse.Size.Big),
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Barn, Locations.AnimalHouse.Size.Deluxe),
                };

                string name = LivestockCategory.LoadDisplayName("5933");
                string description = LivestockCategory.LoadDescription("11349");

                Characters.LivestockAnimalShop animalShop = new Characters.LivestockAnimalShop(4000, name, description, null);

                return new LivestockCategory("Goat", 2, types, buildings, animalShop);
            }
        }
        public static LivestockCategory PigCategory
        {
            get
            {
                List<Characters.Livestock> types = new List<Characters.Livestock>()
                {
                    FarmAnimal.Pig,
                };

                List<string> buildings = new List<string>()
                {
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Barn, Locations.AnimalHouse.Size.Deluxe),
                };

                string name = LivestockCategory.LoadDisplayName("5948");
                string description = LivestockCategory.LoadDescription("11346");

                Characters.LivestockAnimalShop animalShop = new Characters.LivestockAnimalShop(16000, name, description, null);

                return new LivestockCategory("Pig", 6, types, buildings, animalShop);
            }
        }
        public static LivestockCategory DuckCategory
        {
            get
            {
                List<Characters.Livestock> types = new List<Characters.Livestock>()
                {
                    FarmAnimal.Duck,
                };

                List<string> buildings = new List<string>()
                {
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Coop, Locations.AnimalHouse.Size.Big),
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Coop, Locations.AnimalHouse.Size.Deluxe),
                };

                string name = LivestockCategory.LoadDisplayName("5937");
                string description = LivestockCategory.LoadDescription("11337");

                Characters.LivestockAnimalShop animalShop = new Characters.LivestockAnimalShop(4000, name, description, null);

                return new LivestockCategory("Duck", 3, types, buildings, animalShop);
            }
        }
        public static LivestockCategory RabbitCategory
        {
            get
            {
                List<Characters.Livestock> types = new List<Characters.Livestock>()
                {
                    FarmAnimal.Rabbit,
                };

                List<string> buildings = new List<string>()
                {
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Coop, Locations.AnimalHouse.Size.Deluxe),
                };

                string name = LivestockCategory.LoadDisplayName("5945");
                string description = LivestockCategory.LoadDescription("11340");

                Characters.LivestockAnimalShop animalShop = new Characters.LivestockAnimalShop(8000, name, description, null);

                return new LivestockCategory("Rabbit", 5, types, buildings, animalShop);
            }
        }
        public static LivestockCategory DinosaurCategory
        {
            get
            {
                List<Characters.Livestock> types = new List<Characters.Livestock>()
                {
                    FarmAnimal.Dinosaur,
                };

                List<string> buildings = new List<string>()
                {
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Coop, Locations.AnimalHouse.Size.Big),
                    Locations.AnimalHouse.FormatSize(Locations.AnimalHouse.Coop, Locations.AnimalHouse.Size.Deluxe),
                };

                return new LivestockCategory("Dinosaur", 7, types, buildings, null);
            }
        }

        // Harvest types
        public const int LayHarvestType = 0;
        public const int GrabHarvestType = 1;
        public const int ButcherHarvestType = 2; // Only used by Hog in Vanilla

        // Produce
        public const int NoProduce = Objects.Object.NoIndex;
        public static string NonProducerTool => Objects.Object.NoIndex.ToString();
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
        public const string ReadyForHarvestPrefix = "Sheared";

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

        /***
         * Age
         ***/

        public static bool IsBaby(global::StardewValley.FarmAnimal animal)
        {
            return animal.isBaby();
        }


        /***
         * Breeding
         ***/

        public static bool IsMale(global::StardewValley.FarmAnimal animal)
        {
            return animal.isMale();
        }

        public static void AssociateParent(global::StardewValley.FarmAnimal animal, global::StardewValley.FarmAnimal parent)
        {
            Characters.FarmAnimal.AssociateParent(animal, Characters.FarmAnimal.GetUniqueId(parent));
        }

        public static void AssociateParent(global::StardewValley.FarmAnimal animal, long parentId)
        {
            animal.parentId.Value = parentId;
        }


        /***
         * Data
         ***/

        public static void UpdateFromData(global::StardewValley.FarmAnimal animal, string type)
        {
            // Grab the new type's data to override if it exists
            Dictionary<string, string> contentData = Utilities.Content.LoadData<string, string>(Utilities.Content.DataFarmAnimalsContentPath);
            KeyValuePair<string, string> contentDataEntry = Utilities.Content.GetDataEntry<string, string>(contentData, type);

            // Always validate if the type we're trying to use exists
            if (contentDataEntry.Key == null)
            {
                // Get a default type to use
                string defaultType = Characters.FarmAnimal.GetDefaultType(animal);

                // Set it to the default before we continue
                contentDataEntry = contentData.FirstOrDefault(kvp => kvp.Key.Equals(defaultType));

                // Do a final check to make sure the default exists; otherwise 
                // we need to kill everything. This should never happen unless 
                // agressive mods are being used to REMOVE vanilla animals.
                if (contentDataEntry.Key == null)
                {
                    throw new KeyNotFoundException($"Could not find {defaultType} to overwrite custom farm animal for saving. This is a fatal error. Please make sure you have {defaultType} in the game.");
                }
            }
            
            // Save for overwriting after
            bool isCurrentlyProducingAnItem = Characters.FarmAnimal.IsProduceAnItem(Characters.FarmAnimal.GetCurrentProduce(animal));
            bool isCurrentlyProducingDeluxe = Characters.FarmAnimal.IsCurrentlyProducingDeluxe(animal);
            
            string[] values = Utilities.Content.ParseDataValue(contentDataEntry.Value);

            // Reset the instance's values based on the new type
            animal.type.Value = contentDataEntry.Key;
            animal.daysToLay.Value = Convert.ToByte(values[(int)Characters.FarmAnimal.DataValueIndex.DaysToLay]);
            animal.ageWhenMature.Value = Convert.ToByte(values[(int)Characters.FarmAnimal.DataValueIndex.AgeWhenMature]);
            animal.defaultProduceIndex.Value = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.DefaultProduce]);
            animal.deluxeProduceIndex.Value = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.DeluxeProduce]);

            string sound = values[(int)Characters.FarmAnimal.DataValueIndex.Sound];

            animal.sound.Value = Characters.FarmAnimal.IsDataValueNull(sound) ? null : sound;

            int x, y, width, height;

            x = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.FrontBackBoundingBoxX]);
            y = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.FrontBackBoundingBoxY]);
            width = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.FrontBackBoundingBoxWidth]);
            height = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.FrontBackBoundingBoxHeight]);

            animal.frontBackBoundingBox.Value = new Rectangle(x, y, width, height);

            x = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.SidewaysBoundingBoxX]);
            y = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.SidewaysBoundingBoxY]);
            width = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.SidewaysBoundingBoxWidth]);
            height = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.SidewaysBoundingBoxHeight]);

            animal.sidewaysBoundingBox.Value = new Rectangle(x, y, width, height);

            animal.harvestType.Value = Convert.ToByte(values[(int)Characters.FarmAnimal.DataValueIndex.HarvestType]);
            animal.showDifferentTextureWhenReadyForHarvest.Value = Convert.ToBoolean(values[(int)Characters.FarmAnimal.DataValueIndex.ShowDifferentTextureWhenReadyForHarvest]);
            animal.buildingTypeILiveIn.Value = values[(int)Characters.FarmAnimal.DataValueIndex.BuildingTypeILiveIn];

            width = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.SpriteWidth]);
            height = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.SpritHeight]);

            animal.Sprite = new AnimatedSprite(Characters.FarmAnimal.BuildSpriteAssetName(animal), Utilities.Content.StartingFrame, width, height);
            animal.frontBackSourceRect.Value = new Rectangle(0, 0, width, height);

            width = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.SidewaysSourceRectWidth]);
            height = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.SidewaysSourceRectHeight]);

            animal.sidewaysSourceRect.Value = new Rectangle(0, 0, width, height);

            animal.fullnessDrain.Value = Convert.ToByte(values[(int)Characters.FarmAnimal.DataValueIndex.FullnessDrain]);
            animal.happinessDrain.Value = Convert.ToByte(values[(int)Characters.FarmAnimal.DataValueIndex.HappinessDrain]);

            string toolUsedForHarvest = values[(int)Characters.FarmAnimal.DataValueIndex.ToolUsedForHarvest];

            animal.toolUsedForHarvest.Value = Characters.FarmAnimal.IsDataValueNull(toolUsedForHarvest) ? "" : toolUsedForHarvest;
            animal.meatIndex.Value = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.MeatIndex]);
            animal.price.Value = Convert.ToInt32(values[(int)Characters.FarmAnimal.DataValueIndex.Price]);

            // Reset the current produce
            int produceIndex = isCurrentlyProducingAnItem
                ? isCurrentlyProducingDeluxe ? Characters.FarmAnimal.GetDeluxeProduce(animal) : Characters.FarmAnimal.GetDefaultProduce(animal)
                : Characters.FarmAnimal.NoProduce;

            Characters.FarmAnimal.SetCurrentProduce(animal, produceIndex);
        }

        private static bool IsDataValueNull(string value)
        {
            return value == null || value == "null" || value == default(string) || value == "" || value == Utilities.Content.None;
        }


        /***
         * Friendship
         ***/

        public static void DecreaseFriendship(global::StardewValley.FarmAnimal animal, int decrease)
        {
            Characters.FarmAnimal.IncreaseFriendship(animal, decrease * -1);
        }

        public static void IncreaseFriendship(global::StardewValley.FarmAnimal animal, int increase)
        {
            Characters.FarmAnimal.SetFriendship(animal, Characters.FarmAnimal.GetFriendship(animal) + increase);
        }

        public static void SetFriendship(global::StardewValley.FarmAnimal animal, int newAmount)
        {
            animal.friendshipTowardFarmer.Value = Math.Max(0, newAmount);
        }

        public static int GetFriendship(global::StardewValley.FarmAnimal animal)
        {
            return animal.friendshipTowardFarmer.Value;
        }


        /***
         * Fullness and health
         ***/

        public static byte GetFullness(global::StardewValley.FarmAnimal animal)
        {
            return animal.fullness.Value;
        }

        public static void SetFullness(global::StardewValley.FarmAnimal animal, byte fullness)
        {
            animal.fullness.Value = Math.Max(Characters.FarmAnimal.MinFullness, Math.Min(Characters.FarmAnimal.MaxFullness, fullness));
        }

        public static void SetFindGrassPathController(global::StardewValley.FarmAnimal animal, GameLocation location)
        {
            animal.controller = new PathFindController(animal, location, new PathFindController.isAtEnd(global::StardewValley.FarmAnimal.grassEndPointFunction), -1, false, new PathFindController.endBehavior(global::StardewValley.FarmAnimal.behaviorAfterFindingGrassPatch), 200, Point.Zero);
        }

        public static bool IsEating(global::StardewValley.FarmAnimal animal)
        {
            return Utilities.Reflection.GetFieldValue<NetBool>(animal, "isEating").Value;
        }

        public static void StopEating(global::StardewValley.FarmAnimal animal)
        {
            Utilities.Reflection.GetField(animal, "isEating").SetValue(animal, new NetBool(false));
        }

        public static void SetHealth(global:: StardewValley.FarmAnimal animal, int health)
        {
            animal.health.Value = health;
        }

        public static int GetHealth(global::StardewValley.FarmAnimal animal)
        {
            return animal.health.Value;
        }


        /***
         * Happiness
         ***/

        public static byte GetHappiness(global::StardewValley.FarmAnimal animal)
        {
            return animal.happiness.Value;
        }

        public static void SetHappiness(global::StardewValley.FarmAnimal animal, byte happiness)
        {
            animal.happiness.Value = Math.Max(Characters.FarmAnimal.MinHappiness, Math.Min(Characters.FarmAnimal.MaxHappiness, happiness));
        }

        public static byte GetHappinessDrain(global::StardewValley.FarmAnimal animal)
        {
            return animal.happinessDrain.Value;
        }

        public static void SetMoodMessage(global::StardewValley.FarmAnimal animal, Characters.FarmAnimal.MoodMessage moodMessage)
        {
            Utilities.Reflection.GetField(animal, "moodMessage").SetValue(animal, (int)moodMessage);
        }

        public static bool WasPet(global::StardewValley.FarmAnimal animal)
        {
            return animal.wasPet.Value;
        }


        /***
         * Harvest
         ***/

        public static bool IsSheared(global::StardewValley.FarmAnimal animal)
        {
            return animal.showDifferentTextureWhenReadyForHarvest.Value && animal.currentProduce.Value <= 0;
        }

        public static bool HasHarvestType(global::StardewValley.FarmAnimal animal, int harvestType)
        {
            return animal.harvestType.Value == harvestType;
        }

        public static bool HasHarvestType(int harvestType, int target)
        {
            return harvestType == target;
        }

        public static void FindProduce(global::StardewValley.FarmAnimal animal, global::StardewValley.Farmer farmer)
        {
            Utilities.Reflection.GetMethod(animal, "findTruffle").Invoke(animal, new object[] { farmer });
        }

        public static bool CanFindProduce(global::StardewValley.FarmAnimal animal)
        {
            return Characters.FarmAnimal.CanFindProduce(animal.harvestType.Value, animal.toolUsedForHarvest.Value);
        }

        public static bool CanFindProduce(int harvestType, string harvestTool)
        {
            // NOTE: This will NOT catch when tool is -1 which allows for animals 
            // that do not produce anything ever
            return Characters.FarmAnimal.RequiresToolForHarvest(harvestType)
                && Characters.FarmAnimal.IsDataValueNull(harvestTool);
        }

        public static bool CanBeNamed(global::StardewValley.FarmAnimal animal)
        {
            // "It" harvest type doesn't allow you to name the animal. This is 
            // mostly unused and is only seen on the Hog
            return Characters.FarmAnimal.HasHarvestType(animal, Characters.FarmAnimal.ButcherHarvestType);
        }

        public static bool LaysProduce(global::StardewValley.FarmAnimal animal)
        {
            return Characters.FarmAnimal.HasHarvestType(animal, Characters.FarmAnimal.LayHarvestType);
        }

        public static bool RequiresToolForHarvest(global::StardewValley.FarmAnimal animal)
        {
            // "It" harvest type doesn't allow you to name the animal. This is 
            // mostly unused and is only seen on the Hog
            return Characters.FarmAnimal.HasHarvestType(animal, Characters.FarmAnimal.GrabHarvestType);
        }

        public static bool RequiresToolForHarvest(int harvestType)
        {
            // "It" harvest type doesn't allow you to name the animal. This is 
            // mostly unused and is only seen on the Hog
            return Characters.FarmAnimal.HasHarvestType(harvestType, Characters.FarmAnimal.GrabHarvestType);
        }

        public static string GetToolUsedForHarvest(global::StardewValley.FarmAnimal animal)
        {
            return animal.toolUsedForHarvest.Value.Length > 0 ? animal.toolUsedForHarvest.Value : default(string);
        }

        public static bool IsToolUsedForHarvest(global::StardewValley.FarmAnimal animal, string tool)
        {
            return Characters.FarmAnimal.IsToolUsedForHarvest(Characters.FarmAnimal.GetToolUsedForHarvest(animal), tool);
        }

        public static bool IsToolUsedForHarvest(string tool, string target)
        {
            return tool == target;
        }


        /***
         * Home
         ***/

        public static global::StardewValley.Buildings.Building GetHome(global::StardewValley.FarmAnimal animal)
        {
            return animal.home;
        }

        public static bool HasHome(global::StardewValley.FarmAnimal animal)
        {
            return Characters.FarmAnimal.GetHome(animal) != null;
        }

        public static bool IsInHome(global::StardewValley.FarmAnimal animal)
        {
            if (!Characters.FarmAnimal.HasHome(animal))
            {
                return false;
            }

            return Locations.AnimalHouse.GetIndoors(Characters.FarmAnimal.GetHome(animal)).animals.ContainsKey(Characters.FarmAnimal.GetUniqueId(animal));
        }

        public static void SetFindHomeDoorPathController(global::StardewValley.FarmAnimal animal, GameLocation location)
        {
            if (Characters.FarmAnimal.HasHome(animal))
            {
                return;
            }

            animal.controller = new PathFindController(animal, location, new PathFindController.isAtEnd(PathFindController.isAtEndPoint), 0, false, null, 200, new Point(animal.home.tileX.Value + animal.home.animalDoor.X, animal.home.tileY.Value + animal.home.animalDoor.Y));
        }

        public static string GetDisplayHouse(global::StardewValley.FarmAnimal animal)
        {
            return animal.displayHouse;
        }

        public static bool IsCoopDweller(global::StardewValley.FarmAnimal animal)
        {
            string buildingType = Characters.FarmAnimal.HasHome(animal)
                ? animal.home.buildingType.Value
                : animal.buildingTypeILiveIn.Value;

            return Characters.FarmAnimal.IsCoopDweller(buildingType);
        }

        public static bool IsCoopDweller(string buildingType)
        {
            return buildingType == null ? false : buildingType.Contains(Locations.AnimalHouse.Coop);
        }

        public static bool CanLiveIn(global::StardewValley.FarmAnimal animal, Building building)
        {
            return building.buildingType.Value.Contains(animal.buildingTypeILiveIn.Value);
        }

        public static void SetHome(global::StardewValley.FarmAnimal animal, Building home)
        {
            animal.home = home;
            animal.homeLocation.Value = home == null ? default(Vector2) : new Vector2(home.tileX.Value, home.tileY.Value);
        }

        public static bool ReturnHome(global::StardewValley.FarmAnimal animal)
        {
            if (!Characters.FarmAnimal.HasHome(animal))
            {
                return false;
            }

            Building home = animal.home;

            Locations.AnimalHouse.AddAnimal(home, animal);
            Characters.FarmAnimal.SetRandomPositionInHome(animal);
            Characters.FarmAnimal.SetRandomFacingDirection(animal);

            animal.controller = null;

            return true;
        }

        public static bool SetRandomPositionInHome(global::StardewValley.FarmAnimal animal)
        {
            if (!Characters.FarmAnimal.HasHome(animal))
            {
                return false;
            }

            animal.setRandomPosition(animal.home.indoors.Value);

            return true;
        }

        public static void AddToBuilding(global::StardewValley.FarmAnimal animal, Building building)
        {
            Characters.FarmAnimal.SetHome(animal, building);
            Characters.FarmAnimal.SetRandomPositionInHome(animal);
            Locations.AnimalHouse.AddAnimal(building, animal);
        }


        /***
         * IDs
         ***/

        public static void SetUniqueId(global::StardewValley.FarmAnimal animal, long id)
        {
            animal.myID.Value = id;
        }

        public static long GetUniqueId(global::StardewValley.FarmAnimal animal)
        {
            return animal.myID.Value;
        }

        public static long GetOwnerId(global::StardewValley.FarmAnimal animal)
        {
            return animal.ownerID.Value;
        }

        public static void SetOwner(global::StardewValley.FarmAnimal animal, long id)
        {
            animal.ownerID.Value = id;
        }

        public static string GetName(global::StardewValley.FarmAnimal animal)
        {
            return animal.Name;
        }

        public static bool HasName(global::StardewValley.FarmAnimal animal)
        {
            return Characters.FarmAnimal.GetName(animal) != null;
        }

        public static string SetRandomName(global::StardewValley.FarmAnimal animal)
        {
            string name = Utilities.Dialogue.GetRandomName();

            Characters.FarmAnimal.SetName(animal, name);

            return name;
        }

        public static void SetName(global::StardewValley.FarmAnimal animal, string name)
        {
            animal.Name = name;
            animal.displayName = name;
        }


        /***
         * Price
         ***/

        public static int GetPrice(global::StardewValley.FarmAnimal animal)
        {
            return animal.price.Value;
        }

        public static int GetSellPrice(global::StardewValley.FarmAnimal animal)
        {
            return animal.getSellPrice();
        }

        public static int GetCheapestPrice(List<string> types)
        {
            // Collect all of the prices from the animal types
            List<int> prices = Utilities.Content.LoadData<string, string>(Utilities.Content.DataFarmAnimalsContentPath)
                .Where(kvp => types.Contains(kvp.Key))
                .Select(kvp => Int32.Parse(Utilities.Content.ParseDataValue(kvp.Value)[(int)Characters.FarmAnimal.DataValueIndex.Price]))
                .ToList();

            // Sort the prices in ascending order
            prices.Sort();

            return prices.First();
        }

        /***
         * Produce
         ***/

        public static int GetCurrentProduce(global::StardewValley.FarmAnimal animal)
        {
            return animal.currentProduce.Value;
        }

        public static bool IsCurrentlyProducing(global::StardewValley.FarmAnimal animal)
        {
            int currentProduce = Characters.FarmAnimal.GetCurrentProduce(animal);

            // Don't count "Weeds" (index:0) as produce
            return Characters.FarmAnimal.IsProduceAnItem(currentProduce) && currentProduce > 0;
        }

        public static int GetDefaultProduce(global::StardewValley.FarmAnimal animal)
        {
            return animal.defaultProduceIndex.Value;
        }

        public static int GetDeluxeProduce(global::StardewValley.FarmAnimal animal)
        {
            return animal.deluxeProduceIndex.Value;
        }

        public static int GetProduceQuality(global::StardewValley.FarmAnimal animal)
        {
            return animal.produceQuality.Value;
        }

        public static bool HasProduceThatMatchesAll(global::StardewValley.FarmAnimal animal, int[] targets)
        {
            // Intersection length should match target length
            return Characters.FarmAnimal.HasProduceThatMatchesAll(Characters.FarmAnimal.GetDefaultProduce(animal), Characters.FarmAnimal.GetDeluxeProduce(animal), targets);
        }

        public static bool HasProduceThatMatchesAll(int defaultProduceId, int deluxeProduceId, int[] targets)
        {
            int[] produceIndexes = new int[] { defaultProduceId, deluxeProduceId };

            // Intersection length should not change
            return produceIndexes.Intersect(targets).Count()
                .Equals(produceIndexes.Length);
        }

        public static bool HasProduceThatMatchesAtLeastOne(global::StardewValley.FarmAnimal animal, int[] targets)
        {
            return Characters.FarmAnimal.HasProduceThatMatchesAtLeastOne(Characters.FarmAnimal.GetDefaultProduce(animal), Characters.FarmAnimal.GetDeluxeProduce(animal), targets);
        }

        public static bool HasProduceThatMatchesAtLeastOne(int defaultProduceId, int deluxeProduceId, int[] targets)
        {
            // Must actualy be a product
            return targets.Where(o => Characters.FarmAnimal.IsProduceAnItem(o))
                .Intersect(new int[] { defaultProduceId, deluxeProduceId })
                .Any();
        }

        public static bool AreProduceItems(global::StardewValley.FarmAnimal animal)
        {
            return IsDefaultProduceAnItem(animal)
                && IsDeluxeProduceAnItem(animal);
        }

        public static bool AreProduceItems(int defaultProduceIndex, int deluxeProduceIndex)
        {
            return IsProduceAnItem(defaultProduceIndex)
                && IsProduceAnItem(deluxeProduceIndex);
        }

        public static bool IsAtLeastOneProduceAnItem(global::StardewValley.FarmAnimal animal)
        {
            return IsDefaultProduceAnItem(animal)
                || IsDeluxeProduceAnItem(animal);
        }

        public static bool IsAtLeastOneProduceAnItem(int defaultProduceIndex, int deluxeProduceIndex)
        {
            return IsProduceAnItem(defaultProduceIndex)
                || IsProduceAnItem(deluxeProduceIndex);
        }

        public static bool IsCurrentlyProducingDeluxe(global::StardewValley.FarmAnimal animal)
        {
            int currentProduce = Characters.FarmAnimal.GetCurrentProduce(animal);

            return currentProduce == Characters.FarmAnimal.GetDeluxeProduce(animal);
        }

        public static bool IsDefaultProduceAnItem(global::StardewValley.FarmAnimal animal)
        {
            return Characters.FarmAnimal.IsProduceAnItem(animal.defaultProduceIndex.Value);
        }

        public static bool IsDeluxeProduceAnItem(global::StardewValley.FarmAnimal animal)
        {
            return Characters.FarmAnimal.IsProduceAnItem(animal.deluxeProduceIndex.Value);
        }

        public static bool IsProduceAnItem(int produceIndex)
        {
            return produceIndex != Characters.FarmAnimal.NoProduce;
        }

        public static bool IsAProducer(global::StardewValley.FarmAnimal animal)
        {
            // Only animals that require a tool for harvst...
            if (!Characters.FarmAnimal.RequiresToolForHarvest(animal))
            {
                return true;
            }

            // ... and the harvest type of "-1" will never produce
            return !Characters.FarmAnimal.IsToolUsedForHarvest(animal, Characters.FarmAnimal.NonProducerTool);
        }

        public static void SetCurrentProduce(global::StardewValley.FarmAnimal animal, int produceIndex)
        {
            animal.currentProduce.Value = produceIndex;
        }

        public static void SetProduceQuality(global::StardewValley.FarmAnimal animal, Objects.Object.Quality quality)
        {
            animal.produceQuality.Value = (int)quality;
        }

        public static Objects.Object.Quality RollProduceQuality(global::StardewValley.FarmAnimal animal, global::StardewValley.Farmer farmer, int seed)
        {
            int friendship = Characters.FarmAnimal.GetFriendship(animal);
            byte happiness = Characters.FarmAnimal.GetHappiness(animal);

            double num2 = friendship / 1000.0 - (1.0 - happiness / 225.0);

            bool isCoopDweller = Characters.FarmAnimal.IsCoopDweller(animal);
            bool hasShepherdProfession = Characters.Farmer.HasProfession(farmer, Characters.Farmer.Profession.Shepherd);
            bool hasButcherProfession = Characters.Farmer.HasProfession(farmer, Characters.Farmer.Profession.Butcher);

            if (!isCoopDweller && hasShepherdProfession || isCoopDweller && hasButcherProfession)
            {
                num2 += 0.33;
            }

            Random random = new Random(seed);

            if (num2 >= 0.95 && random.NextDouble() < num2 / 2.0)
            {
                return Objects.Object.Quality.Best;
            }
            else if (random.NextDouble() < num2 / 2.0)
            {
                return Objects.Object.Quality.High;
            }
            else if (random.NextDouble() < num2)
            {
                return Objects.Object.Quality.Medium;
            }

            return Objects.Object.Quality.Low;
        }

        public static int RollProduce(global::StardewValley.FarmAnimal animal, int seed, global::StardewValley.Farmer farmer = null, double deluxeProduceLuck = default(double))
        {
            double luck = farmer == null
                ? default(double)
                : Characters.Farmer.GetDailyLuck(farmer) * deluxeProduceLuck;

            return Characters.FarmAnimal.RollDeluxeProduceChance(animal, luck, seed)
                ? Characters.FarmAnimal.GetDeluxeProduce(animal)
                : Characters.FarmAnimal.GetDefaultProduce(animal);
        }

        public static bool RollDeluxeProduceChance(global::StardewValley.FarmAnimal animal, double luck, int seed)
        {
            if (Characters.FarmAnimal.IsBaby(animal))
            {
                return false;
            }

            if (!Characters.FarmAnimal.IsProduceAnItem(Characters.FarmAnimal.GetDeluxeProduce(animal)))
            {
                return false;
            }

            Random random = new Random(seed);
            byte happiness = Characters.FarmAnimal.GetHappiness(animal);

            if (random.NextDouble() >= happiness / 150.0)
            {
                return false;
            }

            double offset = 0.0d;
            int friendship = Characters.FarmAnimal.GetFriendship(animal);

            if (happiness > 200)
            {
                offset = happiness * 1.5;
            }
            else if (happiness <= 100)
            {
                offset = happiness - 100;
            }

            if (luck != 0.0D)
            {
                return Utilities.Random.NextDouble() < (friendship + offset) / 5000.0 + luck;
            }
            else
            {
                if (friendship < 200)
                {
                    return false;
                }

                return Utilities.Random.NextDouble() < (friendship + offset) / 1200.0;
            }
        }


        /***
         * Sounds and sprites
         ***/

        public static void SetPauseTimer(global::StardewValley.FarmAnimal animal, int timer)
        {
            animal.pauseTimer = Math.Max(Characters.FarmAnimal.MinPauseTimer, timer);
        }

        public static int GetPauseTimer(global::StardewValley.FarmAnimal animal)
        {
            return animal.pauseTimer;
        }

        public static void SetHitGlowTimer(global::StardewValley.FarmAnimal animal, int timer)
        {
            animal.hitGlowTimer = Math.Max(Characters.FarmAnimal.MinHitGlowTimer, timer);
        }

        public static int GetHitGlowTimer(global::StardewValley.FarmAnimal animal)
        {
            return animal.hitGlowTimer;
        }

        public static bool HasPathController(global::StardewValley.FarmAnimal animal)
        {
            return animal.controller != null;
        }

        public static void ResetPathController(global::StardewValley.FarmAnimal animal)
        {
            animal.controller = null;
        }

        public static bool MakesSound(global::StardewValley.FarmAnimal animal)
        {
            return Characters.FarmAnimal.GetSound(animal) != null;
        }

        public static string GetSound(global::StardewValley.FarmAnimal animal)
        {
            return animal.sound.Value;
        }

        public static void ReloadSpriteTexture(global::StardewValley.FarmAnimal animal)
        {
            animal.Sprite.LoadTexture(Characters.FarmAnimal.BuildSpriteAssetName(animal));
        }

        public static string BuildSpriteAssetName(global::StardewValley.FarmAnimal animal)
        {
            bool isBaby = Characters.FarmAnimal.IsBaby(animal);
            bool isSheared = !isBaby && Characters.FarmAnimal.IsSheared(animal);

            if (!Characters.FarmAnimal.TryBuildSpriteAssetName(Characters.FarmAnimal.GetType(animal), isBaby, isSheared, out string assetName))
            {
                // Covers the BabyDuck scenario by using BabyWhite Chicken
                bool isCoopDweller = Characters.FarmAnimal.IsCoopDweller(animal);

                assetName = Characters.FarmAnimal.BuildSpriteAssetName(Characters.FarmAnimal.GetDefaultType(isCoopDweller), isBaby, isSheared);
            }

            return assetName;
        }

        public static string BuildSpriteAssetName(string type, bool isBaby = false, bool isSheared = false)
        {
            string prefix = "";

            if (isBaby)
            {
                prefix = Characters.FarmAnimal.BabyPrefix;
            }
            else if (isSheared)
            {
                prefix = Characters.FarmAnimal.ReadyForHarvestPrefix;
            }

            return Utilities.Content.BuildPath(new string[] { Utilities.Content.AnimalsContentDirectory, prefix + type });
        }

        public static bool TryBuildSpriteAssetName(string type, bool isBaby, bool isSheared, out string assetName)
        {
            assetName = Characters.FarmAnimal.BuildSpriteAssetName(type, isBaby, isSheared);

            return Utilities.Content.Exists<Texture2D>(assetName);
        }

        public static AnimatedSprite CreateSprite(global::StardewValley.FarmAnimal animal)
        {
            return new AnimatedSprite(Characters.FarmAnimal.BuildSpriteAssetName(animal), Utilities.Content.StartingFrame, animal.frontBackSourceRect.Width, animal.frontBackSourceRect.Height);
        }

        public static void SetRandomFacingDirection(global::StardewValley.FarmAnimal animal)
        {
            animal.faceDirection(Utilities.Random.Next(4));
        }

        public static void AnimateFindingProduce(global::StardewValley.FarmAnimal animal)
        {
            int frame1, frame2;

            switch (animal.FacingDirection)
            {
                case 0:
                    frame1 = 9;
                    frame2 = 11;
                    break;
                case 1:
                    frame1 = 5;
                    frame2 = 7;
                    break;
                case 2:
                    frame1 = 1;
                    frame2 = 2;
                    break;
                case 3:
                default:
                    frame1 = 5;
                    frame2 = 7;
                    break;
            }

            Delegate @delegate = Delegate.CreateDelegate(typeof(AnimatedSprite.endOfAnimationBehavior), animal, Utilities.Reflection.GetMethod(animal, "findTruffle"));

            AnimatedSprite.endOfAnimationBehavior endOfAnimationBehavior = (AnimatedSprite.endOfAnimationBehavior)@delegate;

            List<FarmerSprite.AnimationFrame> animation = new List<FarmerSprite.AnimationFrame>()
            {
                new FarmerSprite.AnimationFrame(frame1, 250),
                new FarmerSprite.AnimationFrame(frame2, 250),
                new FarmerSprite.AnimationFrame(frame1, 250),
                new FarmerSprite.AnimationFrame(frame2, 250),
                new FarmerSprite.AnimationFrame(frame1, 250),
                new FarmerSprite.AnimationFrame(frame2, 250, false, false, endOfAnimationBehavior, false)
            };

            animal.Sprite.setCurrentAnimation(animation);
            animal.Sprite.loop = false;
        }

        public static int GetFacingDirection(global::StardewValley.FarmAnimal animal)
        {
            return animal.FacingDirection;
        }

        public static Vector2 GetTileLocation(global::StardewValley.FarmAnimal animal)
        {
            return animal.getTileLocation();
        }

        public static bool HasController(global::StardewValley.FarmAnimal animal)
        {
            return animal.controller != null;
        }

        public static Rectangle GetBoundingBox(global::StardewValley.FarmAnimal animal)
        {
            return animal.GetBoundingBox();
        }

        public static byte GetDaysToLay(global::StardewValley.FarmAnimal animal, global::StardewValley.Farmer farmer = null)
        {
            byte daysToLay = animal.daysToLay.Value;

            if (farmer == null)
            {
                return daysToLay;
            }

            bool isSheep = Characters.FarmAnimal.IsType(animal, FarmAnimal.Sheep);
            bool hasShepherdProfession = Characters.Farmer.HasProfession(farmer, Characters.Farmer.Profession.Shepherd);

            daysToLay = (byte)Math.Min(Characters.FarmAnimal.MaxDaysToLay, Math.Max(Characters.FarmAnimal.MinDaysToLay, daysToLay + (isSheep && hasShepherdProfession ? Characters.FarmAnimal.ShepherdProfessionDaysToLayBonus : 0)));

            return daysToLay;
        }

        public static byte GetDaysSinceLastLay(global::StardewValley.FarmAnimal animal)
        {
            return animal.daysSinceLastLay.Value;
        }

        public static void SetDaysSinceLastLay(global::StardewValley.FarmAnimal animal, byte days)
        {
            animal.daysSinceLastLay.Value = Math.Max(Characters.FarmAnimal.MinDaysSinceLastLay, Math.Min(Characters.FarmAnimal.MaxDaysSinceLastLay, days));
        }

        public static int GetMeatIndex(global::StardewValley.FarmAnimal animal)
        {
            return animal.meatIndex.Value;
        }

        /***
         * States
         ***/

        public static global::StardewValley.FarmAnimal CreateFarmAnimal(string type, long ownerId, string name = null, Building home = null, long myId = default(long))
        {
            if (myId == default(long))
            {
                myId = Utilities.Game.GetNewId();
            }

            global::StardewValley.FarmAnimal animal = new global::StardewValley.FarmAnimal(type, myId, ownerId)
            {
                Name = name,
                displayName = name,
                home = home
            };

            Characters.FarmAnimal.UpdateFromData(animal, type);

            return animal;
        }

        public static void Reload(global::StardewValley.FarmAnimal animal, Building home)
        {
            animal.reload(home);
        }

        public static void ReloadAll()
        {
            for (int index = 0; index < Game1.locations.Count; ++index)
            {
                if (!(Game1.locations[index] is Farm farm))
                {
                    continue;
                }

                for (int j = 0; j < farm.buildings.Count; ++j)
                {
                    if (!(farm.buildings[j].indoors.Value is global::StardewValley.AnimalHouse animalHouse))
                    {
                        continue;
                    }

                    for (int k = 0; k < animalHouse.animalsThatLiveHere.Count(); ++k)
                    {
                        long id = animalHouse.animalsThatLiveHere.ElementAt(k);

                        if (animalHouse.animals.ContainsKey(id))
                        {
                            global::StardewValley.FarmAnimal animal = animalHouse.animals[id];

                            Characters.FarmAnimal.Reload(animal, animal.home);
                        }
                    }
                }

                break;
            }
        }

        public static void IncreasePathFindingThisTick(int amount = 1)
        {
            global::StardewValley.FarmAnimal.NumPathfindingThisTick += amount;
        }

        public static bool UnderMaxPathFindingPerTick()
        {
            return global::StardewValley.FarmAnimal.NumPathfindingThisTick < Characters.FarmAnimal.MaxPathFindingPerTick;
        }


        /***
         * Types
         ***/

        public static void SetType(global::StardewValley.FarmAnimal animal, string type)
        {
            animal.type.Value = type;
        }

        public static string GetType(global::StardewValley.FarmAnimal animal)
        {
            return animal.type.Value;
        }

        public static string GetDisplayType(global::StardewValley.FarmAnimal animal)
        {
            return animal.displayType;
        }

        public static bool IsType(global::StardewValley.FarmAnimal animal, Characters.Livestock type)
        {
            return Characters.FarmAnimal.IsType(animal, type.ToString());
        }

        public static bool IsType(global::StardewValley.FarmAnimal animal, string type)
        {
            return Characters.FarmAnimal.IsType(animal.type.Value, type);
        }

        public static bool IsType(string source, string type)
        {
            return source == type;
        }

        public static string GetDefaultType(string buildingType)
        {
            return Characters.FarmAnimal.GetDefaultType(buildingType == Locations.AnimalHouse.Coop);
        }

        public static string GetDefaultType(global::StardewValley.FarmAnimal animal)
        {
            return Characters.FarmAnimal.GetDefaultType(Characters.FarmAnimal.IsCoopDweller(animal));
        }

        public static string GetDefaultType(bool isCoop)
        {
            return isCoop
                ? Characters.FarmAnimal.GetDefaultCoopDwellerType()
                : Characters.FarmAnimal.GetDefaultBarnDwellerType();
        }

        public static string GetDefaultCoopDwellerType()
        {
            return FarmAnimal.WhiteChicken.ToString();
        }

        public static string GetDefaultBarnDwellerType()
        {
            return FarmAnimal.WhiteCow.ToString();
        }

        public static List<string> GetTypesFromProduce(int[] produceIndexes, Dictionary<string, List<string>> restrictions)
        {
            List<string> potentialCategories = new List<string>();
            List<string> potentialTypes = new List<string>();

            // Someone could have the data set up, but not add it to BFAV so that
            // it's hidden from the game so we must use BFAV's restrictions
            Dictionary<string, string> contentData = Utilities.Content.LoadData<string, string>(Utilities.Content.DataFarmAnimalsContentPath);

            foreach (KeyValuePair<string, List<string>> entry in restrictions)
            {
                foreach (string type in entry.Value)
                {
                    string[] values = Utilities.Content.ParseDataValue(contentData[type]);

                    int defaultProduceId = Int32.Parse(values[(int)Characters.FarmAnimal.DataValueIndex.DefaultProduce]);
                    int deluxeProduceId = Int32.Parse(values[(int)Characters.FarmAnimal.DataValueIndex.DeluxeProduce]);

                    if (Characters.FarmAnimal.HasProduceThatMatchesAtLeastOne(defaultProduceId, deluxeProduceId, produceIndexes))
                    {
                        potentialTypes.Add(type);
                        potentialCategories.Add(entry.Key);
                    }
                }
            }

            return potentialTypes;
        }

        public static string GetRandomTypeFromProduce(global::StardewValley.FarmAnimal animal, Dictionary<string, List<string>> restrictions)
        {
            // Use the produce to find other potentials
            return GetRandomTypeFromProduce(new int[] { Characters.FarmAnimal.GetDefaultProduce(animal), Characters.FarmAnimal.GetDeluxeProduce(animal) }, restrictions);
        }

        public static string GetRandomTypeFromProduce(int[] produceIndexes, Dictionary<string, List<string>> restrictions)
        {
            List<string> potentialTypes = Characters.FarmAnimal.GetTypesFromProduce(produceIndexes, restrictions);
            int index = Utilities.Random.Next(potentialTypes.Count);

            // Check to make sure types came back
            return potentialTypes.Any()
                ? potentialTypes[index]
                : null;
        }

        public static string GetRandomTypeFromProduce(int produceIndex, Dictionary<string, List<string>> restrictions)
        {
            return Characters.FarmAnimal.GetRandomTypeFromProduce(new int[] { produceIndex }, restrictions);
        }

        public static bool BlueChickenIsUnlocked(global::StardewValley.Farmer farmer)
        {
            return Characters.Farmer.HasSeenEvent(farmer, Locations.Event.BlueChicken);
        }

        public static bool RollBlueChickenChance(global::StardewValley.Farmer farmer)
        {
            if (!Characters.FarmAnimal.BlueChickenIsUnlocked(farmer))
            {
                return false;
            }

            return Utilities.Random.NextDouble() >= Characters.FarmAnimal.BlueChickenChance;
        }

        public static List<string> SanitizeAffordableTypes(List<string> types, global::StardewValley.Farmer farmer)
        {
            // Filter out any types that the player cannot afford
            return Utilities.Content.LoadData<string, string>(Utilities.Content.DataFarmAnimalsContentPath)
                .Where(kvp => types.Contains(kvp.Key) && Characters.Farmer.CanAfford(farmer, Int32.Parse(Utilities.Content.ParseDataValue(kvp.Value)[(int)Characters.FarmAnimal.DataValueIndex.Price])))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                .Keys
                .ToList();
        }

        public static List<string> SanitizeBlueChickens(List<string> types, global::StardewValley.Farmer farmer)
        {
            // Sanitize for blue chickens
            string blueChicken = FarmAnimal.BlueChicken.ToString();

            // Check for blue chicken chance
            if (types.Contains(blueChicken) && !Locations.AnimalShop.IsBlueChickenAvailableForPurchase(farmer))
            {
                types.Remove(blueChicken);
            }

            return types;
        }


        /***
         * Vanilla
         ***/

        public static List<Characters.LivestockCategory> GetVanillaCategories()
        {
            return new List<Characters.LivestockCategory>()
            {
                Characters.FarmAnimal.ChickenCategory,
                Characters.FarmAnimal.DairyCowCategory,
                Characters.FarmAnimal.DinosaurCategory,
                Characters.FarmAnimal.DuckCategory,
                Characters.FarmAnimal.GoatCategory,
                Characters.FarmAnimal.PigCategory,
                Characters.FarmAnimal.RabbitCategory,
                Characters.FarmAnimal.SheepCategory,
            }
            .OrderBy(o => o.Order)
            .ToList();
        }

        public static List<Characters.Livestock> GetVanillaTypes()
        {
            return new List<Characters.Livestock>()
            {
                FarmAnimal.WhiteChicken,
                FarmAnimal.BrownChicken,
                FarmAnimal.BlueChicken,
                FarmAnimal.VoidChicken,
                FarmAnimal.WhiteCow,
                FarmAnimal.BrownCow,
                FarmAnimal.Goat,
                FarmAnimal.Duck,
                FarmAnimal.Sheep,
                FarmAnimal.Rabbit,
                FarmAnimal.Pig,
                FarmAnimal.Dinosaur,
            };
        }

        public static bool IsVanilla(global::StardewValley.FarmAnimal animal)
        {
            return Characters.FarmAnimal.IsVanillaType(Characters.FarmAnimal.GetType(animal));
        }

        public static bool IsVanillaType(string type)
        {
            return FarmAnimal.GetVanillaTypes()
                .Select(o => o.ToString())
                .Contains(type);
        }

        public static bool IsVanillaCategory(string category)
        {
            return FarmAnimal.GetVanillaCategories()
                .Select(o => o.ToString())
                .Contains(category);
        }
    }
}
