using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0176
{
    public class Program

    {
        public class Color
        {
            public string Name { get; }
            public int R { get; }
            public int G { get; }
            public int B { get; }
            public Color(string name, int r, int g, int b)
            {
                Name = name;
                R = r; G = g; B = b;
            }
        }

        public static Color[] colors = new Color[]
        {
             new Color("black"  ,    0,   0,   0)
            ,new Color("blue"   ,    0,   0, 255)
            ,new Color("lime"   ,    0, 255,   0)
            ,new Color("aqua"   ,    0, 255, 255)
            ,new Color("red"    ,  255,   0,   0)
            ,new Color("fuchsia",  255,   0, 255)
            ,new Color("yellow" ,  255, 255,   0)
            ,new Color("white"  ,  255, 255, 255)
        };

        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "0") return;

                int colorR = Convert.ToInt32(line.Substring(1, 2), 16);
                int colorG = Convert.ToInt32(line.Substring(3, 2), 16);
                int colorB = Convert.ToInt32(line.Substring(5, 2), 16);

                double minV = double.MaxValue;
                string minN = "";

                for (int i = 0 ; i < colors.Length ; i++)
                {
                    double v = Math.Sqrt(Math.Pow(colorR - colors[i].R, 2) + Math.Pow(colorG - colors[i].G, 2) + Math.Pow(colorB - colors[i].B, 2));
                    if ( v <minV)
                    {
                        minV = v;
                        minN = colors[i].Name;
                    }
                }
                Console.WriteLine(minN);
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
