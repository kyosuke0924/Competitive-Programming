using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0054
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                int[] items = Array.ConvertAll(line.Trim().Split(' '), e => int.Parse(e));
                string div = (items[0] / (decimal)items[1] - Math.Floor(items[0] / (decimal)items[1])).ToString("0." + new string('0',100)).Replace("0.","");

                Console.WriteLine(div.Take(items[2]).Select(x => int.Parse(x.ToString())).Sum());
            }              
        }
    }

}
