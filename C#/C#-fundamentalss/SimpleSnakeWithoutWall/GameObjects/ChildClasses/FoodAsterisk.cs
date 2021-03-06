namespace SimpleSnakeWithoutWall.GameObjects.ChildClasses
{
    public class FoodAsterisk : Food
    {
        private const char foodSymbol = '*';
        private const int points = 1;
        public FoodAsterisk() 
            : base(foodSymbol, points)
        {
        }
    }
}
