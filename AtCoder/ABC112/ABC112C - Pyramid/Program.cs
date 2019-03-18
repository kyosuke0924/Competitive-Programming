using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        int n = int.Parse(System.Console.ReadLine().Trim());
        int[][] search = new int[n][];
        int x =0, y =0, h=0, HKari=0;
             
        for(int i = 0; i < n; i++)
        {
            search[i] = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            if (search[i][2] > 0 && h == 0)
            {
                x = search[i][0];
                y = search[i][1];
                h = search[i][2];
            }
        }

        for (int i = 0; i <= 100; i++)
        {
            for (int j = 0; j <= 100; j++)
            {
                
                HKari = h + Math.Abs(i - x) + Math.Abs(j - y);
                int k = 0;
                while (k < n)
                {
                    if (Math.Max(HKari - Math.Abs(i - search[k][0]) - Math.Abs(j - search[k][1]), 0) != search[k][2])
                    {
                        break;
                    }
                    k++;
                }
                if (k == n)
                {
                    System.Console.WriteLine("{0} {1} {2}",i,j, HKari);
                    return;
                }
            }
        }

    }
}
