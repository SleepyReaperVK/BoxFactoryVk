using BTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFactory2._0
{

    public  class xtree
    {

        private BinaryTree<double, BinaryTree<double, Box>> _xtr;
        private LinkedListQueue<Box> _queue = new LinkedListQueue<Box>();

        public BinaryTree<double, BinaryTree<double, Box>> XTree { get { return _xtr; } set { _xtr = value; } }
        public LinkedListQueue<Box> Queue { get { return _queue; } set { _queue = value; } }

        public xtree()
        {
            XTree = new BinaryTree<double, BinaryTree<double, Box>>();
        }

        public void InsertX(double x)
        {
            BinaryTree<double, Box> ytr = new BinaryTree<double, Box>();
            XTree.Insert(x, ytr);

        }

        public void InsertY(double x, double y)
        {
            var temp = XTree.Find(x);//find if node with key x exist
            var tempY = XTree.Root.Value.Root; // give statrt value;
            if (temp != null && temp.Value != null)// if x is found then check if y found if is add stock +1 , else make new node in ytr 
                tempY = temp.Value.Find(y);
            if (tempY != null)
                tempY.Value.Stock++;
            else
            {
                Box newBox = new Box(x, y, 1);
                Queue.Enqueue(newBox);
                temp.Value.Insert(y, newBox); // posobility for exeptions 
            }




        }

        public Node<double, BinaryTree<double, Box>> Find(double x)
        {
            return XTree.Find(x);
        }

        public void Remove(double x , double y)
        {

        }


        public void BigRange(double t, double r)
        {
            double xRange = t * 2;
            double yRange = r * 2;
            var current = this.XTree.Root;


            List<Box> tada =(BigRange(current, xRange, yRange));
            foreach (Box box in tada)
                Console.WriteLine(box.ToString());
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



    }


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
