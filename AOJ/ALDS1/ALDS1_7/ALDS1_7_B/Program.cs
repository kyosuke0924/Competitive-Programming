using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_7_B
{
    public class Program

    {
        public class Node
        {
            public int Parent;
            public int Sibling;
            public int Left;
            public int Right;
            public int Degree;
            public int Depth;
            public int Height;
            public string NodeTypes;

            public Node(int left, int right)
            {
                Parent = -1;
                Sibling = -1;
                this.Left = left;
                this.Right = right;
                Degree = (left == -1 && right == -1) ? 0 : (left != -1 && right != -1) ? 2 : 1;
                Depth = -1;
                Height = -1;
                NodeTypes = "";

            }
        }

        public static void Main(string[] args)
        {
            int n = ReadInt();
            SortedDictionary<int, Node> nodes = new SortedDictionary<int, Node>();

            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                nodes.Add(line[0], new Node(line[1], line[2]));
            }

            //親・兄弟の設定
            foreach (var item in nodes)
            {

                if (item.Value.Left != -1)
                {
                    nodes[item.Value.Left].Parent = item.Key;
                    nodes[item.Value.Left].Sibling = item.Value.Right;
                }

                if (item.Value.Right != -1)
                {
                    nodes[item.Value.Right].Parent = item.Key;
                    nodes[item.Value.Right].Sibling = item.Value.Left;
                }

            }

            //ノード種類の設定
            int rootNode = -1;
            foreach (var item in nodes)
            {
                if (item.Value.Parent == -1)
                {
                    item.Value.NodeTypes = "root";
                    item.Value.Depth = 0;
                    rootNode = item.Key;
                }
                else if (item.Value.Degree == 0)
                {
                    item.Value.NodeTypes = "leaf";
                    item.Value.Height = 0;
                }
                else
                {
                    item.Value.NodeTypes = "internal node";
                }
            }

            //ノードの深さの設定
            Queue<Node> nodeQ = new Queue<Node>();

            nodeQ.Enqueue(nodes[rootNode]);
            while (nodeQ.Count() != 0)
            {
                Node node = nodeQ.Dequeue();
                if (node.Depth == -1) { node.Depth = nodes[node.Parent].Depth + 1; }
                if (node.Left != -1) nodeQ.Enqueue(nodes[node.Left]);
                if (node.Right != -1) nodeQ.Enqueue(nodes[node.Right]);
            }

            //ノードの高さの設定
            Stack<Node> nodeSt = new Stack<Node>();

            nodeSt.Push(nodes[rootNode]);
            while (nodeSt.Count() != 0)
            {
                Node node = nodeSt.Peek();

                bool flg = false;
                if (node.Left != -1 && nodes[node.Left].Height == -1)
                {
                    nodeSt.Push(nodes[node.Left]);
                    flg = true;
                }
                if (node.Right != -1 && nodes[node.Right].Height == -1)
                {
                    nodeSt.Push(nodes[node.Right]);
                    flg = true;
                }

                if (!flg)
                {
                    node.Height = Math.Max(
                        node.Left != -1 ? nodes[node.Left].Height : -1,
                        node.Right != -1 ? nodes[node.Right].Height : -1) + 1;
                    nodeSt.Pop();
                }
            }

            foreach (var item in nodes)
            {
                Console.WriteLine("node {0}: parent = {1}, sibling = {2}, degree = {3}, depth = {4}, height = {5}, {6}",
                    item.Key, item.Value.Parent, item.Value.Sibling, item.Value.Degree, item.Value.Depth, item.Value.Height, item.Value.NodeTypes);
            }
          
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
