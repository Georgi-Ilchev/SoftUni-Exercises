using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace problem4___Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] bombEffects = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            //int[] bombCasings = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> queueEffects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Stack<int> stackCasings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            int ezio = 0;
            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeDecoyBombs = 0;

            int operations = Math.Min(queueEffects.Count(), stackCasings.Count());
            for (int i = 0; i < operations; i++)
            {
                int currentsEffect = queueEffects.Peek();
                int currentsCase = stackCasings.Peek();

                if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoyBombs >= 3)
                {
                    ezio++;
                    break;
                }

                if (currentsEffect + currentsCase == 40)
                {
                    daturaBombs++;
                    queueEffects.Dequeue();
                    stackCasings.Pop();
                }
                else if (currentsEffect + currentsCase == 60)
                {
                    cherryBombs++;
                    queueEffects.Dequeue();
                    stackCasings.Pop();
                }
                else if (currentsEffect + currentsCase == 120)
                {
                    smokeDecoyBombs++;
                    queueEffects.Dequeue();
                    stackCasings.Pop();
                }
                else
                {
                    while (true)
                    {
                        currentsCase -= 5;
                        if (currentsEffect + currentsCase == 40)
                        {
                            daturaBombs++;
                            queueEffects.Dequeue();
                            stackCasings.Pop();
                            break;
                        }
                        else if (currentsEffect + currentsCase == 60)
                        {
                            cherryBombs++;
                            queueEffects.Dequeue();
                            stackCasings.Pop();
                            break;
                        }
                        else if (currentsEffect + currentsCase == 120)
                        {
                            smokeDecoyBombs++;
                            queueEffects.Dequeue();
                            stackCasings.Pop();
                            break;
                        }
                    }
                }
            }

            //1
            if (ezio != 0)
            {
                Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine($"You don't have enough materials to fill the bomb pouch.");
            }

            //2
            if (queueEffects.Count <= 0)
            {
                Console.WriteLine($"Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: " + string.Join(", ", queueEffects));
            }

            //3
            if (stackCasings.Count <= 0)
            {
                Console.WriteLine($"Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: " + string.Join(", ", stackCasings));
            }

            //4
            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombs}");

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //Queue<int> queueEffects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            //Stack<int> stackCasings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            //int ezio = 0;
            //int daturaBombs = 0;
            //int cherryBombs = 0;
            //int smokeDecoyBombs = 0;
            //int decrease = 0;

            //int operations = Math.Min(queueEffects.Count(), stackCasings.Count());
            //while (queueEffects.Count > 0 && stackCasings.Count > 0)
            //{
            //    int currentsEffect = queueEffects.Peek();
            //    int currentsCase = stackCasings.Peek() - decrease;
            //    int sum = currentsEffect + currentsCase;
            //    bool bombCreated = false;

            //    if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoyBombs >= 3)
            //    {
            //        ezio++;
            //        break;
            //    }

            //    if (sum == 40)
            //    {
            //        daturaBombs++;
            //        bombCreated = true;
            //    }
            //    else if (sum == 60)
            //    {
            //        cherryBombs++;
            //        bombCreated = true;
            //    }
            //    else if (sum == 120)
            //    {
            //        smokeDecoyBombs++;
            //        bombCreated = true;
            //    }

            //    if (bombCreated)
            //    {
            //        queueEffects.Dequeue();
            //        stackCasings.Pop();
            //        decrease = 0;
            //    }
            //    else if (currentsCase <= 0)
            //    {
            //        stackCasings.Pop();
            //        decrease = 0;
            //    }
            //    else
            //    {
            //        decrease += 5;
            //    }
            //}

            ////1
            //if (ezio != 0)
            //{
            //    Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
            //}
            //else
            //{
            //    Console.WriteLine($"You don't have enough materials to fill the bomb pouch.");
            //}

            ////2
            //if (queueEffects.Count <= 0)
            //{
            //    Console.WriteLine($"Bomb Effects: empty");
            //}
            //else
            //{
            //    Console.WriteLine($"Bomb Effects: " + string.Join(", ", queueEffects));
            //}

            ////3
            //if (stackCasings.Count <= 0)
            //{
            //    Console.WriteLine($"Bomb Casings: empty");
            //}
            //else
            //{
            //    Console.WriteLine($"Bomb Casings: " + string.Join(", ", stackCasings));
            //}

            ////4
            //Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            //Console.WriteLine($"Datura Bombs: {daturaBombs}");
            //Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombs}");
        }
    }
}
