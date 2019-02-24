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

            string[] values = Api.Content.ParseDataValue(contentDataEntry.Value);

            // Reset the instance's values based on the new type
            animal.type.Value = contentDataEntry.Key;
            animal.daysToLay.Value = Convert.ToByte(values[(int)Constants.FarmAnimal.DataValueIndex.DaysToLay]);
            animal.ageWhenMature.Value = Convert.ToByte(values[(int)Constants.FarmAnimal.DataValueIndex.AgeWhenMature]);
            animal.defaultProduceIndex.Value = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.DefaultProduce]);
            animal.deluxeProduceIndex.Value = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.DeluxeProduce]);
            animal.sound.Value = Api.FarmAnimal.IsDataValueNull(values[(int)Constants.FarmAnimal.DataValueIndex.Sound]) ? null : values[(int)Constants.FarmAnimal.DataValueIndex.Sound];

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
            animal.toolUsedForHarvest.Value = Api.FarmAnimal.IsDataValueNull(values[(int)Constants.FarmAnimal.DataValueIndex.ToolUsedForHarvest]) ? "" : values[(int)Constants.FarmAnimal.DataValueIndex.ToolUsedForHarvest];
            animal.meatIndex.Value = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.MeatIndex]);
            animal.price.Value = Convert.ToInt32(values[(int)Constants.FarmAnimal.DataValueIndex.Price]);
        }

        private static bool IsDataValueNull(string value)
        {
            return value.Equals(null) || value.Equals("null") || value.Equals(default(string)) || value.Equals("") || value.Equals(Constants.Content.None);
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
            animal.friendshipTowardFarmer.Value = newAmount;
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
            animal.fullness.Value = fullness;
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
            animal.happiness.Value = happiness;
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
            return animal.harvestType.Value.Equals(harvestType);
        }

        public static bool HasHarvestType(int harvestType, int target)
        {
            return harvestType.Equals(target);
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
                && (Api.FarmAnimal.IsDataValueNull(harvestTool));
        }

        public static bool CanBeNamed(global::StardewValley.FarmAnimal animal)
        {
            // "It" harvest type doesn't allow you to name the animal. This is 
            // mostly unused and is only seen on the Hog
            return Api.FarmAnimal.HasHarvestType(animal, Constants.FarmAnimal.ItHarvestType);
        }

        public static bool RequiresToolForHarvest(global::StardewValley.FarmAnimal animal)
        {
            // "It" harvest type doesn't allow you to name the animal. This is 
            // mostly unused and is only seen on the Hog
            return Api.FarmAnimal.HasHarvestType(animal, Constants.FarmAnimal.RequiresToolHarvestType);
        }

        public static bool RequiresToolForHarvest(int harvestType)
        {
            // "It" harvest type doesn't allow you to name the animal. This is 
            // mostly unused and is only seen on the Hog
            return Api.FarmAnimal.HasHarvestType(harvestType, Constants.FarmAnimal.RequiresToolHarvestType);
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
            return tool.Equals(target);
        }


        /***
         * Home
         ***/

        public static bool HasHome(global::StardewValley.FarmAnimal animal)
        {
            return animal.home != null;
        }

        public static void SetFindHomeDoorPathController(global::StardewValley.FarmAnimal animal, GameLocation location)
        {
            if (Api.FarmAnimal.HasHome(animal))
            {
                return;
            }

            animal.controller = new PathFindController(animal, location, new PathFindController.isAtEnd(PathFindController.isAtEndPoint), 0, false, null, 200, new Point(animal.home.tileX.Value + animal.home.animalDoor.X, animal.home.tileY.Value + animal.home.animalDoor.Y));
        }

        public static bool IsCoopDweller(global::StardewValley.FarmAnimal animal)
        {
            string buildingType = Api.FarmAnimal.HasHome(animal)
                ? animal.home.buildingType.Value
                : animal.buildingTypeILiveIn.Value;

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
         * Produce
         ***/

        public static int GetCurrentProduce(global::StardewValley.FarmAnimal animal)
        {
            return animal.currentProduce.Value;
        }

        public static int GetDefaultProduce(global::StardewValley.FarmAnimal animal)
        {
            return animal.defaultProduceIndex.Value;
        }

        public static int GetDeluxeProduce(global::StardewValley.FarmAnimal animal)
        {
            return animal.deluxeProduceIndex.Value;
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
            return produceIndexes.Intersect(targets)
                .Count().Equals(produceIndexes.Length);
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
            return !produceIndex.Equals(Constants.FarmAnimal.NoProduce);
        }

        public static bool IsAProducer(global::StardewValley.FarmAnimal animal)
        {
            // Only animals that require a tool for harvst...
            if (!Api.FarmAnimal.RequiresToolForHarvest(animal))
            {
                return true;
            }

            // ... and the harvest type is "-1" will never produce
            return Api.FarmAnimal.IsToolUsedForHarvest(animal, Constants.FarmAnimal.NonProducerTool);
        }

        public static void SetCurrentProduce(global::StardewValley.FarmAnimal animal, int produceIndex)
        {
            animal.currentProduce.Value = produceIndex;
        }

        public static int RollProduce(global::StardewValley.FarmAnimal animal, global::StardewValley.Farmer farmer)
        {
            return Api.FarmAnimal.RollDeluxeProduceChance(animal, Api.Farmer.GetDailyLuck(farmer))
                ? Api.FarmAnimal.GetDeluxeProduce(animal)
                : Api.FarmAnimal.GetDefaultProduce(animal);
        }

        public static bool RollDeluxeProduceChance(global::StardewValley.FarmAnimal animal, double luck)
        {
            if (Api.FarmAnimal.IsBaby(animal))
            {
                return false;
            }

            if (Api.FarmAnimal.IsProduceAnItem(animal.deluxeProduceIndex.Value))
            {
                return false;
            }

            double offset = 0.0d;
            byte happiness = Api.FarmAnimal.GetHappiness(animal);
            int friendship = Api.FarmAnimal.GetFriendship(animal);

            if (happiness > 200)
            {
                offset = happiness * 1.5;
            }
            else if (happiness <= 100)
            {
                offset = happiness - 100;
            }

            if (Api.FarmAnimal.IsType(animal, Constants.VanillaFarmAnimalType.Duck))
            {
                return Helpers.Random.NextDouble() < (friendship + offset) / 5000.0 + luck * 0.01;
            }

            if (Api.FarmAnimal.IsType(animal, Constants.VanillaFarmAnimalType.Rabbit))
            {
                return Helpers.Random.NextDouble() < (friendship + offset) / 5000.0 + luck * 0.02;
            }

            if (friendship < 200)
            {
                return false;
            }

            return Helpers.Random.NextDouble() < (friendship + offset) / 1200.0;
        }


        /***
         * Sounds and sprites
         ***/

        public static bool MakesSound(global::StardewValley.FarmAnimal animal)
        {
            return Api.FarmAnimal.GetSound(animal) != null;
        }

        public static string GetSound(global::StardewValley.FarmAnimal animal)
        {
            return animal.sound.Value;
        }

        public static string BuildSpriteAssetName(global::StardewValley.FarmAnimal animal)
        {
            string prefix = "";

            if (Api.FarmAnimal.IsBaby(animal))
            {
                prefix = Constants.FarmAnimal.BabyPrefix;
            }
            else if (Api.FarmAnimal.IsSheared(animal))
            {
                prefix = Constants.FarmAnimal.ShearedPrefix;
            }

            string assetName = prefix + animal.type.Value;

            // Check if the asset exists (ex. vanilla fails on BabyDuck)
            if (!Api.Content.Exists<Texture2D>(Api.Content.BuildPath(new string[] { Constants.Content.AnimalsContentDirectory, assetName })))
            {
                // Covers the BabyDuck scenario by using BabyWhite Chicken
                assetName = Api.FarmAnimal.GetDefaultType(animal);
            }

            return Api.Content.BuildPath(new string[] { Constants.Content.AnimalsContentDirectory, assetName });
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

            global::StardewValley.Farmer player = Api.Game.GetPlayer();
            Delegate @delegate = Delegate.CreateDelegate(typeof(AnimatedSprite.endOfAnimationBehavior), player, Helpers.Reflection.GetMethod(animal, "findTruffle"));

            List<FarmerSprite.AnimationFrame> animation = new List<FarmerSprite.AnimationFrame>()
            {
                new FarmerSprite.AnimationFrame(frame1, 250),
                new FarmerSprite.AnimationFrame(frame2, 250),
                new FarmerSprite.AnimationFrame(frame1, 250),
                new FarmerSprite.AnimationFrame(frame2, 250),
                new FarmerSprite.AnimationFrame(frame1, 250),
                new FarmerSprite.AnimationFrame(frame2, 250, false, false, (AnimatedSprite.endOfAnimationBehavior)@delegate, false) // TODO: Validate this insanity.
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
        
        /***
         * States
         ***/

        public static global::StardewValley.FarmAnimal CreateFarmAnimal(string type, long ownerId, string name = null, Building home = null, long myId = default(long))
        {
            myId = myId.Equals(default(long)) ? Api.Game.GetNewId() : myId;

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
                        global::StardewValley.FarmAnimal animal = animalHouse.animals[id];

                        Api.FarmAnimal.Reload(animal, animal.home);
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

        public static bool IsType(global::StardewValley.FarmAnimal animal, Constants.VanillaFarmAnimalType type)
        {
            return Api.FarmAnimal.IsType(animal, type.ToString());
        }

        public static bool IsType(global::StardewValley.FarmAnimal animal, string type)
        {
            return Api.FarmAnimal.IsType(animal.type.Value, type);
        }

        public static bool IsType(string source, string type)
        {
            return source.Equals(type);
        }

        public static string GetDefaultType(string buildingType)
        {
            return Api.FarmAnimal.GetDefaultType(buildingType.Equals(Constants.AnimalHouse.Coop));
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
            return Constants.VanillaFarmAnimalType.WhiteChicken.ToString();
        }

        public static string GetDefaultBarnDwellerType()
        {
            return Constants.VanillaFarmAnimalType.WhiteCow.ToString();
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

        public static List<string> SanitizeBlueChickens(List<string> types, global::StardewValley.Farmer farmer)
        {
            // Sanitize for blue chickens
            string blueChicken = Constants.VanillaFarmAnimalType.BlueChicken.ToString();

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
            return Constants.VanillaFarmAnimalType.Exists(type);
        }
    }
}
