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

        public Advice(int id, string description, string owner, string trainer, string athlete ) 
        {
            Id = id;
            Description = description;
            Trainer = trainer;
            Athlete = athlete;
            
        }
    }
}
