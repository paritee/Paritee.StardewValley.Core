using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley.Menus;
using System;
using System.Collections.Generic;

namespace Paritee.StardewValley.Core.Api
{
    public class PurchaseAnimalsMenu : Api.Menu
    {
        public static bool IsFrozen(global::StardewValley.Menus.PurchaseAnimalsMenu menu)
        {
            return Helpers.Reflection.GetFieldValue<bool>(menu, "freeze");
        }

        public static bool IsNamingAnimal(global::StardewValley.Menus.PurchaseAnimalsMenu menu)
        {
            return Helpers.Reflection.GetFieldValue<bool>(menu, "namingAnimal");
        }

        public static void SetNamingAnimal(global::StardewValley.Menus.PurchaseAnimalsMenu menu, bool namingAnimal)
        {
            Helpers.Reflection.GetField(menu, "namingAnimal").SetValue(menu, namingAnimal);
        }

        public static bool IsOnFarm(global::StardewValley.Menus.PurchaseAnimalsMenu menu)
        {
            return Helpers.Reflection.GetFieldValue<bool>(menu, "onFarm");
        }

        public static void SetOnFarm(global::StardewValley.Menus.PurchaseAnimalsMenu menu, bool onFarm)
        {
            Helpers.Reflection.GetField(menu, "onFarm").SetValue(menu, onFarm);
        }

        public static global::StardewValley.FarmAnimal GetAnimalBeingPurchased(global::StardewValley.Menus.PurchaseAnimalsMenu menu)
        {
            return Helpers.Reflection.GetFieldValue<global::StardewValley.FarmAnimal>(menu, "animalBeingPurchased");
        }

        public static void SetAnimalBeingPurchased(global::StardewValley.Menus.PurchaseAnimalsMenu menu, global::StardewValley.FarmAnimal animal)
        {
            Helpers.Reflection.GetField(menu, "animalBeingPurchased").SetValue(menu, animal);
        }

        public static void SetUpAnimalsToPurchase(global::StardewValley.Menus.PurchaseAnimalsMenu menu, List<global::StardewValley.Object> stock, Dictionary<string, Texture2D> icons, out int iconHeight)
        {
            List<ClickableTextureComponent> components = Api.PurchaseAnimalsMenu.GetAnimalsToPurchaseComponents(menu, stock, icons, out iconHeight);

            Api.PurchaseAnimalsMenu.SetAnimalsToPurchase(menu, components);
        }

        public static int GetPriceOfAnimal(global::StardewValley.Menus.PurchaseAnimalsMenu menu)
        {
            return Helpers.Reflection.GetFieldValue<int>(menu, "priceOfAnimal");
        }

        public static void SetPriceOfAnimal(global::StardewValley.Menus.PurchaseAnimalsMenu menu, int price)
        {
            Helpers.Reflection.GetField(menu, "priceOfAnimal").SetValue(menu, price);
        }

        public static global::StardewValley.Buildings.Building GetNewAnimalHome(global::StardewValley.Menus.PurchaseAnimalsMenu menu)
        {
            return Helpers.Reflection.GetFieldValue<global::StardewValley.Buildings.Building>(menu, "newAnimalHome");
        }

        public static void SetNewAnimalHome(global::StardewValley.Menus.PurchaseAnimalsMenu menu, global::StardewValley.Buildings.Building home)
        {
            Helpers.Reflection.GetField(menu, "newAnimalHome").SetValue(menu, home);
        }

        public static ClickableTextureComponent GetOkButton(global::StardewValley.Menus.PurchaseAnimalsMenu menu)
        {
            return menu.okButton;
        }

        public static bool HasOkButton(global::StardewValley.Menus.PurchaseAnimalsMenu menu)
        {
            return Api.PurchaseAnimalsMenu.GetOkButton(menu) != null;
        }

        public static bool HasTappedOkButton(global::StardewValley.Menus.PurchaseAnimalsMenu menu, int x, int y)
        {
            return Api.PurchaseAnimalsMenu.HasOkButton(menu) && Api.PurchaseAnimalsMenu.TappedOnButton(Api.PurchaseAnimalsMenu.GetOkButton(menu), x, y);
        }

        public static bool IsReadyToClose(global::StardewValley.Menus.PurchaseAnimalsMenu menu)
        {
            return menu.readyToClose();
        }

        public static List<ClickableTextureComponent> GetAnimalsToPurchase(global::StardewValley.Menus.PurchaseAnimalsMenu menu)
        {
            return menu.animalsToPurchase;
        }

        public static void SetAnimalsToPurchase(global::StardewValley.Menus.PurchaseAnimalsMenu menu, List<ClickableTextureComponent> animalsToPurchase)
        {
            menu.animalsToPurchase = animalsToPurchase;
        }

        public static void SetHeight(global::StardewValley.Menus.PurchaseAnimalsMenu menu, int height)
        {
            menu.height = height;
        }

        public static List<ClickableTextureComponent> GetAnimalsToPurchaseComponents(global::StardewValley.Menus.PurchaseAnimalsMenu menu, List<global::StardewValley.Object> stock, Dictionary<string, Texture2D> icons, out int iconHeight)
        {
            iconHeight = 0;

            List<ClickableTextureComponent> animalsToPurchase = new List<ClickableTextureComponent>();

            for (int index = 0; index < stock.Count; ++index)
            {
                global::StardewValley.Object obj = stock[index];

                string name = obj.salePrice().ToString();
                string label = (string)null;
                string hoverText = obj.Name;

                Rectangle bounds = new Rectangle(menu.xPositionOnScreen + IClickableMenu.borderWidth + index % 3 * 64 * 2, menu.yPositionOnScreen + IClickableMenu.spaceToClearTopBorder + IClickableMenu.borderWidth / 2 + index / 3 * 85, 128, 64);
                Texture2D texture = icons[obj.Name];
                Rectangle sourceRect = new Rectangle(0, 0, texture.Width, texture.Height);

                float scale = 4f;
                bool drawShadow = obj.Type == null;

                ClickableTextureComponent textureComponent = new ClickableTextureComponent(name, bounds, label, hoverText, texture, sourceRect, scale, drawShadow)
                {
                    item = obj,
                    myID = index,
                    rightNeighborID = index % 3 == 2 ? -1 : index + 1,
                    leftNeighborID = index % 3 == 0 ? -1 : index - 1,
                    downNeighborID = index + 3,
                    upNeighborID = index - 3
                };

                animalsToPurchase.Add(textureComponent);

                // We need the icon height for the menu resize
                iconHeight = texture.Height > iconHeight ? texture.Height : iconHeight;
            }

            return animalsToPurchase;
        }

        public static int GetRows(global::StardewValley.Menus.PurchaseAnimalsMenu menu)
        {
            return (int)Math.Ceiling((float)Api.PurchaseAnimalsMenu.GetAnimalsToPurchase(menu).Count / 3); // Always at least one row
        }

        public static void AdjustHeightBasedOnIcons(global::StardewValley.Menus.PurchaseAnimalsMenu menu, int iconHeight)
        {
            Api.PurchaseAnimalsMenu.SetHeight(menu, (int)(iconHeight * 2f) + IClickableMenu.spaceToClearTopBorder + IClickableMenu.borderWidth / 2 + Api.PurchaseAnimalsMenu.GetRows(menu) * 85);
        }
    }
}
