using StardewValley;
using System.Linq;

namespace Paritee.StardewValley.Core.Api
{
    public class AnimalShop
    {
        public static global::StardewValley.Object FormatAsAnimalAvailableForPurchase(Farm farm, string name, string displayName, int price, string[] buildings)
        {
            Api.AnimalShop.RequiredBuildingIsBuilt(farm, buildings, out string type);

            // Divide price by two because of the weird functionality in Object.salePrice()
            global::StardewValley.Object obj = new global::StardewValley.Object(Constants.AnimalShop.PurchaseAnimalStockParentSheetIndex, Constants.AnimalShop.PurchaseAnimalStockQuantity, false, price / 2)
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
            if (buildings.Where(name => Api.Location.IsBuildingConstructed(farm, name)).Any())
            {
                type = (string)null;

                return true;
            }

            // Grab the display name of the building
            string buildingName = Api.Content.GetDataValue<string, string>(
                Constants.Content.DataBlueprintsContentPath, buildings.First(),
                (int)Constants.Blueprint.DataValueIndex.DisplayName);

            // Grab the requires Coop string so we can replace "Coop" with the building's name
            type = Api.Content.LoadString("Strings\\StringsFromCSFiles:Utility.cs.5926").Replace(Constants.AnimalHouse.Coop, buildingName);

            return false;
        }

        public static bool IsBlueChickenAvailableForPurchase(global::StardewValley.Farmer farmer)
        {
            return Api.FarmAnimal.RollBlueChickenChance(farmer);
        }
    }
}
