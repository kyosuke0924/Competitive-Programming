using System;
using System.Linq;

namespace _0018
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(WriteAr(ReadIntAr().OrderByDescending(x => x).ToArray()));
        }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static string WriteAr(int[] array, string sep = " ") { return String.Join(sep, array.Select(x => x.ToString()).ToArray()); }

    }

}
