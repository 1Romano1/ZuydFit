using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Advice
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Trainer { get; set; }
        public string Athlete { get; set; }
        public DAL DAL { get; set; }

        public Advice(string title,string description) 
        {
            Title = title;
            Description = description;
            DAL = new DAL();
        }

        public Advice() { }

        public void AddAdvice(Advice advice)
        {
            DAL.CreateAdvice(advice);  
        }
        public void ReadAdvice() 
        {
            
        }
        public void UpdateAdvice()
        {

        }
        public void DeleteAdvice(Advice  advice) 
        {
            DAL.DeleteAdvice(advice);
        }

    }
}
