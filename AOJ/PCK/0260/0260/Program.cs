using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0260
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                int[] pipes = RArInt();
                int[] joints = RArInt();
                int[] cSumJoints = new int[joints.Length + 1];
                cSumJoints[0] = 0;

                Array.Sort(joints);
                Array.Reverse(joints);

                for (int i = 1; i < cSumJoints.Length; i++)
                {
                    cSumJoints[i] = cSumJoints[i - 1] + joints[i - 1];
                }

                long salary = 0;
                long pipeSum = pipes.Sum();
                for (int i = 0; i < n; i++)
                {
                    salary = Math.Max(salary, (pipeSum + cSumJoints[i]) * (n - i));
                }
                Console.WriteLine(salary);


            }
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
