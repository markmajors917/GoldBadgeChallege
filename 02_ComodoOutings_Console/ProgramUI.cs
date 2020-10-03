using _02_KomodoOutings_Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ComodoOutings_Console
{
    class ProgramUI
    {
        private EventContentRepo _contentRepo = new EventContentRepo();
        //Method that runs/start the application
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        //Menu 
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //Display options to user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create new Content\n" +
                    "2. View All Content\n" +
                    "3. View Content By Event\n" +
                    "4. Update Exiting Content\n" +
                    "5. Delete Existing Content\n" +
                    "6. Exit");

                //Get the users input
                string input = Console.ReadLine();

                //Evaluate the users input and act
                switch (input)
                {
                    case "1":
                        //Create new content
                        CreateNewContent();
                        break;
                    case "2":
                        //View All Content
                        DisplayAllContent();
                        break;
                    case "3":
                        //View Content By Event
                        DisplayContentbyEvent();
                        break;
                    case "4":
                        //Update Existing Content
                        UpdateExistingContent();
                        break;
                    case "5":
                        //Delete Existing Content
                        DeleteExistingContent();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewContent()
        {
            Console.Clear();
            EventContent newContent = new EventContent();

            //Type of event
            Console.WriteLine("Enter the event type (Golf, Bowling, Concert, Sporting event, etc:");
            newContent.TypeOfEvent = Console.ReadLine();
              
            //Date of event
            Console.WriteLine("Enter the date of the event (01/08/2025:");
            newContent.DateOfEvent = Console.ReadLine();

            //Number of people that will attend
            Console.WriteLine("Enter the number of people that will attend the event");
            string peopleAsString = Console.ReadLine();
            newContent.NumberOfPeopleThatAttend = int.Parse(peopleAsString);

            //Cost per person
            Console.WriteLine("Eneter the cost per person (123.45):");
            string costAsString = Console.ReadLine();
            newContent.CostPerPerson = double.Parse(costAsString);

            //Total cost of event
            Console.WriteLine("Enter the total cost of the event (1234.56)");
            string totalAsString = Console.ReadLine();
            newContent.TotalCostOfEvent = double.Parse(totalAsString);
        } 

        //View Current EventContent that is saved
        private void DisplayAllContent()
        {
            List<EventContent> listOfContent = _contentRepo.GetContentList();

            foreach(EventContent content in listOfContent)
            {
                Console.WriteLine($"TypeOfEvent: {content.TypeOfEvent}\n " +
                    $"Date: {content.DateOfEvent}\n" +
                    $"Number of Attendees {content.NumberOfPeopleThatAttend}\n" +
                    $"Cost per person {content.CostPerPerson}\n" +
                    $"Total cost of event {content.TotalCostOfEvent}");
            }
        }

        //View Existing Content by event
        private void DisplayContentbyEvent()
        {
            Console.Clear();
            //Prompt the user to give me an event
            Console.WriteLine("Enter the name of the event that you would like to see:");

            //Get the users input
            string typeOfEvent = Console.ReadLine();

            //Find the content by that event
            EventContent content =_contentRepo.GetContentByTypeOfEvent(typeOfEvent);

            //Display said content if it isnt't null
            if(content != null)
            {
                Console.WriteLine($"TypeOfEvent: {content.TypeOfEvent}\n " +
                    $"Date: {content.DateOfEvent}\n" +
                    $"Number of Attendees {content.NumberOfPeopleThatAttend}\n" +
                    $"Cost per person {content.CostPerPerson}\n" +
                    $"Total cost of event {content.TotalCostOfEvent}");
            }
            else
            {
                Console.WriteLine("No content by that event.");
            }


        }


        //Update Existing Content
        private void UpdateExistingContent()
        {
            //Display all content
            DisplayAllContent();

            //Ask for the event of the content to update
            Console.WriteLine("Enter the event of the content you'd like to update:");

            //Get that event
            string oldEvent = Console.ReadLine();

            //We will build a new object
            EventContent newContent = new EventContent();

            //Type of event
            Console.WriteLine("Enter the event type (Golf, Bowling, Concert, Sporting event, etc:");
            newContent.TypeOfEvent = Console.ReadLine();

            //Date of event
            Console.WriteLine("Enter the date of the event (01/08/2025:");
            newContent.DateOfEvent = Console.ReadLine();

            //Number of people that will attend
            Console.WriteLine("Enter the number of people that will attend the event");
            string peopleAsString = Console.ReadLine();
            newContent.NumberOfPeopleThatAttend = int.Parse(peopleAsString);

            //Cost per person
            Console.WriteLine("Eneter the cost per person (123.45):");
            string costAsString = Console.ReadLine();
            newContent.CostPerPerson = double.Parse(costAsString);

            //Total cost of event
            Console.WriteLine("Enter the total cost of the event (1234.56)");
            string totalAsString = Console.ReadLine();
            newContent.TotalCostOfEvent = double.Parse(totalAsString);

            //Verify the update worked
            bool wasUpdated = _contentRepo.UpdateExistingContent(oldEvent, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("Content sucsessfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update the content.");
            }

        }

        //Delete Existing Content
        private void DeleteExistingContent()
        {
            DisplayAllContent();

            //Get the event we want to delete
            Console.WriteLine("\nEnter the event you would like to remove:");
            string input = Console.ReadLine();

            //Call the delete method
            bool wasDeleted =_contentRepo.RemoveContentFromList(input);

            //If the content was deleted say so
            //Otherwise state it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The content was sucsessfully deleted.");
            }
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }

            
        }

        //Seed method
        private void SeedContentList()
        {
            EventContent golf = new EventContent("Golf", "10/20/2020", 50, 50.00, 2500.00);
            EventContent concert = new EventContent("Concert", "10/25/2020", 20, 120, 2400.00);
            EventContent bowling = new EventContent("Bowling", "11/20/2020", 40, 20, 800.00);

            _contentRepo.AddContentToList(golf);
            _contentRepo.AddContentToList(concert);
            _contentRepo.AddContentToList(bowling);

        }
      
    }
}
