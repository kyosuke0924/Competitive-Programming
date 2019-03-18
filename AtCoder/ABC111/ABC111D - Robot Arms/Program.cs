using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABC111D
{
    public class Program
    {
        public static void Main(string[] args)
        {
            long n = long.Parse(System.Console.ReadLine().Trim());
            long[][] xy = new long[n][]; 

            for(int i = 0; i < n; i++)
            {
                xy[i] = Array.ConvertAll(System.Console.ReadLine().Trim().Split(' '), long.Parse);
            }

            //全ての偶奇が同一でない場合はNG
            long parity = Math.Abs(xy[0][0] + xy[0][1]) % 2;
            for (int i = 1; i < xy.Length; i++)
            {
                if(Math.Abs(xy[i][0] + xy[i][1]) % 2 != parity)
                {

                    System.Console.WriteLine("{0}",-1);
                    return;
                }
            }

            //最も遠い地点の距離
            long farP = 0;
            for (int i = 0; i < xy.Length; i++)
            {
                farP = Math.Max(farP, Math.Abs(xy[i][0]) + Math.Abs(xy[i][1]));
            }

            //最長のアーム
            long d1 = (long)Math.Pow(2, (long)(Math.Log(farP - 1, 2)));

            //アームコレクション
            List<long> d = new List<long>();
            for(long i = d1;i > 0;i /= 2)
            {
                d.Add(i);
            }
            if (parity == 0) { d.Add(1); }//偶数の場合は腕を追加


            System.Console.WriteLine("{0}", d.Count);
            System.Console.WriteLine("{0}", string.Join(" ", Array.ConvertAll(d.ToArray(), i => i.ToString())));

            long x ,y;
            long distL, distR, distU, distD;
            string rlt = string.Empty;

            //出力のパターンを表示
            for (int i = 0; i < xy.Length; i++)
            {

                x = 0; y = 0;
                distL = 0; distR = 0; distU = 0; distD = 0;
                rlt = string.Empty;
  
                for (int j = 0; j < d.Count; j++)
                {
                    distR = (long)Math.Pow(Math.Abs(xy[i][0] - (x + d[j])),2) + (long)Math.Pow(Math.Abs(xy[i][1] - y), 2);
                    distL = (long)Math.Pow(Math.Abs(xy[i][0] - (x - d[j])), 2) + (long)Math.Pow(Math.Abs(xy[i][1] - y), 2);
                    distU = (long)Math.Pow(Math.Abs(xy[i][0] - x ), 2) + (long)Math.Pow(Math.Abs(xy[i][1] - (y + d[j])), 2);
                    distD = (long)Math.Pow(Math.Abs(xy[i][0] - x ), 2) + (long)Math.Pow(Math.Abs(xy[i][1] - (y - d[j])), 2);

                    if (distR <= distL && distR <= distU && distR <= distD)
                    {
                        rlt += "R";
                        x += d[j];
                        continue;
                    }
                    if (distL <= distR && distL <= distU && distL <= distD)
                    {
                        rlt += "L";
                        x -= d[j];
                        continue;
                    }
                    if (distU <= distR && distU <= distL && distU <= distD)
                    {
                        rlt += "U";
                        y += d[j];
                        continue;
                    }
                    if (distD <= distR && distD <= distL && distD <= distU)
                    {
                        rlt += "D";
                        y -= d[j];
                        continue;
                    }
                }

                System.Console.WriteLine("{0}", rlt);
            }

        }
    }
}