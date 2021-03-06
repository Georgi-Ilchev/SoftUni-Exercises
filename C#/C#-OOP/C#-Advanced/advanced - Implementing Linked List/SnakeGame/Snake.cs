﻿using SnakeGame.Helpers;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SnakeGame
{
    public class Snake : IDrawable
    {
        public Snake(Position headPosition, Action spawnFood)
        {
            this.SpawnFood = spawnFood;
            SnakeBody = new LinkedList();
            SnakeBody.AddHead(new Node(headPosition));
            Foods = new List<Food>();
            for (int i = 1; i <= 2; i++)
            {
                SnakeBody.AddLast(new Node(new Position(headPosition.X + i, headPosition.Y)));
            }
        }
        public Action SpawnFood { get; set; }

        public LinkedList SnakeBody { get; set; }

        public List<Food> Foods { get; set; }

        public void Draw()
        {
            SnakeBody.ForEach(n =>
            {
                var text = "*";
                //Console.SetCursorPosition(n.Value.X, n.Value.Y);
                if (n == SnakeBody.Head)
                {
                    text = "@";
                }
                ConsoleHelper.Write(n.Value, text);
            });
        }

        public bool CheckSelfCanibalism()
        {
            HashSet<Position> set = new HashSet<Position>();
            bool isCanibal = false;
            SnakeBody.ForEach(n =>
            {
                if (set.Contains(n.Value)) isCanibal = true;
                set.Add(n.Value);
            });
            return isCanibal;
        }

        public void Move(Position position)
        {
            if (position.X == 0 && position.Y == 0)
            {
                return;
            }

            ConsoleHelper.Clear(SnakeBody.Tail.Value);

            SnakeBody.ReversedForEach(n =>
            {
                if (n.Previous != null)
                {
                    n.Value.X = n.Previous.Value.X;
                    n.Value.Y = n.Previous.Value.Y;
                }
            });

            SnakeBody.Head.Value.ChangePosition(position);


            for (int i = 0; i < Foods.Count; i++)
            {
                if (Foods[i].Position == SnakeBody.Head.Value)
                {
                    Foods[i].EatFood();
                    Grow(position);
                    Score.Points += 10;
                    SpawnFood();
                }
            }
        }
        
        //public void Score(Score points)
        //{
        //    for (int i = 0; i < Foods.Count; i++)
        //    {
        //        if (Foods[i].Position == SnakeBody.Head.Value)
        //        {
        //            points.Points += 10;
        //        }
        //    }
        //    Console.WriteLine(points.Points);
        //}

        private void Grow(Position position)
        {
            var reverse = new Position(position.X * -1, position.Y * -1);
            var oldPosition = SnakeBody.Tail.Value;
            var newHead = new Node(new Position(oldPosition.X, oldPosition.Y));

            newHead.Value.ChangePosition(reverse);
            BoundariesChecker.CheckBoundaries(newHead.Value, reverse);
            SnakeBody.AddLast(newHead);
        }
    }
}
