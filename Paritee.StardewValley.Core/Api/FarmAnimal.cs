using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Netcode;
using StardewValley;
using StardewValley.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paritee.StardewValley.Core.Api
{
    public class FarmAnimal
    {
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
            Api.FarmAnimal.AssociateParent(animal, Api.FarmAnimal.GetUniqueId(parent));
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
            Dictionary<string, string> contentData = Api.Content.LoadData<string, string>(Constants.Content.DataFarmAnimalsContentPath);
            KeyValuePair<string, string> contentDataEntry = Api.Content.GetDataEntry<string, string>(contentData, type);

            // Always validate if the type we're trying to use exists
            if (contentDataEntry.Key == null)
            {
                // Get a default type to use
                string defaultType = Api.FarmAnimal.GetDefaultType(animal);

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
            bool isCurrentlyProducingAnItem = Api.FarmAnimal.IsProduceAnItem(Api.FarmAnimal.GetCurrentProduce(animal));
            bool isCurrentlyProducingDeluxe = Api.FarmAnimal.IsCurrentlyProducingDeluxe(animal);
            
            string[] values = Api.Content.ParseDataValue(contentDataEntry.Value);

            // Reset the instance's values based on the new type
            animal.type.Value = contentDataEntry.Key;
            animal.daysToLay.Value = Convert.ToByte(values[(int)Constants.FarmAnimal.DataValueIndex.DaysToLay]);
            animal.ageWhenMature.Value = Convert.ToByte(values[(int)Constants.FarmAnimal.DataValueIndex.AgeWhenMature]);
            animal.defaultProduceIndex.Value = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.DefaultProduce]);
            animal.deluxeProduceIndex.Value = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.DeluxeProduce]);

            string sound = values[(int)Constants.FarmAnimal.DataValueIndex.Sound];

            animal.sound.Value = Api.FarmAnimal.IsDataValueNull(sound) ? null : sound;

            int x, y, width, height;

            x = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.FrontBackBoundingBoxX]);
            y = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.FrontBackBoundingBoxY]);
            width = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.FrontBackBoundingBoxWidth]);
            height = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.FrontBackBoundingBoxHeight]);

            animal.frontBackBoundingBox.Value = new Rectangle(x, y, width, height);

            x = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.SidewaysBoundingBoxX]);
            y = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.SidewaysBoundingBoxY]);
            width = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.SidewaysBoundingBoxWidth]);
            height = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.SidewaysBoundingBoxHeight]);

            animal.sidewaysBoundingBox.Value = new Rectangle(x, y, width, height);

            animal.harvestType.Value = Convert.ToByte(values[(int)Constants.FarmAnimal.DataValueIndex.HarvestType]);
            animal.showDifferentTextureWhenReadyForHarvest.Value = Convert.ToBoolean(values[(int)Constants.FarmAnimal.DataValueIndex.ShowDifferentTextureWhenReadyForHarvest]);
            animal.buildingTypeILiveIn.Value = values[(int)Constants.FarmAnimal.DataValueIndex.BuildingTypeILiveIn];

            width = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.SpriteWidth]);
            height = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.SpritHeight]);

            animal.Sprite = new AnimatedSprite(Api.FarmAnimal.BuildSpriteAssetName(animal), Constants.Content.StartingFrame, width, height);
            animal.frontBackSourceRect.Value = new Rectangle(0, 0, width, height);

            width = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.SidewaysSourceRectWidth]);
            height = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.SidewaysSourceRectHeight]);

            animal.sidewaysSourceRect.Value = new Rectangle(0, 0, width, height);

            animal.fullnessDrain.Value = Convert.ToByte(values[(int)Constants.FarmAnimal.DataValueIndex.FullnessDrain]);
            animal.happinessDrain.Value = Convert.ToByte(values[(int)Constants.FarmAnimal.DataValueIndex.HappinessDrain]);

            string toolUsedForHarvest = values[(int)Constants.FarmAnimal.DataValueIndex.ToolUsedForHarvest];

            animal.toolUsedForHarvest.Value = Api.FarmAnimal.IsDataValueNull(toolUsedForHarvest) ? "" : toolUsedForHarvest;
            animal.meatIndex.Value = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.MeatIndex]);
            animal.price.Value = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.Price]);

            // Reset the current produce
            int produceIndex = isCurrentlyProducingAnItem
                ? isCurrentlyProducingDeluxe ? Api.FarmAnimal.GetDeluxeProduce(animal) : Api.FarmAnimal.GetDefaultProduce(animal)
                : Constants.FarmAnimal.NoProduce;

            Api.FarmAnimal.SetCurrentProduce(animal, produceIndex);
        }

        private static bool IsDataValueNull(string value)
        {
            return value == null || value == "null" || value == default(string) || value == "" || value == Constants.Content.None;
        }


        /***
         * Friendship
         ***/

        public static void DecreaseFriendship(global::StardewValley.FarmAnimal animal, int decrease)
        {
            Api.FarmAnimal.IncreaseFriendship(animal, decrease * -1);
        }

        public static void IncreaseFriendship(global::StardewValley.FarmAnimal animal, int increase)
        {
            Api.FarmAnimal.SetFriendship(animal, Api.FarmAnimal.GetFriendship(animal) + increase);
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
            animal.fullness.Value = Math.Max(Constants.FarmAnimal.MinFullness, Math.Min(Constants.FarmAnimal.MaxFullness, fullness));
        }

        public static void SetFindGrassPathController(global::StardewValley.FarmAnimal animal, GameLocation location)
        {
            animal.controller = new PathFindController(animal, location, new PathFindController.isAtEnd(global::StardewValley.FarmAnimal.grassEndPointFunction), -1, false, new PathFindController.endBehavior(global::StardewValley.FarmAnimal.behaviorAfterFindingGrassPatch), 200, Point.Zero);
        }

        public static bool IsEating(global::StardewValley.FarmAnimal animal)
        {
            return Helpers.Reflection.GetFieldValue<NetBool>(animal, "isEating").Value;
        }

        public static void StopEating(global::StardewValley.FarmAnimal animal)
        {
            Helpers.Reflection.GetField(animal, "isEating").SetValue(animal, new NetBool(false));
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
            animal.happiness.Value = Math.Max(Constants.FarmAnimal.MinHappiness, Math.Min(Constants.FarmAnimal.MaxHappiness, happiness));
        }

        public static byte GetHappinessDrain(global::StardewValley.FarmAnimal animal)
        {
            return animal.happinessDrain.Value;
        }

        public static void SetMoodMessage(global::StardewValley.FarmAnimal animal, Constants.FarmAnimal.MoodMessage moodMessage)
        {
            Helpers.Reflection.GetField(animal, "moodMessage").SetValue(animal, (int)moodMessage);
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
            Helpers.Reflection.GetMethod(animal, "findTruffle").Invoke(animal, new object[] { farmer });
        }

        public static bool CanFindProduce(global::StardewValley.FarmAnimal animal)
        {
            return Api.FarmAnimal.CanFindProduce(animal.harvestType.Value, animal.toolUsedForHarvest.Value);
        }

        public static bool CanFindProduce(int harvestType, string harvestTool)
        {
            // NOTE: This will NOT catch when tool is -1 which allows for animals 
            // that do not produce anything ever
            return Api.FarmAnimal.RequiresToolForHarvest(harvestType)
                && Api.FarmAnimal.IsDataValueNull(harvestTool);
        }

        public static bool CanBeNamed(global::StardewValley.FarmAnimal animal)
        {
            // "It" harvest type doesn't allow you to name the animal. This is 
            // mostly unused and is only seen on the Hog
            return Api.FarmAnimal.HasHarvestType(animal, Constants.FarmAnimal.ButcherHarvestType);
        }

        public static bool LaysProduce(global::StardewValley.FarmAnimal animal)
        {
            return Api.FarmAnimal.HasHarvestType(animal, Constants.FarmAnimal.LayHarvestType);
        }

        public static bool RequiresToolForHarvest(global::StardewValley.FarmAnimal animal)
        {
            // "It" harvest type doesn't allow you to name the animal. This is 
            // mostly unused and is only seen on the Hog
            return Api.FarmAnimal.HasHarvestType(animal, Constants.FarmAnimal.GrabHarvestType);
        }

        public static bool RequiresToolForHarvest(int harvestType)
        {
            // "It" harvest type doesn't allow you to name the animal. This is 
            // mostly unused and is only seen on the Hog
            return Api.FarmAnimal.HasHarvestType(harvestType, Constants.FarmAnimal.GrabHarvestType);
        }

        public static string GetToolUsedForHarvest(global::StardewValley.FarmAnimal animal)
        {
            return animal.toolUsedForHarvest.Value.Length > 0 ? animal.toolUsedForHarvest.Value : default(string);
        }

        public static bool IsToolUsedForHarvest(global::StardewValley.FarmAnimal animal, string tool)
        {
            return Api.FarmAnimal.IsToolUsedForHarvest(Api.FarmAnimal.GetToolUsedForHarvest(animal), tool);
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
            return Api.FarmAnimal.GetHome(animal) != null;
        }

        public static bool IsInHome(global::StardewValley.FarmAnimal animal)
        {
            if (!Api.FarmAnimal.HasHome(animal))
            {
                return false;
            }

            return Api.AnimalHouse.GetIndoors(Api.FarmAnimal.GetHome(animal)).animals.ContainsKey(Api.FarmAnimal.GetUniqueId(animal));
        }

        public static void SetFindHomeDoorPathController(global::StardewValley.FarmAnimal animal, GameLocation location)
        {
            if (Api.FarmAnimal.HasHome(animal))
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
            string buildingType = Api.FarmAnimal.HasHome(animal)
                ? animal.home.buildingType.Value
                : animal.buildingTypeILiveIn.Value;

            return Api.FarmAnimal.IsCoopDweller(buildingType);
        }

        public static bool IsCoopDweller(string buildingType)
        {
            return buildingType == null ? false : buildingType.Contains(Constants.AnimalHouse.Coop);
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
            if (!Api.FarmAnimal.HasHome(animal))
            {
                return false;
            }

            Building home = animal.home;

            Api.AnimalHouse.AddAnimal(home, animal);
            Api.FarmAnimal.SetRandomPositionInHome(animal);
            Api.FarmAnimal.SetRandomFacingDirection(animal);

            animal.controller = null;

            return true;
        }

        public static bool SetRandomPositionInHome(global::StardewValley.FarmAnimal animal)
        {
            if (!Api.FarmAnimal.HasHome(animal))
            {
                return false;
            }

            animal.setRandomPosition(animal.home.indoors.Value);

            return true;
        }

        public static void AddToBuilding(global::StardewValley.FarmAnimal animal, Building building)
        {
            Api.FarmAnimal.SetHome(animal, building);
            Api.FarmAnimal.SetRandomPositionInHome(animal);
            Api.AnimalHouse.AddAnimal(building, animal);
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
            return Api.FarmAnimal.GetName(animal) != null;
        }

        public static string SetRandomName(global::StardewValley.FarmAnimal animal)
        {
            string name = Api.Dialogue.GetRandomName();

            Api.FarmAnimal.SetName(animal, name);

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
            List<int> prices = Api.Content.LoadData<string, string>(Constants.Content.DataFarmAnimalsContentPath)
                .Where(kvp => types.Contains(kvp.Key))
                .Select(kvp => Int32.Parse(Api.Content.ParseDataValue(kvp.Value)[(int)Constants.FarmAnimal.DataValueIndex.Price]))
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
            int currentProduce = Api.FarmAnimal.GetCurrentProduce(animal);

            // Don't count "Weeds" (index:0) as produce
            return Api.FarmAnimal.IsProduceAnItem(currentProduce) && currentProduce > 0;
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
            return Api.FarmAnimal.HasProduceThatMatchesAll(Api.FarmAnimal.GetDefaultProduce(animal), Api.FarmAnimal.GetDeluxeProduce(animal), targets);
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
            return Api.FarmAnimal.HasProduceThatMatchesAtLeastOne(Api.FarmAnimal.GetDefaultProduce(animal), Api.FarmAnimal.GetDeluxeProduce(animal), targets);
        }

        public static bool HasProduceThatMatchesAtLeastOne(int defaultProduceId, int deluxeProduceId, int[] targets)
        {
            // Must actualy be a product
            return targets.Where(o => Api.FarmAnimal.IsProduceAnItem(o))
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
            int currentProduce = Api.FarmAnimal.GetCurrentProduce(animal);

            return currentProduce == Api.FarmAnimal.GetDeluxeProduce(animal);
        }

        public static bool IsDefaultProduceAnItem(global::StardewValley.FarmAnimal animal)
        {
            return Api.FarmAnimal.IsProduceAnItem(animal.defaultProduceIndex.Value);
        }

        public static bool IsDeluxeProduceAnItem(global::StardewValley.FarmAnimal animal)
        {
            return Api.FarmAnimal.IsProduceAnItem(animal.deluxeProduceIndex.Value);
        }

        public static bool IsProduceAnItem(int produceIndex)
        {
            return produceIndex != Constants.FarmAnimal.NoProduce;
        }

        public static bool IsAProducer(global::StardewValley.FarmAnimal animal)
        {
            // Only animals that require a tool for harvst...
            if (!Api.FarmAnimal.RequiresToolForHarvest(animal))
            {
                return true;
            }

            // ... and the harvest type of "-1" will never produce
            return !Api.FarmAnimal.IsToolUsedForHarvest(animal, Constants.FarmAnimal.NonProducerTool);
        }

        public static void SetCurrentProduce(global::StardewValley.FarmAnimal animal, int produceIndex)
        {
            animal.currentProduce.Value = produceIndex;
        }

        public static void SetProduceQuality(global::StardewValley.FarmAnimal animal, Constants.Object.Quality quality)
        {
            animal.produceQuality.Value = (int)quality;
        }

        public static Constants.Object.Quality RollProduceQuality(global::StardewValley.FarmAnimal animal, global::StardewValley.Farmer farmer, int seed)
        {
            int friendship = Api.FarmAnimal.GetFriendship(animal);
            byte happiness = Api.FarmAnimal.GetHappiness(animal);

            double num2 = friendship / 1000.0 - (1.0 - happiness / 225.0);

            bool isCoopDweller = Api.FarmAnimal.IsCoopDweller(animal);
            bool hasShepherdProfession = Api.Farmer.HasProfession(farmer, Constants.Farmer.Profession.Shepherd);
            bool hasButcherProfession = Api.Farmer.HasProfession(farmer, Constants.Farmer.Profession.Butcher);

            if (!isCoopDweller && hasShepherdProfession || isCoopDweller && hasButcherProfession)
            {
                num2 += 0.33;
            }

            Random random = new Random(seed);

            if (num2 >= 0.95 && random.NextDouble() < num2 / 2.0)
            {
                return Constants.Object.Quality.Best;
            }
            else if (random.NextDouble() < num2 / 2.0)
            {
                return Constants.Object.Quality.High;
            }
            else if (random.NextDouble() < num2)
            {
                return Constants.Object.Quality.Medium;
            }

            return Constants.Object.Quality.Low;
        }

        public static int RollProduce(global::StardewValley.FarmAnimal animal, int seed, global::StardewValley.Farmer farmer = null, double deluxeProduceLuck = default(double))
        {
            double luck = farmer == null
                ? default(double)
                : Api.Farmer.GetDailyLuck(farmer) * deluxeProduceLuck;

            return Api.FarmAnimal.RollDeluxeProduceChance(animal, luck, seed)
                ? Api.FarmAnimal.GetDeluxeProduce(animal)
                : Api.FarmAnimal.GetDefaultProduce(animal);
        }

        public static bool RollDeluxeProduceChance(global::StardewValley.FarmAnimal animal, double luck, int seed)
        {
            if (Api.FarmAnimal.IsBaby(animal))
            {
                return false;
            }

            if (!Api.FarmAnimal.IsProduceAnItem(Api.FarmAnimal.GetDeluxeProduce(animal)))
            {
                return false;
            }

            Random random = new Random(seed);
            byte happiness = Api.FarmAnimal.GetHappiness(animal);

            if (random.NextDouble() >= happiness / 150.0)
            {
                return false;
            }

            double offset = 0.0d;
            int friendship = Api.FarmAnimal.GetFriendship(animal);

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
                return Helpers.Random.NextDouble() < (friendship + offset) / 5000.0 + luck;
            }
            else
            {
                if (friendship < 200)
                {
                    return false;
                }

                return Helpers.Random.NextDouble() < (friendship + offset) / 1200.0;
            }
        }


        /***
         * Sounds and sprites
         ***/

        public static void SetPauseTimer(global::StardewValley.FarmAnimal animal, int timer)
        {
            animal.pauseTimer = Math.Max(Constants.FarmAnimal.MinPauseTimer, timer);
        }

        public static int GetPauseTimer(global::StardewValley.FarmAnimal animal)
        {
            return animal.pauseTimer;
        }

        public static void SetHitGlowTimer(global::StardewValley.FarmAnimal animal, int timer)
        {
            animal.hitGlowTimer = Math.Max(Constants.FarmAnimal.MinHitGlowTimer, timer);
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
            return Api.FarmAnimal.GetSound(animal) != null;
        }

        public static string GetSound(global::StardewValley.FarmAnimal animal)
        {
            return animal.sound.Value;
        }

        public static void ReloadSpriteTexture(global::StardewValley.FarmAnimal animal)
        {
            animal.Sprite.LoadTexture(Api.FarmAnimal.BuildSpriteAssetName(animal));
        }

        public static string BuildSpriteAssetName(global::StardewValley.FarmAnimal animal)
        {
            bool isBaby = Api.FarmAnimal.IsBaby(animal);
            bool isSheared = !isBaby && Api.FarmAnimal.IsSheared(animal);

            if (!Api.FarmAnimal.TryBuildSpriteAssetName(Api.FarmAnimal.GetType(animal), isBaby, isSheared, out string assetName))
            {
                // Covers the BabyDuck scenario by using BabyWhite Chicken
                bool isCoopDweller = Api.FarmAnimal.IsCoopDweller(animal);

                assetName = Api.FarmAnimal.BuildSpriteAssetName(Api.FarmAnimal.GetDefaultType(isCoopDweller), isBaby, isSheared);
            }

            return assetName;
        }

        public static string BuildSpriteAssetName(string type, bool isBaby = false, bool isSheared = false)
        {
            string prefix = "";

            if (isBaby)
            {
                prefix = Constants.FarmAnimal.BabyPrefix;
            }
            else if (isSheared)
            {
                prefix = Constants.FarmAnimal.ReadyForHarvestPrefix;
            }

            return Api.Content.BuildPath(new string[] { Constants.Content.AnimalsContentDirectory, prefix + type });
        }

        public static bool TryBuildSpriteAssetName(string type, bool isBaby, bool isSheared, out string assetName)
        {
            assetName = Api.FarmAnimal.BuildSpriteAssetName(type, isBaby, isSheared);

            return Api.Content.Exists<Texture2D>(assetName);
        }

        public static AnimatedSprite CreateSprite(global::StardewValley.FarmAnimal animal)
        {
            return new AnimatedSprite(Api.FarmAnimal.BuildSpriteAssetName(animal), Constants.Content.StartingFrame, animal.frontBackSourceRect.Width, animal.frontBackSourceRect.Height);
        }

        public static void SetRandomFacingDirection(global::StardewValley.FarmAnimal animal)
        {
            animal.faceDirection(Helpers.Random.Next(4));
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

            Delegate @delegate = Delegate.CreateDelegate(typeof(AnimatedSprite.endOfAnimationBehavior), animal, Helpers.Reflection.GetMethod(animal, "findTruffle"));

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

            bool isSheep = Api.FarmAnimal.IsType(animal, Constants.Animals.Livestock.Sheep);
            bool hasShepherdProfession = Api.Farmer.HasProfession(farmer, Constants.Farmer.Profession.Shepherd);

            daysToLay = (byte)Math.Min(Constants.FarmAnimal.MaxDaysToLay, Math.Max(Constants.FarmAnimal.MinDaysToLay, daysToLay + (isSheep && hasShepherdProfession ? Constants.FarmAnimal.ShepherdProfessionDaysToLayBonus : 0)));

            return daysToLay;
        }

        public static byte GetDaysSinceLastLay(global::StardewValley.FarmAnimal animal)
        {
            return animal.daysSinceLastLay.Value;
        }

        public static void SetDaysSinceLastLay(global::StardewValley.FarmAnimal animal, byte days)
        {
            animal.daysSinceLastLay.Value = Math.Max(Constants.FarmAnimal.MinDaysSinceLastLay, Math.Min(Constants.FarmAnimal.MaxDaysSinceLastLay, days));
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
                myId = Api.Game.GetNewId();
            }

            global::StardewValley.FarmAnimal animal = new global::StardewValley.FarmAnimal(type, myId, ownerId)
            {
                Name = name,
                displayName = name,
                home = home
            };

            Api.FarmAnimal.UpdateFromData(animal, type);

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

                            Api.FarmAnimal.Reload(animal, animal.home);
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
            return global::StardewValley.FarmAnimal.NumPathfindingThisTick < Constants.FarmAnimal.MaxPathFindingPerTick;
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

        public static bool IsType(global::StardewValley.FarmAnimal animal, Constants.Animals.Livestock type)
        {
            return Api.FarmAnimal.IsType(animal, type.ToString());
        }

        public static bool IsType(global::StardewValley.FarmAnimal animal, string type)
        {
            return Api.FarmAnimal.IsType(animal.type.Value, type);
        }

        public static bool IsType(string source, string type)
        {
            return source == type;
        }

        public static string GetDefaultType(string buildingType)
        {
            return Api.FarmAnimal.GetDefaultType(buildingType == Constants.AnimalHouse.Coop);
        }

        public static string GetDefaultType(global::StardewValley.FarmAnimal animal)
        {
            return Api.FarmAnimal.GetDefaultType(Api.FarmAnimal.IsCoopDweller(animal));
        }

        public static string GetDefaultType(bool isCoop)
        {
            return isCoop
                ? Api.FarmAnimal.GetDefaultCoopDwellerType()
                : Api.FarmAnimal.GetDefaultBarnDwellerType();
        }

        public static string GetDefaultCoopDwellerType()
        {
            return Constants.Animals.Livestock.WhiteChicken.ToString();
        }

        public static string GetDefaultBarnDwellerType()
        {
            return Constants.Animals.Livestock.WhiteCow.ToString();
        }

        public static List<string> GetTypesFromProduce(int[] produceIndexes, Dictionary<string, List<string>> restrictions)
        {
            List<string> potentialCategories = new List<string>();
            List<string> potentialTypes = new List<string>();

            // Someone could have the data set up, but not add it to BFAV so that
            // it's hidden from the game so we must use BFAV's restrictions
            Dictionary<string, string> contentData = Api.Content.LoadData<string, string>(Constants.Content.DataFarmAnimalsContentPath);

            foreach (KeyValuePair<string, List<string>> entry in restrictions)
            {
                foreach (string type in entry.Value)
                {
                    string[] values = Api.Content.ParseDataValue(contentData[type]);

                    int defaultProduceId = Int32.Parse(values[(int)Constants.FarmAnimal.DataValueIndex.DefaultProduce]);
                    int deluxeProduceId = Int32.Parse(values[(int)Constants.FarmAnimal.DataValueIndex.DeluxeProduce]);

                    if (Api.FarmAnimal.HasProduceThatMatchesAtLeastOne(defaultProduceId, deluxeProduceId, produceIndexes))
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
            return GetRandomTypeFromProduce(new int[] { Api.FarmAnimal.GetDefaultProduce(animal), Api.FarmAnimal.GetDeluxeProduce(animal) }, restrictions);
        }

        public static string GetRandomTypeFromProduce(int[] produceIndexes, Dictionary<string, List<string>> restrictions)
        {
            List<string> potentialTypes = Api.FarmAnimal.GetTypesFromProduce(produceIndexes, restrictions);
            int index = Helpers.Random.Next(potentialTypes.Count);

            // Check to make sure types came back
            return potentialTypes.Any()
                ? potentialTypes[index]
                : null;
        }

        public static string GetRandomTypeFromProduce(int produceIndex, Dictionary<string, List<string>> restrictions)
        {
            return Api.FarmAnimal.GetRandomTypeFromProduce(new int[] { produceIndex }, restrictions);
        }

        public static bool BlueChickenIsUnlocked(global::StardewValley.Farmer farmer)
        {
            return Api.Farmer.HasSeenEvent(farmer, Constants.Event.BlueChicken);
        }

        public static bool RollBlueChickenChance(global::StardewValley.Farmer farmer)
        {
            if (!Api.FarmAnimal.BlueChickenIsUnlocked(farmer))
            {
                return false;
            }

            return Helpers.Random.NextDouble() >= Constants.FarmAnimal.BlueChickenChance;
        }

        public static List<string> SanitizeAffordableTypes(List<string> types, global::StardewValley.Farmer farmer)
        {
            // Filter out any types that the player cannot afford
            return Api.Content.LoadData<string, string>(Constants.Content.DataFarmAnimalsContentPath)
                .Where(kvp => types.Contains(kvp.Key) && Api.Farmer.CanAfford(farmer, Int32.Parse(Api.Content.ParseDataValue(kvp.Value)[(int)Constants.FarmAnimal.DataValueIndex.Price])))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                .Keys
                .ToList();
        }

        public static List<string> SanitizeBlueChickens(List<string> types, global::StardewValley.Farmer farmer)
        {
            // Sanitize for blue chickens
            string blueChicken = Constants.Animals.Livestock.BlueChicken.ToString();

            // Check for blue chicken chance
            if (types.Contains(blueChicken) && !Api.AnimalShop.IsBlueChickenAvailableForPurchase(farmer))
            {
                types.Remove(blueChicken);
            }

            return types;
        }


        /***
         * Vanilla
         ***/

        public static bool IsVanilla(global::StardewValley.FarmAnimal animal)
        {
            return Api.FarmAnimal.IsVanilla(Api.FarmAnimal.GetType(animal));
        }

        public static bool IsVanilla(string type)
        {
            return Constants.Animals.Livestock.Exists(type);
        }
    }
}
