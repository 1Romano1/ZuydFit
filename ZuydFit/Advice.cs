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

        public Advice()
        {
            Title = "";
            Description = "";
        }

        public Advice(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public Advice(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }


        //Onderstaande functies geven de ingevoerde data door aan de DAL.
        public void AddAdvice()
        {
            DAL = new DAL();
            DAL.CreateAdvice(this); 
        }
        public List<Advice> ReadAdvice()
        {
            DAL = new DAL();
            DAL.ReadAdvice();
            return DAL.Advices;
        }
        public void GetAdviceByTitle(string title)
        {
            DAL = new DAL();
            List<Advice> advices = DAL.GetAdviceByTitle(title);
            for (int i = 0; i < advices.Count; i++)
            {
                this.Id = advices[i].Id;
                this.Title = advices[i].Title;
                this.Description = advices[i].Description;
            }
            
        }
        public void UpdateAdvice()
        {
            DAL = new DAL();
            DAL.UpdateAdvice(this);
        }
        public void DeleteAdvice() 
        {
            DAL = new DAL();
            DAL.DeleteAdvice(this);
        }

    }
}
