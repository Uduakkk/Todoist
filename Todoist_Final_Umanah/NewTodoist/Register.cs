using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Transactions;

namespace NewTodoist
{
    public class Register
    { 
        
      public static  List <User> users= new List <User> ();
        public static void RegisterUser()
        {
            UI.TodoistHeader("Todoist > Register");
            Console.Write("\nFirst name: ");
           string firstName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(firstName) || !firstName.All(Char.IsLetter))
            {
                Console.WriteLine("name must contain only letters");
                firstName = Console.ReadLine();
            }

            Console.Clear();

            UI.TodoistHeader("Todoist > Register");
            Console.Write("\nLast name: ");
            string lastName = Console.ReadLine ();
            while (string.IsNullOrWhiteSpace(lastName) || !lastName.All(Char.IsLetter))
            {
                Console.WriteLine("name must contain only letters");
                lastName = Console.ReadLine();
            }

            Console.Clear();

            UI.TodoistHeader("Todoist > Register");
            Console.Write("\nEmail: ");
            string email = Console.ReadLine ();
            string Epattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            while (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, Epattern))
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Email is required. It cannot be skipped.");
                }
                else
                {
                    Console.WriteLine("Email is not in a valid format e.g \"name@example.com\"");
                }
                Console.Write("Enter a valid email address: ");
                email = Console.ReadLine();
            }
                bool existingUser = users.Exists(u => u.Email == email);
            if (existingUser)
            {
                Console.WriteLine("\na user with that email already exists!");
                Console.WriteLine("Register with a different email or log in with your verified credentials.");
                Thread.Sleep(2000);
                Console.WriteLine();
                Menu.UserLandingPage();
            }
            

            Console.Clear();

            UI.TodoistHeader("Todoist > Register");
            Console.WriteLine($"\n{firstName} {lastName}");
            Console.WriteLine($"{email}");
            Console.WriteLine("\nCreate a password to secure your account \nPassword must contain a minimum of 8 characters," +
                "and must consist of an uppercase character, a lowercase, and a numerical character.");
            Console.Write("password: ");
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
                            Console.WriteLine("\nCreate your password using at least 8 characters containing an uppercase,a lowercase and a numeric character.");
                        }
                        else
                        {
                            Console.WriteLine("\nPassword must contain at least 8 characters, an Uppercase character, a lowercase, and a numeric character.");
                        }

                        Console.Write("Create a valid password: ");
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
            Console.Write("\nConfirm password: ");
            string ConfirmPassword = "";
            

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    if (string.IsNullOrWhiteSpace(ConfirmPassword) || !Regex.IsMatch(ConfirmPassword, pattern))
                    {
                        if (string.IsNullOrWhiteSpace(ConfirmPassword))
                        {
                            Console.WriteLine("\nBoth password must be the same.");
                        }
                        else
                        {
                            Console.WriteLine("\nBoth password must be the same.");
                        }

                        Console.Write("Confirm password: ");
                        ConfirmPassword = "";
                    }
                    else
                    {
                        break;
                    }
                }
                 else if (key.Key == ConsoleKey.Backspace)
                {
                    if (ConfirmPassword.Length > 0)
                    {
                        ConfirmPassword = ConfirmPassword.Substring(0, ConfirmPassword.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    ConfirmPassword += key.KeyChar;
                    Console.Write("*");
                }
            }


            while (password != ConfirmPassword)
            {
                Console.WriteLine("Passwords do not match");
                Console.Write("Confirm password: ");
                ConfirmPassword = Console.ReadLine();
            }

            Guid guid = Guid.NewGuid ();

            User newUser = new User
            {
                FirstName= firstName,
                LastName= lastName,
                Email= email,
                Password= password,
                Id= guid
            };

            users.Add(newUser);
            

            
            Menu.UserMenu(newUser);
        }
    }
}
