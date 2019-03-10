using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0063
{
    public class Program

    {
        public static void Main(string[] args)
        {
            int cnt = 0;
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;
                if (line == string.Join("",line.Reverse())) cnt++;
            }
            Console.WriteLine(cnt);
        }
    }

}
