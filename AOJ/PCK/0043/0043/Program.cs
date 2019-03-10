using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0043
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                List<int> res = new List<int>();
                for (int i = 1 ; i < 10 ; i++) if (IsCompleteHand(line + i)) res.Add(i);
                Console.WriteLine(res.Count > 0 ? WAr(res) : "0");
            }

        }

        private static bool IsCompleteHand(string line)
        {
            int[] numsCnt = new int[9];
            for (int i = 0 ; i < line.Length ; i++) numsCnt[int.Parse(line[i].ToString()) - 1]++;

            if (numsCnt.Max() > 4) return false; //牌が4枚を超えるとNG

            int sum = numsCnt.Select((x, i) => (i + 1) * x).Sum(); //牌の合計値
            int remOfSum = sum % 3;

            //remOfsum:0 ⇒ 雀頭候補：3,6,9⇒i:2,5,8
            //remOfsum:1 ⇒ 雀頭候補：2,5,8⇒i:1,4,7
            //remOfsum:2 ⇒ 雀頭候補：1,4,7⇒i:0,3,6

            for (int i = (2 - remOfSum) ; i < 9 ; i += 3)
            {
                if (numsCnt[i] < 2) continue;
                int[] numsCntClone = (int[])numsCnt.Clone();
                numsCntClone[i] -= 2;
                if (CanCreate4Set(numsCntClone)) return true;
            }

            return false;
        }

        private static bool CanCreate4Set(int[] numsCnt)
        {
            for (int i = 0 ; i < 7 ; i++)
            {
                int r = numsCnt[i] % 3;
                if (numsCnt[i + 1] >= r && numsCnt[i + 2] >= r)
                {
                    numsCnt[i] -= r; numsCnt[i + 1] -= r; numsCnt[i + 2] -= r;
                }
                else return false;
            }

            if (numsCnt.All(x => x == 0 || x == 3)) return true;
            else return false;
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
