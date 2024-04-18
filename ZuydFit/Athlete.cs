using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydFit.ZuydFit;

namespace ZuydFit
{
    public class Athlete : User
    { 
        public List<Goal> Goals { get; set; }
        public List<Advice> Advices { get; set; }


        public Athlete(int id, string firstName, string lastName, int personalNumber, List<Goal> goals, List<Advice> advices, string password) : base(id, firstName,lastName, personalNumber, password)
        {
            Goals = goals;
            Advices = advices;
        }

    }
}
