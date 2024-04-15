using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Activity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Duration { get; set; }
        public int Sets { get; set; }
        public DAL DAL { get; set; }

        public Activity(string description, string name, decimal duration, int sets)
        {
            this.Name = name;
            this.Description = description;
            this.Duration = duration;
            this.Sets = sets;
            DAL = new DAL();
        }
        public Activity() { }

        public void AddActivity()
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
            DAL.CreateActivity(activity);

            Console.Clear();
            Console.WriteLine("De volgende activiteit is toegevoegd:");
            Console.WriteLine("Naam: " + activity.Name);
            Console.WriteLine("Omschrijving: " + activity.Description);
            Console.WriteLine("Duur per set (in minuten): " + activity.Duration);
            Console.WriteLine("Aantal sets: " + activity.Sets);

        }

        public void ReadActivity()
        {
            List<Activity> activities = new List<Activity>();
            DAL.ReadActivity(activities);

            Console.WriteLine("Activiteit:");
            Console.WriteLine("Naam:\t Beschrijving:\tTijdsduur:\tSet:");
            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.Name + "\t" + activity.Description + "\t" + activity.Duration + "\t" + activity.Sets + "\t");
            }
            Console.WriteLine();
        }

        public void UpdateActivity()
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

            DAL.UpdateActivity(activity);

            Console.WriteLine("De activiteit met id '" + id + "' is succesvol bijgewerkt.");
        }

        public void DeleteActivity()
        {
            Console.WriteLine("Voer de naam in van de oefening dat u wilt verwijderen:");
            string Name = Console.ReadLine();
            DAL.DeleteActivity(Name);
        }

        public void ActivityMenu()
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
                    AddActivity();
                else if (userInput == "2")
                    ReadActivity();
                else if (userInput == "3")
                    UpdateActivity();
                else if (userInput == "4")
                    DeleteActivity();
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
}
