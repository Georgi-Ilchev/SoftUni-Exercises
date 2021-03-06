namespace SimpleSnakeWithoutWall.GameObjects.ChildClasses
{
    class FoodHash : Food
    {
        private const char foodSymbol = '#';
        private const int points = 3;
        public FoodHash()
            : base(foodSymbol, points)
        {
        }
    }
}
