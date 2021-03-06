namespace SimpleSnakeWithoutWall.GameObjects.ChildClasses
{
    class FoodDollar : Food
    {
        private const char foodSymbol = '$';
        private const int points = 2;
        public FoodDollar()
            : base(foodSymbol, points)
        {
        }
    }
}
