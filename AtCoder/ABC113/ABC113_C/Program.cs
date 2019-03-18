using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABC113_C
{
    public class Program

    {

        public  class City
        {
            public int index { get; set; }
            public int year { get; set; } 
            public int p { get; set; }
            public int BirthOrder { get; set; }

            public City(int i,int year,int p)
            {
                this.index = i;
                this.year = year;
                this.p = p;
                this.BirthOrder = 0;
            }
        }

        public static void Main(string[] args)
        {
            int[] line = ReadIntAr();
            int n = line[0];
            int m = line[1];

            List<City> cities = new List<City>();
            int[] tmp;
            for (int i = 0 ; i < m ; i++)
            {
                tmp = ReadIntAr();
                cities.Add(new City(i,tmp[1],tmp[0]));
            }

            var tmp2 = cities.OrderBy(x => x.p).ThenBy(x => x.year);

            int k = 1;
            int beforeP = 0 ;
            foreach (var item in tmp2)
            {
                if (beforeP != item.p) k = 1;
                item.BirthOrder = k;
                beforeP = item.p;
                k++;
            }

            var res = cities.OrderBy(x => x.index).ToArray();
            for (int i = 0 ; i < m ; i++)
            {
                Console.WriteLine(res[i].p.ToString("000000") + res[i].BirthOrder.ToString("000000"));
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
