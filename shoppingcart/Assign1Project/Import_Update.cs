using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1Project
{
    class Import_Update
    {
        public List<List<String>> inventory = new List<List<String>>();
        String[] breakDown;
        String line;
        int counter = 0;
        public Import_Update()
        {
            importInventory();
        }

        // Read from text file
        public void importInventory()
        {
            try
            {
                String directory = Environment.CurrentDirectory + "\\productInventory.txt";
                // Read the file
                System.IO.StreamReader file = new System.IO.StreamReader(directory);
                while ((line = file.ReadLine()) != null)
                {
                    inventory.Add(new List<String>());
                    breakDown = line.Split(',');
                    //Product names can be of different length, but index for prodID, amount and cost are fixed

                    //prodID
                    inventory[counter].Add(breakDown[0]);
                    //amount
                    inventory[counter].Add(breakDown[breakDown.Length - 2]);
                    //cost
                    inventory[counter].Add(breakDown[breakDown.Length - 1]);
                    //name
                    for (int i = 1; i < (breakDown.Length - 2); i++)
                    {
                        inventory[counter].Add(breakDown[i]);
                    }

                    counter++;
                }

                file.Close();                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }
        }
        
        // Export to file
        public void updateInventory(List<List<string>> lst)
        {           
            inventory = lst;
            String directory = Environment.CurrentDirectory + "\\productInventory.txt";
            System.IO.StreamWriter file2 = new System.IO.StreamWriter(directory);
            foreach(List<String> lt in inventory)
            {
                //prodId
                file2.Write("{0},", lt[0]);

                //product name
                for (int i = 3; i < lt.Count; i++)
                {
                    if(i == lt.Count - 1)
                    {
                        file2.Write(lt[i]);
                    }
                    else
                    {
                        file2.Write(lt[i] + " ");
                    }
                }

                //amount and cost
                file2.Write(",{0},{1}", lt[1], lt[2]);
                file2.WriteLine();
            }
            
            file2.Close();
        }
    }
}
