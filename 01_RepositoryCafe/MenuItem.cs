using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_RepositoryCafe
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDesciption { get; set; }
        public string ListOfIngredients { get; set; }
        public double Price { get; set; }

        public MenuItem() { }
       
        public MenuItem(int mealNumber, string mealName, string mealDesciption, string listOfIngredients, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDesciption = mealDesciption;
            ListOfIngredients = listOfIngredients;
            Price = price;
        }
           
    
    }

}
