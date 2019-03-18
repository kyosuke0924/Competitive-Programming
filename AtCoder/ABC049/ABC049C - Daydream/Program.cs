using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{

    static string[] stWords = { "dream", "dreamer", "erase", "eraser" };

    static void Main(string[] args)
    {
        string line = Console.ReadLine().Trim();

        int i = 0;
        int iCur = 0;
        bool foundItem = false;
        
        while (iCur != line.Length)
        {
            foundItem = false;
            for (i = 0; i < stWords.Length; i++)
            {
                if (iCur + stWords[i].Length <= line.Length  && stWords[i] == line.Substring(iCur, stWords[i].Length))
                {
                    if (iCur + stWords[i].Length == line.Length)
                    {
                        foundItem = true;
                        iCur += stWords[i].Length;
                        break;
                    }
                    else
                    {
                        //次の文字が取得できる場合は確定しカーソルを進める
                        for (int j = 0; j < stWords.Length; j++)
                        {
                            if (iCur + stWords[i].Length+ stWords[j].Length <= line.Length && stWords[j] == line.Substring(iCur + stWords[i].Length, stWords[j].Length))
                            {
                                foundItem = true;
                                iCur += stWords[i].Length;
                                break;
                            }
                        }
                    }
                }
                if (foundItem) {break;}
            }
            if (!foundItem)
            {
                Console.WriteLine("NO");
                return;
            }
        }
        Console.WriteLine("YES");
    }
}
