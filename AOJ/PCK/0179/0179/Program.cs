using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0179
{
    public class Program

    {
        public static HashSet<char> colors = new HashSet<char>() { 'r', 'g', 'b' };

        public static void Main(string[] args)
        {
            while (true)
            {
                string line = RSt();
                if (line == "0") break;

                Console.WriteLine(GetSameSteps(line));
            }

        }

        private static string GetSameSteps(string line)
        {

            Dictionary<string, int> dic = new Dictionary<string, int>();
            Queue<string> q = new Queue<string>();

            dic.Add(line, 0);
            q.Enqueue(line);

            while (q.Count() > 0)
            {
                string cur = q.Dequeue();

                if (isAllSame(cur))
                {
                    return dic[cur].ToString();
                }

                for (int i = 0 ; i < cur.Length - 1 ; i++)
                {
                    if (cur[i] != cur[i + 1])
                    {
                        char[] tmp = cur.ToCharArray();
                        tmp[i] = colors.Except(new char[] { cur[i], cur[i + 1] }).First();
                        tmp[i + 1] = tmp[i];

                        string next = string.Join("", tmp);
                        if (!dic.ContainsKey(next))
                        {
                            dic.Add(next, dic[cur] + 1);
                            q.Enqueue(next);
                        }
                    }
                }
            }

            return "NA";
        }

        private static bool isAllSame(string cur)
        {
            foreach (var color in colors) if (cur.All(x => x == color)) return true;
            return false;
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
