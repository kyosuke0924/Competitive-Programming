using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0261
{
    class Program
    {
        static readonly long[] MayaUnit = new long[] { 20, 20, 18, 20, 1 };
        const int BYEAR = 2012, BMONTH = 12, BDAY = 21, MAYACYCLE = 13;

        static void Main(string[] args)
        {
            while (true)
            {
                string s = RSt();
                if (s == "#") break;

                long[] vs = Array.ConvertAll(s.Split('.'), e => long.Parse(e));
                Console.WriteLine(vs.Length == 5 ? CalcAd(vs) : CalcMaya(vs));
            }
        }

        private static string CalcAd(long[] vs)
        {
            long days = 0;
            for (int i = 0; i < vs.Length; i++) days = (days + vs[i]) * MayaUnit[i];
            DateTime newDate = new DateTime(BYEAR, BMONTH, BDAY).AddDays(days);
            return newDate.ToString("yyyy.M.d");
        }

        private static string CalcMaya(long[] vs)
        {
            long days = GetDays(vs[0], vs[1], vs[2]) - GetDays(BYEAR, BMONTH, BDAY);

            long[] mayaDate = new long[MayaUnit.Length];
            for (int i = MayaUnit.Length - 1; i > 0; i--)
            {
                mayaDate[i] = days % MayaUnit[i - 1];
                days /= MayaUnit[i - 1];
            }
            mayaDate[0] = days % MAYACYCLE;
            return WAr(mayaDate, ".");
        }

        private static long GetDays(long year, long month, long day)
        {
            long y = year - 1;
            long days = y * 365 + y / 4 - y / 100 + y / 400;

            y = year % 400 + 400;
            days += (new DateTime((int)y, (int)month, (int)day) - new DateTime((int)y, 1, 1)).Days;
            return days;
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
