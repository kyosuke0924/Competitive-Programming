using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {

        long[] result = { 0, 0, 0, 0 };
        string readLine = string.Empty;
        List<long> line = new List<long>();

        while ((readLine = Console.ReadLine()) != null)
        {
            line = Array.ConvertAll(readLine.Split(' '), long.Parse).ToList();
            line.Sort();
            if (line[0] + line[1] <= line[2])
            {
                break;
            }
            else
            {

                result[0]++;
                if (Math.Pow(line[0], 2) + Math.Pow(line[1], 2) == Math.Pow(line[2], 2))
                { result[1]++; }
                else if (Math.Pow(line[0], 2) + Math.Pow(line[1], 2) > Math.Pow(line[2], 2))
                { result[2]++; }
                else
                { result[3]++; }
            }
        }
        Console.WriteLine("{0} {1} {2} {3}", result[0], result[1], result[2], result[3]);
    }
}

