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

        public Planning(DateTime dateTime, string activity)
        {
            DateTime = dateTime;
            Activity = activity;
        }
    }
}
