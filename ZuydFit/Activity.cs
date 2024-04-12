using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public int Sets { get; set; }
        public DAL DAL { get; set; }

        public Activity(string name, string description, decimal duration, int sets)
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
            
        }

        public void ReadActivity()
        {

        }

        public void UpdateActivity()
        {

        }

        public void DeleteActivity()
        {
            Console.WriteLine("Voer de naam in van de oefening dat u wilt verwijderen:");
            int Id = int.Parse(Console.ReadLine());

            DAL.DeleteActivity(Id);
        }
    } 
}
