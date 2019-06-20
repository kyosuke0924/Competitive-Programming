using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0287
{
    class Program
    {
        static readonly string[] units =
            { "", "Man", "Oku", "Cho", "Kei", "Gai", "Jo", "Jou", "Ko",
            "Kan", "Sei", "Sai", "Gok", "Ggs", "Asg", "Nyt", "Fks", "Mts"};

        static void Main(string[] args)
        {
            while (true)
            {
                int[] mn = RArInt();
                if (mn.Sum() == 0) break;

                int[] num = new int[units.Length];
                num[0] = mn[0];
                for (int i = 1; i < mn[1]; i++)
                {
                    int carrying = 0;
                    for (int j = 0; j < num.Length; j++)
                    {
                        int nNum = num[j] * mn[0] + carrying;
                        num[j] = nNum % 10000;
                        carrying = nNum / 10000;
                    }
                }

                string res = string.Empty;
                for (int i = num.Length - 1; i >= 0; i--)
                {
                    if (num[i] > 0) res += num[i].ToString() + units[i];
                }

                Console.WriteLine(res);
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
