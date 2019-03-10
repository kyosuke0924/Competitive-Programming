using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0047
{
    public class Program

    {
        public static void Main(string[] args)
        {
            Dictionary<string, bool> cups = new Dictionary<string, bool>() { { "A", true }, { "B", false }, { "C", false } };
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                string[] change = line.Split(',');
                bool tmp = cups[change[0]]; cups[change[0]] = cups[change[1]]; cups[change[1]] = tmp;
            }
            Console.WriteLine(cups.Where(x => x.Value == true).First().Key);
        }

    }

}
