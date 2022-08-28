using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFactory2._0
{
    // Manu is the collection of all defult Console screens 
    public  class Menu
    {
        xtree Tree = new xtree();


        public static void MenuManeger()//choose if maneger or customer
        {
            Console.WriteLine("Welcom to the BoxShop, you are? \n 1.Maneger \n 2.Customer");
            var Input =Console.ReadLine();
            int temp;
            int.TryParse(Input , out temp);
            Array ar = new int[] { 1, 2 };

                if (isInvalid(ar, temp))
                {
                    if (temp == 1)
                    {
                        ManegerMenue();
                       
                    }
                        
                    else
                        CustomerMenue();

                }
                else
            {
                Console.WriteLine("Invalid input, Press any key ...");
                Console.ReadKey();
                Console.Clear();
                MenuManeger();
            }
    
        }

        /// <summary>
        ///  Customer wanna buy a Box , give back "best box" by dementions , if no exact Box found return a list of 5 closes pickes///
        ///  when Customer comformes its buy , update the Queue , XTree.
        /// </summary>
        private static void  CustomerMenue()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  Maneger can view the stock , check for expire box, add boxes , Remove existing ones
        ///  
        /// </summary>

        private static void ManegerMenue()
        {
            Console.WriteLine("Welcom back, Boss : \n 1.addBox \n 2.RemoveBox \n 3.Check for expired boxes \n 4.Display Storage by Date ");
            var Input = Console.ReadLine();
            int temp;
            int.TryParse(Input, out temp);
            Array ar = new int[] { 1, 2, 3, 4 };

            if (isInvalid(ar, temp))
            {
                if (temp == 1)// adding
                {
                    Console.WriteLine("Adding new Box :");
                    Console.WriteLine("What is the base?(double x)");
                    double x = double.Parse(Console.ReadLine());
                    Console.WriteLine("What is the Hight?(double y)");
                    double y = double.Parse(Console.ReadLine());
                    Console.WriteLine($"adding Box : Base-{x} Hight-{y} ... Press any key");
                    Console.ReadKey(true);
                   // xtree.InsertX(x); // can be optimized
                    //xtree.InsertY(x, y);
                }

                else if (temp == 2)// removing
                {
                    Console.WriteLine("Removing existing Box :");
                    Console.WriteLine("What is the base?(double x)");
                    double x = double.Parse(Console.ReadLine());
                    Console.WriteLine("What is the Hight?(double y)");
                    double y = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Remove Box : Base-{x} Hight-{y} ... Press Y or N");
                    char ch = Console.ReadKey().KeyChar;
                    if (ch == 'Y' || ch == 'y') 
                    {
                        //xtree.Remove(x, y);// check befor hand if the box exist, then save it and remove safely from xtr and the the queue
                    }
                    else if(ch == 'n' || ch == 'N')
                    {
                        Console.WriteLine("Didnt Remove the Box , reseting ... Press any key");
                        Console.ReadKey();
                        Console.Clear();
                        ManegerMenue();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input , reseting ... Press any key");
                        Console.ReadKey();
                        Console.Clear();
                        ManegerMenue();
                    }

                    
                }
                else if (temp == 3)// expied boxes
                {
                    //how do u determan what is expierd.

                }
                else // display stock
                { 
                    
                }
                    

            }
            else
            {
                Console.WriteLine("Invalid input, Press any key ...");
                Console.ReadKey();
                Console.Clear();
                MenuManeger();
            }
        }

        public static bool isInvalid(Array options, object Input)
        {
            foreach (var option in options)
                if(option.Equals(Input))
                    return true;
            return false;
        }

    }
}
