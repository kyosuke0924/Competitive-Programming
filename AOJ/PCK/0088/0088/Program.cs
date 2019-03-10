using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0088
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                string bit = "";
                foreach (var item in line) bit += toBit[item];
                bit += new string('0', (5 - bit.Length % 5) % 5);

                string res = "";
                for (int i = 0 ; i < bit.Length ; i += 5) res += toChar[Convert.ToInt32(bit.Substring(i, 5), 2)];

                Console.WriteLine(res);
            }
        }

        static readonly Dictionary<char, string> toBit = new Dictionary<char, string>()
        {
            {' ',"101" },
            {'\'',"000000" },
            {',',"000011" },
            {'-',"10010001" },
            {'.',"010001" },
            {'?',"000001" },
            {'A',"100101" },
            {'B',"10011010" },
            {'C',"0101" },
            {'D',"0001" },
            {'E',"110" },
            {'F',"01001" },
            {'G',"10011011" },
            {'H',"010000" },
            {'I',"0111" },
            {'J',"10011000" },
            {'K',"0110" },
            {'L',"00100" },
            {'M',"10011001" },
            {'N',"10011110" },
            {'O',"00101" },
            {'P',"111" },
            {'Q',"10011111" },
            {'R',"1000" },
            {'S',"00110" },
            {'T',"00111" },
            {'U',"10011100" },
            {'V',"10011101" },
            {'W',"000010" },
            {'X',"10010010" },
            {'Y',"10010011" },
            {'Z',"10010000" }
        };

        static readonly char[] toChar = new char[]
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
