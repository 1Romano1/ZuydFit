using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ZuydFit
{
    public class Location
    {
        public int Id { get; set; }
        public string Classroom { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public List<Training> Trainings { get; set; }

        List<Location> locations = new List<Location>();

        public Location(string classroom, string adress, string zipcode, string city, List<Training> trainings)
        { 
            Classroom = classroom;
            Address = adress;
            Zipcode = zipcode;
            City = city;
            Trainings = trainings;
        }

        public Location() { }

        public void CreateLocation()
        {
            Console.WriteLine("In Welk lokaal heb je de training?");
            string classroom = Console.ReadLine();

            Console.WriteLine("wat is het adres van de locatie?");
            string adress = Console.ReadLine();

            Console.WriteLine("wat is de postcode van de locatie?");
            string zipcode = Console.ReadLine();

            Console.WriteLine("in welke stad is de locatie?");
            string city = Console.ReadLine();

            Location newLocation = new Location(classroom, adress, zipcode, classroom, Trainings);
            locations.Add(newLocation);

            DisplayLocations();
        }

        public void DisplayLocations()
        {
            Console.WriteLine("List of Locations:");
            foreach (var location in locations)
            {
                Console.WriteLine($"Classroom: {location.Classroom}, Address: {location.Address}, Zipcode: {location.Zipcode}, City: {location.City}");
            }
        }


        public void ReadLocation()
        {


        }

        public void DeleteLocation()
        {


        }
        
        public void UpdateLocation()
        {

        }


    }
}
