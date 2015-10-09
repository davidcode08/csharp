using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1Project
{
    class Program
    {
        // Class objects
        Import_Update importExporter = new Import_Update();
        UIDisplay UIComponent = new UIDisplay();
        ExceptionMessage exception = new ExceptionMessage();
        Finder finder = new Finder();

        static void Main(string[] args)
        {
            // Object declaration
            Program p = new Program();

            // Synchronize object field references
            p.UIComponent.modifiedInventory = p.importExporter.inventory;
            p.UIComponent.finder = p.finder;
            p.UIComponent.exception = p.exception;
            p.UIComponent.importer = p.importExporter;
            p.finder.modifiedInventory = p.UIComponent.modifiedInventory;
            p.finder.shopperCart = p.UIComponent.shopperCart;

            // Display UI
            p.UIComponent.beginDisplay();
            p.UIComponent.displayShop();
        }

    }
}
