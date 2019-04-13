using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0266
{
    class Program
    {
        static void Main(string[] args)
        {
            const char DESERT = 'D';

            Dictionary<char, char[]> map = new Dictionary<char, char[]>();
            map.Add('A', new char[] { 'X', 'Y' });
            map.Add('B', new char[] { 'Y', 'X' });
            map.Add('W', new char[] { 'B', 'Y' });
            map.Add('X', new char[] { DESERT, 'Z' });
            map.Add('Y', new char[] { 'X', DESERT });
            map.Add('Z', new char[] { 'W', 'B' });

            while (true)
            {
                string p = RSt();
                if (p == "#") break;

                char cur = 'A';
                for (int i = 0; i < p.Length; i++)
                {
                    cur = map[cur][int.Parse(p[i].ToString())];
                    if(cur == DESERT)
                    {
                        break;
                    }
                }
                Console.WriteLine(cur == 'B' ? "Yes" : "No");
            }
        }
        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RArSt(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RArInt(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RArLong(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RArDouble(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }
}
