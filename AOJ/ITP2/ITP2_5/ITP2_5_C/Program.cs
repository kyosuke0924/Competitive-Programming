using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_5_C
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            string s = ReadSt();
            int[] line = Array.ConvertAll(s.Split(' '), e => int.Parse(e));

            int[] cur = line.OrderBy(x => x).ToArray();
            string[] items = Perm(cur).ToArray();
            int m = items.Count();
            for (int i = 0 ; i < m ; i++)
            {
                if (items[i] == s)
                {
                    if (i > 0) Console.WriteLine(items[i - 1]);
                    Console.WriteLine(items[i]);
                    if (i < items.Count() - 1) Console.WriteLine(items[i + 1]);
                    return;
                }
            }
        }

        static public IEnumerable<string> Perm(IEnumerable<int> items)
        {
            if (items.Count() == 1)
            {
                yield return items.First().ToString();
                yield break;
            }

            foreach (int item in items)
            {
                IEnumerable<int> unused = items.Where(x => x != item);
                foreach (string rightside in Perm(unused))
                {
                    yield return item.ToString() + " " + rightside;
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
        static string WriteAr(int[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(double[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(long[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }

    }
}
