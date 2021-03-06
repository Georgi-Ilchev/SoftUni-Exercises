using System;
using System.Text.RegularExpressions;

namespace _10._Warrior_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "For Azeroth")
                {
                    break;
                }
                else
                {
                    string[] splitted = input.Split(" ");
                    string command = splitted[0];

                    if (command == "GladiatorStance")
                    {
                        skill = skill.ToUpper();
                        Console.WriteLine(skill);
                    }
                    else if (command == "DefensiveStance")
                    {
                        skill = skill.ToLower();
                        Console.WriteLine(skill);
                    }
                    else if (command == "Dispel")
                    {
                        int index = int.Parse(splitted[1]);
                        char letter = char.Parse(splitted[2]);

                        if (index >= 0 && index < skill.Length)
                        {
                            var currentSkill = skill.ToCharArray();
                            currentSkill[index] = letter;
                            skill = string.Join("", currentSkill);
                            Console.WriteLine("Success!");
                        }
                        else
                        {
                            Console.WriteLine("Dispel too weak.");
                        }
                    }
                    else if (command == "Target")
                    {
                        string changeOrRemove = splitted[1];
                        

                        if (changeOrRemove == "Change")
                        {
                            string substring = splitted[2];
                            string secondSubstring = splitted[3];
                            //skill = skill.Replace(substring, secondSubstring);
                            skill = Regex.Replace(skill, substring, secondSubstring);
                            Console.WriteLine(skill);
                        }
                        else if (changeOrRemove == "Remove")
                        {
                            string substring = splitted[2];
                            skill = Regex.Replace(skill, substring, "");
                            Console.WriteLine(skill);
                        }
                        else
                        {
                            Console.WriteLine("Command doesn't exist!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Command doesn't exist!");
                    }
                }
            }
        }
    }
}
