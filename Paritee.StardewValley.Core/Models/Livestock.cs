namespace Paritee.StardewValley.Core.Models
{
    public class Livestock : Animal
    {
        public double DeluxeProduceLuck;

        public Livestock(string name, double deluxeProduceLuck) : base(name)
        {
            this.DeluxeProduceLuck = deluxeProduceLuck;
        }
    }
}
