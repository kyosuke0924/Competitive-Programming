using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABC110B___1_Dimensional_World_s_Tale
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] line = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            int n = line[0];
            int m = line[1];
            int x = line[2];
            int y = line[3];
            int[] lineX = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
            int[] lineY = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);

            for(int z = x + 1; z <= y; z++)
            {
                if (isNoWar(z, lineX, lineY))
                {
                    Console.WriteLine("No War");
                    return;
                }
            }

            Console.WriteLine("War");

        }

        static bool isNoWar(int z,int[] lineX, int[] lineY)
        {
            for (int i = 0; i < lineX.Count(); i++)
            {
                if (lineX[i] >= z){return false;}
            }

            for (int i = 0; i < lineY.Count(); i++)
            {
                if (lineY[i] < z) { return false;}

            }
            return true;
        }
    }

}
