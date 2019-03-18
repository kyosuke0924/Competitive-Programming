using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int line = int.Parse(System.Console.ReadLine().Trim());
        System.Console.WriteLine(new string(char.Parse(((line - 1) / 111 + 1).ToString()), 3));

    }
}
