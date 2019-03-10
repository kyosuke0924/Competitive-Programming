using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0123
{
    public class Program

    {
        public struct Lank
        {
            public string Name { get; set; }
            public double Border0500 { get; set; }
            public double Border1000 { get; set; }
            public Lank(string name, TimeSpan _500, TimeSpan _1000)
            { Name = name; Border0500 = _500.TotalSeconds; Border1000 = _1000.TotalSeconds; }
        }
        public static List<Lank> borders = new List<Lank>();

        public static void Main(string[] args)
        {
            borders.Add(new Lank("AAA", new TimeSpan(0, 0, 0, 35, 500), new TimeSpan(0, 0, 1, 11, 000)));
            borders.Add(new Lank("AA" , new TimeSpan(0, 0, 0, 37, 500), new TimeSpan(0, 0, 1, 17, 000)));
            borders.Add(new Lank("A"  , new TimeSpan(0, 0, 0, 40, 000), new TimeSpan(0, 0, 1, 23, 000)));
            borders.Add(new Lank("B"  , new TimeSpan(0, 0, 0, 43, 000), new TimeSpan(0, 0, 1, 29, 000)));
            borders.Add(new Lank("C"  , new TimeSpan(0, 0, 0, 50, 000), new TimeSpan(0, 0, 1, 45, 000)));
            borders.Add(new Lank("D"  , new TimeSpan(0, 0, 0, 55, 000), new TimeSpan(0, 0, 1, 56, 000)));
            borders.Add(new Lank("E"  , new TimeSpan(0, 0, 1, 10, 000), new TimeSpan(0, 0, 2, 28, 000)));

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                double[] times = Array.ConvertAll(line.Trim().Split(' '), e => double.Parse(e));
                Console.WriteLine(GetLankName(times));
            }          
        }

        private static string GetLankName(double[] times)
        {
            foreach (var item in borders)
            {
                if (times[0] < item.Border0500 && times[1] < item.Border1000) return item.Name;
            }
            return "NA";
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
