using _03_RepoPattern_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoClaims_Console
{
    class ProgramUI
    {
        private ClaimsContentRepo _contentRepo = new ClaimsContentRepo();
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



                //Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Content\n" +
                    "2. View All Content\n" +
                    "3. View Content By Claim ID\n" +
                    "4. Update Existing Content\n" +
                    "5. Delete Existing Content\n" +
                    "6. Exit");


                //Get the users input
                string input = Console.ReadLine();

                //Evaluate the users inout and act
                switch (input)
                {
                    case "1":
                        //Create new content
                        CreateNewContent();
                        break;
                    case "2":
                        //View all content
                        DisplayAllContent();
                        break;
                    case "3":
                        //View Content By Claim ID
                        DisplayContentByClaimId();
                        break;
                    case "4":
                        //Update existing content
                        UpdateExistingContent();
                        break;
                    case "5":
                        //Delete existing content
                        DeleteExistingContent();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;

                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }
        //Create new Claim Content
        private void CreateNewContent()
        {
            Console.Clear();
            ClaimsContent newContent = new ClaimsContent();

            //Claim ID
            Console.WriteLine("Enter the Claim ID (Last Name, First Initial SmithA):");
            newContent.ClaimId = Console.ReadLine();

            //Claim Type
            Console.WriteLine("Enter the claim type:\n" +
            "1. Car\n" +
            "2. Home\n" +
            "3. Theft");

            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newContent.TypeOfClaim = (ClaimType)claimTypeAsInt;

            //Desciption
            Console.WriteLine("Enter the Claim Description:");
            newContent.Description = Console.ReadLine();

            //Claim Amount
            Console.WriteLine("Enter the claim amount(555.55:");
            string claimAsString = Console.ReadLine();
            newContent.ClaimAmount = double.Parse(claimAsString);

            //Date Of Incident
            Console.WriteLine("Enter the date of the incident (ie 02/20/2020:");
            newContent.DateOfIncident = Console.ReadLine();

            //Date Of Claim
            Console.WriteLine("Enter the date of the claim (ie 02/24/2020:");
            newContent.DateOfClaim = Console.ReadLine();


            //Is Valid
            Console.WriteLine("Is the claim valid? (y/n):");
            string isValidString = Console.ReadLine().ToLower();

            if (isValidString == "y")
            {
                newContent.IsValid = true;
            }
            else
            {
                newContent.IsValid = false;
            }

            _contentRepo.AddContentToList(newContent);

        }


        //View current ClaimsContent that is saved
        private void DisplayAllContent()
        {
            Console.Clear();

            List<ClaimsContent> listOfContent = _contentRepo.GetContentList();

            foreach (ClaimsContent content in listOfContent)
            {
                Console.WriteLine($"ClaimId: {content.ClaimId}\n" +
                    $"Description: {content.Description}\n" +
                    $"Claim Amount: {content.ClaimAmount}\n" +
                    $"Date of Incident: {content.DateOfIncident}\n" +
                    $"Date of Claim: {content.DateOfClaim}\n" +
                    $"Is Valid:{content.IsValid}\n" +
                    $"Type of Claim{content.TypeOfClaim}");
            }
        }

        //View existing Content by Claim ID
        private void DisplayContentByClaimId()
        {
            Console.Clear();
            //Prompt for claim ID
            Console.WriteLine("Enter the claim ID of the claim you would like to see(Last Name, First Initial SmithA:)");

            //Get the users input
            string claimId = Console.ReadLine();

            //Find the content by that ID
            ClaimsContent content = _contentRepo.GetContentByClaimId(claimId);

            //Display Content if it isn't null
            if (content != null)
            {
                Console.WriteLine($"ClaimId: {content.ClaimId}\n" +
                    $"Description: {content.Description}\n" +
                    $"Claim Amount: {content.ClaimAmount}\n" +
                    $"Date of Incident: {content.DateOfIncident}\n" +
                    $"Date of Claim: {content.DateOfClaim}\n" +
                    $"Is Valid:{content.IsValid}\n" +
                    $"Type of Claim{content.TypeOfClaim}");
            }
            else
            {
                Console.WriteLine("No content by that claim ID");
            }
        }

        //Update Existing Content
        private void UpdateExistingContent()
        {
            //Display all content
            DisplayAllContent();

            //Ask for the Claim ID of the title we wish to update
            Console.WriteLine("Enetr the Claim ID of the claim you would like to update:");

            //Get that Claim ID
            string oldClaimId = Console.ReadLine();

            //Build new object
            ClaimsContent newContent = new ClaimsContent();

            //Claim ID
            Console.WriteLine("Enter the Claim ID (Last Name, First Initial SmithA):");
            newContent.ClaimId = Console.ReadLine();

            //Claim Type
            Console.WriteLine("Enter the claim type:\n" +
            "1. Car\n" +
            "2. Home\n" +
            "3. Theft");

            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newContent.TypeOfClaim = (ClaimType)claimTypeAsInt;

            //Desciption
            Console.WriteLine("Enter the Claim Description:");
            newContent.Description = Console.ReadLine();

            //Claim Amount
            Console.WriteLine("Enter the claim amount(555.55:");
            string claimAsString = Console.ReadLine();
            newContent.ClaimAmount = double.Parse(claimAsString);

            //Date Of Incident
            Console.WriteLine("Enter the date of the incident (ie 02/20/2020:");
            newContent.DateOfIncident = Console.ReadLine();

            //Date Of Claim
            Console.WriteLine("Enter the date of the claim (ie 02/24/2020:");
            newContent.DateOfClaim = Console.ReadLine();


            //Is Valid
            Console.WriteLine("Is the claim valid? (y/n):");
            string isValidString = Console.ReadLine().ToLower();

            if (isValidString == "y")
            {
                newContent.IsValid = true;
            }
            else
            {
                newContent.IsValid = false;

            }
    


        }
        //Delete Existing Content
        private void DeleteExistingContent()
        {
            DisplayAllContent();

            //Get the Claim ID to delete
            Console.WriteLine("Enter the Claim ID you would like to remove:");

            string input = Console.ReadLine();

            //Call the delete method
            bool wasDeleted = _contentRepo.RemoveContentFromList(input);

            //If the content was deleted, say so
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
            ClaimsContent jonesj = new ClaimsContent("JonesJ", "Hit telephone pole",  2300.00, "09/20/20", "09/21/20", true, ClaimType.Car);
            ClaimsContent smithb = new ClaimsContent("SmithB", "Roof collapsed", 15000.00, "09/10/20", "09/10/20", true, ClaimType.Home);
            ClaimsContent smythea = new ClaimsContent("SmytheA", "Purse stolen", 500.00, "09/25/20", "09/26/20", true, ClaimType.Theft);

            _contentRepo.AddContentToList(jonesj);
            _contentRepo.AddContentToList(smithb);
            _contentRepo.AddContentToList(smythea);
        }
    }

}

