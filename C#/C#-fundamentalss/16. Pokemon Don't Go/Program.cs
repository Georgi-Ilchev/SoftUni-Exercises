using System;
using System.Collections.Generic;
using System.Linq;

namespace _16._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sumOfRemovedElements = 0;

            while (pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    int removedCase1 = pokemons[0];
                    sumOfRemovedElements += removedCase1;
                    pokemons[0] = pokemons[pokemons.Count - 1];
                    RemovedIndexCase1(pokemons,removedCase1);
                    
                }
                else if (index >=pokemons.Count)
                {
                    int removedCase2 = pokemons[pokemons.Count - 1];
                    sumOfRemovedElements += removedCase2;
                    pokemons[pokemons.Count - 1] = pokemons[0];
                    RemovedIndexCase2(pokemons, removedCase2);
                }
                else
                {
                    int removedCase3 = pokemons[index];
                    sumOfRemovedElements += removedCase3;
                    pokemons.RemoveAt(index);
                    RemovedIndexCase3(pokemons, removedCase3);
                }
            }
            Console.WriteLine(sumOfRemovedElements);
        }
        static void RemovedIndexCase1(List<int> pokemons, int removedNumberCase1)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                if (pokemons[i] <= removedNumberCase1)
                {
                    pokemons[i] += removedNumberCase1;
                }
                else
                {
                    pokemons[i] -= removedNumberCase1;
                }
            }
            
        }

        static void RemovedIndexCase2(List<int> pokemons, int removedNumberCase2)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                if (pokemons[i] <= removedNumberCase2)
                {
                    pokemons[i] += removedNumberCase2;
                }
                else
                {
                    pokemons[i] -= removedNumberCase2;
                }
            }

        }

        static void RemovedIndexCase3(List<int> pokemons, int removedNumberCase3)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                if (pokemons[i] <= removedNumberCase3)
                {
                    pokemons[i] += removedNumberCase3;
                }
                else
                {
                    pokemons[i] -= removedNumberCase3;
                }
            }

        }

    }
}
