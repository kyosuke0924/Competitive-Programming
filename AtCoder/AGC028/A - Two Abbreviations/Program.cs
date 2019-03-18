using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        long[] line = Array.ConvertAll(System.Console.ReadLine().Trim().Split(' '), long.Parse);
        long n = line[0];
        long m = line[1];
        string s = System.Console.ReadLine().Trim();
        string t = System.Console.ReadLine().Trim();

        if (n > m)
        {
            long tmp1;
            string tmp2;

            tmp1 = n;
            n = m;
            m = tmp1;
            tmp2 = s;
            s = t;
            t = tmp2;

        }

        long gcd = Gcd(n, m);
        for (long i = 0; i < gcd ; i++)
        {
            if (s[(int)(i * (n / gcd))] != t[(int)(i * (m / gcd))])
            {
                System.Console.WriteLine("{0}", -1);
                return;
            }
        }

        System.Console.WriteLine("{0}", Lcm(n, m));

    }

        // 最小公倍数
        static long Lcm(long a, long b)
    {
        return a / Gcd(a, b) * b;
    }

    // 最大公約数
    static long Gcd(long a, long b)
    {
        if (a < b)
            return Gcd(b, a);  // 引数を入替えて自分を呼び出す
        long d = 0;
        do
        {
            d = a % b;
            a = b;
            b = d;
        } while (d != 0);
        return a;
    }

}
