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
        public List<Activity> Activities { get; set; }
        public Training(int Id, List<Activity> activities) 
        {
            Id = Id;
            Activities = activities;
        }
    }
}
