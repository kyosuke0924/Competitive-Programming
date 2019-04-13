using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0239
{
    class Program
    {
        class Sweets
        {
            public int ID { get; set; }
            public int Protein { get; set; }
            public int Lipid { get; set; }
            public int Carbohydrate { get; set; }
            public int Calorie { get; set; }
            public Sweets(int[] vs)
            {
                ID = vs[0];
                Protein = vs[1];
                Lipid = vs[2];
                Carbohydrate = vs[3];
                Calorie = (Protein + Carbohydrate) * 4 + Lipid * 9;
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                Sweets[] sweets = new Sweets[n];
                for (int i = 0; i < n; i++) sweets[i] = new Sweets(RArInt());

                int[] limit = RArInt();
                bool flg = false;
                for (int i = 0; i < sweets.Length; i++)
                {
                    if (sweets[i].Protein <= limit[0] && sweets[i].Lipid <= limit[1] 
                         && sweets[i].Carbohydrate <= limit[2] && sweets[i].Calorie <= limit[3])
                    {
                        Console.WriteLine(sweets[i].ID);
                        flg = true;
                    }
                }
                if (!flg) Console.WriteLine("NA");
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
