using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



        public Location(int id, string classroom, string adress, string zipcode, string city, List<Training> trainings) 
        {
            Id = id;
            Classroom = classroom;
            Address = adress;
            Zipcode = zipcode;
            City = city;
            Trainings = trainings;
            

        }   

    }
}

