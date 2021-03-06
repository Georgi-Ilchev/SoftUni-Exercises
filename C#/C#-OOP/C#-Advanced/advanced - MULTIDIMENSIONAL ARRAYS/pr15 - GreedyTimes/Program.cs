using System;
using System.Collections.Generic;
using System.Linq;

namespace pr15___GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            Dictionary<string, List<Ruby>> book = new Dictionary<string, List<Ruby>>();
            book["Gold"] = new List<Ruby>();
            book["Gem"] = new List<Ruby>();
            book["Cash"] = new List<Ruby>();

            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < input.Length; i += 2)
            {
                string name = input[i].ToUpper();
                long money = long.Parse(input[i + 1]);

                var bagCount = book["Gold"].Sum(a => a.Money) +
                               book["Gem"].Sum(a => a.Money) +
                               book["Cash"].Sum(a => a.Money);

                if (bagCapacity < bagCount + money)
                {
                    continue;
                }

                if (name == "GOLD")
                {
                    if (book["Gold"].All(a => a.UpperName != name))
                    {
                        var currentItem = new Ruby
                        {
                            UpperName = name,
                            NormalName = input[i],
                            Money = money
                        };
                        book["Gold"].Add(currentItem);
                    }
                    else
                    {
                        foreach (var item in book["Gold"])
                        {
                            if (item.UpperName == name)
                            {
                                item.Money += money;
                            }
                        }
                    }
                }
                else if (name.EndsWith("GEM") && name.Length > 3)
                {
                    if (book["Gold"].Sum(a => a.Money) < book["Gem"].Sum(a => a.Money) + money)
                    {
                        continue;
                    }

                    if (book["Gem"].All(a => a.UpperName != name))
                    {
                        var currentItem = new Ruby
                        {
                            UpperName = name,
                            NormalName = input[i],
                            Money = money
                        };
                        book["Gem"].Add(currentItem);
                    }
                    else
                    {
                        foreach (var item in book["Gem"])
                        {
                            if (item.UpperName == name)
                            {
                                item.Money += money;
                            }
                        }
                    }
                }
                else if (name.Length == 3)
                {
                    if (book["Gem"].Sum(a => a.Money) < book["Cash"].Sum(a => a.Money) + money)
                    {
                        continue;
                    }

                    if (book["Cash"].All(a => a.UpperName != name))
                    {
                        var currentItem = new Ruby
                        {
                            UpperName = name,
                            NormalName = input[i],
                            Money = money
                        };
                        book["Cash"].Add(currentItem);
                    }
                    else
                    {
                        foreach (var item in book["Cash"])
                        {
                            if (item.UpperName == name)
                            {
                                item.Money += money;
                            }
                        }
                    }
                }
            }

            book = book.OrderByDescending(x => x.Value.Sum(p => p.Money)).ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in book)
            {
                if (item.Value.Sum(x => x.Money) > 0)
                {
                    //“<{ type}> ${ total amount}”
                    //“##{item} - {amount}” 

                    Console.WriteLine($"<{item.Key}> ${item.Value.Sum(x => x.Money)}");

                    foreach (var item2 in item.Value.OrderByDescending(a => a.NormalName).ThenBy(a => a.Money))
                    {
                        Console.WriteLine($"##{item2.NormalName} - {item2.Money}");
                    }
                }
            }
        }

        class Ruby
        {
            public string UpperName { get; set; }
            public string NormalName { get; set; }
            public long Money { get; set; }
        }
    }
}
