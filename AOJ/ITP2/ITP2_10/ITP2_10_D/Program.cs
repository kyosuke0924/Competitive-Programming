using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP2_10_D
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = ReadInt();
            ulong num = 0;

            ulong[] masks = new ulong[n];
            for (int i = 0 ; i < n ; i++)
            {
                int[] line = ReadIntAr();
                foreach (var x in line.Skip(1)) masks[i] |= (1UL << x);        
            }

            int q = ReadInt();
            for (int i = 0 ; i < q ; i++)
            {
                int[] line = ReadIntAr();
                switch (line[0])
                {
                    case 0:
                        Console.WriteLine(num >> line[1] & 1);
                        break;
                    case 1:
                        num |= masks[line[1]];
                        break;
                    case 2:
                        num &= ~masks[line[1]];
                        break;
                    case 3:
                        num ^= masks[line[1]];
                        break;
                    case 4:
                        Console.WriteLine((num & masks[line[1]]) == masks[line[1]] ? 1 : 0);
                        break;
                    case 5:
                        Console.WriteLine((num & masks[line[1]]) >0 ? 1 : 0);
                        break;
                    case 6:
                        Console.WriteLine((num & masks[line[1]]) == 0 ? 1 : 0);
                        break;
                    case 7:
                        Console.WriteLine(BitCount(num & masks[line[1]]));
                        break;
                    case 8:
                        Console.WriteLine(num & masks[line[1]]);
                        break;
                }
            }
        }

        private static ulong BitCount(ulong bits)
        {
            bits = (bits & 0x5555555555555555) + (bits >> 1 & 0x5555555555555555);    //  2bitごとに計算
            bits = (bits & 0x3333333333333333) + (bits >> 2 & 0x3333333333333333);    //  4bitごとに計算
            bits = (bits & 0x0f0f0f0f0f0f0f0f) + (bits >> 4 & 0x0f0f0f0f0f0f0f0f);    //  8bitごとに計算
            bits = (bits & 0x00ff00ff00ff00ff) + (bits >> 8 & 0x00ff00ff00ff00ff);    //  16ビットごとに計算   
            bits = (bits & 0x0000ffff0000ffff) + (bits >> 16 & 0x0000ffff0000ffff);    //  16ビットごとに計算   
            return (bits & 0x00000000ffffffff) + (bits >> 32);    //  32ビット分を計算  
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
