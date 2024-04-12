using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Trainer : User
    {
        public int Id { get; set; }
        public List<Advice> Advices { get; set; }
        public List<Training> Trainings { get; set; }

        public Trainer(int id,string firstName, string lastName, int personalNumber, List<Advice> advices, List<Training> trainings) : base( id, firstName, lastName,personalNumber)

        {
            Advices = advices;
            Trainings = trainings;
        }
    }
}
