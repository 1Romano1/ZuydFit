using System;
using System.Linq;
using ZuydFit.Models;
using ZuydFit.ZuydFit;

public class Program
{
    static void Main(string[] args)
    {
        ChooseOption();
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
            Console.WriteLine("7. Trainingmenu");
            Console.WriteLine("8. Exit");
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
                Console.Clear();
                TrainingMenu();
            }
            else if (userInput == "8")
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
        activity.Create();

        Console.Clear();
        Console.WriteLine("De volgende activiteit is toegevoegd:");
        Console.WriteLine("Naam: " + activity.Name);
        Console.WriteLine("Omschrijving: " + activity.Description);
        Console.WriteLine("Duur per set (in minuten): " + activity.Duration);
        Console.WriteLine("Aantal sets: " + activity.Sets);
    }
    static List<Activity> AskForListActivity()
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

        return activities;
    }
    static void AskToAdjustActivity()
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
    static void AskToDeleteActivity()
    {
        AskForListActivity();
        Console.WriteLine("Voer de naam in van de oefening dat u wilt verwijderen:");
        string Name = Console.ReadLine();
        Activity activity = new Activity(Name);
        activity.Delete();
        Console.WriteLine("De activiteit" + Name + "is succes vol verwijderd");
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
                AskToAdjustActivity();
            }
            else if (userInput == "4")
            {
                Console.Clear();
                AskToDeleteActivity();
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
    static void AskForNewGoal()
    {
        Console.WriteLine("Schrijf de titel van je Goal");
        string name = Console.ReadLine();

        Console.WriteLine("Geef een beschrijving van je Goal");
        string descriptionadd = Console.ReadLine();

        Console.WriteLine("Hoeveel progressie heb je gemaakt aan deze goal?");
        string progression = Console.ReadLine();

        Goal goaladd = new Goal(name, descriptionadd, progression);
        goaladd.Create();
    }
    static void AskForListGoal()
    {
        Goal goalRead = new Goal();
        
        foreach (var goal in goalRead.Read())
        {
            Console.WriteLine(goal.Id);
            Console.WriteLine(goal.Name);
            Console.WriteLine(goal.Description);
        }
    }
    static void AskToAdjustGoal()
    {
        Goal goalUpdate = new Goal();
        
        foreach (var goal in goalUpdate.Read())
        {
            Console.WriteLine(goal.Name);
        }
        Console.WriteLine("Welk advies wilt u aanpassen? Type de naam");
        string nameUpdate = Console.ReadLine();
        Goal goalUp = new Goal();

        Console.WriteLine(nameUpdate);
        goalUp.ReadByName(nameUpdate);

        Console.WriteLine("wat is de naam van je goal");
        goalUp.Name = Console.ReadLine();

        Console.WriteLine("Wat is de goal dat je wilt behalen?");
        goalUp.Description = Console.ReadLine();

        Console.WriteLine("Wat is het progressieid");
        goalUp.Progression = Console.ReadLine();

        goalUp.Update();
    }
    static void AskToDeleteGoal()
    {
        Goal goalDelete = new Goal();
        foreach (var goal in goalDelete.Read())
        {
            Console.WriteLine(goal.Name);
        }

        Console.WriteLine("Wat is de naam van de goal die je wilt verwijderen?");
        string nameDelete = Console.ReadLine();

        Goal goalDel = new Goal();
        goalDel.ReadByName(nameDelete);
        goalDel.Delete();
        Goal goalDele = new Goal();
        
        foreach (var go in goalDele.Read())
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
                AskForNewGoal();
            else if (userInput == "2")
                AskForListGoal();
            else if (userInput == "3")
                AskToAdjustGoal();
            else if (userInput == "4")
                AskToDeleteGoal();
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
    static void AskForNewAdvice()
    {
        Console.WriteLine("wat is de titel van je advies?");
        string title = Console.ReadLine();

        Console.WriteLine("Wat is het advies dat je wilt geven?");
        string description = Console.ReadLine();

        Advice adviceAdd = new Advice(title, description);
        adviceAdd.Create();

        Advice adviceAd = new Advice();
        foreach (var adv in adviceAd.Read())
        {
            Console.WriteLine(adv.Title);
            Console.WriteLine(adv.Description);
        }
    }
    static void AskForListAdvice()
    {
        Console.WriteLine("Dit is de lijst met advices");

        Advice adviceList = new Advice();
        
        foreach (var adv in adviceList.Read())
        {
            Console.WriteLine(adv.Title);
            Console.WriteLine(adv.Description);
        }
    }
    static void AskToAdjustAdvice()
    {
        Advice adviceUpdate = new Advice();
        
        foreach (var adv in adviceUpdate.Read())
        {
            Console.WriteLine(adv.Title);
        }

        Console.WriteLine("Welk advies wilt u aanpassen? Type de titel.");
        string titleUpdate = Console.ReadLine();

        Console.WriteLine(titleUpdate);
        adviceUpdate.ReadByTitle(titleUpdate);

        Console.WriteLine("wat is de nieuwe titel van je advies.");
        adviceUpdate.Title = Console.ReadLine();

        Console.WriteLine("Wat is het nieuwe advies dat je wilt geven?");
        adviceUpdate.Description = Console.ReadLine();

        adviceUpdate.Update();
    }
    static void AskToDeleteAdvice()
    {
        Console.WriteLine("Welk advies wil je verwijderen? voer het Id in.");
        string title = Console.ReadLine();

        Advice advice = new Advice();
        advice.ReadByTitle(title);
        advice.Delete();


        Advice adviceDelete = new Advice();
        List<Advice> Advices = adviceDelete.Read();
        
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
                AskForNewAdvice();
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
                AskToDeleteAdvice();
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
        location.Create();
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
    static void AskToAdjustLocation()
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
    static void AskToDeleteLocation()
    {
        AskForListLocation();
        Console.WriteLine("Voer het klaslokaal in van de locatie die u wilt verwijderen?");
        string Classroom = Console.ReadLine();
        
        Location location = new Location(Classroom);
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
                AskToAdjustLocation();
            else if (userInput == "4")
                AskToDeleteLocation();
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
        planning.Create();

        Console.Clear();
        Console.WriteLine("Dit volgende planning is gelogd.");
        Console.WriteLine("Datum en Tijd:" + planning.DateTime);
        Console.WriteLine("Uitgevoerde activiteit:" + planning.ActivityId);
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
    static void AskToAdjustPlanning()
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
    static void AskToDeletePlanning()
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
                AskToAdjustPlanning();
            else if (userInput == "4")
                AskToDeletePlanning();
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
        Console.WriteLine("wat is de beschrijving van je Progression?");
        string description = Console.ReadLine();

        Console.WriteLine("Wat is de progress die je gemaakt hebt in prozenten?");
        int percentage = Int32.Parse(Console.ReadLine());

        Progression progression = new Progression(description, percentage);
        progression.Create();

        Progression progressionAdd = new Progression();
        foreach (var prog in progressionAdd.Read())
        {
            Console.WriteLine(prog.Description);
            Console.WriteLine(prog.Percentage);
        }
    }
    static void AskForListProgression()
    {
        Console.WriteLine("Dit is de lijst met Progressions");

        Progression ProgressionList = new Progression();
        foreach (var pro in ProgressionList.Read())
        {
            Console.WriteLine(pro.Description);
            Console.WriteLine(pro.Percentage);
        }
    }
    static void AskToAdjustProgression()
    {
        Progression progressionAdjsut = new Progression();
        foreach (var progr in progressionAdjsut.Read())
        {
            Console.WriteLine(progr.Id);
            Console.WriteLine(progr.Description);
            Console.WriteLine(progr.Percentage);
        }

        Console.WriteLine("Welke Progress wilt u aanpassen? Type het Id.");
        int id = Int32.Parse(Console.ReadLine());

        Console.WriteLine(id);
        progressionAdjsut.ReadById(id);

        Console.WriteLine("wat is de nieuwe beschrijving van je progressie.");
        progressionAdjsut.Description = Console.ReadLine();

        Console.WriteLine("Wat is het nieuwe percentage wat je wilt geven voor de progressie?");
        progressionAdjsut.Percentage = Int32.Parse(Console.ReadLine());

        progressionAdjsut.Update();
    }
    static void AskToDeleteProgression()
    {
        Console.WriteLine("Welke progressie wil je verwijderen? voer het Id in.");
        int Id = Int32.Parse(Console.ReadLine());

        Progression progressiondelete = new Progression();
        progressiondelete.ReadById(Id);
        progressiondelete.Delete();


        Progression progression = new Progression();
        List<Progression> progressions = progression.Read();
        
        foreach (var progre in progressions)
        {
            Console.WriteLine(progre.Id);
            Console.WriteLine(progre.Description);
            Console.WriteLine(progre.Percentage);
        }
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
                AskToDeleteProgression();
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


    //Hieronder komen de functies van training.
    static void AskForNewTraining()
    {
        Console.WriteLine("Voer de naam in van de nieuwe training:");
        string name = Console.ReadLine();

        Training training = new Training(name);
        AddExistingActivityToTraining(training);
        training.Create();
    }
    static void AskForListTraining()
    {
        Console.WriteLine("Trainingen");
        Training training = new Training();
        List<Training> trainings = training.Read();
        
        foreach (Training tra in trainings)
        {
            Console.WriteLine($"Name: {tra.Name}");
        }
    }
    static void AskToAdjustTraining()
    {
        Console.WriteLine("Voer de id van de activiteit in die u wilt gaan bijwerken:");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            return;
        }

        Console.WriteLine("Voer de nieuwe naam in:");
        string name = Console.ReadLine();

        Training training = new Training
        {
            Id = id,
            Name = name
        };
        
        training.Update();
        Console.WriteLine("De activiteit met id '" + id + "' is succesvol bijgewerkt.");
    }
    static void AskToDeleteTraining()
    {
        Console.WriteLine("Voer de naam in van de training die je wilt verwijderen:");
        string trainingName = Console.ReadLine();

        Training training = new Training(trainingName);

        training.Delete();
        Console.WriteLine($"Training '{trainingName}' is succesvol verwijderd.");
    }
    static void AddExistingActivityToTraining(Training training)
    {
        bool addactivity = true;
        while (addactivity)
        {
            AskForListActivity();
            Console.WriteLine("Voer de naam in van de activiteit die u aan de training wilt toevoegen:");
            string activityName = Console.ReadLine();
            
            List<Activity> activities = AskForListActivity();
            Console.Clear();   
            // Zoek naar een activiteit in de lijst van activiteiten met een naam die overeenkomt met de opgegeven activiteitnaam, 
            // waarbij hoofdletters en spaties niet van belang zijn.
            Activity selectedActivity = activities.Find(activity => activity.Name.Trim().Equals(activityName, StringComparison.OrdinalIgnoreCase));

            if (selectedActivity != null)
            {
                Console.WriteLine($"De activiteit '{selectedActivity.Name}' is succesvol toegevoegd aan de training.");
            }
            else
            {
                Console.WriteLine($"Geen activiteit gevonden met de naam '{activityName}'. De activiteit wordt niet toegevoegd aan de training.");
            }

            Console.WriteLine("Is er nog een activiteit dat u wilt toevoegen? (Y/N):");
            string choice = Console.ReadLine();
            Console.Clear();

            if (choice == "N" || choice == "n")
            {
                addactivity = false;
                Console.Clear();
            }
        }
        
    }
    static void TrainingMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Wat wil je gaan doen?");
            Console.WriteLine("1. Een training toevoegen");
            Console.WriteLine("2. Trainingen bekijken");
            Console.WriteLine("3. Een training bijwerken");
            Console.WriteLine("4. Een training verwijderen");
            Console.WriteLine("5. Terug naar hoofdmenu");
            
            string userInput = Console.ReadLine();
            if (userInput == "1")
                AskForNewTraining();
            else if (userInput == "2")
                AskForListTraining();
            else if (userInput == "3")
                AskToAdjustTraining();
            else if (userInput == "4")
                AskToDeleteTraining();
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


    //Functies voor de Login.
    static bool PerformLogin(int personalNumber, string password)
    {
        Athlete athlete = new Athlete(personalNumber, password);
        bool isAthleteLoggedIn = athlete.Login();

        Trainer trainer = new Trainer(personalNumber, password);
        bool isTrainerLoggedIn = trainer.Login();

        if (isAthleteLoggedIn)
        {
            Console.WriteLine("Welkom, atleet!");
            return true;
        }
        else if (isTrainerLoggedIn)
        {
            Console.WriteLine("Welkom, trainer!");
            return true;
        }
        else
        {
            Console.WriteLine("Ongeldige inloggegevens. Probeer het opnieuw.");
            return false;
        }
    }
    static void ChooseOption()
    {
        Console.WriteLine("Maak een keuze:");
        Console.WriteLine("1. Inloggen als atleet");
        Console.WriteLine("2. Inloggen als trainer");
        Console.WriteLine("3. Testen zonder in te loggen.");

        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            PerformAthleteLogin();
        }
        else if (choice == 2)
        {
            PerformTrainerLogin();
        }
        else if (choice == 3)
        {
            MainMenu();
        }
        else
        {
            Console.WriteLine("Ongeldige keuze. Probeer het opnieuw.");
        }
    }
    static void PerformAthleteLogin()
    {
        bool isLoggedIn = false;

        while (!isLoggedIn)
        {
            Console.WriteLine("Voer hier je nummer in:");
            int personalNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Voer hier je wachtwoord in:");
            string password = Console.ReadLine();

            Athlete athlete = new Athlete(personalNumber, password);
            isLoggedIn = athlete.Login();

            if (isLoggedIn)
            {
                Console.WriteLine("Welkom, atleet!");
                AtletheMenu();
            }
            else
            {
                Console.WriteLine("Ongeldige inloggegevens. Probeer het opnieuw.");
            }
        }
    }
    static void PerformTrainerLogin()
    {
        bool isLoggedIn = false;

        while (!isLoggedIn)
        {
            Console.WriteLine("Voer hier je nummer in:");
            int personalNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Voer hier je wachtwoord in:");
            string password = Console.ReadLine();

            Trainer trainer = new Trainer(personalNumber, password);
            isLoggedIn = trainer.Login();

            if (isLoggedIn)
            {
                Console.WriteLine("Welkom, trainer!");
                TrainerMenu();
            }
            else
            {
                Console.WriteLine("Ongeldige inloggegevens. Probeer het opnieuw.");
            }
        }
    }
    static void AtletheMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Hoofdmenu:");
            Console.WriteLine("1. Goalmenu");
            Console.WriteLine("2. Progressionmenu");
            Console.WriteLine("3. Locatie inzien");
            Console.WriteLine("4. Activiteit bekijken");
            Console.WriteLine("5. Training bekijken");
            Console.WriteLine("6. Exit");

            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Console.Clear();
                GoalMenu();
            }
            else if (userInput == "2")
            {
                Console.Clear();
                ProgressionMenu();
            }
            else if (userInput == "3")
            {
                Console.Clear();
                AskForListLocation();
            }
            else if (userInput == "4")
            {
                Console.Clear();
                AskForListActivity();
            }
            else if (userInput == "5")
            {
                Console.Clear();
                AskForListTraining();
            }
            else if (userInput == "6")
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
    static void TrainerMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Hoofdmenu:");
            Console.WriteLine("1. Doelen inzien");
            Console.WriteLine("2.Advies geven");
            Console.WriteLine("4.Locatie bekijken.");
            Console.WriteLine("2. ProgressionMenu");
            Console.WriteLine("3. ActivityMenu");
            Console.WriteLine("4. Trainingmenu");
            Console.WriteLine("5. Exit");

            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Console.Clear();
                AskForListGoal();
            }
            else if (userInput == "2")
            {
                Console.Clear();
                AskForNewAdvice();
            }
            else if (userInput == "3")
            {
                Console.Clear();
                AskForListLocation();
            }
            else if (userInput == "4")
            {
                Console.Clear();
                ProgressionMenu();
            }
            else if (userInput == "5")
            {
                Console.Clear();
                ActivityMenu();
            }
            else if (userInput == "6")
            {
                Console.Clear();
                TrainingMenu();
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
}