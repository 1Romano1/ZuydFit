using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Progression { get; set; }
        public List<Goal> Goals { get; set; } = new List<Goal>();
        public DAL DAL { get; set; }

        public Goal() 
        {
            Name = "";
            Description = "";
            Progression = "";   
        }

        public Goal(int id, string name, string description) 
        {
            Id = id;
            Name=name;
            Description=description;
        }
        public Goal( string name, string description, string progression)
        {
            Name = name;
            Description = description;
            Progression = progression;
        }
        public Goal(int id, string name, string description, string progression)
        {
            Id = id;
            Name = name;
            Description = description;
            Progression = progression;
        }
        public void AddGoal() 
        {
            DAL = new DAL();
            DAL.CreateGoal(this);
        }
        public List<Goal> GetGoals() 
        {
            DAL = new DAL();
            DAL.ReadGoal();
            return DAL.Goals;
        }
        public void UpdateGoals() 
        {
            DAL = new DAL();
            DAL.UpdateGoal(this);      
        }
        public void DeleteGoal() 
        {
            DAL = new DAL();
            DAL.DeleteGoal(this);       
        }
        public void GetGoalByName(string name)
        {
            DAL = new DAL();
            Goal goal = DAL.GetGoalByName(name);
            this.Id = goal.Id;
            this.Name = goal.Name;
            this.Description = goal.Description;
        }
    }
}
