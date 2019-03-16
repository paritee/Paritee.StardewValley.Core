namespace Paritee.StardewValley.Core.Constants.Animals
{
    public class Stable : Models.Animal
    {
        public static Stable Horse => new Stable("Horse");

        private Stable(string name) : base(name) { }
    }
}
