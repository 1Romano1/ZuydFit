using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydFit.ZuydFit;

namespace ZuydFit
{
    public class Trainer : User
    {
        public int Id { get; set; }
        public List<Advice> Advices { get; set; }
        public List<Training> Trainings { get; set; }

        public Trainer(int id, string firstName, string lastName, int personalNumber, List<Advice> advices, List<Training> trainings, string password) : base(id, firstName, lastName,personalNumber, password)

        {
            Advices = advices;
            Trainings = trainings;
        }
    }
}
