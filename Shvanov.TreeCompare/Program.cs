using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shvanov.TreeCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(2);
            tree.Add(9);

            var tree2 = new BinaryTree(5);
            tree2.Add(3);
            tree2.Add(7);
            tree2.Add(1);
            tree2.Add(2);

            Console.WriteLine(Compare(tree, tree2, false));

            tree2.Add(9);
            Console.WriteLine(Compare(tree, tree2, true));

            tree2.Add(8);
            Console.WriteLine(Compare(tree, tree2, false));

            Console.ReadLine();
        }

        private static string Compare(BinaryTree first, BinaryTree second, bool expected)
        {
            var result = first.Equals(second);
            var ok = expected == result ? "OK" : "ERROR";
            string message = $"[{ok}] Compare first and second trees. Expexted: {expected}. Actual: {result}.";
            return message;
        }
    }
}
