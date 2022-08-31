using BoxFactory.Logi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFactory2._0
{
    // Manu is the collection of all defult Console screens 

    public class Menu
    {
        private Configuration _config;
        private xtree _tree;
        public Menu()
        {
            _config = new Configuration();
            _tree = new xtree(_config);// tries to load config , if config is empty will crate new
            _tree.StartTree();
            _config.Data.DataXTree = _tree;
            //_config.update(_config.Data);
        }

        public void MenuManeger()//choose if maneger or customer
        {
            Console.Clear();
            Console.WriteLine("Welcom  \n 1.Maneger \n 2.Customer");
            var Input = Console.ReadLine();
            int temp;
            int.TryParse(Input, out temp);
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
        private void CustomerMenue()
        {
            Console.Clear();
            Console.WriteLine("Welcom dear Customer ,  \n 1.dispaly \n 2.buy");
            var Input = Console.ReadLine();
            int temp;
            int.TryParse(Input, out temp);
            Array ar = new int[] { 1, 2 };
            if (isInvalid(ar, temp))
                if (temp == 2)
                {
                    Console.WriteLine("please input the Base of your present: ");
                    var Inputx = Console.ReadLine();
                    double tempx;
                    Console.WriteLine("please input the Hight of your present: ");
                    var Inputy = Console.ReadLine();
                    double tempy;
                    Console.WriteLine("please input the amount you need: ");
                    var InputS = Console.ReadLine();
                    int tempS;
                    if (!Double.TryParse(Inputx, out tempx) || !Double.TryParse(Inputy, out tempy) || !int.TryParse(InputS, out tempS)) // checking Inputs
                    {
                        Console.WriteLine("Invalid Input/s .... resturting ,press any key");
                        Console.ReadKey();
                        CustomerMenue();
                    }
                    else // input is valid // bring boxes // find the box
                    {
                        Console.WriteLine($"u wanna buy box : Base-{tempx} Hight-{tempy} Amount-{tempS}  press y/n ");
                        var ch = Console.ReadKey().KeyChar;
                        if (ch == 'Y' || ch == 'y')
                            try
                            {
                                _tree.Remove(tempx, tempy, tempS);
                                //Console.WriteLine("seccsesful... press any key");
                                Console.ReadKey();
                                //MenuManeger();
                            }
                            catch
                            {
                                CustemerBuy(tempx, tempy, tempS);
                                //Console.WriteLine("seccsesful... press any key");
                                Console.ReadKey();
                                //MenuManeger();

                            }
                            


                        else
                        {
                            Console.WriteLine("Aborting Perches... press any key");
                            Console.Clear();
                            Console.ReadKey();
                            MenuManeger();
                        }
                    }
                    MenuManeger();
                }
                else if (temp == 1)
                {
                    Console.WriteLine(_tree.Queue.DisplayFromOlder());
                    Console.WriteLine(" Press any key");
                    Console.ReadKey();
                    Console.Clear();
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
        ///  Maneger can view the stock , check for expire box, add boxes , Remove existing ones
        ///  
        /// </summary>
        private void ManegerMenue()
        {
            Console.WriteLine("Welcom back, Boss : \n 1.addBox \n 2.RemoveBox \n 3.Check for expired boxes \n 4.Display Storage by Date \n 5.Save Changes");
            var Input = Console.ReadLine();
            int temp;
            int.TryParse(Input, out temp);
            Array ar = new int[] { 1, 2, 3, 4, 5 };

            if (isInvalid(ar, temp))
            {
                if (temp == 1)// adding
                {
                    Console.WriteLine("Removing existing Box :");
                    Console.WriteLine("What is the base?(double x)");
                    double x = double.Parse(Console.ReadLine());
                    Console.WriteLine("What is the Hight?(double y)");
                    double y = double.Parse(Console.ReadLine());
                    Console.WriteLine("What is the amount?(int amount)");
                    int amount = int.Parse(Console.ReadLine());
                    Console.WriteLine($"adding Box : Base-{x} Hight-{y} Amount-{amount} ... Press any key");
                    Console.ReadKey(true);
                    if(amount > _config.Data.MaxBoxes)
                    {
                        _tree.Insert(x, y, _config.Data.MaxBoxes);
                    }
                    else
                    {
                        _tree.Insert(x, y, amount);
                    }
                    _config.Data.DataXTree = _tree;
                    ManegerMenue();
                }

                else if (temp == 2)// removing
                {
                    Console.WriteLine("Removing existing Box :");
                    Console.WriteLine("What is the base?(double x)");
                    double x = double.Parse(Console.ReadLine());
                    Console.WriteLine("What is the Hight?(double y)");
                    double y = double.Parse(Console.ReadLine());
                    Console.WriteLine("What is the amount?(int amount)");
                    int amount = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Remove Box : Base-{x} Hight-{y} Amount-{amount} ... Press Y or N");
                    char ch = Console.ReadKey().KeyChar;
                    if (ch == 'Y' || ch == 'y')
                    {
                        _tree.Remove(x, y, amount);// check befor hand if the box exist, then save it and remove safely from xtr and the the queue
                        _config.Data.DataXTree = _tree;

                        ManegerMenue();
                    }
                    else if (ch == 'n' || ch == 'N')
                    {
                        Console.WriteLine("Didnt Remove the Box , reseting ... Press any key");
                        Console.ReadKey();
                        Console.Clear();
                        _config.Data.DataXTree = _tree;
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
                    var listBox = _tree.expire(10);
                    foreach(var item in listBox)
                    {
                        Console.WriteLine(item.ToString());
                        _tree.Remove(item.X,item.Y,item.Stock);
                    }
                    Console.WriteLine("all expired been removed");
                    Console.ReadKey();
                    Console.Clear();
                    ManegerMenue();

                }
                else if (temp == 4) // display stock
                {
                    Console.WriteLine(_tree.Queue.DisplayFromOlder());
                    Console.WriteLine(" Press any key");
                    Console.ReadKey();
                    Console.Clear();
                    ManegerMenue();

                }
                else if (temp == 5)
                {
                    _config.update(_config.Data);
                    Console.Clear();
                    ManegerMenue();
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
                if (option.Equals(Input))
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
        private  void CustemerBuy(double x, double y, int amount)
        {
            var xNode = _tree.XTree.Find(x);//may be not found
                if (xNode == null)//x not found display "BestBoxes"
                {
                    Console.WriteLine("no box with this base, display 5 closest opthions? Y/N");
                    var Input = Console.ReadLine();

                if (Input.StartsWith('y') || Input.StartsWith('Y')) ;//choose to display bestboxes
                                                                     //_tree.BestBoxes(x,x*1.5, y,y*1.5, amount);
                else //input is not positive
                {
                    Console.WriteLine("reseting ... press any key");
                    Console.ReadKey();
                    CustomerMenue();
                }

                }
                else// current x is found try find y
                {
                    var yNode = xNode.Find(y);
                    if (yNode == null)//y not found display "BestBoxes"
                    {
                        Console.WriteLine("no box with this Hight, display 5 closest opthions? Y/N");
                        var Input = Console.ReadLine();

                    if (Input.StartsWith('y') || Input.StartsWith('Y')) ; //choose to display bestboxes
                            //_tree.BestBoxes(x, x * 1.5, y, y * 1.5, amount);
                        else //input is not positive
                        {
                            Console.WriteLine("reseting ... press any key");
                            Console.ReadKey();
                            CustomerMenue();
                        }

                    }
                }
               
            }
        }
    }






