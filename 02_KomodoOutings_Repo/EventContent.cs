using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoOutings_Repo
{
 
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert,
        Picnic
    }
      
    public class EventContent
    {
        public string TypeOfEvent { get; set; }
        public string DateOfEvent { get; set; }
        public int NumberOfPeopleThatAttend { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalCostOfEvent { get; set; }

        public EventContent() { }

        public EventContent(string typeOfEvent, string dateOfEvent, int numberOfPeopleThatAttend, double costPerPerson, double totalCostOfEvent)
        {
            TypeOfEvent = typeOfEvent;
            DateOfEvent = dateOfEvent;
            NumberOfPeopleThatAttend = numberOfPeopleThatAttend;
            CostPerPerson = costPerPerson;
            TotalCostOfEvent = totalCostOfEvent;
        }
    }
}
