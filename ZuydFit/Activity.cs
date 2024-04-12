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
                Console.WriteLine(activity.Name + "\t" + activity.Description + "\t" + activity.Duration + "\t" + activity.Sets +"\t");
            }
            Console.WriteLine();
        }

        public void UpdateActivity()
        {

        }

        public void DeleteActivity()
        {
            Console.WriteLine("Voer de naam in van de oefening dat u wilt verwijderen:");
            string Name = Console.ReadLine();
            DAL.DeleteActivity(Name);
        }
    } 
}
