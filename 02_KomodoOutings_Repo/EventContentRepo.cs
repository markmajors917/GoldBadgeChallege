using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoOutings_Repo
{
    public class EventContentRepo
    {
        private List<EventContent> _listOfContent = new List<EventContent>();
        
        //Create
        public void AddContentToList(EventContent content)
        {
            _listOfContent.Add(content);
        }

        //Read
        public List<EventContent> GetContentList()
        {
            return _listOfContent;
        }


        //Update
        public bool UpdateExistingContent(string originalTypeOfEvent, EventContent newContent)
        {
            //Find the Content
            EventContent oldContent = GetContentByTypeOfEvent(originalTypeOfEvent);


            //Update the content
            if(oldContent != null)
            {
                oldContent.TypeOfEvent = newContent.TypeOfEvent;
                oldContent.DateOfEvent = newContent.DateOfEvent;
                oldContent.NumberOfPeopleThatAttend = newContent.NumberOfPeopleThatAttend;
                oldContent.CostPerPerson = newContent.CostPerPerson;
                oldContent.TotalCostOfEvent = newContent.TotalCostOfEvent;

                return true;
            }
            else
            {
                return false;
            }
        }


        //Delete
        public bool RemoveContentFromList(string typeOfEvent)
        {
            EventContent content = GetContentByTypeOfEvent(typeOfEvent);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfContent.Count;
            _listOfContent.Remove(content);

            if(initialCount > _listOfContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method
        public EventContent GetContentByTypeOfEvent(string typeOfEvent)
        {
            foreach (EventContent content in _listOfContent)
            {
                if (content.TypeOfEvent.ToLower() == typeOfEvent.ToLower())
                {
                    return content; 
                }
            }

            return null;
        }
        
    }
}
