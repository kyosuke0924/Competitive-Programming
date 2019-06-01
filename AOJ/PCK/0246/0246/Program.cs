using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0246
{
    class Program
    {

        static public int[] buns;
        static private List<int[]> ptn = new List<int[]>();

        static void Main(string[] args)
        {
            MakePtn(new List<long>(), 0);
            while (true)
            {
                int n = RInt();
                if (n == 0) break;
                int[] vs = RArInt();
            
                buns = new int[10];
                for (int i = 0; i < vs.Length; i++) buns[vs[i]]++;

                int res = 0;
                res += GetTwoPairs();
                res += GetOtherGroups(buns, new Dictionary<ulong, int>());
                Console.WriteLine(res);
            }
        }

        private static void MakePtn(List<long> vs, long sum)
        {
            if (sum == 10)
            {
                int[] cnts = new int[10];
                for (int i = 0; i < vs.Count(); i++) cnts[vs[i]]++;
                ptn.Add(cnts);
            }
            else
            {
                long s = vs.Count == 0 ? 1 : vs.Last();
                for (long i = s; i + sum <= 10; i++)
                {
                    if (i == 10) continue;
                    List<long> tn = new List<long>(vs); tn.Add(i);
                    MakePtn(new List<long>(tn), sum + i);
                }
            }
        }

        private static int GetTwoPairs()
        {
            int res = 0, cnt = 0;
            for (int i = 1; i < buns.Length / 2; i++)
            {
                cnt = Math.Min(buns[i], buns[buns.Length - i]);
                res += cnt;
                buns[i] -= cnt;
                buns[buns.Length - i] -= cnt;
            }
            res += buns[buns.Length / 2] / 2;
            buns[buns.Length / 2] = buns[buns.Length / 2] % 2;
            return res;
        }

        private static int GetOtherGroups(int[] rems, Dictionary<ulong, int> memo)
        {
            ulong bitRems = ChangeIArrToBit(rems);
            if (memo.ContainsKey(bitRems)) return memo[bitRems];

            int cnt = 0;
            for (int i = 0; i < ptn.Count(); i++)
            {
                int[] newRems = new int[rems.Length];
                Array.Copy(rems, newRems, rems.Length);
                if (RemoveRems(newRems, ptn[i]))
                {
                    cnt = Math.Max(cnt, 1 + GetOtherGroups(newRems, memo));
                }
            }
            memo.Add(bitRems, cnt);
            return cnt;
        }

        private static bool RemoveRems(int[] rems, int[] ptn)
        {
            for (int i = 0; i < ptn.Length; i++)
            {
                rems[i] -= ptn[i];
                if (rems[i] < 0) return false;
            }
            return true;
        }

        private static ulong ChangeIArrToBit(int[] cnts)
        {
            ulong res = 0;
            for (int i = 0; i < cnts.Length; i++)
            {
                res |= (ulong)cnts[i] << (i * 7);
            }
            return res;
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


