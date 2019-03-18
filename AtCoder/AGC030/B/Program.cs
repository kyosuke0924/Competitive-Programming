using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B
{
    public class Program

    {
        public static void Main(string[] args)
        {
            
            int[] items = RIntAr();

            LinkedList<int> trees = new LinkedList<int>();
            for (int i = 0 ; i < items[1] ; i++) trees.AddLast(RInt());

            long res = 0;
            int cur = 0;
            while (trees.Count>0)
            {
                int ccwMove = cur < trees.First() ? trees.First() - cur : trees.First() + items[0] - cur;
                int cwMove = cur > trees.Last() ? trees.Last() - cur : cur - trees.Last() + items[0] ;

                if (ccwMove > cwMove)
                {
                    cur = trees.First();
                    res += ccwMove;
                    trees.RemoveFirst();
                }
                else
                {
                    cur = trees.Last();
                    res += cwMove;
                    trees.RemoveLast();
                }
            }

            Console.WriteLine(res);
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}
