using System;
using System.Collections.Generic;
using System.Linq;

namespace problem10___Santa_s_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boxMaterials = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] magicValues = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stackMaterials = new Stack<int>(boxMaterials);
            Queue<int> queueValues = new Queue<int>(magicValues);

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            while (stackMaterials.Count > 0 && queueValues.Count > 0)
            {
                int currentMaterial = stackMaterials.Peek();
                int currentValue = queueValues.Peek();

                if (currentMaterial == 0 || currentValue == 0)
                {
                    if (currentMaterial == 0)
                    {
                        stackMaterials.Pop();
                    }
                    if (currentValue == 0)
                    {
                        queueValues.Dequeue();
                    }
                    continue;
                }

                int result = currentMaterial * currentValue;

                if (result > 0)
                {
                    switch (result)
                    {
                        case 150:
                            if (dictionary.ContainsKey("Doll"))
                            {
                                dictionary["Doll"] += 1;
                            }
                            else
                            {
                                dictionary.Add("Doll", 1);
                            }
                            stackMaterials.Pop();
                            queueValues.Dequeue();
                            break;

                        case 250:
                            if (dictionary.ContainsKey("Wooden train"))
                            {
                                dictionary["Wooden train"] += 1;
                            }
                            else
                            {
                                dictionary.Add("Wooden train", 1);
                            }
                            stackMaterials.Pop();
                            queueValues.Dequeue();
                            break;
                        case 300:
                            if (dictionary.ContainsKey("Teddy bear"))
                            {
                                dictionary["Teddy bear"] += 1;
                            }
                            else
                            {
                                dictionary.Add("Teddy bear", 1);
                            }
                            stackMaterials.Pop();
                            queueValues.Dequeue();
                            break;
                        case 400:
                            if (dictionary.ContainsKey("Bicycle"))
                            {
                                dictionary["Bicycle"] += 1;
                            }
                            else
                            {
                                dictionary.Add("Bicycle", 1);
                            }
                            stackMaterials.Pop();
                            queueValues.Dequeue();
                            break;

                        default:
                            var current = stackMaterials.Pop() + 15;
                            stackMaterials.Push(current);
                            queueValues.Dequeue();
                            break;
                    }
                }
                else if (result < 0)
                {
                    int sum = stackMaterials.Pop() + queueValues.Dequeue();
                    stackMaterials.Push(sum);
                }
            }

            if (dictionary.ContainsKey("Doll") && dictionary.ContainsKey("Wooden train") ||
                dictionary.ContainsKey("Teddy bear") && dictionary.ContainsKey("Bicycle"))
            {
                Console.WriteLine($"The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine($"No presents this Christmas!");
            }

            if (stackMaterials.Count > 0)
            {
                Console.WriteLine($"Materials left: " + string.Join(", ", stackMaterials).ToString());
            }
            if (queueValues.Count > 0)
            {
                Console.WriteLine($"Magic left: " + string.Join(", ", queueValues).ToString());
            }

            dictionary = dictionary.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}".ToString());
            }
        }
    }
}
