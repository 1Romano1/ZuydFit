using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Trainer
    {
        public int Id { get; set; }
        public List<Advice> Advices { get; set; }
        public List<Training> Trainings { get; set; }

        public Trainer(List<Advice> advices, List<Training> trainings)
        {
            Advices = advices;
            Trainings = trainings;
        }
    }
}
