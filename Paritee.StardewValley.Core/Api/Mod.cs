using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace Paritee.StardewValley.Core.Api
{
    public class Mod
    {
        public static string GetPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static string SmapiSaveDataKey(string uniqueModId, string key)
        {
            return $"smapi/mod-data/{uniqueModId}/{key}";
        }

        public static T ReadSaveData<T>(string uniqueModId, string key) where T : new()
        {
            T data = Api.Game.ReadSaveData<T>(Api.Mod.SmapiSaveDataKey(uniqueModId, key));

            return data == null ? new T() : data;
        }

        public static void WriteSaveData<T>(string uniqueModId, string key, T data)
        {
            Api.Game.WriteSaveData<T>(Api.Mod.SmapiSaveDataKey(uniqueModId, key), data);
        }

        public static T ReadConfig<T>(string modPath, string fileName)
        {
            string path = Path.Combine(modPath, fileName);
            string json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(json);
        }
        
        public static Texture2D LoadTexture(string filePath)
        {
            Texture2D texture;

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                texture = Texture2D.FromStream(Api.Content.GetGraphicsDevice(), fileStream);
            }

            return texture;
        }
    }
}
