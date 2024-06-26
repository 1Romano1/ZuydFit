﻿using System;
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

namespace ZuydFit.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Classroom { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public DAL DAL { get; set; }


        List<Location> locations = new List<Location>();


        public Location(string classroom, string address, string zipcode, string city)
        {
            Classroom = classroom;
            Address = address;
            Zipcode = zipcode;
            City = city;
        }

        public Location(string classroom)
        {
            Classroom = classroom;
        }
        public Location() { }


        //Onderstaande functies geven de ingevoerde data door aan de DAL.
        public void Create()
        {
            DAL = new DAL();
            DAL.CreateLocation(this);
        }
        public List<Location> Read()
        {
            DAL = new DAL();
            DAL.ReadLocation(locations);
            return locations;
        }
        public void Update()
        {
            DAL = new DAL();
            DAL.UpdateLocation(this);
        }
        public void Delete()
        {
            DAL = new DAL();
            DAL.DeleteLocation(Classroom);
        }
    }
}