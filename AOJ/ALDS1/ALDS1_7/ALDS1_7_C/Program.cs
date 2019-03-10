using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib.Tree.BinaryTree;
using CompProgLib.Tree;

namespace ALDS1_7_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            BinaryTree<int> bt = new BinaryTree<int>();
            NodeList<int> nodes = new NodeList<int>();
            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                if (nodes.FindByValue(line[0]) == null) nodes.Add(new BinaryTreeNode<int>(line[0]));
                if (line[1] != -1 && nodes.FindByValue(line[1]) == null) nodes.Add(new BinaryTreeNode<int>(line[1]));
                if (line[2] != -1 && nodes.FindByValue(line[2]) == null) nodes.Add(new BinaryTreeNode<int>(line[2]));
                ((BinaryTreeNode<int>)nodes.FindByValue(line[0])).Left = (BinaryTreeNode<int>)nodes.FindByValue(line[1]);
                if (line[1] != -1) ((BinaryTreeNode<int>)nodes.FindByValue(line[1])).Parent = (BinaryTreeNode<int>)nodes.FindByValue(line[0]);
                ((BinaryTreeNode<int>)nodes.FindByValue(line[0])).Right = (BinaryTreeNode<int>)nodes.FindByValue(line[2]);
                if (line[2] != -1) ((BinaryTreeNode<int>)nodes.FindByValue(line[2])).Parent = (BinaryTreeNode<int>)nodes.FindByValue(line[0]);

            }

            BinaryTreeNode<int> tmp = (BinaryTreeNode<int>)nodes[0];
            while (true)
            {
                if (tmp.Parent == null)
                {
                    bt.Root = tmp;
                    break;
                }
                tmp = (BinaryTreeNode<int>)tmp.Parent;
            }

            List<int> res1 = new List<int>();
            List<int> res2 = new List<int>();
            List<int> res3 = new List<int>();
            bt.PreorderTraversal(bt.Root, res1);
            bt.InorderTraversal(bt.Root, res2);
            bt.PostorderTraversal(bt.Root, res3);

            Console.WriteLine("Preorder");
            Console.WriteLine(" {0}", string.Join(" ", res1.Select(x => x.ToString()).ToArray()));
            Console.WriteLine("Inorder");
            Console.WriteLine(" {0}", string.Join(" ", res2.Select(x => x.ToString()).ToArray()));
            Console.WriteLine("Postorder");
            Console.WriteLine(" {0}", string.Join(" ", res3.Select(x => x.ToString()).ToArray()));

        }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }

    }

}
