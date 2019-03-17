using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace Paritee.StardewValley.Core.Utilities
{
    public class Mod
    {
        public static string Path => Utilities.Mod.GetPath();

        public static string GetPath()
        {
            return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static string SmapiSaveDataKey(string uniqueModId, string key)
        {
            return $"smapi/mod-data/{(uniqueModId ?? "").ToLower()}/{key}";
        }

        public static T ReadSaveData<T>(string uniqueModId, string key) where T : new()
        {
            T data = Utilities.Game.ReadSaveData<T>(Utilities.Mod.SmapiSaveDataKey(uniqueModId, key));

            return data == null ? new T() : data;
        }

        public static void WriteSaveData<T>(string uniqueModId, string key, T data)
        {
            Utilities.Game.WriteSaveData<T>(Utilities.Mod.SmapiSaveDataKey(uniqueModId, key), data);
        }

        public static T ReadConfig<T>(string modPath, string fileName) where T: new()
        {
            string path = System.IO.Path.Combine(modPath, fileName);

            if (!File.Exists(path))
            {
                return new T();
            }

            string json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(json);
        }
        
        public static Texture2D LoadTexture(string filePath)
        {
            Texture2D texture;

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                texture = Texture2D.FromStream(Utilities.Content.GetGraphicsDevice(), fileStream);
            }

            return texture;
        }
    }
}
