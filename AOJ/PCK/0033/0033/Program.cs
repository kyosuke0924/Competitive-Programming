using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0033
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = RInt();

            for (int i = 0 ; i < n ; i++)
            {
                int[] items = RIntAr();
                LinkedList<int> cylinderB = new LinkedList<int>();
                LinkedList<int> cylinderC = new LinkedList<int>();

                cylinderB.AddFirst(0);
                cylinderC.AddFirst(0);

                bool CanPut = true;
                for (int j = 0 ; j < items.Count() ; j++)
                {
                    if (cylinderB.Last.Value < items[j] || cylinderC.Last.Value < items[j])
                    {
                        if (cylinderB.Last.Value < items[j] && cylinderC.Last.Value > items[j]) cylinderB.AddLast(items[j]);
                        else if (cylinderB.Last.Value > items[j] && cylinderC.Last.Value < items[j]) cylinderC.AddLast(items[j]);
                        else { if(cylinderB.Last.Value > cylinderC.Last.Value) cylinderB.AddLast(items[j]); else cylinderC.AddLast(items[j]); }
                    }
                    else
                    {
                        CanPut = false;
                        break;
                    }
                }
                Console.WriteLine(CanPut ? "YES" : "NO");
            }
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
