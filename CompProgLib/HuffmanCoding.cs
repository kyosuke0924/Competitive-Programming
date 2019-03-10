using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{
    public class HuffmanCoding
    {
        public class CodeInfo
        {
            public int Code { get; private set; }
            public int CodeSize { get; private set; }

            public CodeInfo(int code, int codeSize)
            {
                this.Code = code;
                this.CodeSize = codeSize;
            }
        }

        public class Node : IComparable<Node>
        {
            internal char Value { get; private set; }
            internal int Occurrence { get; private set; }
            internal List<Node> Children { get; private set; }
            public CodeInfo CodeInfo { get; internal set; }

            public Node(char v1, int v2)
            {
                this.Value = v1;
                this.Occurrence = v2;
            }

            public Node(char v1, int v2, Node n1, Node n2) : this(v1, v2)
            {
                Children = new List<Node>();
                if (n1 != null) Children.Add(n1);
                if (n2 != null) Children.Add(n2);
            }

            public void IncrementOccurrence() { Occurrence++; }
            public int CompareTo(Node other) { return other.Occurrence - Occurrence; }
        }

        public string Target { get; set; }
        public Dictionary<char, Node> Nodes { get; private set; }

        public HuffmanCoding(string s)
        {
            Target = s;
            createValue2Code();
        }

        private void createValue2Code()
        {
            // 各バイト値の発生回数を数える
            Nodes = new Dictionary<char, Node>();
            for (int i = 0 ; i < Target.Length ; i++)
            {
                if (!Nodes.ContainsKey(Target[i]))
                {
                    Nodes.Add(Target[i], new Node(Target[i], 1));
                }
                else
                {
                    Nodes[Target[i]].IncrementOccurrence();
                }
            }

            // ハフマン木を作成
            PriorityQueue<Node> queue = new PriorityQueue<Node>();
            foreach (var item in Nodes) { queue.Enqueue(item.Value); }

            if (queue.Count == 1)
            {
                Node n1 = queue.Dequeue();
                Nodes[n1.Value].CodeInfo = new CodeInfo(1, 1);
            }
            else
            {
                while (queue.Count > 1)
                {
                    Node n1 = queue.Dequeue();
                    Node n2 = queue.Dequeue();
                    queue.Enqueue(new Node('\0', n1.Occurrence + n2.Occurrence, n1, n2));
                }

                Node root = queue.Dequeue();
                // 深さ優先探索でバイト値→符号情報を作成
                dfs(root, 0, 0);
            }           
        }

        private void dfs(Node node, int code, int codeSize)
        {
            if (node.Children == null)
            {
                Nodes[node.Value].CodeInfo = new CodeInfo(code, codeSize);
            }
            else
            {
                dfs(node.Children[0], code << 1, codeSize + 1);
                dfs(node.Children[1], (code << 1) + 1, codeSize + 1);
            }
        }
    }
}
