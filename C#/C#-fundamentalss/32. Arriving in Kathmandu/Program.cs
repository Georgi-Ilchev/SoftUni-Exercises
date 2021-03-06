﻿using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _32._Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<nameofpeak>[A-Za-z0-9!@#$?]+)=(?<length>\d+)<<(?<code>(.*?)+)$";
            string input;
            Regex regex = new Regex(pattern);
            while ((input = Console.ReadLine()) != "Last note")
            {
                Match match = regex.Match(input);
                if (match.Success == false)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }
                string nameOfPeak = match.Groups["nameofpeak"].Value;
                int length = int.Parse(match.Groups["length"].Value);
                string code = match.Groups["code"].Value;
                string nameOfPeakResult = string.Empty;
                if (code.Length != length)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }

                for (int i = 0; i < nameOfPeak.Length; i++)
                {
                    if (char.IsLetterOrDigit(nameOfPeak[i]))
                    {
                        nameOfPeakResult += nameOfPeak[i];
                    }
                }

                Console.WriteLine($"Coordinates found! {nameOfPeakResult} -> {code}");
            }
        }
    }
}
