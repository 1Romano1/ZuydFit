using System;
using System.Linq;
using ZuydFit;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welkom bij onze ZuydFit app");
        MainMenu();
    }


    //Overkoepelende functie voor alle menu's.
    static void MainMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Hoofdmenu:");
            Console.WriteLine("1. Goalmenu");
            Console.WriteLine("2. Advicemenu");
            Console.WriteLine("3. Activitymenu");
            Console.WriteLine("4. Locationmenu");
            Console.WriteLine("5. Planningmenu");
            Console.WriteLine("6. Progressionmenu");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Kies een optie:");

            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.Clear();
                GoalMenu();
            }
            else if (userInput == "2")
            {
                Console.Clear();
                AdviceMenu();
            }
            else if (userInput == "3")
            {
                Console.Clear();
                ActivityMenu();
            }
            else if (userInput == "4")
            {
                Console.Clear();
                LocationMenu();
            }
            else if (userInput == "5")
            {
                Console.Clear();
                PlanningMenu();
            }
            else if (userInput == "6")
            {
                Console.Clear();
                ProgressionMenu();
            }
            else if (userInput == "7")
            {
                exit = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
            }
        }
    }


    //Hieronder staan de functies van Activity
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
            {
                Console.Clear();
                AskForNewActivity();
            }
            else if (userInput == "2")
            {
                Console.Clear();
                AskForListActivity();
            }
            else if (userInput == "3")
            {
                Console.Clear();
                AskForAdjustActivity();
            }
            else if (userInput == "4")
            {
                Console.Clear();
                AskForDeleteActivity();
            }
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


    //Hieronder staan de functies van goal.
    static void AskForGoal()
    {
        Console.WriteLine("Schrijf de titel van je Goal");
        string name = Console.ReadLine();

        Console.WriteLine("Geef een beschrijving van je Goal");
        string description1 = Console.ReadLine();

        Console.WriteLine("Hoeveel progressie heb je gemaakt aan deze goal?");
        string progression = Console.ReadLine();

        Goal goal = new Goal(name, description1, progression);
        goal.AddGoal();
    }
    static void AskToAdjustGoal()
    {
        Goal goal4 = new Goal();
        foreach (var goal in goal4.GetGoals())
        {
            Console.WriteLine(goal.Name);
        }
        Console.WriteLine("Welk advies wilt u aanpassen? Type de naam");
        string name2 = Console.ReadLine();
        Goal goal3 = new Goal();

        Console.WriteLine(name2);
        goal3.GetGoalByName(name2);

        Console.WriteLine("wat is de naam van je goal");
        goal3.Name = Console.ReadLine();

        Console.WriteLine("Wat is de goal dat je wilt behalen?");
        goal3.Description = Console.ReadLine();

        Console.WriteLine("Wat is het progressieid");
        goal3.Progression = Console.ReadLine();

        goal3.UpdateGoals();
    }
    static void AskForListGoal()
    {
        Goal goal1 = new Goal();
        foreach (var goal in goal1.GetGoals())
        {
            Console.WriteLine(goal.Id);
            Console.WriteLine(goal.Name);
            Console.WriteLine(goal.Description);
        }
    }
    static void AskToRemoveGoalFromList()
    {
        Goal goal5 = new Goal();
        foreach (var goal in goal5.GetGoals())
        {
            Console.WriteLine(goal.Name);
        }

        Console.WriteLine("Wat is de naam van de goal die je wilt verwijderen?");
        string name1 = Console.ReadLine();

        Goal goal2 = new Goal();
        goal2.GetGoalByName(name1);
        goal2.DeleteGoal();
        Goal goal4 = new Goal();
        foreach (var go in goal4.GetGoals())
        {
            Console.WriteLine(go.Name);
        }
    }
    static void GoalMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Wat wil je gaan doen?");
            Console.WriteLine("1. Een doel toevoegen");
            Console.WriteLine("2. Doelen bekijken");
            Console.WriteLine("3. Een doel bijwerken");
            Console.WriteLine("4. Een doel verwijderen");
            Console.WriteLine("5. Terug naar hoofdmenu");
            string userInput = Console.ReadLine();

            if (userInput == "1")
                AskForGoal();
            else if (userInput == "2")
                AskForListGoal();
            else if (userInput == "3")
                AskToAdjustGoal();
            else if (userInput == "4")
                AskToRemoveGoalFromList();
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


    //Hieronder staan de functies voor advies.
    static void AskForAdvice()
    {
        Console.WriteLine("wat is de titel van je advies?");
        string title = Console.ReadLine();

        Console.WriteLine("Wat is het advies dat je wilt geven?");
        string description = Console.ReadLine();

        Advice advice2 = new Advice(title, description);
        advice2.AddAdvice();

        Advice advice1 = new Advice();
        foreach (var adv in advice1.ReadAdvice())
        {
            Console.WriteLine(adv.Title);
            Console.WriteLine(adv.Description);
        }
    }
    static void AskForListAdvice()
    {
        Console.WriteLine("Dit is de lijst met advices");

        Advice adviceList = new Advice();
        foreach (var adv in adviceList.ReadAdvice())
        {
            Console.WriteLine(adv.Title);
            Console.WriteLine(adv.Description);
        }
    }
    static void AskToAdjustAdvice()
    {
        Advice advice3 = new Advice();
        foreach (var adv in advice3.ReadAdvice())
        {
            Console.WriteLine(adv.Title);
        }

        Console.WriteLine("Welk advies wilt u aanpassen? Type de titel.");
        string title1 = Console.ReadLine();

        Console.WriteLine(title1);
        advice3.GetAdviceByTitle(title1);

        Console.WriteLine("wat is de nieuwe titel van je advies.");
        advice3.Title = Console.ReadLine();

        Console.WriteLine("Wat is het nieuwe advies dat je wilt geven?");
        advice3.Description = Console.ReadLine();

        advice3.UpdateAdvice();
    }
    static void AskToRemoveAdvice()
    {
        Console.WriteLine("Welk advies wil je verwijderen? voer het Id in.");
        string title = Console.ReadLine();

        Advice advice = new Advice();
        advice.GetAdviceByTitle(title);
        advice.DeleteAdvice();


        Advice advice3 = new Advice();
        List<Advice> Advices = advice3.ReadAdvice();
        foreach (var ad in Advices)
        {
            Console.WriteLine(ad.Title);
        }
    }
    static void AdviceMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Wat wil je gaan doen?");
            Console.WriteLine("1. Advies toevoegen");
            Console.WriteLine("2. Adviezen bekijken");
            Console.WriteLine("3. Advies aanpassen");
            Console.WriteLine("4. Advies verwijderen");
            Console.WriteLine("5. Terug naar hoofdmenu");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                AskForAdvice();
            }
            else if (userInput == "2")
            {
                AskForListAdvice();
            }
            else if (userInput == "3")
            {
                AskToAdjustAdvice();
            }
            else if (userInput == "4")
            {
                AskToRemoveAdvice();
            }
            else if (userInput == "5")
            {
                exit = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
            }

            // Extra regel om de interface duidelijk te houden na het uitvoeren van een actie
            Console.WriteLine("Druk op Enter om door te gaan...");
            Console.ReadLine();
            Console.Clear();
        }
    }


    //Hieronder staan de functies van location.
    static void AskForNewLocation()
    {
        Console.WriteLine("In Welk lokaal heb je de training?");
        string classroom = Console.ReadLine();

        Console.WriteLine("wat is het adres van de locatie?");
        string address = Console.ReadLine();

        Console.WriteLine("wat is de postcode van de locatie?");
        string zipcode = Console.ReadLine();

        Console.WriteLine("in welke stad is de locatie?");
        string city = Console.ReadLine();


        Location location = new Location(classroom, address, zipcode, city);
        location.Add();
    }
    static void AskForListLocation()
    {
        Console.WriteLine("Locaties");
        Location location = new Location();
        List<Location> locations = location.Read();
        foreach (Location loc in locations)
        {
            Console.WriteLine($"Classroom: {loc.Classroom} \tAddress: {loc.Address} \tZipcode: {loc.Zipcode} \tCity: {loc.City}");
        }
    }
    static void AskForUpdateLocation()
    {
        Console.WriteLine("Voer het Id in die u wilt bijwerken:");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            return;
        }

        Console.WriteLine("Voer het nieuwe klaslokaal in:");
        string classroom = Console.ReadLine();

        Console.WriteLine("Voer het nieuwe adres in:");
        string address = Console.ReadLine();

        Console.WriteLine("Voer de nieuwe postcode in:");
        string zipcode = Console.ReadLine();

        Console.WriteLine("Voer de nieuwe stad in:");
        string city = Console.ReadLine();

        Location location = new Location()
        {
            Id = id,
            Classroom = classroom,
            Address = address,
            Zipcode = zipcode,
            City = city
        };
        location.Update();
        Console.WriteLine("De Locatie met id '" + id + "' is succesvol bijgewerkt.");
    }
    static void AskForDeleteLocation()
    {
        Console.WriteLine("Voer het ID in van de locatie die u wilt verwijderen?");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            return;
        }
        Location location = new Location();
        location.Delete();
    }
    static void LocationMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Wat wil je gaan doen?");
            Console.WriteLine("1. Een Locatie toevoegen");
            Console.WriteLine("2. Locaties bekijken");
            Console.WriteLine("3. Een Locatie bijwerken");
            Console.WriteLine("4. Een Locatie verwijderen");
            Console.WriteLine("5. Terug naar hoofdmenu");
            string userInput = Console.ReadLine();

            if (userInput == "1")
                AskForNewLocation();
            else if (userInput == "2")
                AskForListLocation();
            else if (userInput == "3")
                AskForUpdateLocation();
            else if (userInput == "4")
                AskForDeleteLocation();
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


    //Hieronder staan de functies van planning.
    static void AskForNewPlanning()
    {
        Console.WriteLine("Voer de datum en tijd van de activiteit in (bijv. '2024-04-16 14:30'): ");
        DateTime datetime = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Voer de ID van de activiteit in: ");
        int activityId = int.Parse(Console.ReadLine());

        Planning planning = new Planning(datetime, activityId);
        planning.Add();

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
        Console.WriteLine("Voer de datum en tijd in van de planning die u wilt verwijderen (bijv. '2024-04-18 14:30'):");

        if (DateTime.TryParse(Console.ReadLine(), out DateTime datetime))
        {

        }
        else
        {
            Console.WriteLine("Ongeldige invoer. Voer een geldige datum en tijd in.");
        }
        Planning planning = new Planning();
        planning.Delete();
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


    //Hieronder staan de functies van Progression.
    static void AskForNewProgression()
    {

    }
    static void AskForListProgression()
    {

    }
    static void AskToAdjustProgression()
    {

    }
    static void AskToRemoveProgression()
    {

    }
    static void ProgressionMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Wat wil je gaan doen?");
            Console.WriteLine("1. Een progressie toevoegen");
            Console.WriteLine("2. Progressies bekijken");
            Console.WriteLine("3. Een progressie bijwerken");
            Console.WriteLine("4. Een progressie verwijderen");
            Console.WriteLine("5. Terug naar hoofdmenu");
            string userInput = Console.ReadLine();

            if (userInput == "1")
                AskForNewProgression();
            else if (userInput == "2")
                AskForListProgression();
            else if (userInput == "3")
                AskToAdjustProgression();
            else if (userInput == "4")
                AskToRemoveProgression();
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

