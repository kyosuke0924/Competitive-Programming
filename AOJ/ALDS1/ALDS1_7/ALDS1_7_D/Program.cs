using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib.Tree.BinaryTree;

namespace ALDS1_7_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            int[] preOrder = ReadIntAr();
            int[] inOrder = ReadIntAr();

            BinaryTreeNodeList<int> nodes = new BinaryTreeNodeList<int>(n);
            BinaryTree<int> bt = new BinaryTree<int>();

            for (int i = 0 ; i < n ; i++) { nodes[i] = new BinaryTreeNode<int>(inOrder[i]); }

            int index = 0;
            bt.Root = Reconstruct(nodes, preOrder, inOrder, ref index);
            List<int> res = new List<int>();
            bt.PostorderTraversal(bt.Root, res);

            Console.WriteLine(String.Join(" ", res.Select(x => x.ToString()).ToArray()));
        }

        static BinaryTreeNode<int> Reconstruct(BinaryTreeNodeList<int> nodes, int[] preoder, int[] inorder, ref int i)
        {
            var root = preoder[i];
            var index = Array.IndexOf(inorder, root);
            

            if (index == 0)
                nodes.FindByValue(root).Left = null;
            else
            {
                i++;
                BinaryTreeNode<int> left = Reconstruct(nodes, preoder, inorder.Take(index).ToArray(), ref i);
                nodes.FindByValue(root).Left = left;
            }

            if (index == inorder.Length - 1)
                nodes.FindByValue(root).Right = null;
            else
            {
                i++;
                BinaryTreeNode<int> right = Reconstruct(nodes, preoder, inorder.Skip(index + 1).Take(inorder.Length - index - 1).ToArray(), ref i);
                nodes.FindByValue(root).Right = right;
            }
            return nodes.FindByValue(root);
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
