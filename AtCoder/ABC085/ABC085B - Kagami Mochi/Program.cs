using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(System.Console.ReadLine().Trim());

        List<int> list = new List<int>();
        for (int i=0;i<n;i++){
            list.Add(int.Parse(System.Console.ReadLine().Trim()));
        }
        System.Console.WriteLine(list.Distinct().Count().ToString());
    }
}