﻿using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Paritee.StardewValley.Core.Api
{
    public class Content
    {
        public static GraphicsDevice GetGraphicsDevice()
        {
            return Game1.game1.GraphicsDevice;
        }

        public static bool Exists<T>(string name)
        {
            try
            {
                Api.Content.Load<T>(name);

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
            return data.First(kvp => kvp.Key.Equals(id));
        }

        public static U GetDataValue<T, U>(string path, T id, int index)
        {
            Dictionary<T, U> data = Api.Content.LoadData<T, U>(Constants.Content.DataBlueprintsContentPath);
            KeyValuePair<T, U> entry = Api.Content.GetDataEntry<T, U>(data, id);

            return (U)System.Convert.ChangeType(Api.Content.ParseDataValue(entry.Value.ToString())[index], typeof(U));
        }

        public static KeyValuePair<T, U> LoadDataEntry<T, U>(string path, T id)
        {
            Dictionary<T, U> data = Api.Content.Load<Dictionary<T, U>>(path);

            return Api.Content.GetDataEntry<T, U>(data, id);
        }

        public static Dictionary<T, U> LoadData<T, U>(string path)
        {
            return Api.Content.Load<Dictionary<T, U>>(path);
        }

        public static string BuildPath(string[] parts)
        {
            return Path.Combine(parts);
        }

        public static string[] ParseDataValue(string str)
        {
            return str.Split(Constants.Content.DataValueDelimiter);
        }
    }
}
