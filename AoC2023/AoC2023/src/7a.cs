using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace AoC2023.src
{
    public class _7a
    {
        class Hand
        {
            public char[] hand;
            public int bid;
            public string Value;
        }
        public void GetResults()
        {
            var input = ReadFile();

            List<List<string>> parsed = new List<List<string>>();
            List<Hand> AllHands = new List<Hand>();
            foreach (var item in input)
            {
                parsed.Add(item.Split(" ").ToList());  

            }

            foreach (var hand in parsed)
            {
                AllHands.Add(new Hand { hand = StupidHandConverter(hand), bid = Int32.Parse(hand[1]), Value = GetHandAsPointsJoker(hand) });
            }

            var SortedHands = AllHands.OrderByDescending(x => x.Value).ThenByDescending((lst => new string(lst.hand))).ToList();


            var totalPoints = 0;
            var rank = SortedHands.Count();
            foreach (var item in SortedHands)
            {
                Console.WriteLine(item.Value + " " + item.bid + " " + item.hand[0] + item.hand[1] + item.hand[2] + item.hand[3] + item.hand[4] + " Rank: " + rank + "\n");
                totalPoints = totalPoints + (rank * item.bid);
                rank--;
            }
            Console.WriteLine(totalPoints);

           List<string> output = new List<string>();
            output.Add("AAAAA");
            while (true)
            {
                output[0] = Console.ReadLine();
                Console.WriteLine(GetHandAsPointsJoker(output));
            }
        }


        public char[] StupidHandConverter(List<string> val)
        {
            char[] chararr = val[0].ToCharArray();
            for (int i = 0; i < 5; i++)
            {
                switch (chararr[i])
                {
                    case 'T':
                        chararr[i] = 'A';
                        break;
                    case 'J':
                        chararr[i] = '0';
                        break;
                    case 'Q':
                        chararr[i] = 'C';
                        break;
                    case 'K':
                        chararr[i] = 'D';
                        break;
                    case 'A':
                        chararr[i] = 'E';
                        break;
                    default:
                        break;
                }
            }

            return chararr;

        }
        public string GetHandAsPointsJoker(List<string> Item1)
        {
            var NrOfJ = Item1[0].Count(x => x == 'J');

            if(NrOfJ == 0)
            {
                return GetHandAsPoints(Item1).ToString();                
            }

            if(NrOfJ == 1)
            {
                if (NrOfJ == 1 && Item1[0].Where(x => x != 'J').GroupBy(x => x).Count() == 1)
                {
                    return "6";

                }
                if (NrOfJ == 1 && Item1[0].Where(x => x != 'J').GroupBy(x => x).Count() == 4)
                {
                    return "1";

                }
                if (NrOfJ == 1 && Item1[0].Where(x => x != 'J').GroupBy(x => x).Any(x=>x.Count() == 3))
                {
                    return "5";

                }
                if (Item1[0].Where(x => x != 'J').GroupBy(x => x).Count() == 3)
                {
                    return "3";
                }

                return "4";
            }

            if(NrOfJ == 2)
            {
                if(Item1[0].Where(x => x != 'J').GroupBy(x => x).Count() == 3)
                {
                    return "3";
                }
                if(Item1[0].Where(x => x != 'J').GroupBy(x => x).Count() == 2)
                {
                    return "5";
                }
                if(Item1[0].Where(x => x != 'J').GroupBy(x => x).Count() == 1)
                {
                    return "6";
                }
            }
            if(NrOfJ == 3)
            {
                if(Item1[0].Where(x => x != 'J').GroupBy(x => x).Count() == 1)
                {
                    return "6";
                }
                if (Item1[0].Where(x => x != 'J').GroupBy(x => x).Count() == 2)
                {
                    return "5";
                }
            }

            return "6";

                   
        }


        public int GetHandAsPoints(List<string> Item1)
        {
            
            if(Item1.ElementAt(0).GroupBy(x => x).Count() == 1)
            {
                return 6;
            }
            if(Item1.ElementAt(0).GroupBy(x => x).Count() == 2)
            {
                if (Item1.ElementAt(0).GroupBy(x => x).Any(g => g.Count() == 3))
                {
                    return 4;
                }
                if (Item1.ElementAt(0).GroupBy(x => x).Any(g => g.Count() == 4))
                {
                    return 5;
                }

                return 3;
            }

            if (Item1.ElementAt(0).GroupBy(x => x).Count() == 3)
            {
                if (Item1.ElementAt(0).GroupBy(x => x).Any(g => g.Count() == 3))
                {
                    return 3;
                }
                if (Item1.ElementAt(0).GroupBy(x => x).Any(g => g.Count() == 2))
                {
                    return 2;
                }
            }

            if (Item1.ElementAt(0).GroupBy(x => x).Count() == 4)
            {
                return 1;
            }

            return 0;

        }


        public string[] ReadFile()
        {
            var file = @"C:\Users\sanmat04\source\repos\CodeAdvent\AoC2023\AoC2023\input\7a.txt";
            string[] lines = File.ReadAllLines(file);
            return lines;
        }
       
    }
}             
