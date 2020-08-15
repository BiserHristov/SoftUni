namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {

        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
        }

        public override int Size
        {
            get => 5;
            protected set => this.size = value;
        }
        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
