using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Advice
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Trainer { get; set; }
        public string Athlete { get; set; }

        public Advice(string description, string trainer, string athlete) 

        {
            Description = description;
            Trainer = trainer;
            Athlete = athlete;
            
        }
    }
}
