namespace Pr._04.WildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        protected Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }
        public double WingSize
        {
            get => this.wingSize;
            set => this.wingSize = value;
        }
    }
}
