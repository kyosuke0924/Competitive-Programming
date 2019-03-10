using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0083
{
    public class Program

    {
        public static void Main(string[] args)
        {
            string[] Eras = new string[] { "", "meiji", "taisho", "showa", "heisei" };


            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                int[] items = Array.ConvertAll(line.Trim().Split(' '), e => int.Parse(e));

                System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ja-JP", false);
                ci.DateTimeFormat.Calendar = new System.Globalization.JapaneseCalendar();
                DateTime date = new DateTime(items[0], items[1], items[2]);

                if (date < new DateTime(1868, 9, 8))
                {
                    Console.WriteLine("pre-meiji");
                }
                else
                {
                    Console.WriteLine("{0} {1} {2} {3}",
                        Eras[ci.DateTimeFormat.Calendar.GetEra(date)]
                        , ci.DateTimeFormat.Calendar.GetYear(date)
                        , ci.DateTimeFormat.Calendar.GetMonth(date)
                        , ci.DateTimeFormat.Calendar.GetDayOfMonth(date)
                        );
                }
            }
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
