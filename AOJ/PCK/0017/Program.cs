using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0017
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null) break;
                for (int i = 1 ; i <= 26 ; i++)
                {
                    string res = string.Join("", line.Select(x => ('a' <= x && x <= 'z') ? (char)((x - 'a' + i) % 26 + 'a') : x));
                    if (res.Contains("the") || res.Contains("this") || res.Contains("that"))
                    {
                        Console.WriteLine(res);
                        break;
                    }
                }
            }
        }
    }

}
