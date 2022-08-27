using System.Collections;

namespace BTree
{

    public class Node<k, v> where k : IComparable
    {
        public k Key { get; set; }
        public v? Value { get; set; } 
        private Node<k, v> _left, _right;

        public Node<k, v> leftNode { get { return _left; } set { _left = value; } }//Right Child
        public Node<k, v> rightNode { get { return _right; } set { _right = value; } }//left Child


        //Node constructor
        public Node(k key, v value) 
        {
            Key = key;
            Value = value;
        }
        public Node(k key)
        {
            Key = key;
        }


        public Node<k, v> Find(k key)
        {

            Node<k, v> currentNode = this;

            //loop through this node and all of the children of this node
            while (currentNode != null)
            {

                if (currentNode.Key.Equals(key))
                {
                    return currentNode;
                }
                else if (currentNode.Key.CompareTo(key)<0)
                {
                    currentNode = currentNode.rightNode;//if the value passed in is greater than the current Key then go to the right child
                }
                else//otherwise if the value is less than the current nodes Key the go to the left child node 
                {
                    currentNode = currentNode.leftNode;
                }
            }

            return null;
        }

        public Node<k, v> FindRecursive(k key)
        {

            if (Key.Equals(key))
            {
                return this;
            }
            else if (key.CompareTo(key)>0 && leftNode != null)//if the key passed in is less than the current Key then go to the left child
            {
                return leftNode.FindRecursive(key);
            }
            else if (rightNode != null)//if its great then go to the right child node
            {
                return rightNode.FindRecursive(key);
            }
            else
            {
                return null;
            }
        }



        public void Insert(k key, v value)
        {
            if (key.CompareTo(Key) == 0) //if key passed is equal to the Key then dont add.
            { }
            else
            {

                //if the key passed  is greater to the Key then insert to right node 
                if (key.CompareTo(Key) > 0)
                {   //if right child node is null create one
                    if (rightNode == null)
                    {
                        rightNode = new Node<k, v>(key, value);
                    }
                    else
                    {//if right node is not null recursivly call insert on the right node
                        rightNode.Insert(key, value);
                    }
                }
                else
                {//if the key passed in is less than the Key then insert to left node
                    if (leftNode == null)
                    {
                        leftNode = new Node<k, v>(key,value);
                    }
                    else

                        leftNode.Insert(key, value);
                }
            }
        }

        //Number return in ascending order
        //Left->Root->Right Nodes recursively of each subtree 
        public void InOrderTraversal()
        {
            //first go to left child its children will be null so we print its Key
            if (leftNode != null)
                leftNode.InOrderTraversal();
            //Then we print the root node 
            Console.Write(Key + " ");

            //Then we go to the right node which will print itself as both its children are null
            if (rightNode != null)
                rightNode.InOrderTraversal();
        }


        //Root->Left->Right Nodes recursively of each subtree 
        public void PreOrderTraversal()
        {
            //First we print the root node 
            Console.Write(Key + " ");

            //Then go to left child its children will be null so we print its Key
            if (leftNode != null)
                leftNode.PreOrderTraversal();

            //Then we go to the right node which will print itself as both its children are null
            if (rightNode != null)
                rightNode.PreOrderTraversal();
        }

        //Left->Right->Root Nodes recursively of each subtree 
        public void PostorderTraversal()
        {
            //First go to left child its children will be null so we print its Key
            if (leftNode != null)
                leftNode.PostorderTraversal();

            //Then we go to the right node which will print itself as both its children are null
            if (rightNode != null)
                rightNode.PostorderTraversal();

            //Then we print the root node 
            Console.Write(Key + " ");
        }

        
    }

    public class BinaryTree<k,v> where k: IComparable
    {
        private Node<k , v> root;
        public Node<k, v> Root
        {
            get { return root; }
        }


        //O(Log n)
        public Node<k, v> Find(k key)
        {
            //if the root is not null then we call the find method on the root
            if (root != null)
            {
                // call node method Find
                return root.Find(key);
            }
            else
            {//the root is null so we return null, nothing to find
                return null;
            }
        }

        //O(Log n)
        public Node<k, v> FindRecursive(k key)
        {
            //if the root is not null then we call the recursive find method on the root
            if (root != null)
            {
                //call Node Method FindRecursive
                return root.FindRecursive(key);
            }
            else
            {//the root is null so we return null, nothing to find
                return null;
            }

        }

