using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_7_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            SortedList<int,int> sd = new SortedList<int, int>();

            int count = 0;
            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                switch (line[0])
                {
                    case 0:
                        if (sd.ContainsKey(line[1]))
                        {
                            sd[line[1]]++;
                        }
                        else
                        {
                            sd.Add(line[1], 1);
                        }
                        count++;
                        Console.WriteLine(count);
                        break;
                    case 1:
                        if (sd.ContainsKey(line[1]))
                        {
                            Console.WriteLine(sd[line[1]]);
                        }
                        else Console.WriteLine(0);
                        break;
                    case 2:
                        if (sd.ContainsKey(line[1]))
                        {
                            count -= sd[line[1]];
                            sd.Remove(line[1]);
                        }
                        break;
                    case 3:

                        for (int k = Math.Max(sd.IndexOfKey(line[1]),0) ; k < sd.Keys.Count() ; k++)
                        {
                            if(sd.Keys[k] <= line[2] && line[1] <= sd.Keys[k])
                            {
                                for (int l = 0 ; l < sd.Values[k] ; l++)
                                {
                                    Console.WriteLine(sd.Keys[k]);
                                }
                            }
                            if (sd.Keys[k] > line[2])
                            {
                                break;
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
