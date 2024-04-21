using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZuydFit.Models
{
    public class Planning
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ActivityId { get; set; }
        public DAL DAL { get; set; }


        List<Planning> plannings = new List<Planning>();
        public Planning(int id, DateTime datetime, int activityId)
        {
            Id = id;
            DateTime = datetime;
            ActivityId = activityId;

        }
        public Planning(DateTime datetime, int activityId)
        {
            DateTime = datetime;
            ActivityId = activityId;
        }
        public Planning()
        {


        }


        //Onderstaande functies geven de data uit de program door aan de DAL.
        public void Create()
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
    }
}