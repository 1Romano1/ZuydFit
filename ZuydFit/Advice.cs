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
        public DAL DAL { get; set; }

        public Advice(string description) 
        {
            Description = description;
            DAL = new DAL();
        }

        public Advice() { }

        public static void AddAdvice()
        {
            Console.WriteLine("Wat is het advies dat je wilt geven?");
            string Description = Console.ReadLine();
            Advice advice = new Advice(Description);
            DAL.CreateAdvice(advice);
            
        }
        public void ReadAdvice() 
        {
        
        }
        public void UpdateAdvice()
        {

        }
        public void DeleteAdvice() 
        {
        
        }

    }
}
