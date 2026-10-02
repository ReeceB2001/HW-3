using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        
        string[] courses = new string[0];

        
        List<string> assignments = new List<string>();

        
        Dictionary<string, string> assignmentDetails =
            new Dictionary<string, string>();

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("===== ASSIGNMENT TRACKER =====");
            Console.WriteLine("1. Create Course (Array)");
            Console.WriteLine("2. Update Course (Array)");
            Console.WriteLine("3. Add Assignment (List)");
            Console.WriteLine("4. Update Assignment (List)");
            Console.WriteLine("5. Remove Assignment by Index (List)");
            Console.WriteLine("6. Add or Update Assignment Details (Dictionary)");
            Console.WriteLine("7. Remove Assignment by Name");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                

                Console.Write("How many courses? ");
                int numberOfCourses = Convert.ToInt32(Console.ReadLine());

                courses = new string[numberOfCourses];

                for (int i = 0; i < courses.Length; i++)
                {
                    Console.Write("Enter course " + (i + 1) + ": ");
                    courses[i] = Console.ReadLine();
                }

                Console.WriteLine();
                Console.WriteLine("Courses:");

                for (int i = 0; i < courses.Length; i++)
                {
                    Console.WriteLine(i + ". " + courses[i]);
                }
            }
            else if (choice == "2")
            {
                
                if (courses.Length == 0)
                {
                    Console.WriteLine(
                        "Courses have not been created. Please use Option 1 first.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Current Courses:");

                    for (int i = 0; i < courses.Length; i++)
                    {
                        Console.WriteLine(i + ". " + courses[i]);
                    }

                    Console.Write("Enter the course index to update: ");
                    int courseIndex = Convert.ToInt32(Console.ReadLine());

                    if (courseIndex >= 0 && courseIndex < courses.Length)
                    {
                        Console.Write("Enter the new course name: ");
                        courses[courseIndex] = Console.ReadLine();

                        Console.WriteLine();
                        Console.WriteLine("Updated Courses:");

                        for (int i = 0; i < courses.Length; i++)
                        {
                            Console.WriteLine(i + ". " + courses[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid course index.");
                    }
                }
            }
            else if (choice == "3")
            {
                

                Console.WriteLine();
                Console.WriteLine("Current Assignments:");

                if (assignments.Count == 0)
                {
                    Console.WriteLine("No assignments.");
                }
                else
                {
                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine(i + ". " + assignments[i]);
                    }
                }

                string answer = "y";

                while (answer.ToLower() == "y")
                {
                    Console.Write("Enter assignment name: ");
                    string assignmentName = Console.ReadLine();

                    assignments.Add(assignmentName);

                    Console.Write("Add another assignment? (y/n): ");
                    answer = Console.ReadLine();
                }

                Console.WriteLine();
                Console.WriteLine("Updated Assignments:");

                for (int i = 0; i < assignments.Count; i++)
                {
                    Console.WriteLine(i + ". " + assignments[i]);
                }
            }
            else if (choice == "4")
            {
                

                if (assignments.Count == 0)
                {
                    Console.WriteLine("There are no assignments to update.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Current Assignments:");

                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine(i + ". " + assignments[i]);
                    }

                    Console.Write("Enter the assignment index to update: ");
                    int assignmentIndex = Convert.ToInt32(Console.ReadLine());

                    if (assignmentIndex >= 0 &&
                        assignmentIndex < assignments.Count)
                    {
                        string oldName = assignments[assignmentIndex];

                        Console.Write("Enter the new assignment name: ");
                        string newName = Console.ReadLine();

                        assignments[assignmentIndex] = newName;

                        // If the old assignment exists in the Dictionary,
                        // move its value to the new key.
                        if (assignmentDetails.ContainsKey(oldName))
                        {
                            string existingDetails =
                                assignmentDetails[oldName];

                            assignmentDetails.Remove(oldName);
                            assignmentDetails[newName] = existingDetails;
                        }

                        Console.WriteLine();
                        Console.WriteLine("Updated Assignments:");

                        for (int i = 0; i < assignments.Count; i++)
                        {
                            Console.WriteLine(i + ". " + assignments[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid assignment index.");
                    }
                }
            }
            else if (choice == "5")
            {
                

                if (assignments.Count == 0)
                {
                    Console.WriteLine("There are no assignments to remove.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Current Assignments:");

                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine(i + ". " + assignments[i]);
                    }

                    Console.Write("Enter the assignment index to remove: ");
                    int removeIndex = Convert.ToInt32(Console.ReadLine());

                    if (removeIndex >= 0 &&
                        removeIndex < assignments.Count)
                    {
                        assignments.RemoveAt(removeIndex);

                        Console.WriteLine();
                        Console.WriteLine("Updated Assignments:");

                        for (int i = 0; i < assignments.Count; i++)
                        {
                            Console.WriteLine(i + ". " + assignments[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid assignment index.");
                    }
                }
            }
            else if (choice == "6")
            {
                

                Console.WriteLine();
                Console.WriteLine("Current Assignment Details:");

                foreach (KeyValuePair<string, string> item
                         in assignmentDetails)
                {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }

                Console.Write("Enter assignment name: ");
                string detailAssignment = Console.ReadLine();

                Console.Write("Enter description: ");
                string description = Console.ReadLine();

                Console.Write("Enter progress status: ");
                string status = Console.ReadLine();

                string details = description + " - " + status;

                assignmentDetails[detailAssignment] = details;

                Console.WriteLine();
                Console.WriteLine("Updated Assignment Details:");

                foreach (KeyValuePair<string, string> item
                         in assignmentDetails)
                {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }
            }
            else if (choice == "7")
            {
                

                Console.WriteLine();
                Console.WriteLine("Current Assignments:");

                for (int i = 0; i < assignments.Count; i++)
                {
                    Console.WriteLine(i + ". " + assignments[i]);
                }

                Console.Write("Enter assignment name to remove: ");
                string removeName = Console.ReadLine();

                if (assignments.Remove(removeName))
                {
                    Console.WriteLine(
                        "Assignment removed from the List.");

                    Console.WriteLine();
                    Console.WriteLine("Updated Assignments:");

                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine(i + ". " + assignments[i]);
                    }

                    Console.Write(
                        "Do you also want to remove its Dictionary entry? (y/n): ");

                    string dictionaryAnswer = Console.ReadLine();

                    if (dictionaryAnswer.ToLower() == "y")
                    {
                        Console.Write("Enter Dictionary key to remove: ");
                        string keyToRemove = Console.ReadLine();

                        if (assignmentDetails.Remove(keyToRemove))
                        {
                            Console.WriteLine(
                                "Dictionary entry removed.");
                        }
                        else
                        {
                            Console.WriteLine(
                                "Dictionary key not found.");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Updated Assignment Details:");

                        foreach (KeyValuePair<string, string> item
                                 in assignmentDetails)
                        {
                            Console.WriteLine(
                                item.Key + ": " + item.Value);
                        }
                    }
                }
                else
                {
                    Console.WriteLine(
                        "Assignment was not found.");
                }
            }
            else if (choice == "8")
            {
                

                running = false;
                Console.WriteLine("Good work!");
            }
            else
            {
                

                Console.WriteLine(
                    "Invalid option. Choose 1-8.");
            }
        }
    }
}