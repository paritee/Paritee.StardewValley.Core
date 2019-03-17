using StardewValley;
using System;
using System.Linq;

namespace Paritee.StardewValley.Core.Locations
{
    public class AnimalShop
    {
        public const int PurchaseAnimalStockParentSheetIndex = 100;
        public const int PurchaseAnimalStockQuantity = 1;

        public static global::StardewValley.Object FormatAsAnimalAvailableForPurchase(Farm farm, string name, string displayName, string[] types, string[] buildings)
        {
            Locations.AnimalShop.RequiredBuildingIsBuilt(farm, buildings, out string type);

            // Divide the first price by two because of the weird functionality 
            // in Object.salePrice(). Need to use ceiling even though it may 
            // exclude the lowest type if the lowest price is an odd number.
            int price = (int)Math.Ceiling(Characters.FarmAnimal.GetCheapestPrice(types.ToList()) / 2f);

            global::StardewValley.Object obj = new global::StardewValley.Object(Locations.AnimalShop.PurchaseAnimalStockParentSheetIndex, Locations.AnimalShop.PurchaseAnimalStockQuantity, false, price)
            {
                Type = type,
                displayName = displayName
            };

            // MUST do this outside of the block because it gets overridden in 
            // the constructor
            obj.Name = name;

            return obj;
        }

        public static bool RequiredBuildingIsBuilt(Farm farm, string[] buildings, out string type)
        {
            if (buildings.Where(name => Locations.Location.IsBuildingConstructed(farm, name)).Any())
            {
                type = (string)null;

                return true;
            }

            // Grab the display name of the building
            string buildingName = Utilities.Content.GetDataValue<string, string>(
                Utilities.Content.DataBlueprintsContentPath, buildings.First(),
                (int)Objects.Blueprint.DataValueIndex.DisplayName);

            // Grab the requires Coop string so we can replace "Coop" with the building's name
            type = Utilities.Content.LoadString("Strings\\StringsFromCSFiles:Utility.cs.5926").Replace(Locations.AnimalHouse.Coop, buildingName);

            return false;
        }

        public static bool IsBlueChickenAvailableForPurchase(global::StardewValley.Farmer farmer)
        {
            return Characters.FarmAnimal.RollBlueChickenChance(farmer);
        }
    }
}
