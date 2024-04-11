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

        public Progression(List<Goal> goals, string description)
        {
            Goals = goals;
            Description = description;
        }
    }
}
