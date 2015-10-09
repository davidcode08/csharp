using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1Project
{
    class UIDisplay
    {
        // Inventory format: prodID, amount, cost, name
        public List<List<String>> modifiedInventory = new List<List<String>>();
        
        // Shopper cart format: prodID, product Name, amount, total cost
        public List<List<String>> shopperCart = new List<List<String>>();

        // Counter to keep track adding to Cart
        int indexCursor = 0;

        // Classe Objects
        public ExceptionMessage exception = new ExceptionMessage();
        public Import_Update importer = new Import_Update();
        public Finder finder = new Finder();

        // Methods
        public void beginDisplay()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n\t\t     WELCOME TO THE CONSOLE SHOPPING CART");
            Console.ResetColor();
            Console.Write("\t\t\t  press any key to continue: ");
            Console.ReadKey();
        }

        public void displayInventory()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-----------------------------STORE INVENTORY------------------------------");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ID\tStock\tCost\tProduct name");
            Console.ResetColor();
            foreach (List<string> lst in modifiedInventory)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    Console.Write("{0}\t", lst[i]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-----------------------------STORE INVENTORY------------------------------\n");
            Console.ResetColor();
        }

        public void displayShop()
        {
            Console.Clear();
            displayInventory();
            Console.WriteLine("Following options are available to you:");
            Console.Write("1. Add an item to cart \n2. Remove an item from the cart\n3. View the cart\n4. Checkout and Pay\n5. Exit\nEnter your option: ");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice < 6 && choice > 0)
                {
                    // Customer prompt
                    customerPrompt(choice);
                }
                else
                {
                    exception.optionInvalid();     
                    displayShop();
                }
            }

            catch (FormatException)
            {
                exception.printFormatEx();
                displayShop();
            }

        }



        public void displayCart()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------------------------YOUR SHOPPING CART----------------------------");
            Console.ResetColor();
            Console.WriteLine("ID\t\tAmount\t\tCost\t\tProduct name");
            foreach (List<String> lst in shopperCart)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", lst[0], lst[3], lst[5], finder.findProdName(Convert.ToInt32(lst[0])));
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------------------------YOUR SHOPPING CART----------------------------\n");
            Console.ResetColor();
        }

        public void orderTotal()
        {
            int total = 0;
            foreach (List<String> lst in shopperCart)
            {
                total += Convert.ToInt32(lst[5]);
            }
            Console.WriteLine("Order total: ${0}", total);
        }

        public void customerPrompt(int option)
        {
            switch (option)
            {
                // Add item to cart
                case 1:
                    int cost = -1;
                    int inCart = -1;
                    Console.Clear();
                    displayInventory();
                    Console.Write("<Press -1 to be back to main menu>\nEnter the id of the product: ");
                    try
                    {
                        int prodId = Convert.ToInt32(Console.ReadLine());

                        // To get back to main menu
                        if (prodId == -1)
                        {
                            displayShop();
                        }
                        else
                        {
                        // Checking if ID is valid
                        if (finder.isValid(0, -1, prodId) != -1)
                        {
                            Console.Write("Enter the amount: ");

                            try
                            {
                                int amnt = Convert.ToInt32(Console.ReadLine());

                                // Checking stock value
                                if ((cost = finder.isValid(1, prodId, amnt)) != -1)
                                {
                                    // Check if the item is already in the cart
                                    if ((inCart = finder.isInCart(prodId)) != -1)
                                    {
                                        // Update shopping cart
                                        shopperCart[inCart][3] = (Convert.ToInt32(shopperCart[inCart][3]) + amnt).ToString();
                                        shopperCart[inCart][5] = (Convert.ToInt32(shopperCart[inCart][5]) + amnt * cost).ToString();
                                    }

                                    // Item is not in list yet
                                    else
                                    {
                                        shopperCart.Add(new List<String>());
                                        shopperCart[indexCursor].Add(prodId + "");
                                        shopperCart[indexCursor].Add(" |Product: " + finder.findProdName(prodId));
                                        shopperCart[indexCursor].Add(" |Amount: ");
                                        shopperCart[indexCursor].Add(amnt + "");
                                        shopperCart[indexCursor].Add(" |Cost: ");
                                        shopperCart[indexCursor].Add(cost * amnt + "");
                                        // Increment for adding (decrement for removing)
                                        indexCursor++;
                                    }

                                    // Update Stock value
                                    int indexToMod = finder.findInventory(prodId);
                                    modifiedInventory[indexToMod][1] = (Convert.ToInt32(modifiedInventory[indexToMod][1]) - amnt) + "";




                                    // Printing Cart
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n-----------------------------ORDER COMPLETED------------------------------");
                                    Console.ResetColor();
                                    displayCart();

                                    
                                    Console.Write("Press any key to continue ");
                                    Console.ReadKey();
                                    displayShop();

                                }

                                else
                                {
                                    exception.stockInvalid();
                                    customerPrompt(1);
                                }


                            }
                            catch (FormatException)
                            {
                                exception.printFormatEx();
                                customerPrompt(1);
                            }
                            catch (Exception e)
                            {
                                exception.printGeneralEx(e);
                                customerPrompt(1);
                            }
                        }

                        else
                        {
                            exception.prodIdInvalid();  
                            customerPrompt(1);
                        }
                    }
                    }
                    catch (FormatException)
                    {
                        exception.printFormatEx();
                        customerPrompt(1);
                    }
                    catch (Exception e)
                    {
                        exception.printGeneralEx(e);
                        customerPrompt(1);
                    }
                    break;

                // Remove item from cart
                case 2:
                    // Allow item removal if customer bought something already
                    if(shopperCart.Count > 0)
                    {
                        Console.Clear();
                        int indexDelete = -1;

                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("------------------------------REMOVING ITEM-------------------------------");
                        Console.ResetColor();
                        displayCart();

                        Console.Write("<Press -1 to be back to Main Menu>\nEnter the item productID to delete: ");
                        try
                        {
                            int idDelete = Convert.ToInt32(Console.ReadLine());

                            // To get back to main menu
                            if (idDelete == -1)
                            {
                                displayShop();
                            }
                            else
                            {
                                // Check valid prodID existed in Cart
                                if ((indexDelete = finder.isInCart(idDelete)) != -1)
                                {
                                    // Re-add stock to store
                                    int cartAmnt = Convert.ToInt32(shopperCart[indexDelete][3]);
                                    int prodId = Convert.ToInt32(shopperCart[indexDelete][0]);
                                    idDelete = finder.findInventory(prodId);
                                    modifiedInventory[idDelete][1] = (Convert.ToInt32(modifiedInventory[idDelete][1]) + cartAmnt) + "";

                                    shopperCart.RemoveAt(indexDelete);
                                    indexCursor--;

                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("-----------------------------REMOVAL COMPLETED----------------------------");
                                    Console.Write("Press any key to continue ");
                                    Console.ReadKey();
                                    displayShop();

                                }

                                else
                                {                                    
                                    exception.prodIdNotCart();
                                    customerPrompt(2);

                                }
                            }


                        }
                        catch (FormatException)
                        {
                            exception.printFormatEx();
                            customerPrompt(2);
                        }
                        catch (Exception e)
                        {
                            exception.printGeneralEx(e);
                            customerPrompt(2);
                        }
                    }

                    else
                    {
                        exception.cartEmpty();
                        displayShop();
                    }
                    break;

                // View the cart
                case 3:
                    Console.Clear();
                    displayCart();
                    Console.Write("Press any key to continue ");
                    Console.ReadKey();
                    displayShop();
                    break;

                // Check out and pay
                case 4:
                    // Allow to check out if Customer bought something already
                    if(shopperCart.Count > 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Checking out...");

                        displayCart();
                        orderTotal();

                        Console.Write("Do you want to proceed the Checkout?(y/n): ");
                        String confirm = Console.ReadLine();

                        switch (confirm)
                        {
                            case "y":
                                // Clear cart
                                shopperCart = new List<List<string>>();

                                // Reset counter
                                indexCursor = 0;

                                // Update inventory file
                                importer.updateInventory(modifiedInventory);

                                // Return to menu
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("----------------------------CHECKOUT COMPLETED----------------------------");
                                Console.ResetColor();
                                Console.WriteLine("Success: Your shopping cart has been checked out.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("----------------------------CHECKOUT COMPLETED----------------------------");
                                Console.ResetColor();
                                Console.Write("Press any key to continue ");
                                Console.ReadKey();
                                displayShop();
                                break;
                            case "n":
                                // Return to menu
                                Console.Clear();
                                displayShop();
                                break;
                            default:
                                exception.exitInvalid();
                                customerPrompt(4);
                                break;
                        }
                    }
                    
                    else
                    {
                        exception.cartEmpty();
                        displayShop();
                    }


                    break;

                // Exit                
                case 5:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("--------------------------SHOPPING SESSION OVER---------------------------");
                    Console.ResetColor();
                    Console.WriteLine("Thank you for shopping with us. See you again!");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("---------------------------PRODUCT INTRODUCTION---------------------------");
                    Console.ResetColor();
                    Console.Write("Name:\t\tVo Quoc Hung\nid:\t\ts3479778\nProject:\tAssignment 1\nCourse:\t\tWeb Development Technology\n\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Press 1 to CONTINUE shopping or other keys to EXIT: ");
                    Console.ResetColor();
                    
                    String choice = Console.ReadLine();
                    if(choice.Equals("1"))
                    {
                        displayShop();
                    }
                    else
                    {
                        Console.Beep();
                        System.Environment.Exit(1);
                    }
                    
                    break;

            }
            Console.ReadLine();


        }
    }
}

