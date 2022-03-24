using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "Travel")
            {
                List<string> inputs = command.Split(':', StringSplitOptions.RemoveEmptyEntries).ToList();

                string action = inputs[0];

                if (action == "Add Stop")
                {
                    int index = int.Parse(inputs[1]);
                    string givvenString = inputs[2];

                    if (index >= 0 && index < destination.Length)
                    {
                        destination = destination.Insert(index, givvenString);
                    }
                }
                else if (action == "Remove Stop")
                {
                    int startIndex = int.Parse(inputs[1]);
                    int endIndex = int.Parse(inputs[2]);

                    if (startIndex >= 0 && startIndex < destination.Length && endIndex >= 0 && endIndex < destination.Length)
                    {
                        destination = destination.Remove(startIndex, endIndex - startIndex + 1);
                    }
                }
                else if (action == "Switch")
                {
                    string oldString = inputs[1];
                    string newString = inputs[2];

                    if (destination.Contains(oldString))
                    {
                        destination = destination.Replace(oldString, newString);
                    }

                }
                Console.WriteLine(destination);
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {destination}");
        }
    }
}