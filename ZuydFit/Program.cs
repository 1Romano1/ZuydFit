using System;
using System.Linq;
using ZuydFit;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welkom bij onze ZuydFit app");
        AskForDeletePlanning();
        /*
        Console.WriteLine("wat is de titel van je advies");
        string title = Console.ReadLine();

        Console.WriteLine("Wat is het advies dat je wilt geven?");
        string description = Console.ReadLine();

        Advice advice2 = new Advice(title, description);
        advice2.AddAdvice();
        
        Advice advice1 = new Advice();
        foreach (var adv in advice1.ReadAdvice())
        {
            Console.WriteLine(adv.Title);
            Console.WriteLine(adv.Description)
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

        while (!exit)
        {
            Console.WriteLine("Wat wil je gaan doen?");
            Console.WriteLine("1. Een activiteit toevoegen");
            Console.WriteLine("2. Activiteiten bekijken");
            Console.WriteLine("3. Een activiteit bijwerken");
            Console.WriteLine("4. Een activiteit verwijderen");
            Console.WriteLine("5. Terug naar hoofdmenu");
            string userInput = Console.ReadLine();



            if (userInput == "1")
                AskForNewActivity();
            else if (userInput == "2")
                AskForListActivity();
            else if (userInput == "3")
                AskForAdjustActivity();
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

    //hieronder staan de functies van goal.
    /*Console.WriteLine("Schrijf de titel van je Goal");
    string name = Console.ReadLine();

    Console.WriteLine("Geef een beschrijving van je Goal");
    string description1 = Console.ReadLine();

    Console.WriteLine("Hoeveel progressie heb je gemaakt aan deze goal?");
    string progression = Console.ReadLine();

    Goal goal = new Goal(name, description1, progression);
    goal.AddGoal();

    Goal goal1 = new Goal();
    foreach (var goal in goal1.GetGoals())
    {
        Console.WriteLine(goal.Id);
        Console.WriteLine(goal.Name);
        Console.WriteLine(goal.Description);
    }
    Console.WriteLine("Welke goal wil je verwijderen voer de naam in");
    string name1 = Console.ReadLine();

    Goal goal2 = new Goal();
    goal2.GetGoalByName(name1);
    goal2.DeleteGoal();
    Goal goal3 = new Goal();
    foreach (var go in goal3.GetGoals())
    {
        Console.WriteLine(go.Name);
    }
    Console.WriteLine("Welk advies wilt u aanpassen? Type de naam");
    string name2 = Console.ReadLine();

    Console.WriteLine(name2);
    goal3.GetGoalByName(name2);

    Console.WriteLine("wat is de naam van je goal");
    goal3.Name = Console.ReadLine();

    Console.WriteLine("Wat is het goal dat je wilt behalen?");
    goal3.Description = Console.ReadLine();

    Console.WriteLine("Wat is het progressieid");
    goal3.Progression = Console.ReadLine();

    userInput = Console.ReadLine();
    goal3.UpdateGoals();*/

    static void AskForNewPlanning()
    {
        Console.WriteLine("Voer de datum en tijd van de activiteit in (bijv. '2024-04-16 14:30'): ");
        DateTime datetime = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Voer de ID van de activiteit in: ");
        int activityId = int.Parse(Console.ReadLine());

        Planning planning = new Planning(datetime, activityId);
        planning.AddPlanning();

        Console.Clear();
        Console.WriteLine("Dit volgende planning is gelogd.");
        Console.WriteLine("Datum en Tijd:" + planning.DateTime);
        Console.WriteLine("Uitgevoerde activiteit:" + planning.ActivityId);
    }

    static void AskForAdjustPlanning()
    {
        Console.WriteLine("Voer de Id in van de planning die u wilt bewerken.");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            return;
        }
        Console.WriteLine("Voer de nieuwe datum en tijd in:");
        string input = Console.ReadLine();

        DateTime datetime;
        if (DateTime.TryParse(input, out datetime))
        {

            Console.WriteLine("Ingevoerde datum en tijd: " + datetime);
        }
        else
        {

            Console.WriteLine("Ongeldige invoer. Voer een geldige datum- en tijdnotatie in.");
        }


        Console.WriteLine("Voer de nieuwe activiteitId in:");
        if (int.TryParse(Console.ReadLine(), out int activityId))
        {
            // Hier kun je de activityId gebruiken
        }
        else
        {
            Console.WriteLine("Ongeldige invoer. Voer een geldig getal in.");
        }


        Planning planning = new Planning
        {
            Id = id,
            DateTime = datetime,
            ActivityId = activityId
        };
        planning.Update();
        Console.WriteLine("De planning met id" + id + "is succesvol bijgewerkt.");


    }

    static void AskForListPlanning()
    {
        Console.WriteLine("Planning");
        Console.WriteLine("Datum en tijd:\t ActiviteitId:");
        Planning planning = new Planning();
        List<Planning> plannings = planning.Read();
        foreach (Planning act in plannings)
        {
            Console.WriteLine(act.DateTime + "\t" + act.ActivityId + "\t");
        }
        Console.WriteLine();
    }

    static void AskForDeletePlanning()
    {
        Console.WriteLine("Voer het ID in van de planning die u wilt verwijderen.");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Planning planning = new Planning();
            planning.Id = id; // Stel het Id in voordat Delete wordt aangeroepen
            planning.Delete();
            Console.WriteLine("De planning met Id: " + id + " is succesvol verwijderd.");
        }
        else
        {
            Console.WriteLine("Ongeldige invoer. Voer een geldig ID (integer) in.");
        }
    }




    static void PlanningMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Wat wil je gaan doen?");
            Console.WriteLine("1. Een planning toevoegen");
            Console.WriteLine("2. Planningen bekijken");
            Console.WriteLine("3. Een planning bijwerken");
            Console.WriteLine("4. Een planning verwijderen");
            Console.WriteLine("5. Terug naar hoofdmenu");
            string userInput = Console.ReadLine();

            if (userInput == "1")
                AskForNewPlanning();
            else if (userInput == "2")
                AskForListPlanning();
            else if (userInput == "3")
                AskForAdjustPlanning();
            else if (userInput == "4")
                AskForDeletePlanning();
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


