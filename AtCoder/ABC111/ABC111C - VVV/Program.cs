using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(System.Console.ReadLine().Trim());
        int[] line = Array.ConvertAll(System.Console.ReadLine().Trim().Split(' '),int.Parse);

        Dictionary<int, int> s = new Dictionary<int, int>();
        Dictionary<int, int> t = new Dictionary<int, int>();
        Dictionary<int, int> tmp;

        for (int i = 0; i < n ; i++)
        {
           
            tmp = (i % 2 == 0) ? s: t;

            if(tmp.ContainsKey(line[i]))
            {
                tmp[line[i]]++;
            }
            else
            {
                tmp.Add(line[i], 1);
            }
        }

        int s1 = 0, s2 = 0, t1 = 0, t2 = 0;

        //出現頻度で並び替え
        s = s.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        t = t.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        List <int> sSortedKeys = s.Keys.ToList();
        List <int> tSortedKeys = t.Keys.ToList();

        s1 = s[sSortedKeys[0]];
        t1 = t[tSortedKeys[0]];

        if(sSortedKeys[0] != tSortedKeys[0])
        {
            //最頻値が異なればsもtも最頻値で置換
            System.Console.WriteLine("{0}", (n - s1 - t1));

        }
        else{

            //最頻値が同じならいずれかを2番目の頻度の値で置換
            if (s.Count > 1) s2 = s[sSortedKeys[1]];
            if (t.Count > 1) t2 = t[tSortedKeys[1]];

            //sを最頻値で、tを二番目で書き換え
            //tを最頻値で、sを二番目で書き換え
            int sRlt = n - s1 - t2;
            int tRlt = n - s2 - t1;

            System.Console.WriteLine("{0}", Math.Min(sRlt, tRlt));

        }


    }

    


}
