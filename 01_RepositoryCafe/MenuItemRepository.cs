using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_RepositoryCafe
{
    public class MenuItemRepository
    {
        private List<MenuItem> _listOfItem = new List<MenuItem>();

        //Create
        public void AddItemToList(MenuItem item)
        {
            _listOfItem.Add(item);
        }

        //Read
        public List<MenuItem> GetItemList()
        {
            return _listOfItem;
        }

        //Update
        public void UpdateExistingItem(string originalMealName, MenuItem newItem)
        {
            //Find the content
            MenuItem oldItem = GetItemByMealName(originalMealName);
                    
            //Update the content
            if (oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealName = newItem.MealName;
                oldItem.MealDesciption = newItem.MealDesciption;
                oldItem.ListOfIngredients = newItem.ListOfIngredients;
                oldItem.Price = newItem.Price;
            }
           
        }

        //Delete
        public bool RemoveItemFromList(string mealName)
        {
            MenuItem item = GetItemByMealName(mealName);

            if (item == null)
            {
                return false;
            }

            int initialCount = _listOfItem.Count;
            _listOfItem.Remove(item);

            if (initialCount > _listOfItem.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper Method
         public MenuItem GetItemByMealName(string mealName)
         {
                foreach (MenuItem item in _listOfItem)
                {
                    if (item.MealName.ToLower() == mealName.ToLower())
                    {
                        return item;
                    }
                }
                return null;
         }
    }
}


