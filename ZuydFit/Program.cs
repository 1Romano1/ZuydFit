using System;
using System.Linq;
using ZuydFit;
using ZuydFit.ZuydFit;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Test");
        AddPlanning();
    }

    public static void AddPlanning()
    {
        Console.WriteLine("Voer de datum en tijd van de activiteit in (bijv. '2024-04-16 14:30'): ");
        DateTime datetime = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Voer de ID van de activiteit in: ");
        int activityId = int.Parse(Console.ReadLine());

        Planning planning = new Planning(datetime, activityId);
        planning.AddPlanning();

        Console.WriteLine("Planning succesvol toegevoegd.");
    }
}

