using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0221
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                int[] vs = RArInt();
                if (vs.Sum() == 0) break;

                Queue<int> players = new Queue<int>();
                for (int i = 1; i <= vs[0]; i++) players.Enqueue(i);

                for (int i = 1; i <= vs[1]; i++)
                {
                    string state = RSt();
                    if (players.Count() > 1)
                    {                      
                        int tmp = players.Dequeue();
                        if (state == GetCorrectAnswer(i)) players.Enqueue(tmp);
                    }
                }
                Console.WriteLine(WAr(players.OrderBy(x => x)));
            }
        }

        static string GetCorrectAnswer(int n)
        {
            if (n % 15 == 0) return "FizzBuzz";
            if (n % 5 == 0) return "Buzz";
            if (n % 3 == 0) return "Fizz";
            return n.ToString();
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RArSt(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RArInt(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RArLong(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RArDouble(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }
}
