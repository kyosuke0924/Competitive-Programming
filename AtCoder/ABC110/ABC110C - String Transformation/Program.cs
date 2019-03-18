using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABC110C___String_Transformation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string lineA = Console.ReadLine().Trim();
            string lineB = Console.ReadLine().Trim();

            Dictionary<char, int> dicA = new Dictionary<char, int>();
            Dictionary<char, int> dicB = new Dictionary<char, int>();

            //Aの出現頻度
            for (int i = 0; i < lineA.Length; i++)
            {
                if (dicA.ContainsKey(lineA[i]))
                    dicA[lineA[i]]++;
                else
                    dicA.Add(lineA[i], 1);
            }

            //Bの出現頻度
            for (int i = 0; i < lineB.Length; i++)
            {
                if (dicB.ContainsKey(lineB[i]))
                    dicB[lineB[i]]++;
                else
                    dicB.Add(lineB[i], 1);
            }

            //出現頻度でソート
            List<int> listA = dicA.OrderBy((x) => x.Value).Select((x) => x.Value).ToList();
            List<int> listB = dicB.OrderBy((x) => x.Value).Select((x) => x.Value).ToList();

            for  (int i = 0; i < listA.Count; i++)
            {
               if (listA[i] != listB[i])
                {
                    Console.WriteLine("{0}", "No");
                    return;
                }
             }

            Console.WriteLine("{0}", "Yes");
            return;

        }
    }

}
