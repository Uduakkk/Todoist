using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace NewTodoist
{
    public class Login
    {
        
        Register register  =   new  Register();
        
        public static void UserLogin(User userlogin)
        {
            UI.TodoistHeader("Todoist > Log in");
            Console.Write("Email: ");
            string Email = Console.ReadLine ();
            Validations.IsStringEmail(Email);
            Console.Write("Password: ");
            string password = "";
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    if (string.IsNullOrWhiteSpace(password) || !Regex.IsMatch(password, pattern))
                    {
                        if (string.IsNullOrWhiteSpace(password))
                        {
                            Console.WriteLine("\nPassword must contain at least 8 characters, an Uppercase character, a lowercase, and a numeric character.");
                        }
                        else
                        {
                            Console.WriteLine("\nPassword must contain at least 8 characters, an Uppercase character, a lowercase, and a numeric character.");
                        }

                        Console.Write("Enter a valid password: ");
                        password = "";
                    }
                    else
                    {
                        break;
                    }
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }

            User currentUser = Register.users.FirstOrDefault(u => u.Email == Email && u.Password == password);
            if (currentUser != null)
            {
                Console.WriteLine("\nLogin successful");
                Thread.Sleep(1000);
                Console.Clear();
        
                Menu.UserMenu(currentUser);
            }
            else
            {
                Console.WriteLine("Invalid username or password");
                Menu.UserLandingPage();
            }
        }
    }
}
