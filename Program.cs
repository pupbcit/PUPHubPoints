
using PointsBusinessRules;
using PUPHubModels;
using System;
using System.Collections.Generic;

internal class Program
{
    
    static List<string> actions = new List<string>()
            { "view points (type 0)", "use points (type 1)", "exit app (type 2)" };

    static StudentRulesService studentRulesService = new StudentRulesService();
    static PointsRulesService pointsRulesService = new PointsRulesService();

    static Student student;

    static void Main(string[] args)
    {
        Console.WriteLine("PUP-Points (Student) <press any key to continue>");
        Console.ReadKey();

        Console.Write("Please enter your Student Number: ");
        var userInput = Console.ReadLine();

        if (studentRulesService.IsStudentExists(userInput))
        {
            student = studentRulesService.GetStudent(userInput);
            ProcessActionsForStudents();
        }
        else
        {
            Console.WriteLine("Sorry you entered an incorrect password! Application will exit.");
        }
    }

    private static void ProcessActionsForStudents()
    {
        for (int useraction = GetUserAction();
             useraction != actions.IndexOf("exit app (type 2)");
             useraction = GetUserAction())
        {
            switch (useraction)
            {
                case 0:
                    Console.WriteLine($"Total points as of {DateTime.Now.Date}: " +
                        $"{pointsRulesService.GetCurrentPoint(student)}");
                    break;
                case 1:
                    UsePoints();
                    break;
                default:
                    Console.WriteLine("Invalid! Try again.");
                    break;
            }
            Console.WriteLine();
        }
        Console.WriteLine("Application exiting...");
        Console.ReadKey();
    } //ui

    private static void UsePoints()
    {
        Console.Write("How many points do you want to use? ");
        var pointsToUse = Convert.ToInt32(Console.ReadLine());

        if (pointsRulesService.UseStudentPoints(student, pointsToUse) != -1)
        {
            Console.WriteLine($"Successfully used {pointsToUse} points. ");
        }
        else
        {
            Console.WriteLine($"Insufficient balance. Please try again.");
            Console.WriteLine(pointsRulesService.GetCurrentPoint(student));
        }

        Console.WriteLine($"Total points as of {DateTime.Now.Date}: {pointsRulesService.GetCurrentPoint(student)}");
    }

    static int GetUserAction() //ui
    {
        ShowOptions();
        Console.Write("ACTION: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    static void ShowOptions() //ui
    {
        Console.WriteLine("Choose any of the following options. ");

        foreach (var action in actions)
        {
            Console.WriteLine(action);
        }
    }
}