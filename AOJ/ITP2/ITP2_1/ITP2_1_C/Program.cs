using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_1_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            LinkedList<int> ll = new LinkedList<int>();
            LinkedListNode<int> cur = new LinkedListNode<int>(int.MaxValue);
            ll.AddFirst(cur);

            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                switch (line[0])
                {
                    case 0:
                        {
                           ll.AddBefore(cur, line[1]);
                            cur = cur.Previous;
                            break;
                        }
                    case 1:
                        {
                            if (line[1] > 0) {
                                for (int j = 0 ; j < line[1] ; j++) cur = cur.Next;
                            }
                            else {
                                for (int j = 0 ; j < -1 * line[1] ; j++) cur = cur.Previous;
                            }
                            break;
                        }                     
                    case 2:
                        {
                            cur = cur.Next;
                            ll.Remove(cur.Previous);
                            break;
                        }
                }
            }

            foreach (var item in ll)
            {
                if (item != int.MaxValue) Console.WriteLine(item.ToString());
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
