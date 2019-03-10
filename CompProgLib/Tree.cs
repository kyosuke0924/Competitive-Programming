using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib.Tree
{
    public class Node<T>
    {
        public T Value { get; set; }
        public virtual Node<T> Parent { get; set; }
        protected NodeList<T> Neighbors { get; set; }

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            Value = data;
            Neighbors = neighbors;
        }
    }

    public class NodeList<T> : List<Node<T>>
    {
        public NodeList() : base() { }
        public NodeList(int initialSize)
        { for (int i = 0 ; i < initialSize ; i++) Add(default(Node<T>)); }

        public Node<T> FindByValue(T value)
        {
            foreach (Node<T> node in this) if (node.Value.Equals(value)) return node;
            return null;
        }
    }
}
