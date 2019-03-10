using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1237
{
    public class Program

    {
        public static void Main(string[] args)
        {

            while (true)
            {
                int[] line = ReadIntAr();
                if (line[0] + line[1] == 0) break;

                int t = line[0];
                string num = line[1].ToString();
                int max = -1;
                bool multiFlg = false;
                bool overTFlg = false;
                List<int> max_items = new List<int>();

                for (int i = 0 ; i < Math.Pow(2, num.Length - 1) ; i++)
                {
                    List<int> nums = new List<int>();
                    int startIdx = 0;
                    int lengthGet = 0;
                    int sum = 0;
                    overTFlg = false;

                    for (int j = 0 ; j < num.Length ; j++)
                    {
                        lengthGet++;
                        if ((i >> j & 1) == 1 || j == num.Length - 1)
                        {
                            int item = int.Parse(num.Substring(startIdx, lengthGet));
                            nums.Add(item);
                            sum += item;
                            startIdx = j + 1;
                            lengthGet = 0;
                            if (sum > t)
                            {
                                overTFlg = true;
                                break;
                            }
                        }
                    }
                    if (overTFlg) continue;

                    if (max < sum)
                    {
                        max = sum;
                        max_items = nums;
                        multiFlg = false;
                    }
                    else if (max == sum)
                    {
                        multiFlg = true;
                    }
                }

                if (max == -1) Console.WriteLine("error");
                else if (multiFlg) Console.WriteLine("rejected");
                else Console.WriteLine("{0} {1}", max.ToString(), String.Join(" ",max_items.Select(x => x.ToString()).ToArray()));                
            }

        }

        static string ReadSt() { return Console.ReadLine(); }
        static int ReadInt() { return int.Parse(Console.ReadLine()); }
        static long ReadLong() { return long.Parse(Console.ReadLine()); }
        static double ReadDouble() { return double.Parse(Console.ReadLine()); }
        static string[] ReadStAr(char sep = ' ') { return Console.ReadLine().Split(sep); }
        static int[] ReadIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => int.Parse(e)); }
        static long[] ReadLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => long.Parse(e)); }
        static double[] ReadDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Split(sep), e => double.Parse(e)); }

    }

}
