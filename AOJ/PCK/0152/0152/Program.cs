using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0152
{
    public class Program

    {
        struct Student
        {
            public int ID { get; }
            public int Score { get; }
            public Student(int id, int score) { ID = id;  Score = score; }
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                int n = RInt();
                if (n == 0) break;

                Student[] students = new Student[n];
                for (int k = 0 ; k < n ; k++)
                {
                    int[] items = RIntAr();
                    int ID = items[0];
                    List<int>[] frame = SetFrame(items.Skip(1));
                    students[k] = new Student(ID, CalcScore(frame));
                }

                foreach (var item in students.OrderByDescending(x => x.Score).ThenBy(x => x.ID))
                {
                    Console.WriteLine("{0} {1}", item.ID, item.Score);
                }
            }
        }

        public static List<int>[] SetFrame(IEnumerable<int> pins)
        {
            List<int>[] res = new List<int>[10];
            for (int i = 0 ; i < res.Length ; i++) res[i] = new List<int>(3);

            int frame = 0;
            int throwCnt = 0;
            foreach (var pin in pins)
            {
                res[frame].Add(pin);

                if (frame < 9)
                {
                    if (pin == 10 || throwCnt == 1)
                    {
                        frame++;
                        throwCnt = 0;
                    }
                    else throwCnt++;
                }
            }
            return res;
        }

        public static int CalcScore(List<int>[] frame)
        {
            int sum = frame.Sum(x => x.Sum());
            for (int i = 0 ; i < frame.Length - 1 ; i++)
            {
                if (frame[i].Sum() == 10)
                {
                    if (frame[i].Count() == 2) sum += frame[i + 1][0];
                    else
                    {
                        if (frame[i + 1].Count() >= 2) sum += frame[i + 1][0] + frame[i + 1][1];
                        else sum += frame[i + 1][0] + frame[i + 2][0];
                    }
                }
            }
            return sum;
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}
