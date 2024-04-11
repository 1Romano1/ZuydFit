using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Athlete 
    { 
        public List<Goal> Goals { get; set; }
        public List<Advice> Advices { get; set; }


        public Athlete(List<Goal> goals, List<Advice> advices) 
        {
            Goals = goals;
            Advices = advices;
        }

    }
}
