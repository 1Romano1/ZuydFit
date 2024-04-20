using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Activity> Activities { get; set; } = new List<Activity>();
        public DAL DAL { get; set; }


        List<Training> training = new List<Training>();
        

        public Training(string name)
        {
            Name = name;
        }
        public Training(string name, List<Activity> activities)
        {
            Name = name;
            Activities = activities;
        }
        public Training() { }


        //Onderstaande functies geven de data uit de program door aan de DAL.
        public void Create()
        {
            
            DAL = new DAL();
            DAL.CreateTraining(this);

        }
        public List<Training> Read()
        {
            DAL = new DAL();
            DAL.ReadTraining(training);
            return training;
        }
        public void Update()
        {
            DAL = new DAL();
            DAL.UpdateTraining(this);
        }
        public void Delete()
        {
            DAL = new DAL();
            DAL.DeleteTraining(Name);
        }
    }
}