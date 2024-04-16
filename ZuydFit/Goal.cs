using System;
using System.Collections.Generic;
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

        public Goal() 
        {
            Name = "";
            Description = "";
            Progression = "";   
        }

        public Goal(string name, string description, string progression) 
        {
            Name=name;
            Description=description;
            Progression=progression;
        }
        public Goal(int id, string name, string description, string progression)
        {
            Id = id;
            Name = name;
            Description = description;
            Progression = progression;
        }
    }
}
