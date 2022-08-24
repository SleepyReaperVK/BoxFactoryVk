using BTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFactory2._0
{

    public class LinkedListQueue<T>
    {
        private TNode<T> front, back;

        public LinkedListQueue()
        {
            front = back = null;
        }
        public void Enqueue(T val)
        {
            var temp = new TNode<T>( val, null);


        if (isEmpty())
                front = back = temp;
            else
            {
                back.Next = temp;
                back = temp;

            }
        }

        public bool isEmpty()
        {
            return front == null;
        }

        public T Dequeue()
        {
            if (isEmpty())
                return default;
            T temp = front.Data;
            front = front.Next;
            if (front == null)
                back = null;
            return temp;
        }

        public string FrontToBack()// front the lates box added Back the oldes box added to shop.
        {
            if (isEmpty())
                return default;
            var temp = front;
            string str= string.Empty;
            while (temp!=null)
            {
                 str += temp.Data+"\n";
                temp = temp.Next;
            }
                return str;
        }



    }

    internal class TNode<T>
    {
        private T _data;
        private TNode<T> _next;

        public TNode(T date , TNode<T> next)
        {
            _data = date;
            _next = next;
        }

        public T Data { get { return _data; } set { _data = value; } }
        public TNode<T> Next { get { return _next; } set { _next = value; } }

    }

}

