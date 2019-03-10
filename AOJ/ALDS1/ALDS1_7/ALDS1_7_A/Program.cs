using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_7_A
{
    public class Program

    {

        public class Node
        {
            public int Parent;
            public int Depth;
            public string NodeTypes;
            public List<int> Children;

            public Node()
            {
                Parent = -1;
                Depth = -1;
                NodeTypes = "";
                Children = new List<int>();
            }
        }

        public static void Main(string[] args)
        {
            int n = ReadInt();
            SortedDictionary<int,Node> nodes = new SortedDictionary<int, Node>();

            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                nodes.Add(line[0],new Node());
                for (int j = 0 ; j < line[1] ; j++)
                { 
                    nodes[line[0]].Children.Add(line[j + 2]);
                }
            }

            foreach (var item in nodes)
            {
                for (int i = 0 ; i < item.Value.Children.Count ; i++)
                {
                    nodes[item.Value.Children[i]].Parent = item.Key;
                }

            }

            int rootNode = -1;
            foreach (var item in nodes)
            {
                if (item.Value.Parent == -1)
                {
                    item.Value.NodeTypes = "root";
                    item.Value.Depth = 0;
                    rootNode = item.Key;
                }
                else if (item.Value.Children.Count == 0)
                {
                    item.Value.NodeTypes = "leaf";
                }
                else
                {
                    item.Value.NodeTypes = "internal node";
                }
            }

            Queue<Node> nodeQ = new Queue<Node>();

            nodeQ.Enqueue(nodes[rootNode]);
            while (nodeQ.Count() != 0)
            {
                Node node = nodeQ.Dequeue();
                if (node.Depth == -1) { node.Depth = nodes[node.Parent].Depth + 1; }
                for (int i = 0 ; i < node.Children.Count ; i++) { nodeQ.Enqueue(nodes[node.Children[i]]); }
            }


            foreach (var item in nodes)
            {
                Console.WriteLine("node {0}: parent = {1}, depth = {2}, {3}, [{4}]",
                    item.Key, item.Value.Parent, item.Value.Depth, item.Value.NodeTypes, String.Join(", ", item.Value.Children.Select(x => x.ToString()).ToArray()));
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
