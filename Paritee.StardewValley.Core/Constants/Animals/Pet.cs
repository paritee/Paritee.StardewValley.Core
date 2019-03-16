namespace Paritee.StardewValley.Core.Constants.Animals
{
    public class Pet : Models.Animal
    {
        // Pets
        public static Pet Cat => new Pet("Cat");
        public static Pet Dog => new Pet("Dog");

        private Pet(string name) : base(name) { }
    }
}
