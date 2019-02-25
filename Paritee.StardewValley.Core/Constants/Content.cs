namespace Paritee.StardewValley.Core.Constants
{
    public class Content
    {
        public const string AnimalsContentDirectory = "Animals";
        public const char DataValueDelimiter = '/';
        public const string None = "none";
        public const int StartingFrame = 0;

        public static string DataFarmAnimalsContentPath => Api.Content.BuildPath(new string[] { "Data", "FarmAnimals" });
        public static string DataBlueprintsContentPath => Api.Content.BuildPath(new string[] { "Data", "Blueprints" });
    }
}
