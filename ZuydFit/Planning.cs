using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using ZuydFit;

    namespace ZuydFit
    {
    public class Planning
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ActivityId { get; set; }
        public DAL DAL { get; set; }

        List <Planning> plannings = new List<Planning>();
        public Planning(int id, DateTime datetime, int activityId)
        {
            this.Id = id;
            this.DateTime = datetime;
            this.ActivityId = activityId;

        }
        public Planning(DateTime datetime, int activityId)
        {
            this.DateTime = datetime;
            this.ActivityId = activityId;
        }
        public Planning() 
        {
        
        
        }

        public void AddPlanning()
        {

            DAL = new DAL();
            DAL.CreatePlanning(this);

        
        }

        public List<Planning> Read()
        {
            DAL = new DAL();
            DAL.ReadPlanning(plannings);
            return plannings;
        }

        public void Update()
        {
            DAL = new DAL();
            DAL.UpdatePlanning(this);
        }

        public void Delete()
        {
            DAL = new DAL();
            DAL.DeletePlanning(Id);
        }
        /*public void ReadPlanning()
        {
            PlanningsList = new List<Planning>();
            DAL.ReadPlanning(PlanningsList);
            Console.WriteLine("Hier zijn de planningen");
            foreach (Planning planning in PlanningsList)
            {
                Console.WriteLine($"DateTime: {planning.DateTime}\tActivity: {planning.ActivityId}");
            }
        }

        public void DeletePlanning()
        {
            Console.WriteLine("Welke Planning wilt u verwijderen?");
            string activityId = Console.ReadLine();
            
        }
        public void UpdatePlanning()
        {
            Console.WriteLine("Welke activiteit wilt u bijwerken?");
            string activityToUpdate = Console.ReadLine();


            Planning planningToUpdate = PlanningsList.FirstOrDefault(p => p.ActivityId == activityToUpdate);

            if (planningToUpdate != null)
            {
                Console.WriteLine("Wat is de nieuwe datum en tijd voor deze activiteit?");
                DateTime newDateTime = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Wat is de nieuwe naam voor deze activiteit?");
                string newActivityId = Console.ReadLine();


                planningToUpdate.DateTime = newDateTime;
                planningToUpdate.ActivityId = newActivityId;


                //DAL.UpdatePlanning(planningToUpdate);

                Console.WriteLine("Planning succesvol bijgewerkt.");
            }
            else
            {
                Console.WriteLine("Activiteit niet gevonden. Geen planning bijgewerkt.");
            }
        }*/
    }
}

