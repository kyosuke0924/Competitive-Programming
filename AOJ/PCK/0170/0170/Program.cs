using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0170
{
    public class Program

    {
        public class Food
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public int Capacity { get; set; }
            public Food(string[] line)
            {
                Name = line[0];
                Weight = int.Parse(line[1]);
                Capacity = int.Parse(line[2]);
            }
        }

        public static Food[] foods;
        public static bool[] used;
        public static int[] candidates;
        public static int[] res;
        public static double centerOfG = double.MaxValue;
        public static double sumOfW;

        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                foods = new Food[n];
                for (int i = 0 ; i < n ; i++) foods[i] = new Food(RStAr());
                Init(n);
                SetFoods(0);
                foreach (var item in res.Reverse()) Console.WriteLine(foods[item].Name);
            }

        }

        private static void Init(int n)
        {         
            candidates = new int[n];
            res = new int[n];
            used = new bool[n];
            centerOfG = double.MaxValue;
            sumOfW = foods.Sum(x => x.Weight);
        }

        //上から順次食べ物を追加
        private static void SetFoods(int k)
        {
            if (k == foods.Length)
            {
                double curG = CalcGravity();
                if (centerOfG > curG)
                {
                    centerOfG = curG;
                    Array.Copy(candidates, res, res.Length);
                }
                return;
            }

            for (int i = 0 ; i < foods.Length ; i++)
            {
                if ((!used[i]) && CanPutUnder(k, i))
                {
                    used[i] = true;
                    candidates[k] = i;
                    SetFoods(k + 1);
                    used[i] = false;
                }
            }
        }

        private static bool CanPutUnder(int k, int i)
        {
            return candidates.Take(k).Select(x => foods[x].Weight).Sum() <= foods[i].Capacity;
        }

        private static double CalcGravity()
        {
            return candidates.Select((x, i) => foods[x].Weight * (candidates.Length - i)).Sum() / sumOfW;
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
