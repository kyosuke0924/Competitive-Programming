using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0111
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null) return;

                string bit = "";
                foreach (var item in line) bit += Convert.ToString(Array.IndexOf(toBit, item), 2).PadLeft(5,'0');

                string res = "";
                int pos = 0;
                int len = 1;
                while (pos + len <= bit.Length)
                {
                    if (toChar.ContainsKey(bit.Substring(pos, len)))
                    {
                        res += toChar[bit.Substring(pos, len)];
                        pos += len; len = 1;
                    }
                    else len++;
                }
                Console.WriteLine(res);
            }
        }

        static readonly Dictionary<string, char> toChar = new Dictionary<string, char>()
        {
            {"101",' '},
            {"000000",'\''},
            {"000011",','},
            {"10010001",'-'},
            {"010001",'.'},
            {"000001",'?'},
            {"100101",'A'},
            {"10011010",'B'},
            {"0101",'C'},
            {"0001",'D'},
            {"110",'E'},
            {"01001",'F'},
            {"10011011",'G'},
            {"010000",'H'},
            {"0111",'I'},
            {"10011000",'J'},
            {"0110",'K'},
            {"00100",'L'},
            {"10011001",'M'},
            {"10011110",'N'},
            {"00101",'O'},
            {"111",'P'},
            {"10011111",'Q'},
            {"1000",'R'},
            {"00110",'S'},
            {"00111",'T'},
            {"10011100",'U'},
            {"10011101",'V'},
            {"000010",'W'},
            {"10010010",'X'},
            {"10010011",'Y'},
            {"10010000",'Z'}
        };

        static readonly char[] toBit = new char[]
        {
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',' ','.',',','-','\'','?'
        };


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
