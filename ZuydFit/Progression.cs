using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Progression
    {
        public int Id { get; set; }
        public List<Goal> Goals { get; set; }
        public string Description { get; set; }
        public int Percentage { get; set; }

        public Progression(string description, int percentage)
        {
            Description = "";
            Percentage = "";
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
    }
}
