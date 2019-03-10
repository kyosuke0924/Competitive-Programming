using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0038
{
    public class Program

    {
        enum hand
        {
            nothing
            , one_pair
            , two_pair
            , three_card
            , straight
            , full_house
            , four_card
        }

        public static void Main(string[] args)
        {
            string[] hand = new string[]
            {
                "null"
                ,"one pair"
                ,"two pair"
                ,"three card"
                ,"straight"
                ,"full house"
                ,"four card"
            };

            while (true)
            {

                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                int[] cards = Array.ConvertAll(line.Trim().Split(','), e => int.Parse(e));
                Console.WriteLine(hand[handDecision(cards)]);
            }

        }

        private static int handDecision(int[] cards)
        {
            Dictionary<int, int> cardsCnt = new Dictionary<int, int>();
            for (int i = 0 ; i < cards.Count() ; i++)
            {
                if (!cardsCnt.ContainsKey(cards[i])) cardsCnt.Add(cards[i], 0);
                cardsCnt[cards[i]]++;
            }

            if (cardsCnt.Any(x => x.Value == 4)) return (int)hand.four_card;
            if (cardsCnt.Any(x => x.Value == 3) && cardsCnt.Any(x => x.Value == 2)) return (int)hand.full_house;
            if (IsStraight(cards)) return (int)hand.straight;
            if (cardsCnt.Any(x => x.Value == 3)) return (int)hand.three_card;
            if (cardsCnt.Count(x => x.Value == 2) == 2) return (int)hand.two_pair;
            if (cardsCnt.Any(x => x.Value == 2)) return (int)hand.one_pair;
            return (int)hand.nothing;
        }

        private static bool IsStraight(int[] cards)
        {
            if (cards.Distinct().Count() < 5) return false;
            cards = cards.OrderBy(x => x).ToArray();

            if (cards[0] == 1 && cards[1] == 10 && cards[2] == 11 && cards[3] == 12 && cards[4] == 13) return true;
            for (int i = 0 ; i < cards.Count() - 1 ; i++)
            {
                if (cards[i + 1] - cards[i] > 1) return false;
            }
            return true;
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
