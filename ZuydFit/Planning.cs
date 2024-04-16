using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ZuydFit;

    namespace ZuydFit
    {
    public class Planning
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string ActivityId { get; set; }
        public DAL DAL { get; set; }

        public List<Planning> PlanningsList { get; set; }
        public Planning(DateTime datetime, string activityId)
        {
            DateTime = datetime;
            ActivityId = activityId;

        }




        public void AddPlanning()
        {
            try
            {
                Console.WriteLine("Voer de datum en tijd van de activiteit in (bijv. '2024-04-16 14:30'): ");
                DateTime datetime = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Voer de activiteit in: ");
                string activity = Console.ReadLine();

                Planning planning = new Planning(datetime, activity);
                DAL.CreatePlanning(planning);

                Console.WriteLine("Planning succesvol toegevoegd.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Er is een fout opgetreden bij het toevoegen van de planning: " + ex.Message);
            }
        }

        public void ReadPlanning()
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
        }
    }
}

