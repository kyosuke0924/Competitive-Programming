using MathX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABC110D___Factorization
{
    public class Program
    {
    
        public static readonly int MOD = (int)Math.Pow(10, 9) + 7;

        public static void Main(string[] args)
        {
            checked { 
                string[] line = Console.ReadLine().Trim().Split(' ');
                int n = int.Parse(line[0]);
                int m = int.Parse(line[1]);

                List<int> primes = MathX.MathX.PrimeFactor(m).Select(x => (int)x).ToList();
                Dictionary<int, int> primesDic = new Dictionary<int, int>();
                foreach (int i in primes)
                {
                    if (primesDic.ContainsKey(i)) primesDic[i]++;
                    else primesDic.Add(i, 1);
                }

                long rlt = 1;

                foreach(KeyValuePair<int,int> i in primesDic)
                {
                    rlt *= MathX.MathX.Combination(i.Value + n - 1, i.Value, MOD);
                    rlt %= MOD;
                }

                Console.WriteLine(rlt % MOD);
            }
        }
    }

}
