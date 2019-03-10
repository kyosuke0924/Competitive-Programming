using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib.Tree.BinaryTree
{
    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode() : base() { }
        public BinaryTreeNode(T data) : base(data, null) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            Value = data;
            Neighbors = new NodeList<T> { left, right };
        }

        public new virtual BinaryTreeNode<T> Parent { set; get; }
        public virtual BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Neighbors == null) return null;
                else return (BinaryTreeNode<T>)Neighbors[0];
            }
            set
            {
                if (base.Neighbors == null) base.Neighbors = new NodeList<T>(2);
                base.Neighbors[0] = value;
                if (value != null) value.Parent = this;
            }
        }

        public virtual BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbors == null) return null;
                else return (BinaryTreeNode<T>)Neighbors[1];
            }
            set
            {
                if (base.Neighbors == null) Neighbors = new NodeList<T>(2);
                base.Neighbors[1] = value;
                if (value != null) value.Parent = this;
            }
        }
    }

    public class BinaryTreeNodeList<T> : NodeList<T>
    {
        public BinaryTreeNodeList() : base() { }
        public BinaryTreeNodeList(int initialSize)
        { for (int i = 0 ; i < initialSize ; i++) Add(default(BinaryTreeNode<T>)); }

        public new BinaryTreeNode<T> FindByValue(T value)
        {
            foreach (BinaryTreeNode<T> node in this) if (node.Value.Equals(value)) return node;
            return null;
        }
    }

    public class BinaryTree<T>
    {

        public BinaryTreeNode<T> Root { get; protected set; }
        public int Count { get;  set; }

        public BinaryTree() { Root = null; }
        public virtual void Clear() { Root = null; }

        public List<T> PreorderTraversal(BinaryTreeNode<T> current)
        {
            List<T> res = new List<T>();
            PreorderTraversal(current, res);
            return res;
        }
        private void PreorderTraversal(BinaryTreeNode<T> current, List<T> res)
        {
            if (current != null)
            {
                res.Add(current.Value);
                PreorderTraversal(current.Left, res);
                PreorderTraversal(current.Right, res);
            }
        }

        public List<T> InorderTraversal(BinaryTreeNode<T> current)
        {
            List<T> res = new List<T>();
            InorderTraversal(current, res);
            return res;
        }
        private void InorderTraversal(BinaryTreeNode<T> current, List<T> res)
        {
            if (current != null)
            {
                InorderTraversal(current.Left, res);
                res.Add(current.Value);
                InorderTraversal(current.Right, res);
            }
        }

        public List<T> PostorderTraversal(BinaryTreeNode<T> current)
        {
            List<T> res = new List<T>();
            PostorderTraversal(current, res);
            return res;
        }
        private void PostorderTraversal(BinaryTreeNode<T> current, List<T> res)
        {
            if (current != null)
            {
                PostorderTraversal(current.Left, res);
                PostorderTraversal(current.Right, res);
                res.Add(current.Value);
            }
        }

        public virtual void Add(T data)
        {
            BinaryTreeNode<T> n = new BinaryTreeNode<T>(data);
            Add(n);
        }

        public virtual void Add(BinaryTreeNode<T> n)
        {

            int result;
            System.Collections.Comparer comparer = new System.Collections.Comparer(System.Globalization.CultureInfo.CurrentCulture);

            BinaryTreeNode<T> current = Root, parent = null;
            while (current != null)
            {
                result = comparer.Compare(current.Value, n.Value);
                if (result == 0)
                    return;
                else if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
            }

            Count++;
            if (parent == null)
                Root = n;
            else
            {
                result = comparer.Compare(parent.Value, n.Value);
                if (result > 0)
                    parent.Left = n;
                else
                    parent.Right = n;
            }
        }

        public bool Remove(T data)
        {

            System.Collections.Comparer comparer = new System.Collections.Comparer(System.Globalization.CultureInfo.CurrentCulture);
            if (Root == null) return false;

            BinaryTreeNode<T> current = Root;
            int result = comparer.Compare(current.Value, data);
            while (result != 0)
            {
                if (result > 0)
                {
                    current = current.Left;
                }
                else if (result < 0)
                {
                    current = current.Right;
                }
                if (current == null)
                    return false;
                else
                    result = comparer.Compare(current.Value, data);
            }

            Count--;

            DeleteNode(current);
            return true;
        }

        private void DeleteNode(BinaryTreeNode<T> current)
        {
            int result;
            System.Collections.Comparer comparer = new System.Collections.Comparer(System.Globalization.CultureInfo.CurrentCulture);

            if (current.Left == null && current.Right == null)
            {
                if (current.Parent == null) Root = null;
                else
                {
                    result = comparer.Compare(current.Parent.Value, current.Value);
                    if (result > 0)
                        current.Parent.Left = null;
                    else if (result < 0)
                        current.Parent.Right = null;
                }
            }
            else if (current.Left == null && current.Right != null)
            {
                if (current.Parent == null)
                {
                    Root = current.Right;
                    Root.Parent = null;
                }
                else
                {
                    result = comparer.Compare(current.Parent.Value, current.Value);
                    if (result > 0)
                        current.Parent.Left = current.Right;
                    else if (result < 0)
                        current.Parent.Right = current.Right;
                }
            }
            else if (current.Left != null && current.Right == null)
            {
                if (current.Parent == null)
                {
                    Root = current.Left;
                    Root.Parent = null;
                }
                else
                {
                    result = comparer.Compare(current.Parent.Value, current.Value);
                    if (result > 0)
                        current.Parent.Left = current.Left;
                    else if (result < 0)
                        current.Parent.Right = current.Left;
                }
            }
            else
            {
                BinaryTreeNode<T> nextnode = current.Right, nextnodeParent = current;
                while (nextnode != null)
                {
                    nextnodeParent = nextnode;
                    nextnode = nextnode.Left;
                }

                T tmp = nextnodeParent.Value;
                DeleteNode(nextnodeParent);
                current.Value = tmp;

            }
        }

        public bool Contains(T data)
        {
            BinaryTreeNode<T> current = Root;
            int result;

            System.Collections.Comparer comparer = new System.Collections.Comparer(System.Globalization.CultureInfo.CurrentCulture);
            while (current != null)
            {
                result = comparer.Compare(current.Value, data);
                if (result == 0)
                    return true;
                else if (result > 0)
                    current = current.Left;
                else if (result < 0)
                    current = current.Right;
            }

            return false;
        }

    }

}
