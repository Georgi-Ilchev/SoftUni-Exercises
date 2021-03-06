using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem18._Wizard_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> newDeck = new List<string>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Ready")
            {
                List<string> command = input.Split().ToList();

                if (command[0] == "Add")
                {
                    string cardName = command[1];
                    if (cards.Contains(cardName))
                    {
                        newDeck.Add(cardName);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (command[0] == "Insert")
                {
                    string cardName = command[1];
                    int index = int.Parse(command[2]);
                    if (cards.Contains(cardName))
                    {
                        if (index >= 0 && index < newDeck.Count)
                        {
                            newDeck.Insert(index, cardName);
                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
                else if (command[0] == "Remove")
                {
                    string cardName = command[1];
                    if (newDeck.Contains(cardName))
                    {
                        newDeck.Remove(cardName);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (command[0] == "Swap")
                {
                    string cardName1 = command[1];
                    string cardName2 = command[2];

                    int index1 = newDeck.IndexOf(cardName1);
                    int index2 = newDeck.IndexOf(cardName2);

                    string temp1 = newDeck[index1];
                    string temp2 = newDeck[index2];

                    newDeck[index1] = temp2;
                    newDeck[index2] = temp1;
                }
                else if (command[0] == "Shuffle")
                {
                    newDeck.Reverse();
                }
            }
            Console.WriteLine(string.Join(" ",newDeck));
        }
    }
}
