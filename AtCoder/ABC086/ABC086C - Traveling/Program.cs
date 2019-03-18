using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(System.Console.ReadLine().Trim());
        int[] line;
        int t = 0, x = 0, y = 0;
        int dt=0, dx=0, dy=0;

        for(int i = 0; i < n; i++)
        {
            line = Array.ConvertAll<string,int>(Console.ReadLine().Trim().Split(' '),int.Parse);
            dt = line[0]-t;
            dx = Math.Abs(line[1] - x);
            dy = Math.Abs(line[2] - y);
            if (dt < dx + dy || dt%2 != (dx+dy)%2)
            {
                Console.WriteLine("No");
                return;
            }
            t = line[0];
            x = line[1];
            y = line[2];

        }
        System.Console.WriteLine("Yes");
    }
}
