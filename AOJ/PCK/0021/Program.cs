using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0021
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0 ; i < n ; i++)
            {
                decimal[] items = ReadDecAr();
                decimal slopeA = (items[2] - items[0]) * (items[7] - items[5]);
                decimal slopeB = (items[6] - items[4]) * (items[3] - items[1]);
                Console.WriteLine(slopeA == slopeB  ? "YES" : "NO");
            }
           
        }

        static decimal[] ReadDecAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => decimal.Parse(e)); }

    }

}
