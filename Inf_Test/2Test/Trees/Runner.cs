using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test._2Test.Trees
{
    public class Runner
    {
         public void Run()
        {
            var tree = new BinarySearchTree<int>();
            tree.Add(8, 8);
            tree.Add(3, 3);
            tree.Add(10, 10);
            tree.Add(1, 1);
            tree.Add(6, 6);
            tree.Add(14, 14);
            tree.Add(4, 4);
            tree.Add(7, 7);
            tree.Add(13, 13);
            tree.FindAllNode(0);
            Console.WriteLine();
            tree.FindAllNode(1);
            Console.WriteLine();
            tree.FindAllNode(2);
            Console.WriteLine();
            tree.FindAllNode(3);
            Console.WriteLine();
            Console.WriteLine(tree.CountLeaves());
            Console.WriteLine();
            tree.PrintColor();
        }
    }
}
