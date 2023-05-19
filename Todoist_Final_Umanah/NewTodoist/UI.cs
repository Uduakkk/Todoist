using System;
using System.Collections.Generic;
using System.Text;

namespace NewTodoist
{
    public class UI
    {
        static readonly int tableWidth = 90;


        public static void TodoistHeader(string input)
        {
            int headerWidth = input.Length + 4;
            int centerPosition = (Console.WindowWidth / 2) - (headerWidth / 2);


            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(new string('>', 60));
            Console.Write(new string('<', 60));
            Console.WriteLine($"{new string(' ', centerPosition)}|  {input} |");

            Console.Write(new string('>', 60));
            Console.Write(new string('<', 60));
            Console.ResetColor();
        }
        public static void PrintList( User user)
        {

            TodoistHeader("ToDoIst list");
            PrintLine();
            PrintRow("ID", "Title", "Description", "DueDate", "Priority", "Status");
            PrintLine();
            int id = 1;
            foreach (Items items in user.item)
            {
                //int counter = item.IndexOf(items);
                PrintRow(Convert.ToString(items.ItemId = id), items.Title, items.Description, items.DueDate.ToString("yyyy-MM-dd"), items.Priority, items.Status);
                id++;
            }
            PrintLine();
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length + 1) / columns.Length;
            string row = "|";
            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }

        static string CentreText(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            int totalSpaces = width - text.Length;
            int leftSpaces = totalSpaces / 2;
            return new string(' ', leftSpaces) + text + new string(' ', totalSpaces - leftSpaces);
        }
    }
}
