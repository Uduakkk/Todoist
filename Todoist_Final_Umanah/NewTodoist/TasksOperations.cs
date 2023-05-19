using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace NewTodoist
{
    public class TasksOperations
    {
         
        public static void AddTasks(User user, List<Items> item)
        {
            bool IsContinue = true;
            string check;
            do
            {
                Thread.Sleep(1000);
                Console.Clear();
                UI.TodoistHeader("Todoist > home > menu > add task");
                Items items = new Items();
                items.ItemId = user.item.Count +1 ;

                Console.Write("\nTask title: ");
                items.Title = Console.ReadLine();
                string TitlePattern = (@"^[a-zA-Z0-9\s]+$");

                while (string.IsNullOrWhiteSpace(items.Title) || !Regex.IsMatch(items.Title, TitlePattern))
                {
                    if (string.IsNullOrWhiteSpace(items.Title))
                    {
                        Console.WriteLine("Title is required. It cannot be skipped.");
                    }
                    else
                    {
                        Console.WriteLine("Title is not in a valid format");
                    }
                    Console.Write("Title: ");
                    items.Title = Console.ReadLine();
                }
                Thread.Sleep(500);
                Console.Clear();
                UI.TodoistHeader("Todoist > home > menu > add task");
                Console.Write("Task description: ");
                items.Description = Console.ReadLine();
                string DescriptionPattern = (@"^[A-Za-z0-9\s\p{P}]+$");

                while (string.IsNullOrWhiteSpace(items.Description) || !Regex.IsMatch(items.Description, DescriptionPattern))
                {
                    if (string.IsNullOrWhiteSpace(items.Description))
                    {
                        Console.WriteLine("Title is required. It cannot be skipped.");
                    }
                    else
                    {
                        Console.WriteLine("Title is not in a valid format");
                    }
                    Console.Write("Description: ");
                    items.Description = Console.ReadLine();
                }
                Thread.Sleep(500);
                Console.Clear();
                UI.TodoistHeader("Todoist > home > menu > add task");
                Console.Write("Task due date): ");
                Console.Write("Due date (YYYY/MM/DD: ");
                DateTime dueDate;
                while (!DateTime.TryParse(Console.ReadLine(), out dueDate) || dueDate < DateTime.Now)
                {
                    Console.WriteLine("Invalid input. Please enter a valid future date: ");
                }

                items.DueDate = dueDate;
                Thread.Sleep(500);
                Console.Clear();
                UI.TodoistHeader("Todoist > home > menu > add task");
                Console.WriteLine("\n1. low");
                Console.WriteLine("2. medium");
                Console.WriteLine("3. high");
                Console.Write("Select task priority: ");
                string set = Console.ReadLine();

                if (set == "1")
                {
                    items.Priority = "low";
                }
                else if (set == "2")
                {
                    items.Priority = "medium";
                }
                else if (set == "3")
                {
                    items.Priority = "high";
                }

                while (set != "1" && set != "2" && set != "3" || string.IsNullOrWhiteSpace(set))
                {
                    if (string.IsNullOrWhiteSpace(set))
                    {
                        Console.WriteLine("selection is mandatory");
                    }
                    else
                    {

                        Console.WriteLine("Invalid Input");
                    }

                    Console.WriteLine("\n1. low");
                    Console.WriteLine("2. medium");
                    Console.WriteLine("3. high");
                    Console.Write("Select task priority");
                    set = Console.ReadLine();


                    items.UserId = user.Id;
                }

                    Console.WriteLine("Do you want to add another Task  (Y/N)");
                    check = Console.ReadLine();

                    if (check.ToLower().Trim() == "y")
                    {
                        IsContinue = true;
                    }
                    else if (check.ToLower().Trim() == "n")
                    {
                        IsContinue = false;
                    }

                Console.WriteLine("Your task(s) has been added");
                item.Add(items);
            } while (IsContinue);
            
        }
        public static void EditItem (User user, List<Items> item)
        {

            Thread.Sleep(1000);
            Console.Clear();
            UI.TodoistHeader("Todoist > home > menu > Edit task");
            if (item.Count == 0)
            {
                Console.WriteLine("You do not have any available todo Item to edit.");
                Menu.TasksMenu(loggedInUser: user);
            }

            UI.PrintList(user: user);
            Console.Write("Enter the item number to edit: ");
            int taskId;
                while (!int.TryParse(Console.ReadLine(), out taskId))
                {
                    Console.WriteLine("Invalid command");
                    Console.WriteLine("\nSelect a valid option: ");
                   
                }
            var EditItem = item.Find(task => task.ItemId == taskId);
            if (EditItem != null)
            {
                

                Console.WriteLine("Enter the new details for the item:");
                Console.Write("Title: ");
                EditItem.Title = Console.ReadLine();
                string TitlePattern = (@"^[a-zA-Z0-9\s]+$");

                while (string.IsNullOrWhiteSpace(EditItem.Title) || !Regex.IsMatch(EditItem.Title, TitlePattern))
                {
                    if (string.IsNullOrWhiteSpace(EditItem.Title))
                    {
                        Console.WriteLine("Title is required. It cannot be skipped.");
                    }
                    else
                    {
                        Console.WriteLine("Title is not in a valid format");
                    }
                    Console.Write("Title: ");
                    EditItem.Title = Console.ReadLine();
                }
                Console.Write("Description: ");
                EditItem.Description = Console.ReadLine();
                string DescriptionPattern = (@"^[A-Za-z0-9\s\p{P}]+$");

                while (string.IsNullOrWhiteSpace(EditItem.Description) || !Regex.IsMatch(EditItem.Description, DescriptionPattern))
                {
                    if (string.IsNullOrWhiteSpace(EditItem.Description))
                    {
                        Console.WriteLine("Title is required. It cannot be skipped.");
                    }
                    else
                    {
                        Console.WriteLine("Title is not in a valid format");
                    }
                    Console.Write("Description: ");
                    EditItem.Description = Console.ReadLine();
                }

                
                Console.Write("Due date (YYYY/MM/DD): ");
                DateTime dueDate;
                while (!DateTime.TryParse(Console.ReadLine(), out dueDate) || dueDate < DateTime.Now)
                {
                    Console.WriteLine("Invalid input. Please enter a valid future date: ");
                }

                EditItem.DueDate = dueDate;
                Console.WriteLine("\n1. low");
                Console.WriteLine("2. medium");
                Console.WriteLine("3. high");
                Console.Write("Select task priority: ");
                string set = Console.ReadLine();

                if (set == "1")
                {
                    EditItem.Priority = "low";
                }
                else if (set == "2")
                {
                    EditItem.Priority = "medium";
                }
                else if (set == "3")
                {
                    EditItem.Priority = "high";
                }

                while (set != "1" && set != "2" && set != "3" || string.IsNullOrWhiteSpace(set))
                {
                    if (string.IsNullOrWhiteSpace(set))
                    {
                        Console.WriteLine("selection is mandatory");
                    }
                    else
                    {

                        Console.WriteLine("Invalid Input");
                    }

                    Console.WriteLine("\n1. low");
                    Console.WriteLine("2. medium");
                    Console.WriteLine("3. high");
                    Console.Write("Select task priority");
                    set = Console.ReadLine();
                }
                Console.WriteLine("Item edited successfully");
                Menu.TasksMenu(loggedInUser: user);
            }
            else
            {
                Console.WriteLine("Invalid item number.");
                Menu.TasksMenu(loggedInUser: user);
            }
        
        }
        public static void DeleteTask (User user, List<Items> item)
        {
            Thread.Sleep(500);
            Console.Clear();
            UI.TodoistHeader("Todoist > home > menu > delete task");

            if (item.Count == 0)
            {
                Console.WriteLine("You do not have any available todo item to delete.");
                Menu.TasksMenu(loggedInUser:user);
            }

            UI.PrintList(user:user);
            Console.WriteLine("\nEnter the item number to delete: ");
            int DelItem = int.Parse(Console.ReadLine()) -1;

            if (DelItem >= 0 && DelItem < item.Count)
            {
                item.RemoveAt(DelItem);
                Console.WriteLine("Item deleted successfully");
            }
            else
            {
                Console.WriteLine("Invalid item number.");
                Menu.TasksMenu(loggedInUser: user);
            }
        }
        public static void SetStatus(User user, List<Items> item)
        {
            Thread.Sleep(500);
            Console.Clear();
            UI.TodoistHeader("Todoist > home > menu > task status");
            if (item.Count == 0)
            {
                Console.WriteLine("You do not have any available todo Item.");
                Menu.TasksMenu(loggedInUser: user);
            }
            UI.PrintList(user: user);
            Console.Write("Enter the item number to set status: ");
            int taskId;
            while (!int.TryParse(Console.ReadLine(), out taskId))
            {
                Console.WriteLine("Invalid input. Please enter a valid item number: ");
            }
            var SetStatus = item.Find(task => task.ItemId == taskId);
            if (SetStatus != null)
            {
                Console.WriteLine("\n1. Started");
                Console.WriteLine("2. Completed");
                Console.Write("Select task status: ");
                string set = Console.ReadLine();

                if (set == "1")
                {
                    SetStatus.Status = "started";
                }
                else if (set == "2")
                {
                    SetStatus.Status = "completed";
                }
                else
                {
                    Console.WriteLine("Invalid command");
                    Menu.TasksMenu(loggedInUser: user);
                }
            }
        }
    }
}
