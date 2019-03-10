using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_8_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            Dictionary<string, List<int>> sd = new Dictionary<string, List<int>>();
            SortedSet<string> ss = new SortedSet<string>();
            for (int i = 0 ; i < n ; i++)
            {
                string[] line = ReadStAr();
                switch (int.Parse(line[0]))
                {
                    case 0:
                        if (sd.ContainsKey(line[1]))
                        {
                            sd[line[1]].Add(int.Parse(line[2]));
                        }
                        else
                        {
                            sd.Add(line[1], new List<int>());
                            sd[line[1]].Add(int.Parse(line[2]));
                            ss.Add(line[1]);
                        }
                        break;
                    case 1:
                        if (sd.ContainsKey(line[1]))
                        {
                            foreach (var item in sd[line[1]])
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    case 2:
                        sd.Remove(line[1]);
                        ss.Remove(line[1]);
                        break;
                    case 3:
                        foreach (var item in ss.GetViewBetween(line[1], line[2]))
                        {
                            foreach (var item2 in sd[item])
                            {
                                Console.WriteLine("{0} {1}", item, item2);
                            }                        
                        }
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
        static string WriteAr(int[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(double[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }
        static string WriteAr(long[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }

    }

}
