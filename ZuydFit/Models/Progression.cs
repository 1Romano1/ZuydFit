using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit.Models
{
    public class Progression
    {
        public int Id { get; set; }
        public List<Goal> Goals { get; set; }
        public string Description { get; set; }
        public int Percentage { get; set; }
        public DAL DAL { get; set; }


        public Progression()
        {
            Description = "";
            Percentage = 0;
        }
        public Progression(int id, string description, int percentage)
        {
            Id = id;
            Description = description;
            Percentage = percentage;
        }
        public Progression(string description, int percentage)
        {
            Description = description;
            Percentage = percentage;
        }
        public Progression(int id, List<Goal> goals, string description, int percentage)
        {
            Id = id;
            Goals = goals;
            Description = description;
            Percentage = percentage;
        }


        //Onderstaande functies geven de data uit de program door aan de DAL.
        public void Create()
        {
            DAL = new DAL();
            DAL.CreateProgression(this);
        }
        public List<Progression> Read()
        {
            DAL = new DAL();
            DAL.ReadProgression();
            return DAL.Progressions;
        }
        public void ReadById(int id)
        {
            DAL = new DAL();
            Progression progression = DAL.GetProgressionById(id);
            Id = progression.Id;
            Description = progression.Description;
            Percentage = progression.Percentage;
        }
        public void Update()
        {
            DAL = new DAL();
            DAL.UpdateProgression(this);
        }
        public void Delete()
        {
            DAL = new DAL();
            DAL.DeleteProgression(this);
        }
    }
}
