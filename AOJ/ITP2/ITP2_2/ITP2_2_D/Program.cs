using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_2_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int[] n = ReadIntAr();
            List<MyLinkedList<int>> li = new List<MyLinkedList<int>>();
            for (int i = 0 ; i < n[0] ; i++) li.Add(new MyLinkedList<int>());

            for (int i = 0 ; i < n[1] ; i++)
            {
                int[] line = ReadIntAr();
                switch (line[0])
                {
                    case 0: li[line[1]].InsertLast(line[2]); break;
                    case 1: Console.WriteLine(String.Join(" ", li[line[1]].Select(x => x.ToString()).ToArray())); break;
                    case 2:
                        {
                            li[line[2]].Concat(li[line[1]]);
                            li[line[1]].Clear();
                        }
                        break;
                }
            }
        }

        public class MyLinkedList<T> : IEnumerable<T>
        {
            public class Node
            {
                public T Value { get; set; }
                public Node Next { get; set; }
                public Node Prev { get; set; }
                internal Node(T val, Node prev, Node next)
                {
                    Value = val; Prev = prev; Next = next;
                }
            }

            public Node Dummy { get; set; }

            public MyLinkedList()
            {
                Clear();
            }

            public Node First { get{ return Dummy.Next; }  } 
            public Node Last { get { return Dummy.Prev; } }
            public Node End { get { return Dummy; } }
            public int Count
            {
                get
                {
                    int i = 0;
                    for (Node n = this.First ; n != this.End ; n = n.Next)
                        ++i;
                    return i;
                }
            }

            public Node InsertAfter(Node n, T elem)
            {
                Node m = new Node(elem, n, n.Next);
                n.Next.Prev = m;
                n.Next = m;
                return m;
            }

            public Node InsertBefore(Node n, T elem)
            {
                Node m = new Node(elem, n.Prev, n);
                n.Prev.Next = m;
                n.Prev = m;
                return m;
            }

            public Node InsertFirst(T elem)
            {
                return InsertAfter(Dummy, elem);
            }

            public Node InsertLast(T elem)
            {
                return InsertBefore(this.Dummy, elem);
            }

            public Node Erase(Node n)
            {
                if (n == Dummy) return Dummy;
                n.Prev.Next = n.Next;
                n.Next.Prev = n.Prev;
                return n.Next;
            }

            public void EraseFirst()
            {
                Erase(First);
            }

            public void EraseLast()
            {
                Erase(Last);
            }

            public void Concat(MyLinkedList<T> other)
            {
                Dummy.Prev.Next = other.Dummy.Next;
                other.Dummy.Next.Prev = Dummy.Prev.Next;

                other.Dummy.Prev.Next = Dummy;
                Dummy.Prev = other.Dummy.Prev;
            }

            public void Clear()
            {
                Dummy = new Node(default(T), null, null);
                Dummy.Next = Dummy;
                Dummy.Prev = Dummy;
            }

            public IEnumerator<T> GetEnumerator()
            {
                for (Node n = First ; n != End ; n = n.Next)
                    yield return n.Value;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
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
