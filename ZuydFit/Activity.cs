using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class Activity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Duration { get; set; }

        public int Sets { get; set; }

        public Activity(int id, string description, string name, decimal duration, int sets) 
        {
            Id = id;
            Description = description;
            Name = name;
            Duration = duration;
            Sets = sets;

        }
    }
}
