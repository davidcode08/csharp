using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1Project
{
    class Finder
    {
        // Inventory format: prodID, amount, cost, name
        public List<List<String>> modifiedInventory = new List<List<String>>();

        // Shopper cart format: prodID, product Name, amount, total cost
        public List<List<String>> shopperCart = new List<List<String>>();

        // Find index of Product in Inventory
        public int findInventory(int productId)
        {
            foreach (List<String> lst in modifiedInventory)
            {
                if (Convert.ToInt32(lst[0]) == productId)
                {
                    return modifiedInventory.IndexOf(lst);
                }
            }
            return -1;
        }

        public String findProdName(int prodId)
        {
            StringBuilder prodName = new StringBuilder();
            for (int i = 3; i < modifiedInventory[findInventory(prodId)].Count; i++)
            {
                prodName.Append(modifiedInventory[findInventory(prodId)][i]);
            }
            return prodName.ToString();
        }

        
        // Find if the product is in cart
        public int isInCart(int productId)
        {
            foreach (List<String> lst in shopperCart)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    if(Convert.ToInt32(lst[0]) == productId)
                    {
                        return shopperCart.IndexOf(lst);
                    }
                }                
            }            
            return -1;
        }


        public int isValid(int option, int chosenProduct, int value)
        {
            
            switch(option)
            {
                // Checking existence of product ID
                case 0:                    
                    foreach (List<string> lst in modifiedInventory)
                    {
                        for (int i = 0; i < lst.Count; i++)
                        {                                            
                            if (Convert.ToInt32(lst[0]) == value)
                            {
                                return 0;
                            }                            
                        }          
                    }
                    break;
                
                // Checking valid order amount
                case 1:
                    int prodIndex = findInventory(chosenProduct);
                    if (value > 0 && Convert.ToInt32(modifiedInventory[prodIndex][1]) >= value)
                    {                        
                        // return the cost of the product
                        return Convert.ToInt32(modifiedInventory[prodIndex][2]);
                    }
                   
                    break;               
            }
            return -1;
        }     
    }
}
