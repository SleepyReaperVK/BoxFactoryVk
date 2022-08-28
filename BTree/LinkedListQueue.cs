
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFactory.Logi
{

    public class LinkedListQueue<T>
    {
        private TNode<T> front, back;// front is the oldessin the queue while Back is the latest

        public LinkedListQueue()
        {
            front = back = null;
        }

        //O(1)
        public void Enqueue(T val)// adds a box to the  back aka the to the youngest box
        {
            var temp = new TNode<T>( val, null,null);


        if (isEmpty())
                front = back = temp;
            else
            {
                var temp2 = back;
               back.Next = temp;
                back = temp;
                back.Prev = temp2;

            }
        }

        //O(1)
        public bool isEmpty()
        {
            return front == null;
        }

        //O(1)
        public T Dequeue()/// returns the oldes of boxes//
        {
            if (isEmpty())
                return default;
            T temp = front.Data;
            front = front.Next;
            front.Prev = null;
            if (front == null)
                back = null;
            return temp;
        }

        //O(n)
        public bool remove(T val)
        {
            var temp = new TNode<T>(val, null, null);
            bool isSuccessful = false;
            if (isEmpty())
                return isSuccessful ;
            var temp2 = back;
            // goes from the the youngest box to the oldes 
            while (true)
            {
                if(temp2 ==null)
                    break ;
                if (temp.Data.Equals(temp2.Data))
                {
                    temp2.Prev.Next = temp2.Next;
                    isSuccessful= true;
                    break;
                }
                temp2 = temp2.Prev;
            }
            return isSuccessful;


        }
        public string DisplayFromOlder()// front is the oldessin the queue while Back is the latest
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
        public string DisplayFromYounger()// back it the oldest box in the shop while front is the latest
        {
            if (isEmpty())
                return default;
            var temp = back;
            string str = string.Empty;
            while (temp != null)
            {
                str += temp.Data + "\n";
                temp = temp.Prev;
            }
            return str;
        }

        

    }

    internal class TNode<T>
    {
        private T _data;
        private TNode<T> _next;
        private TNode<T> _prev;

        public TNode(T date , TNode<T> next , TNode<T> prev)
        {
            _data = date;
            _next = next;
            _prev = prev;
        }

        public T Data { get { return _data; } set { _data = value; } }
        public TNode<T> Next { get { return _next; } set { _next = value; } }
        public TNode<T> Prev { get { return _prev; } set { _prev = value; } }
    }

}

