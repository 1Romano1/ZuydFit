﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        List <Activity> activities = new List<Activity>();

        public Activity(string description, string name, decimal duration, int sets)
        {
            this.Name = name;
            this.Description = description;
            this.Duration = duration;
            this.Sets = sets;
        }
        public Activity() { }

        //Doorgeef functies van program naar DAL.  
        public void Add()
        {
            DAL = new DAL();
            DAL.CreateActivity(this);
        }

        public List <Activity> Read()
        {
            DAL = new DAL();
            DAL.ReadActivity(activities);
            return activities;
        }

        public void Update()
        {
            DAL = new DAL();
            DAL.UpdateActivity(this);
        }

        public void Delete()
        {
            DAL = new DAL();
            DAL.DeleteActivity(Name);
        }
    }
}
