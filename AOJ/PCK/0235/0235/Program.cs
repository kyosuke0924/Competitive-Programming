using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0235
{
    class Program
    {
        static Dictionary<int, Dictionary<int, int>> bridges;

        static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;
                Init(n);

                int AllTime = GetAllTime(0, 1);
                int LongestTime = GetLongestTime(0, 1, 0);
                Console.WriteLine(AllTime * 2 - LongestTime);
            }

        }

        private static void Init(int n)
        {
            bridges = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 1; i <= n; i++) { bridges.Add(i, new Dictionary<int, int>()); }
            for (int i = 0; i < n - 1; i++)
            {
                int[] vs = RArInt();
                bridges[vs[0]].Add(vs[1], vs[2]);
                bridges[vs[1]].Add(vs[0], vs[2]);
            }
        }

        private static int GetAllTime(int parentID, int ID)
        {
            int res = 0;
            foreach (var child in bridges[ID].Where(x => x.Key != parentID))
            {
                if (bridges[child.Key].Count(x => x.Key != ID) > 0)
                {
                    res += bridges[ID][child.Key] + GetAllTime(ID, child.Key);
                }
            }
            return res;
        }

        private static int GetLongestTime(int parentID, int ID, int time)
        {
            int maxTime = time;
            foreach (var child in bridges[ID].Where(x => x.Key != parentID))
            {
                if (bridges[child.Key].Count(x => x.Key != ID) > 0)
                {
                    maxTime = Math.Max(maxTime, bridges[ID][child.Key] + GetLongestTime(ID, child.Key, time));
                }
            }
            return maxTime;
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
