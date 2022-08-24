
using BoxFactory2._0;
using BTree;

class program
{

    /// <summary>
    ///  testing grounds for  Xtree and ytree
    /// </summary>
    /// <param name="args"> love sex and robots</param>
    public static void Main(string[] args)
    {

        //// xtree is an object using Btree to make the xtree with ytree as its value
        #region test 1 treeSetup
        xtree xtree = new xtree();
        xtree.InsertX(10.0);
        xtree.InsertX(11.0);
        xtree.InsertX(5.0);
        xtree.InsertX(4.0);
        xtree.InsertX(7.0);
        xtree.InsertX(6.0);
        xtree.InsertX(8.0);
        xtree.InsertX(10.0);
        xtree.InsertX(9.0);
        xtree.InsertX(10.0);
        xtree.InsertY(11.0, 10);
        xtree.InsertY(11.0, 20);
        xtree.InsertY(11.0, 10);
        xtree.InsertY(10, 6);
        xtree.InsertY(10, 6);
        xtree.InsertY(10, 8);
        xtree.InsertY(10, 4);
        xtree.InsertY(10, 6);
        xtree.InsertY(10, 5);
        xtree.InsertY(10, 1);
        xtree.InsertY(10, 1);
        xtree.InsertY(10, 10);
        xtree.InsertY(10, 10);
        xtree.InsertY(10, 7);
        xtree.InsertY(10, 8);
        xtree.InsertY(10, 9);
        #endregion

     //xtree.BigRange(10, 5);
        Console.WriteLine(xtree.Queue.FrontToBack());
        Menu.MenuManeger();




    }

}