// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using ZuydFit;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welkom bij onze ZuydFit app");
        ActivityMenu();
        /*
        Console.WriteLine("wat is de titel van je advies");
        string title = Console.ReadLine();

        Console.WriteLine("Wat is het advies dat je wilt geven?");
        string description = Console.ReadLine();

        Advice advice2 = new Advice(title, description);
        advice2.AddAdvice();
        
        Advice advice1 = new Advice();
        List<Advice> advices = advice1.ReadAdvice();
        foreach (var adv in advices)
        {
            Console.WriteLine(adv.Title);
        }

        Console.WriteLine("Welk advies wil je verwijderen voer de Id in");
        string Title = Console.ReadLine();

        Advice advice = new Advice();
        advice.GetAdviceByTitle(title);
        advice.DeleteAdvice();

        
        Advice advice3 = new Advice();
        List<Advice> Advices = advice3.ReadAdvice();
        foreach (var ad in Advices)
        {
            Console.WriteLine(ad.Title);
        }
        Console.WriteLine("Welk advies wilt u aanpassen? Type de titel");
        string title1 = Console.ReadLine();

        Console.WriteLine(title1);
        advice3.GetAdviceByTitle(title1);

        Console.WriteLine("wat is de titel van je advies");
        advice3.Title = Console.ReadLine();

        Console.WriteLine("Wat is het advies dat je wilt geven?");
        advice3.Description = Console.ReadLine();

        advice3.UpdateAdvice();
        */
    }

    static void AskForNewActivity()
    {
        Console.WriteLine("Wat is de naam van de oefening wilt u gaan toevoegen?");
        string name = Console.ReadLine();

        Console.WriteLine("Omschrijf deze oefening.");
        string description = Console.ReadLine();

        Console.WriteLine("Hoelang duurt 1 set van deze oefening in minuten?");
        decimal duration = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Hoeveel sets van " + name + " wilt u gaan doen?");
        int sets = int.Parse(Console.ReadLine());

        Activity activity = new Activity(name, description, duration, sets);
        activity.Add();

        Console.Clear();
        Console.WriteLine("De volgende activiteit is toegevoegd:");
        Console.WriteLine("Naam: " + activity.Name);
        Console.WriteLine("Omschrijving: " + activity.Description);
        Console.WriteLine("Duur per set (in minuten): " + activity.Duration);
        Console.WriteLine("Aantal sets: " + activity.Sets);
    }
    static void AskForAdjustActivity()
    {
        Console.WriteLine("Voer de id van de activiteit in die u wilt gaan bijwerken:");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            return;
        }

        Console.WriteLine("Voer de nieuwe naam in:");
        string name = Console.ReadLine();

        Console.WriteLine("Voer de nieuwe beschrijving in:");
        string description = Console.ReadLine();

        Console.WriteLine("Voer de nieuwe tijdsduur in minuten:");
        decimal duration;
        if (!decimal.TryParse(Console.ReadLine(), out duration))
        {
            return;
        }

        Console.WriteLine("Voer de nieuwe hoeveelheid sets in:");
        int sets;
        if (!int.TryParse(Console.ReadLine(), out sets))
        {
            return;
        }

        Activity activity = new Activity
        {
            Id = id,
            Name = name,
            Description = description,
            Duration = duration,
            Sets = sets
        };
        activity.Update();
        Console.WriteLine("De activiteit met id '" + id + "' is succesvol bijgewerkt.");
    }
    static void AskForListActivity()
    {
        Console.WriteLine("Activiteit:");
        Console.WriteLine("Naam:\t Beschrijving:\tTijdsduur:\tSet:");
        Activity activity = new Activity();
        List<Activity> activities = activity.Read();
        foreach (Activity act in activities)
        {
            Console.WriteLine(act.Name + "\t" + act.Description + "\t" + act.Duration + "\t" + act.Sets + "\t");
        }
        Console.WriteLine();
    }
    static void AskForDeleteActivity()
    {
        Console.WriteLine("Voer de naam in van de oefening dat u wilt verwijderen:");
        string Name = Console.ReadLine();
        Activity activity = new Activity();
        activity.Delete();
    }
    static void ActivityMenu()
    {
        bool exit = false;
        string userInput;

        while (!exit)
        {
            Console.WriteLine("Wat wil je gaan doen?");
            Console.WriteLine("1. Een activiteit toevoegen");
            Console.WriteLine("2. Activiteiten bekijken");
            Console.WriteLine("3. Een activiteit bijwerken");
            Console.WriteLine("4. Een activiteit verwijderen");
            Console.WriteLine("5. Terug naar hoofdmenu");

            userInput = Console.ReadLine();

            if (userInput == "1")
                AskForNewActivity();
            else if (userInput == "2")
                AskForAdjustActivity();
            else if (userInput == "3")
                AskForListActivity();
            else if (userInput == "4")
                AskForDeleteActivity();
            else if (userInput == "5")
                exit = true;
            else
            {
                Console.Clear();
                Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                continue;
            }

            // Extra regel om de interface duidelijk te houden na het uitvoeren van een actie
            Console.WriteLine("Druk op Enter om door te gaan...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
