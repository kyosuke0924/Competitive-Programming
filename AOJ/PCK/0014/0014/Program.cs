using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0014
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string n = Console.ReadLine();
                if (n == null) break;

                int width = int.Parse(n);
                int blocks = 600 / width;
                int erea = 0;
                for (int i = 0; i < blocks; i++)
                {
                    erea += width * (int)Math.Pow(width * i, 2);
                }

                Console.WriteLine(erea);
            }
        }
        
    }
}
