namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {

       

        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
        }

        public override int Size
        {
            get => 3;
            protected set => this.size = value;
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
