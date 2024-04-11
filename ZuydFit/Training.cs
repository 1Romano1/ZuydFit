using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Training
    {
        public int Id { get; set; }
        public int TimeDuration { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Location> Locations { get; set; }
        public Training(int timeDuration, List<Activity> activities, List<Location> locations) 
        {
            TimeDuration = timeDuration;
            Activities = activities;
            Locations  = locations;
        }
       

    }
}
