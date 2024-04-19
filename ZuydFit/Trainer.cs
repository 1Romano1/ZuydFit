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
        public string Specialization { get; set; } 
        public List<Advice> Advices { get; set; }
        public List<Training> Trainings { get; set; }

        /*public Trainer(int personalNumber, string password, string specialization, List<Advice> advices, List<Training> trainings) : base(personalNumber, password)

        {
            Specialization = specialization;
            Advices = advices;
            Trainings = trainings;
        }*/
        public Trainer(int personalNumber, string password) : base(personalNumber, password)
        {

        }

        public override bool Login()
        {
            DAL = new DAL();
            return DAL.ValidateTrainer(PersonalNumber, Password);
        }

    }
}
