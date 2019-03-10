using System;
using System.Collections.Generic;
using System.Linq;

namespace _0085
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] items = RIntAr();
                if (items.Sum() == 0) break;

                int res = 1;
                for (int i = 2 ; i <= items[0] ; i++)
                {
                    res = (res + items[1]) % i;
                    if (res == 0) res = i;
                }
                Console.WriteLine(res);
            } 
        }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
    }

}
