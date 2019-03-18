using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] line = Array.ConvertAll<string, int>(Console.ReadLine().Trim().Split(' '), int.Parse);
        int n = line[0];
        int time = line[1];
        int cost = 1000;
        bool founded = false;

        for (int i = 0; i < n; i++)
        {
            line = Array.ConvertAll<string, int>(Console.ReadLine().Trim().Split(' '), int.Parse);
            if (line[1]<= time && line[0] <= cost)
            {
                founded = true;
                cost = line[0]; 
            }
        }

        if (!founded)
        { System.Console.WriteLine("TLE"); }
        else
        { System.Console.WriteLine(cost.ToString()); }
    }
}
