using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;

namespace NewTodoist
{
    public class Menu
    {
      static public User users = new User();
        public static void UserLandingPage()
        {
            while (true)
            {
                UI.TodoistHeader("Todoist");
                Console.WriteLine("\n1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Help");
                Console.WriteLine("4. Exit");
                Console.WriteLine("");
                int command = int.Parse(Console.ReadLine());
                Console.Clear();

                if (command == 1)
                {
                    Register.RegisterUser();  //(users, item);
                }
                else if (command == 2)
                {
                    Login.UserLogin(users);//(users, user, item);
                }
                else if (command == 3)
                {
                    //help
                }
                else if ( command == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command");
                    Menu.UserLandingPage();//(users, user, item);
                }
            }
        }

        // public static void UserMenu(List<User> users, User user, List<Items> item)
        public static  void UserMenu(User currentUser)
         {
            users = currentUser;
            Thread.Sleep(1000);
            Console.Clear();
            UI.TodoistHeader("Todoist > Home");
            Console.WriteLine($"\nWelcome {currentUser.LastName}");
            Console.WriteLine($"\n{currentUser.FirstName} {currentUser.LastName}");
            Console.WriteLine($"{currentUser.Email}");
            Console.WriteLine($"Number of active tasks: {currentUser.item.Count}");
            Console.WriteLine("\n1. Menu");
            Console.WriteLine("2. help");
            Console.WriteLine("3. Logout");

            int command = int.Parse(Console.ReadLine());
            if (command == 1)
            {
                TasksMenu(currentUser);
            }
            else if (command == 2)
            {
                Console.WriteLine("see readme file for clarifications");
                UserMenu(currentUser);
            }
            else if (command == 3)
            {
                Menu.UserLandingPage();
            }
        }

        public static void TasksMenu(User loggedInUser )
        {
            users = loggedInUser;
            Thread.Sleep(1000);
            Console.Clear();
            UI.TodoistHeader("Todoist > home > Menu");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Edit Task");
            Console.WriteLine("3. Set Task status");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. View Task lists");
            Console.WriteLine("6. Back");
            int operation = int.Parse(Console.ReadLine());

            if (operation == 1)
            {
                Console.Clear();
                TasksOperations.AddTasks(users, users.item);
                TasksMenu(loggedInUser);

            }
            else if (operation == 2)
            {
                TasksOperations.EditItem(users, users.item);
                Thread.Sleep(2000);
                Console.Clear();
                TasksMenu(loggedInUser);
            }
            else if (operation == 3)
            {
                TasksOperations.SetStatus(users, users.item);
                Thread.Sleep(2000);
                Console.Clear();
                TasksMenu(loggedInUser);
            }
            else if (operation == 4)
            {
                TasksOperations.DeleteTask(users, users.item);
                Thread.Sleep(2000);
                Console.Clear();
                TasksMenu(loggedInUser);
            }
            else if (operation == 5)
            {
                UI.PrintList(users);
                Thread.Sleep(2000);
                TasksMenu(loggedInUser);
            }
            else if (operation == 6)
            {
                UserMenu(loggedInUser);
            }
            else
            {
                Console.WriteLine("Invalid command");
                TasksMenu(loggedInUser);
            }

        }
    }
}
