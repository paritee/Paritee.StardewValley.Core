using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.BellsAndWhistles;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Paritee.StardewValley.Core.Utilities
{
    public class Content
    {
        public const string AnimalsContentDirectory = "Animals";
        public const char DataValueDelimiter = '/';
        public const string None = "none";
        public const int StartingFrame = 0;

        public static string DataFarmAnimalsContentPath => Utilities.Content.BuildPath(new string[] { "Data", "FarmAnimals" });
        public static string DataBlueprintsContentPath => Utilities.Content.BuildPath(new string[] { "Data", "Blueprints" });
        public static string DataObjectInformationContentPath => Utilities.Content.BuildPath(new string[] { "Data", "ObjectInformation" });

        public static GraphicsDevice GetGraphicsDevice()
        {
            return Game1.game1.GraphicsDevice;
        }

        public static bool Exists<T>(string name)
        {
            try
            {
                Utilities.Content.Load<T>(name);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T Load<T>(string path)
        {
            return Game1.content.Load<T>(path);
        }

        public static string LoadString(string path)
        {
            return Game1.content.LoadString(path);
        }

        public static string LoadString(string path, object sub1)
        {
            return Game1.content.LoadString(path, sub1);
        }

        public static string LoadString(string path, object sub1, object sub2)
        {
            return Game1.content.LoadString(path, sub1, sub2);
        }

        public static string LoadString(string path, object sub1, object sub2, object sub3)
        {
            return Game1.content.LoadString(path, sub1, sub2, sub3);
        }

        public static string LoadString(string path, params string[] substitutions)
        {
            return Game1.content.LoadString(path, substitutions);
        }

        public static KeyValuePair<T, U> GetDataEntry<T, U>(Dictionary<T, U> data, T id)
        {
            return data.FirstOrDefault(kvp => kvp.Key.Equals(id));
        }

        public static U GetDataValue<T, U>(string path, T id, int index)
        {
            Dictionary<T, U> data = Utilities.Content.LoadData<T, U>(path);
            KeyValuePair<T, U> entry = Utilities.Content.GetDataEntry<T, U>(data, id);

            if (entry.Key == null || entry.Key.Equals(default(T)))
            {
                return default(U);
            }

            return (U)System.Convert.ChangeType(Utilities.Content.ParseDataValue(entry.Value.ToString())[index], typeof(U));
        }

        public static KeyValuePair<T, U> LoadDataEntry<T, U>(string path, T id)
        {
            Dictionary<T, U> data = Utilities.Content.Load<Dictionary<T, U>>(path);

            return Utilities.Content.GetDataEntry<T, U>(data, id);
        }

        public static Dictionary<T, U> LoadData<T, U>(string path)
        {
            return Utilities.Content.Load<Dictionary<T, U>>(path);
        }

        public static string BuildPath(string[] parts)
        {
            return Path.Combine(parts);
        }

        public static string[] ParseDataValue(string str)
        {
            return str.Split(Utilities.Content.DataValueDelimiter);
        }

        public static int GetWidthOfString(string str, int widthContraint = 9999999)
        {
            return SpriteText.getWidthOfString(str);
        }

        public static string FormatMoneyString(int amount)
        {
            return "$" + Utilities.Content.LoadString("Strings\\StringsFromCSFiles:LoadGameMenu.cs.11020", amount);
        }
    }
}
