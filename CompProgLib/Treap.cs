using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib.Tree.BinaryTree

{

    public class TreapNode<T> : BinaryTreeNode<T>
    {
        public int Priority { get; set; }
        public TreapNode() : base() { }
        public TreapNode(T data) : base(data)
        {
            Random cRandom = new Random(123456789);
            Priority = cRandom.Next(int.MaxValue);
        }
        public TreapNode(T data, int priority) : base(data)
        {
            Priority = priority;
        }
    }

    public class Treap<T> : BinaryTree<T>
    {

        public virtual void Add(T data, int priority)
        {
            TreapNode<T> n = new TreapNode<T>(data, priority);
            base.Add(n);

            TreapNode<T> current = n;
            while (current.Parent != null && current.Priority > ((TreapNode<T>)current.Parent).Priority)
            {
                if (current.Parent.Left == current)
                {
                    RightRotate((TreapNode<T>)current.Parent);
                }
                else
                {
                    LeftRotate((TreapNode<T>)current.Parent);
                }
            }
        }

        public void RightRotate(TreapNode<T> current)
        {
            int result;
            System.Collections.Comparer comparer = new System.Collections.Comparer(System.Globalization.CultureInfo.CurrentCulture);

            var parent = current.Parent;
            var newRoot = current.Left;
            current.Left = newRoot.Right;
            newRoot.Right = current;

            if (parent == null)
            {
                Root = newRoot;
                Root.Parent = null;
            }
            else
            {
                result = comparer.Compare(parent.Value, newRoot.Value);
                if (result > 0)
                    parent.Left = newRoot;
                else
                    parent.Right = newRoot;
            }
        }

        public void LeftRotate(TreapNode<T> current)
        {
            int result;
            System.Collections.Comparer comparer = new System.Collections.Comparer(System.Globalization.CultureInfo.CurrentCulture);

            var parent = current.Parent;
            var newRoot = current.Right;
            current.Right = newRoot.Left;
            newRoot.Left = current;

            if (parent == null)
            {
                Root = newRoot;
                Root.Parent = null;
            }
            else
            {
                result = comparer.Compare(parent.Value, newRoot.Value);
                if (result > 0)
                    parent.Left = newRoot;
                else
                    parent.Right = newRoot;
            }
        }

        public new bool Remove(T data)
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
                LeftRotate((TreapNode<T>)current);
                DeleteNode(current);

            }
            else if (current.Left != null && current.Right == null)
            {
                RightRotate((TreapNode<T>)current);
                DeleteNode(current);
            }
            else
            {
                if (((TreapNode<T>)current.Left).Priority > ((TreapNode<T>)current.Right).Priority)
                {
                    RightRotate((TreapNode<T>)current);
                }
                else
                {
                    LeftRotate((TreapNode<T>)current);
                }
                DeleteNode(current);
            }
        }
    }
}