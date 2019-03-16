namespace Paritee.StardewValley.Core.Constants.Animals
{
    public class Mount : Models.Animal
    {
        public static Mount Horse => new Mount("Horse");

        private Mount(string name) : base(name) { }
    }
}
