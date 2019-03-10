using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALDS1_3_B
{
    public class Program

    {
        struct Task
        {
            public string name { get; set; }
            public int time { get; set; }

            public Task(string[] x)
            {
                this.name = x[0];
                this.time = int.Parse(x[1]);
            }
        }

        public static void Main(string[] args)
        {
            int[] line = ReadIntAr();
            int n = line[0];
            int q = line[1];
            Queue<Task> tasks = new Queue<Task>();
            for (int i = 0 ; i < n ; i++) tasks.Enqueue(new Task(ReadStAr()));

            int elapsedTime = 0;
            Task tmp;
            while (tasks.Count > 0)
            {
                tmp = tasks.Dequeue();
                if (tmp.time <= q)
                {
                    elapsedTime += tmp.time;
                    Console.WriteLine("{0} {1}", tmp.name,elapsedTime);
                }
                else
                {
                    elapsedTime += q;
                    tmp.time -= q;
                    tasks.Enqueue(tmp);
                }
            }
        }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }

    }

}
