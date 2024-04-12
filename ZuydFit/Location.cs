using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Channels;
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
        public DAL DAL { get; set; }

        List<Location> locations = new List<Location>();

        public Location(string classroom, string address, string zipcode, string city)//List<Training> trainings)
        {
            Classroom = classroom;
            Address = address;
            Zipcode = zipcode;
            City = city;
            //Trainings = trainings;
            DAL = new DAL();
        }

        public Location() { }

        public void AddLocation()
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
            DAL.CreateLocation(location);

           

        }

    
        public void ReadLocation()
        {
            List<Location> locations = new List<Location>();
            DAL.ReadLocation(locations);
            
            Console.WriteLine("Locaties");

            foreach (Location location in locations)
            {
                
                Console.WriteLine($"Classroom: {location.Classroom} \tAddress: {location.Address} \tZipcode: {location.Zipcode} \tCity: {location.City}");
            }
            
        }
        


        public void DeleteLocation()
        {
            Console.WriteLine("Welke locatie wilt u verwijderen?");
            string Classroom = Console.ReadLine();
            DAL.DeleteLocation(Classroom);

        }
        
        public void UpdateLocation()
        {

        }


    }
}
