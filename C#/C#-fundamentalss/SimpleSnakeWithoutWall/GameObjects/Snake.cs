using SimpleSnakeWithoutWall.GameObjects.ChildClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnakeWithoutWall.GameObjects
{
    public class Snake
    {
        private const char SnakeSymbol = '\u25CF';

        private readonly Queue<Point> snakeElements;
        private readonly Food[] foods;
        private readonly Obstacle obstacle;

        private int foodIndex;
        private int nextLeftX;
        private int nextTopY;

        public Snake()
        {
            this.foods = new Food[3];
            this.snakeElements = new Queue<Point>();
            this.foodIndex = RandomFoodNumber;
            this.obstacle = new Obstacle();

            this.GetFoods();
            this.CreateSnake();
        }

        public int LeftX { get; set; }
        public int TopY { get; set; }

        private void CreateSnake()
        {
            //for (int topY = 1; topY <= 6; topY++)
            //{
            //    this.snakeElements.Enqueue(new Point(2, topY));
            //}

            for (int leftX = 1; leftX <= 6; leftX++)
            {
                this.snakeElements.Enqueue(new Point(leftX, 2));
            }

            this.foods[this.foodIndex].SetRandomFood(snakeElements, this.obstacle.Obstacles);
        }

        private void GetFoods()
        {
            this.foods[0] = new FoodHash();
            this.foods[1] = new FoodDollar();
            this.foods[2] = new FoodAsterisk();
        }

        private void GetNextPoints(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 || snake.LeftX == 0 ||
                   snake.LeftX == this.LeftX - 1 || snake.TopY == this.TopY;
        }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();
            this.GetNextPoints(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeElements
                .Any(x => x.LeftX == this.nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (snakeNewHead.LeftX == -1)
            {
                snakeNewHead.LeftX = Console.WindowWidth - 1;
            }
            else if (snakeNewHead.LeftX == Console.WindowWidth)
            {
                snakeNewHead.LeftX = 0;
            }

            if (snakeNewHead.TopY == -1)
            {
                snakeNewHead.TopY = Console.WindowHeight - 1;
            }
            else if (snakeNewHead.TopY == Console.WindowHeight)
            {
                snakeNewHead.TopY = 0;
            }

            if (DateTime.Now.Second % 10 == 0)
            {
                this.obstacle.SetRandomObstacle(snakeElements, direction);
            }

            if (this.obstacle.IsObstacle(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            Console.BackgroundColor = ConsoleColor.Gray;

            snakeNewHead.Draw(SnakeSymbol);
            Console.BackgroundColor = ConsoleColor.White;

            if (this.foods[this.foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();

            snakeTail.Draw(' ');

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = this.foods[this.foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                this.GetNextPoints(direction, currentSnakeHead);
            }

            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomFood(snakeElements, this.obstacle.Obstacles);
        }

        private int RandomFoodNumber => new Random().Next(0, this.foods.Length);
    }
}
