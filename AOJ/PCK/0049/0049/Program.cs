using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0049
{
    public class Program

    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> bloodTypeCnt = new Dictionary<string, int>() { { "A", 0 }, { "B", 0 }, { "AB", 0 }, { "O", 0 } };
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;
                bloodTypeCnt[line.Trim().Split(',')[1]]++;
            }
            foreach (var item in bloodTypeCnt) Console.WriteLine(item.Value);
        }
    }

}
