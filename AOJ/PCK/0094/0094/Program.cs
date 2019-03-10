using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0094
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] n = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), e => int.Parse(e));
            Console.WriteLine(n[0]*n[1]/3.305785);
        }
    }

}
