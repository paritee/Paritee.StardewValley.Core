namespace Paritee.StardewValley.Core.Utilities
{
    public class Dialogue
    {
        public static string GetRandomName()
        {
            return global::StardewValley.Dialogue.randomName();
        }

        public static string ConvertToDwarvish(string str)
        {
            return global::StardewValley.Dialogue.convertToDwarvish(str);
        }
    }
}
