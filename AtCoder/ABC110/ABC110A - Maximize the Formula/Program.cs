using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABC110A___Maximize_the_Formula
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] line = Array.ConvertAll(Console.ReadLine().Trim().Split(' '),int.Parse);
            Array.Sort(line);
            Array.Reverse(line);
            Console.WriteLine("{0}",line[0]*10+line[1] + line[2]);
        }
    }

}
