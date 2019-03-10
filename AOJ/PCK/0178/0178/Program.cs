using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0178
{
    public class Program

    {
        enum direction { Horizontal, Vertical }
        static public List<int> field;
        public const int COLCNT = 5;

        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt(); if (n == 0) break;

                field = new List<int>();
                field.Add((int)Math.Pow(2, COLCNT) - 1); //Sentinel

                for (int k = 0 ; k < n ; k++)
                {
                    int[] items = RIntAr();
                    direction dir = (direction)(items[0] - 1);
                    int blockLength = items[1];
                    int pos = items[2] - 1;

                    int num = 0;
                    int h = 0;

                    switch (dir)
                    {
                        case direction.Horizontal:
                            num = ((int)Math.Pow(2, blockLength) - 1) << pos;
                            h = 1;
                            break;
                        case direction.Vertical:
                            num = 1 << pos;
                            h = blockLength;
                            break;
                    }

                    for (int i = field.Count - 1 ; i >= 0 ; i--)
                    {
                        if ((num & field[i]) != 0)
                        {
                            int maxIdx = field.Count - 1;
                            for (int j = i + h ; j > i ; j--) if (j > maxIdx) field.Add(num); else field[j] |= num;　//put
                            for (int j = i + h ; j > i ; j--) if (field[j] == (int)Math.Pow(2, COLCNT) - 1) field.RemoveAt(j); //erase
                            break;
                        }
                    }
                }

                Console.WriteLine(field.Skip(1).Sum(x => BitCount(x)));
            }
        }

        public static int BitCount(int bits)
        {
            bits = (bits & 0x55555555) + (bits >> 1 & 0x55555555);    //  2bitごとに計算
            bits = (bits & 0x33333333) + (bits >> 2 & 0x33333333);    //  4bitごとに計算
            bits = (bits & 0x0f0f0f0f) + (bits >> 4 & 0x0f0f0f0f);    //  8bitごとに計算
            bits = (bits & 0x00ff00ff) + (bits >> 8 & 0x00ff00ff);    //  16ビットごとに計算   
            return (bits & 0x0000ffff) + (bits >> 16);    //  32ビット分を計算   
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
