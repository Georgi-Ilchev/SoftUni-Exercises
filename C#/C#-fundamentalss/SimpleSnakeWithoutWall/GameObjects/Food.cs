using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnakeWithoutWall.GameObjects
{
    public abstract class Food : Point
    {
        private readonly Random random;
        private readonly char foodSymbol;

        protected Food(char foodSymbol, int points)
        {
            this.FoodPoints = points;
            this.foodSymbol = foodSymbol;

            this.random = new Random();
        }

        public int FoodPoints { get; }

        public void SetRandomFood(Queue<Point> snakeElements, IReadOnlyCollection<Point> obstacles)
        {
            Point food = this.GetRandomPosition(snakeElements);

            while (IsFood(food, obstacles))
            {
                food = this.GetRandomPosition(snakeElements);
            }

            food.Draw(this.foodSymbol);
        }

        private bool IsFood(Point food, IReadOnlyCollection<Point> obstacles)
            => obstacles.Any(x => x.LeftX == food.LeftX && x.TopY == food.TopY);

        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY &&
                   snake.LeftX == this.LeftX;
        }
    }
}
