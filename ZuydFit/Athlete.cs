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
        public string FavoriteMuscleGroup { get; set; }
        public List<Goal> Goals { get; set; }
        public List<Advice> Advices { get; set; }


        /*public Athlete(int personalNumber, string password,string favoriteMuscleGroup, List<Goal> goals, List<Advice> advices) : base(personalNumber, password)
        {
            FavoriteMuscleGroup = favoriteMuscleGroup;
            Goals = goals;
            Advices = advices;
        }*/
        public Athlete(int personalNumber, string password) : base(personalNumber, password)
        {
         

        }
        
        
        public override bool Login()
        {
            DAL = new DAL();
            return DAL.ValidateAthlete(PersonalNumber, Password);
        }
    }
}