        //O(Log n)
        public void Insert(k key, v value)
        {
            //if the root is not null then we call the Insert method on the root node
            if (root != null)
            {
                root.Insert(key, value);
            }
            else
            {
                root = new Node<k, v>(key, value);
            }
        }

        public void InOrderTraversal()
        {
            if (root != null)
                root.InOrderTraversal();
        }

        //O(Log n)
        public void Remove(k key)
        {

            Node<k, v> current = root;
            Node<k, v> parent = root;
            bool isLeftChild = false;//keeps track of which child of parent should be removed

            //empty tree
            if (current == null)
            {
                return;
            }

            //Find the Node
            //loop through until node is not found or if we found the node with matching key
            #region finding Node with key
            while (current != null && !current.Key.Equals(key))
            {

                parent = current;


                if (key.CompareTo(current.Key) < 0 )
                {
                    current = current.leftNode;
                    isLeftChild = true;//Set the variable to determin which child we are looking at
                }
                else
                {
                    current = current.rightNode;
                    isLeftChild = false;//Set the variable to determin which child we are looking at
                }
            }

            //if the node is not found nothing to delete just return
            if (current == null)
            {
                return;
            }
            #endregion

            //We found a Leaf node aka no children
            #region found Node is Leaf
            if (current.rightNode == null && current.leftNode == null)
            {
                //The root doesn't have parent to check what child it is,so just set to null
                if (current == root)
                {
                    root = null;
                }
                else
                {
                    //When not the root node
                    //see which child of the parent should be deleted
                    if (isLeftChild)
                    {
                        //remove reference to left child node
                        parent.leftNode = null;
                    }
                    else
                    {   //remove reference to right child node
                        parent.rightNode = null;
                    }
                }
            }
            #endregion
            #region found Node with only left child
            else if (current.rightNode == null) //current only has left child, so we set the parents node child to be this nodes left child
            {
                //If the current node is the root then we just set root to Left child node
                if (current == root)
                {
                    root = current.leftNode;
                }
                else
                {
                    //see which child of the parent should be deleted
                    if (isLeftChild)//is this the right child or left child
                    {
                        //current is left child so we set the left node of the parent to the current nodes left child
                        parent.leftNode = current.leftNode;
                    }
                    else
                    {   //current is right child so we set the right node of the parent to the current nodes left child
                        parent.rightNode = current.leftNode;
                    }
                }
            }
            #endregion
            #region found Node with only right child
            else if (current.leftNode == null) //current only has right child, so we set the parents node child to be this nodes right child
            {
                //If the current node is the root then we just set root to Right child node
                if (current == root)
                {
                    root = current.rightNode;
                }
                else
                {
                    //see which child of the parent should be deleted
                    if (isLeftChild)
                    {   //current is left child so we set the left node of the parent to the current nodes right child
                        parent.leftNode = current.rightNode;
                    }
                    else
                    {   //current is right child so we set the right node of the parent to the current nodes right child
                        parent.rightNode = current.rightNode;
                    }
                }
            }
            #endregion
            #region found Node with both children, to delete this node need the least greater node
            else//Current Node has both a left and a right child
            {
                //Find the successor node aka least greater node
                Node<k, v> successor = GetSuccessor(current);

                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {
                    parent.leftNode = successor;
                }
                else
                {
                    parent.rightNode = successor;
                }
            } 
            #endregion

        }


        private Node<k, v> GetSuccessor(Node<k, v> node)
        {
            Node<k, v> parentOfSuccessor = node;
            Node<k, v> successor = node;
            Node<k, v> current = node.rightNode;

            //starting at the right child we go down every left child node
            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.leftNode;// go to next left node
            }
            //if the succesor is not just the right node then
            if (successor != node.rightNode)
            {
                //set the Left node on the parent node of the succesor node to the right child node of the successor in case it has one
                parentOfSuccessor.leftNode = successor.rightNode;
                //attach the right child node of the node being deleted to the successors right node
                successor.rightNode = node.rightNode;
            }
            //attach the left child node of the node being deleted to the successors leftnode node
            successor.leftNode = node.leftNode;

            return successor;
        }
    
    
    }
}