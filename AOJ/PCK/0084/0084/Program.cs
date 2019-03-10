using System;
using System.Linq;

namespace _0084
{
    public class P
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(" ", Console.ReadLine().Split(" .,".ToArray()).Where(x => x.Length > 2 && x.Length < 7)));
        }
    }

}
