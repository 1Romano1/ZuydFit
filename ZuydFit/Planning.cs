using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Planning
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Activity { get; set; }

        public Planning(int id, DateTime dateTime, string activity)
        {
            Id = id;
            DateTime = dateTime;
            Activity = activity;
        }
    }
}
