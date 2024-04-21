using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZuydFit.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public int Sets { get; set; }
        public DAL DAL { get; set; }


        List<Activity> activities = new List<Activity>();


        public Activity(string name, string description, decimal duration, int sets)
        {
            Name = name;
            Description = description;
            Duration = duration;
            Sets = sets;
        }

        public Activity(string name)
        {
            Name = name;  
        }
        public Activity() { }



        //Onderstaande functies geven de ingevoerde data door aan de DAL.
        public void Create()
        {
            DAL = new DAL();
            DAL.CreateActivity(this);
        }
        public List<Activity> Read()
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