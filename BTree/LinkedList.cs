using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFactory.Logi
{
    public class LinkedListVK<T> 
    {
        public Node<T> Head { get; set; }//Oldest box
        public Node<T> Last { get; set; }// youngest box

        public int Length { get; set; }

        public LinkedListVK()
        {
            Head = null;
            Last = null;

        }
        //O(1)
        public void AddToStart(T Data)
        {
            Node<T> node = new Node<T>(Data);
            if (Head != null)
            {
                node.Next = Head;
                Head.Prev = node;
            }
            else
            {

                Last = node;
            }
            Head = node;
            Length++;
        }
        //O(1)
        public void AddToTail(T Data)
        {
            Node<T> node = new Node<T>(Data);
            if (Last != null)
            {
                Last.Next = node;
                node.Prev = Last;
            }
            else
            {
                Head = node;
            }
            Last = node;
            Length++;
        }
        //O(1)
        public void RemoveFromStart()
        {
            if (Head != null)
            {
                Head = Head.Next;
                if (Head == null)
                {
                    Last = null;
                }
                Head = null;
            }
            Length--;
        }
        //O(1)
        public void RemoveFromLast()
        {
            if (Last != null)
            {
                Last = Last.Prev;
                if (Last == null)
                {
                    Head = null;
                }
            }
            Length--;
        }

        //O(n)
        public bool remove(T data)
        {
            var temp = new Node<T>(data);
            bool isSuccessful = false;
            if (isEmpty())
                return isSuccessful;
            var temp2 = Last;
            // goes from the the youngest box to the oldes 
            while (true)
            {
                if (temp2 == null)
                    break;
                if (temp.Data.Equals(temp2.Data))
                {
                    temp2.Prev.Next = temp2.Next;
                    isSuccessful = true;
                    break;
                }
                temp2 = temp2.Prev;
            }
            return isSuccessful;
        }
            public bool isEmpty()
            {
                return Head == null;
            }



    public class Node<T>
    {
        public T Data { get; private set; }
        public Node<T> Next { get; internal set; }
        public Node<T> Prev { get; internal set; }
        public Node(T data, Node<T> next = null, Node<T> previous = null)
        {
            Data = data;
            Next = next;
            Prev = previous;
        }
    }
}
}
