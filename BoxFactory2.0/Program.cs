﻿
using BoxFactory2._0;
using BoxFactory.Logi;



class program
{

    /// <summary>
    ///  testing grounds for  Xtree and ytree
    /// </summary>
    /// <param name="args"> love sex and robots</param>
    public static void Main(string[] args)
    {


        Menu main = new Menu();
        main.MenuManeger();
        
        
        
        
        // xtree is an object using Btree to make the xtree with ytree as its value
        #if false //test 1 treeSetup
        xtree xtree = new xtree();


        xtree.Insert(11.0, 10);//front - oldes
        xtree.Insert(11.0, 20);
        xtree.Insert(11.0, 10);
        xtree.Insert(10, 6);
        xtree.Insert(10, 6);
        xtree.Insert(10, 8);
        xtree.Insert(10, 4);
        xtree.Insert(10, 6);
        xtree.Insert(10, 5);
        xtree.Insert(10, 1);
        xtree.Insert(10, 1);
        xtree.Insert(10, 10);
        xtree.Insert(10, 10);
        xtree.Insert(10, 7);
        xtree.Insert(10, 8);
        xtree.Insert(10, 9);//back - young
        #endif





#if false // testing xtree.remove 
        Console.WriteLine(xtree.Queue.DisplayFromOlder());
        Console.WriteLine("_____________________________\n");
        xtree.Remove(10, 10);
        Console.WriteLine(xtree.Queue.DisplayFromOlder());
        Console.WriteLine("_____________________________\n");
        xtree.Remove(10, 4);// exeption couldnt find 40 in (10,40)\\
        Console.WriteLine("_____________________________\n");
        Console.WriteLine(xtree.Queue.DisplayFromOlder()); 
#endif

#if false // testting xtree.LinkedList




#endif



    }

}