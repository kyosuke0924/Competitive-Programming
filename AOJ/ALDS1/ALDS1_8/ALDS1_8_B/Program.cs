using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompProgLib.Tree.BinaryTree;

namespace ALDS1_8_B
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            BinaryTree<int> bt = new BinaryTree<int>();
            for (int i = 0 ; i < n ; i++)
            {
                string[] line = ReadStAr();
                switch (line[0])
                {
                    case "insert":
                        bt.Add(int.Parse(line[1]));
                        break;
                    case "find":
                        Console.WriteLine(bt.Contains(int.Parse(line[1])) ? "yes" : "no");
                        break;
                    case "print":
                        Console.WriteLine(" " + string.Join(" ", bt.InorderTraversal(bt.Root).Select(x => x.ToString()).ToArray()));
                        Console.WriteLine(" " + string.Join(" ", bt.PreorderTraversal(bt.Root).Select(x => x.ToString()).ToArray()));
                        break;
                    default:
                        break;
                }
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
