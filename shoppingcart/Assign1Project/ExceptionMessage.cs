using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1Project
{
    class ExceptionMessage
    {

        public void printFormatEx()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.WriteLine("Invalid input. Please enter a number.");
            Console.WriteLine("Press any key to try again.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void printGeneralEx(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.WriteLine("Oops. Something unexpected happened.\nError type: {0}.", e.GetType());
            Console.WriteLine("Press any key to try again.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void optionInvalid()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.WriteLine("Error: Only option 1 to option 5 are available.\nPress any key to try again.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void stockInvalid()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.WriteLine("Error: Stock error. Enter a non-negative amount that is within stock range.\nPress any key to try again.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void prodIdNotCart()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.WriteLine("Error: The product is not in cart.\nPress any key to try again.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void prodIdInvalid()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.WriteLine("Error: Product ID does not exists. Press any key to try again.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void exitInvalid()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.WriteLine("Error: Please enter 'y' for yes or 'n' for no\nPress any key to try again.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void cartEmpty()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.WriteLine("Error: Your cart is empty\nPress any key to try again.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------ERROR MESSAGE-------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
