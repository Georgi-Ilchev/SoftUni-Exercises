using System;
using System.Collections.Generic;
using System.Linq;

namespace newProblem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split('|');
                string piece = tokens[0];
                string composer = tokens[1];
                string key = tokens[2];

                Piece newPiece = new Piece()
                {
                    Composer = composer,
                    Key = key
                };
                pieces.Add(piece, newPiece);
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] tokens = input.Split('|');
                string command = tokens[0];
                string piece = tokens[1];

                if (command == "Add")
                {
                    string composer = tokens[2];
                    string key = tokens[3];

                    if (pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        Piece newPiece = new Piece()
                        {
                            Composer = composer,
                            Key = key
                        };
                        pieces.Add(piece, newPiece);

                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string newKey = tokens[2];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece].Key = newKey;

                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                input = Console.ReadLine();
            }

            pieces = pieces.OrderBy(x => x.Key).ThenBy(x => x.Value.Composer).ToDictionary(x => x.Key, x => x.Value);

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
        class Piece
        {
            public string Composer { get; set; }
            public string Key { get; set; }
        }
    }
}
