using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0060
{
    public class Program

    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                int[] cards = Array.ConvertAll(line.Trim().Split(' '), e => int.Parse(e));

                int cnt = 0;
                for (int i = 1 ; i <= 10 ; i++)
                {
                    if (cards.Contains(i)) continue;
                    if (cards[0] + cards[1] + i <= 20) cnt++;
                }
                Console.WriteLine(cnt >= 4 ? "YES" : "NO");
            }        
        }
    }

}
