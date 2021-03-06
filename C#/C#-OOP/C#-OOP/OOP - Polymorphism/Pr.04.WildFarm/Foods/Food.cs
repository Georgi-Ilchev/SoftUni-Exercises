namespace Pr._04.WildFarm.Foods
{
    public abstract class Food
    {
        private int quantity;
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity
        {
            get => this.quantity;
            set => this.quantity = value;
        }
    }
}
