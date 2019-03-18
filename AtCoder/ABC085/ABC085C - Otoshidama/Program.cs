using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] line = Array.ConvertAll(Console.ReadLine().Trim().Split(' '),int.Parse);
        int iCnt = line[0];
        int iAmount = line[1];

        for(int i = iCnt; i >=0; i--)
        {
            for (int j = iCnt -i; j >= 0; j--)
            {
                    if(i*10000+j*5000+(iCnt - i -j) *1000 == iAmount)
                    {
                        Console.WriteLine("{0} {1} {2}",i,j, (iCnt - i - j));
                        return;
                    }
            }
        }
        Console.WriteLine("{0} {1} {2}", -1, -1, -1);
    }
}
