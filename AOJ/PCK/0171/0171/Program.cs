using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0171
{
    public class Program

    {
        public static Dice[] dices;
        public static int[][] states;

        public enum Face { Top, Front, Right, Left, Back, Bottom };
        public class Dice
        {
            public int[][] Rotations { get; set; }
            public bool used { get; set; }
            public Dice(string v)
            {
                Rotations = new int[24][];
                Rotations[0] = GetPips(new char[] { v[0], v[1], v[2], v[3], v[4], v[5] });
                Rotations[1] = GetPips(new char[] { v[0], v[2], v[4], v[1], v[3], v[5] });
                Rotations[2] = GetPips(new char[] { v[0], v[4], v[3], v[2], v[1], v[5] });
                Rotations[3] = GetPips(new char[] { v[0], v[3], v[1], v[4], v[2], v[5] });

                Rotations[4] = GetPips(new char[] { v[1], v[0], v[3], v[2], v[5], v[4] });
                Rotations[5] = GetPips(new char[] { v[1], v[3], v[5], v[0], v[2], v[4] });
                Rotations[6] = GetPips(new char[] { v[1], v[5], v[2], v[3], v[0], v[4] });
                Rotations[7] = GetPips(new char[] { v[1], v[2], v[0], v[5], v[3], v[4] });

                Rotations[8] = GetPips(new char[] { v[2], v[5], v[4], v[1], v[0], v[3] });
                Rotations[9] = GetPips(new char[] { v[2], v[4], v[0], v[5], v[1], v[3] });
                Rotations[10] = GetPips(new char[] { v[2], v[0], v[1], v[4], v[5], v[3] });
                Rotations[11] = GetPips(new char[] { v[2], v[1], v[5], v[0], v[4], v[3] });

                Rotations[12] = GetPips(new char[] { v[3], v[0], v[4], v[1], v[5], v[2] });
                Rotations[13] = GetPips(new char[] { v[3], v[4], v[5], v[0], v[1], v[2] });
                Rotations[14] = GetPips(new char[] { v[3], v[5], v[1], v[4], v[0], v[2] });
                Rotations[15] = GetPips(new char[] { v[3], v[1], v[0], v[5], v[4], v[2] });

                Rotations[16] = GetPips(new char[] { v[4], v[0], v[2], v[3], v[5], v[1] });
                Rotations[17] = GetPips(new char[] { v[4], v[2], v[5], v[0], v[3], v[1] });
                Rotations[18] = GetPips(new char[] { v[4], v[5], v[3], v[2], v[0], v[1] });
                Rotations[19] = GetPips(new char[] { v[4], v[3], v[0], v[5], v[2], v[1] });

                Rotations[20] = GetPips(new char[] { v[5], v[1], v[3], v[2], v[4], v[0] });
                Rotations[21] = GetPips(new char[] { v[5], v[3], v[4], v[1], v[2], v[0] });
                Rotations[22] = GetPips(new char[] { v[5], v[4], v[2], v[3], v[1], v[0] });
                Rotations[23] = GetPips(new char[] { v[5], v[2], v[1], v[4], v[3], v[0] });
            }

            private int[] GetPips(char[] v)
            {
                int[] rotation = new int[6];
                for (int i = 0 ; i < rotation.Length ; i++)
                {
                    rotation[i] = char.IsLower(v[i]) ? v[i] - ('a' - 1) : (v[i] - ('A' - 1)) * -1;
                }
                return rotation;
            }
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                dices = new Dice[8];
                states = new int[8][];
                for (int i = 0 ; i < dices.Length ; i++)
                {
                    string line = RSt(); if (line == "0") return;
                    dices[i] = new Dice(line);
                }
                Console.WriteLine(SetDice(0) ? "YES" : "NO");
            }
        }

        private static bool SetDice(int k)
        {
            if (k == 8) { return true; }

            for (int i = 0 ; i < 8 ; i++)
            {
                if (!dices[i].used)
                {
                    dices[i].used = true;
                    for (int j = 0 ; j < dices[i].Rotations.Length ; j++)
                    {
                        if (CanPut(k, dices[i].Rotations[j]))
                        {
                            states[k] = dices[i].Rotations[j];
                            if (SetDice(k + 1)) return true;
                        }
                    }
                    dices[i].used = false;
                }
            }
            return false;
        }

        private static bool CanPut(int k, int[] target)
        {
            bool res = false;
            switch (k)
            {
                case 0:
                    res = true;
                    break;
                case 1:
                    res = states[0][(int)Face.Right] + target[(int)Face.Left] == 0;
                    break;
                case 2:
                    res = states[0][(int)Face.Front] + target[(int)Face.Back] == 0;
                    break;
                case 3:
                    res = states[1][(int)Face.Front] + target[(int)Face.Back] == 0 &&
                          states[2][(int)Face.Right] + target[(int)Face.Left] == 0;
                    break;
                case 4:
                    res = states[0][(int)Face.Top] + target[(int)Face.Bottom] == 0;
                    break;
                case 5:
                    res = states[1][(int)Face.Top] + target[(int)Face.Bottom] == 0 &&
                          states[4][(int)Face.Right] + target[(int)Face.Left] == 0;
                    break;
                case 6:
                    res = states[2][(int)Face.Top] + target[(int)Face.Bottom] == 0 &&
                          states[4][(int)Face.Front] + target[(int)Face.Back] == 0;
                    break;
                case 7:
                    res = states[3][(int)Face.Top] + target[(int)Face.Bottom] == 0 &&
                          states[5][(int)Face.Front] + target[(int)Face.Back] == 0 &&
                          states[6][(int)Face.Right] + target[(int)Face.Left] == 0;
                    break;
            }
            return res;
        }

        static string RSt() { return Console.ReadLine(); }
        static int RInt() { return int.Parse(Console.ReadLine().Trim()); }
        static long RLong() { return long.Parse(Console.ReadLine().Trim()); }
        static double RDouble() { return double.Parse(Console.ReadLine()); }
        static string[] RStAr(char sep = ' ') { return Console.ReadLine().Trim().Split(sep); }
        static int[] RIntAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => int.Parse(e)); }
        static long[] RLongAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => long.Parse(e)); }
        static double[] RDoubleAr(char sep = ' ') { return Array.ConvertAll(Console.ReadLine().Trim().Split(sep), e => double.Parse(e)); }
        static string WAr<T>(IEnumerable<T> array, string sep = " ") { return string.Join(sep, array.Select(x => x.ToString()).ToArray()); }
    }

}
