using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFactory2._0
{
    // Manu is the collection of all defult Console screens 



#if false
    public static class Menu
    {




        public static void MenuManeger()//choose if maneger or customer
        {
            Console.Clear();
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
            Console.Clear();
            Console.WriteLine("Hello dear Customer , please input the Base of your present: ");
            var Inputx = Console.ReadLine();
            double tempx;
            Console.WriteLine("please input the Hight of your present: ");
            var Inputy = Console.ReadLine();
            double tempy;
            Console.WriteLine("please input the amount you need: ");
            var InputS = Console.ReadLine();
            int tempS;
            if (!Double.TryParse(Inputx, out tempx) || !Double.TryParse(Inputy, out tempy)|| !int+.TryParse(Inputy, out tempy)) // checking Inputs
            {
                Console.WriteLine("Invalid Input/s .... resturting ,press any key");
                Console.ReadKey();
                CustomerMenue();
            }
            else // input is valid // bring boxes
            {

            }
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


        /// <summary>
        /// returns false if Perches isnt complete , true if Perches is complete , updates the Queue and amount
        /// possibale to buy diffrent box if amount is high. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private static bool CustemerBuy(double x , double y , int amount)
        {
            var xNode = xtree.find(x);//may be not found
            if(xNode == null)//x not found display "BestBoxes"
            {
                Console.WriteLine("no box with this base, display 5 closest opthions? Y/N");
                var Input = Console.ReadLine();

                if (Input.StartsWith('y') || Input.StartsWith('Y'))//choose to display bestboxes
                    xtree.BestBoxes(x,y,5);
                else //input is not positive
                {
                    Console.WriteLine("reseting ... press any key");
                    Console.ReadKey();
                    CustomerMenue();
                }
            
            }
            else// current x is found try find y
            {
                var yNode = xNode.find(y);
                if (yNode == null)//y not found display "BestBoxes"
                {
                    Console.WriteLine("no box with this Hight, display 5 closest opthions? Y/N");
                    var Input = Console.ReadLine();

                    if (Input.StartsWith('y') || Input.StartsWith('Y'))//choose to display bestboxes
                        xtree.BestBoxes(x, y, 5);
                    else //input is not positive
                    {
                        Console.WriteLine("reseting ... press any key");
                        Console.ReadKey();
                        CustomerMenue();
                    }

                }

                return false;
        }


    }
#endif
}
