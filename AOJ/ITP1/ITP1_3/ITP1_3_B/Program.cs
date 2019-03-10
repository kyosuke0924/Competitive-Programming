using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITP1_3_B
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string line;
            int i = 0;

            do
            {
                i++;
                line = Console.ReadLine();
                if (line == "0") return;
                Console.WriteLine("Case {0}: {1}",i,line);

            } while (line != null) ;
        }
    }

}
