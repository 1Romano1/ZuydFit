using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Goal
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Progression { get; set; }

        public Goal(int id, string description, string progression)
        {
            Id = id;
            Description = description;
            Progression = progression;
        }
    }
}
