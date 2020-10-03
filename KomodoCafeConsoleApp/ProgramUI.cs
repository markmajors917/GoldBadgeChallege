using _01_RepositoryCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeConsoleApp
{
    class ProgramUI
    {
        private MenuItemRepository _itemRepo = new MenuItemRepository();
        //Method that starts UI
        public void Run()
        {
            SeedItemList();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //Display options to the user
                Console.WriteLine("Select a menu item:\n" +
                    "1. Create new menu item\n" +
                    "2. Display all menu items\n" +
                    "3. View menu items by meal name\n" +
                    "4. Update existing menu item\n" +
                    "5. Delete menu item\n" +
                    "6. Exit");

                //Get the users inout
                string input = Console.ReadLine();

                //Evaluate users input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create new menu item
                        CreateNewItem();
                        break;
                    case "2":
                        //Display all menu items
                        DisplayAllItem();
                        break;
                    case "3":
                        //View menu item by meal name
                        DisplayItemByMealName();
                        break;
                    case "4":
                        //Update Existing Item
                        UpdateExistingItem();
                        break;
                    case "5":
                        //Delete menu item
                        DeleteExistingItem();
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
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Create new menu item
        private void CreateNewItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();

            //Meal number
            Console.WriteLine("Which meal number would you like? (1, 2, 3, 4, 5, 6):");
            string mealNumberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNumberAsString);

            //Meal name
            Console.WriteLine("Enter the meal name:");
            newItem.MealName = Console.ReadLine();

            //Decription
            Console.WriteLine("Enter the desciption of the menu item: (Sandwich, Pasta, Salad, Pizza, etc):");
            newItem.MealDesciption = Console.ReadLine();

            //List of ingredients
            Console.WriteLine("Enter the ingredients: (Flour, Sugar, Salt, etc):");
            newItem.ListOfIngredients = Console.ReadLine();

            //Price
            Console.WriteLine("Enter the price:");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);

            _itemRepo.AddItemToList(newItem);

        }

        //View all menu items that is saved
        private void DisplayAllItem()
        {
            Console.Clear();
            List<MenuItem> listOfItem = _itemRepo.GetItemList();

            foreach(MenuItem item in listOfItem)
            {
                Console.WriteLine($"Meal Name: {item.MealName}\n" +
                    $"Description: {item.MealDesciption}\n" +
                    $"Meal Number: {item.MealNumber}\n" +
                    $"List of ingredients: {item.ListOfIngredients}\n" +
                    $"Price: {item.Price}");
            }
        }

        //View existing item by meal name
        public void DisplayItemByMealName()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the menu item you would like to see:");
            string mealName = Console.ReadLine();
            MenuItem item = _itemRepo.GetItemByMealName(mealName);

            if(item != null)
            {
                Console.WriteLine($"Meal Name: {item.MealName}\n" +
                    $"Description: {item.MealDesciption}\n" +
                    $"Meal Number: {item.MealNumber}\n" +
                    $"List of ingredients: {item.ListOfIngredients}\n" +
                    $"Price: {item.Price}");
            }
            else
            {
                Console.WriteLine("No item by that meal name.");
            }


        }
        //Update
        public void UpdateExistingItem()
        {
            //Display all item
            DisplayAllItem();

            //Ask for the meal name to update
            Console.WriteLine("Eneter the meal name you would like to update:");

            //Get the meal name
            string oldMealName = Console.ReadLine();

            //Build a new object
            MenuItem newItem = new MenuItem();

            //Meal number
            Console.WriteLine("Which meal number would you like? (1, 2, 3, 4, 5, 6):");
            string mealNumberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNumberAsString);

            //Meal name
            Console.WriteLine("Enter the meal name:");
            newItem.MealName = Console.ReadLine();

            //Decription
            Console.WriteLine("Enter the desciption of the menu item: (Sandwich, Pasta, Salad, Pizza, etc):");
            newItem.MealDesciption = Console.ReadLine();

            //List of ingredients
            Console.WriteLine("Enter the ingredients: (Flour, Sugar, Salt, etc):");
            newItem.ListOfIngredients = Console.ReadLine();

            //Price
            Console.WriteLine("Enter the price:");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);

        }


        //Delete menu item
        private void DeleteExistingItem()
        {
            //Get the meal name we want to delete
            Console.WriteLine("Enter the meal name you want to delete:");
            string input = Console.ReadLine();

            //Call the delete method
            bool wasDeleted = _itemRepo.RemoveItemFromList(input);


            //If the item was deleted say so
            if (wasDeleted)
            {
                Console.WriteLine("The item was sucsessfully deleted.");
            }
            else
            {
                Console.WriteLine("Item could not be deleted");
            }

            //Otherwise could not be deleted
        }

        //Seed method
        private void SeedItemList()
        {
            MenuItem bigmic = new MenuItem(1, "Big Mic", "Burger", "Bun, Pattie, Sauce, Lettuce, Cheese, Pickles, Onions", 5.99);
            MenuItem ziti = new MenuItem(2, "Ziti", "Pasta", "Sauce, Marinara, Cheese, Meatballs", 5.99);
            MenuItem kalecrunch = new MenuItem(3, "Kale Crunch", "Salad", "Kale, Lettuce, Onions, Roasted Peppers, Dressing", 5.99);
            _itemRepo.AddItemToList(bigmic);
            _itemRepo.AddItemToList(ziti);
            _itemRepo.AddItemToList(kalecrunch);
        }

       

    }
}
