using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ZuydFit;

namespace ZuydFit
{
    namespace ZuydFit
    {
        public class Planning
        {
            public int Id { get; set; }
            public DateTime DateTime { get; set; }
            public string Activity { get; set; }
            public DAL DAL { get; set; }

            public List<Planning> PlanningsList { get; set; } 
            public Planning(DateTime datetime, string activity)
            {
                DateTime = datetime;
                Activity = activity;
                DAL = new DAL();
            }

            public Planning() { }

            public void AddPlanning()
            {
                Console.WriteLine("Wat is de datum en tijd dat je de activiteit hebt uitgevoerd?");
                DateTime datetime = DateTime.Now;

                Console.WriteLine("Welke activiteit heb je uitgevoerd ?");
                string activity = Console.ReadLine();

                Planning planning = new Planning(datetime, activity);
                DAL.CreatePlanning(planning);
            }

            public void ReadPlanning()
            {
                PlanningsList = new List<Planning>(); 
                DAL.ReadPlanning(PlanningsList);
                Console.WriteLine("Hier zijn de planningen");
                foreach (Planning planning in PlanningsList)
                {
                    Console.WriteLine($"DateTime: {planning.DateTime}\tActivity: {planning.Activity}");
                }
            }

            public void DeletePlanning()
            {
                Console.WriteLine("Welke Planning wilt u verwijderen?");
                string activity = Console.ReadLine();
                DAL.DeletePlanning(activity);
            }
            public void UpdatePlanning()
            {
                Console.WriteLine("Welke activiteit wilt u bijwerken?");
                string activityToUpdate = Console.ReadLine();

                
                Planning planningToUpdate = PlanningsList.FirstOrDefault(p => p.Activity == activityToUpdate);

                if (planningToUpdate != null)
                {
                    Console.WriteLine("Wat is de nieuwe datum en tijd voor deze activiteit?");
                    DateTime newDateTime = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Wat is de nieuwe naam voor deze activiteit?");
                    string newActivity = Console.ReadLine();

                    
                    planningToUpdate.DateTime = newDateTime;
                    planningToUpdate.Activity = newActivity;

                    
                    DAL.UpdatePlanning(planningToUpdate);

                    Console.WriteLine("Planning succesvol bijgewerkt.");
                }
                else
                {
                    Console.WriteLine("Activiteit niet gevonden. Geen planning bijgewerkt.");
                }
            }


        }
    }
    }

