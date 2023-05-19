using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NewTodoist
{
    public class Validations
    {
        public static void ValidateStrings(string input, string message)
        {
            while (string.IsNullOrWhiteSpace(input) || !input.All(Char.IsLetter))
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
        }

        public static void IsStringEmail(string input)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            while (string.IsNullOrWhiteSpace(input) || !Regex.IsMatch(input, pattern))
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Email is required. It cannot be skipped.");
                }
                else
                {
                    Console.WriteLine("Email is not in a valid format e.g \"name@example.com\"");
                }
                Console.Write("Enter a valid email address: ");
                input = Console.ReadLine();
            }

        }
        public static void IsEmail(string str) 
        { 
        string pattern = (@"^[a-zA-Z0-9\s]+$");

                while (string.IsNullOrWhiteSpace(str) || !Regex.IsMatch(str, pattern))
                {
                    if (string.IsNullOrWhiteSpace(str))
                    {
                        Console.WriteLine("Title is required. It cannot be skipped.");
                    }
                    else
                    {
                        Console.WriteLine("Title is not in a valid format");
                    }
                    Console.Write("Title: ");
                    str = Console.ReadLine();
                }
        }
       
    }
}
