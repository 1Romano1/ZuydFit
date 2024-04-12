using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Athlete : User
    { 
        public List<Goal> Goals { get; set; }
        public List<Advice> Advices { get; set; }


        public Athlete(int id, string firstName, string lastName, int personalNumber, List<Goal> goals, List<Advice> advices) : base(id, firstName,lastName, personalNumber)
        {
            Goals = goals;
            Advices = advices;
        }

    }
}
