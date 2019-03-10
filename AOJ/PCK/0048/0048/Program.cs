using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0048
{
    public class Program

    {
        public static void Main(string[] args)
        {
            SortedDictionary<int, string> ranks = new SortedDictionary<int, string>
            {
                  {48,"light fly" }
                , {51,"fly" }
                , {54,"bantam"}
                , {57,"feather" }
                , {60,"light"}
                , {64,"light welter"}
                , {69,"welter"}
                , {75,"light middle" }
                , {81,"middle"}
                , {91,"light heavy"}
                , {150,"heavy"}
            };

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;
                Console.WriteLine(ranks.Where(x => decimal.Parse(line) <= x.Key).First().Value);
            }
        }
    }
}

