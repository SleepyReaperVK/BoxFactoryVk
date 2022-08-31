using BoxFactory.Logi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFactory2._0
{

    public  class xtree
    {

        private BinaryTree<double, BinaryTree<double, Box>> _xtr;
        private LinkedListQueue<Box> _queue = new LinkedListQueue<Box>();
        private Configuration _config;

        public BinaryTree<double, BinaryTree<double, Box>> XTree { get { return _xtr; } set { _xtr = value; } }
        public LinkedListQueue<Box> Queue { get { return _queue; } set { _queue = value; } }

        #region ConfigProp

        public Configuration Config { get { return _config;} set { _config = value; } }
        public int MaxBox { get; set; } = 100;
        public int MinBox { get; set; } = 0;



        #endregion

        public xtree()
        {

            XTree = new BinaryTree<double, BinaryTree<double, Box>>();
            Queue = new LinkedListQueue<Box>();      

        }

        public xtree(Configuration config)
        {
            Config=config;
            try
            {
                XTree = config.Data.DataXTree.XTree;
                Queue = config.Data.DataXTree.Queue;
                MaxBox = config.Data.DataXTree.MaxBox;
                MinBox = config.Data.DataXTree.MinBox;
                Debug.WriteLine("config is done");
            }
            catch
            {
                XTree = new BinaryTree<double, BinaryTree<double, Box>>();
                Queue = new LinkedListQueue<Box>();
                Debug.WriteLine("config is error");
            }
            

        }


        public void Insert(double x, double y)
        {
            BinaryTree<double, Box> ytr = new BinaryTree<double, Box>();
            XTree.Insert(x, ytr);//insert x in xtr in the right place  with the an empty ytr.
            var temp = XTree.Find(x);//find if node with key x exist.
            var tempY = XTree.Root.Value.Root; // give statrt value.
            if (temp != null && temp.Value != null)// if x is found then check if y found if is add stock +1 , else make new node in ytr 
                tempY = temp.Value.Find(y);
            if (tempY != null)
                tempY.Value.Stock++;
            else
            {
                Box newBox = new Box(x, y, 1);
                temp.Value.Insert(y, newBox); // posobility for exeptions 
                Queue.Enqueue(newBox);//posobility for exeptions
            }
        }
        public void Insert(double x, double y , int amount)
        {
            BinaryTree<double, Box> ytr = new BinaryTree<double, Box>();
            XTree.Insert(x, ytr);//insert x in xtr in the right place  with the an empty ytr.
            var temp = XTree.Find(x);//find if node with key x exist.
            var tempY = XTree.Root.Value.Root; // give statrt value.
            if (temp != null && temp.Value != null)// if x is found then check if y found if is add stock +1 , else make new node in ytr 
                tempY = temp.Value.Find(y);
            if (tempY != null && tempY.Value.Stock + amount <= MaxBox)
                tempY.Value.Stock += tempY.Value.Stock + amount;
            else if (tempY != null && tempY.Value.Stock + amount > MaxBox)
                tempY.Value.Stock = MaxBox;
            else
            {
                Box newBox;
                if (amount >= MaxBox)
                    newBox = new Box(x, y, MaxBox);
                else
                  newBox = new Box(x, y, amount);
                temp.Value.Insert(y, newBox); // posobility for exeptions 
                Queue.Enqueue(newBox);//posobility for exeptions
            }
        }

        public Node<double, BinaryTree<double, Box>> Find(double x)
        {
            return XTree.Find(x);
        }
        
        /// <summary>
        /// Removes y from ytr , if ytr is null , remove the x. 
        /// if y.box stock goes to zero , remove y from ytr adn del the box in Queue
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Remove(double x , double y)
        {
            var ytr = XTree.Find(x).Value;
            if (ytr != null)//if null remove the x ; 
            {
              var yBox =  ytr.Find(y).Value;// may be null
            if(yBox.Stock== 1) // last stock , can remove the box from ytr and queue
                {
                    Console.WriteLine("wasRemove "+ Queue.remove(yBox));
                        ytr.Remove(y);
                    if (ytr == null)
                        XTree.Remove(x);

                }
            else if (yBox.Stock > 1)// nore then 1 in stock then sub 1 from the stock
                    yBox.Stock--;
            }
             
            else
                XTree.Remove(x);

        }

        public void Remove(double x, double y , int amount)
        {
            var ytr = XTree.Find(x).Value;
            if (ytr != null)//if null remove the x ; 
            {
                var yBox = ytr.Find(y).Value;// may be null
                if (yBox.Stock <= 1) // last stock , can remove the box from ytr and queue
                {
                    Console.WriteLine("wasRemove " + Queue.remove(yBox));
                    ytr.Remove(y);
                    if (ytr == null)
                        XTree.Remove(x);

                }
                else if (yBox.Stock > amount)// more then {amount} in stock then sub amount from the stock
                    yBox.Stock-=amount;
                else if(yBox.Stock < amount)// amount is higher then stock remove the box from store
                {
                    Console.WriteLine("wasRemove " + Queue.remove(yBox));
                    ytr.Remove(y);
                    if (ytr == null)
                        XTree.Remove(x);
                }

            }

            else
                XTree.Remove(x);

        }


        public List<Box> expire(int days)
        {
           
            var temp = Queue.Front;
            List<Box> list=null;
            while (temp != null)
            {
                if (temp.Data.Time >= DateTime.Now.AddDays(days))
                    list.Add(temp.Data);
                temp = temp.Next;
            }
            return list;
        }
    
        #region needs Testing and refining
        public void BigRange(double t, double r)// need to returns all boxes  to fill up the amount.///
        {
            double xRange = t * 2;
            double yRange = r * 2;
            var current = this.XTree.Root;


            List<Box> tada = (BigRange(current, xRange, yRange));// need to returns all boxes  to fill up the amount.///
            //foreach (Box box in tada)
            //    Console.WriteLine(box.ToString());
            
        }


        private List<Box> BigRange(Node<double, BinaryTree<double, Box>> cur, double x, double y)
        {
            List<Box> result = new List<Box>();
            while (true)
            {
                if (cur == null)
                    break;

                if (cur.Key < x && cur.Key >= x / 2)// found x in range
                {
                    return Join(BigRange(cur.Value.Root, y), result);
                }
                else if (cur.Key > x)//if key is over the max limit
                {
                    return Join(BigRange(cur.leftNode, x, y), result);
                }
                cur = cur.rightNode;

            }
            return result;

        }

        private List<Box> BigRange(Node<double, Box> cur, double y)// finding y in ytr
        {
            List<Box> result = new List<Box>();
            while (true)
            {
                if (cur == null)
                    break;

                if (cur.Key < y && cur.Key > y / 2)// found x in range
                {
                    List<Box> temp = new List<Box>() { cur.Value };
                    return Join(temp, result);
                }
                else if (cur.Key > y)//if key is over the max limit
                {
                    return Join(BigRange(cur.leftNode, y), result);
                }
                cur = cur.rightNode;

            }
            return result;

        }

        private List<Box> Join(List<Box> first, List<Box> second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            return first.Concat(second).ToList();
        }

        internal void StartTree()
        {
            Insert(11.0, 10);//front - oldes
            Insert(11.0, 20);
            Insert(11.0, 10);
            Insert(20, 6);
            Insert(15, 6);
            Insert(16, 8);
            Insert(8, 4);
            Insert(5, 6);
            Insert(7, 5);
            Insert(8, 1);
            Insert(10, 1);
            Insert(10, 10);
            Insert(10, 10);
            Insert(10, 7);
            Insert(10, 8);
            Insert(10, 9);//back - young
        }

        //internal LinkedListVK<Box> BestBoxes(double Width, double MaximumW, double Height, double MaximumH, int QuantitiUser)
        //{


        //    LinkedListVK<Box> list = new LinkedListVK<Box>();

        //        foreach (var MainNode in XTree.GetSuitableNodesByRange(Width, MaximumW))
        //        {
        //            foreach (var InnerNode in XTree.Find(Width).GetSuitableNodesByRange(Height, MaximumH))
        //            {
        //                if (QuantitiUser > InnerNode.Value._quantity)
        //                {
        //                    QuantitiUser -= InnerNode.Value._quantity;
        //                    list.AddToTail(InnerNode.Value);

        //                }
        //                else if (QuantitiUser == 0)
        //                {
        //                    return list;
        //                }
        //                else //QuantitiUser < InnerNode.Value._quantity
        //                {
        //                    QuantitiUser -= InnerNode.Value._quantity;
        //                    list.AddToTail(InnerNode.Value);
        //                    return list;
        //                }
        //            }
        //        }
        //        return list;
        //    }
        }

        #endregion


   


    public class Box
    {
        private double _x;
        private double _y;
        private int _stock;
        private DateTime _time;

        public double X { get { return _x; } set { _x = value; } }
        public double Y { get { return _y; } set { _y = value; } }
        public int Stock { get { return _stock; } set { _stock = value; } }
        public DateTime Time { get { return _time; } set { _time = value; } }


        public Box(double x, double y, int stock)
        {
            _x = x;
            _y = y;
            _stock = stock;
            _time = DateTime.Now;
        }




        public override string ToString()
        {
            return $"X: {this._x} Y: {this._y} Stock: {this._stock} Time:{this._time.ToString()}";
        }


    }


    
}
