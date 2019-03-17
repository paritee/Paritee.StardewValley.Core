using StardewValley.Menus;

namespace Paritee.StardewValley.Core.Menus
{
    public class Menu
    {
        public static bool TappedOnButton(ClickableTextureComponent button, int x, int y)
        {
            return button.containsPoint(x, y);
        }
    }
}
