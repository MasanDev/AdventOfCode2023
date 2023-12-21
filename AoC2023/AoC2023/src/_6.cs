using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2023.src
{
    public class _6
    {
        public static ulong findLCM(ulong a, ulong b)
        {
            ulong num1, num2;

            if (a > b)
            {
                num1 = a;
                num2 = b;
            }
            else
            {
                num1 = b;
                num2 = a;
            }

            for (ulong i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num2;
        }
        public void GetResults()
        {
            var input = ReadFile();
            var WaysToWinCurrent = 0;
            var totalWaysMultiplied = 0;

            var time = input[0].Split(" ").Skip(1).Where(x => x != "").Select(int.Parse).ToArray();
            var Distance = input[1].Split(" ").Skip(1).Where(x => x != "").Select(int.Parse).ToArray();

            long Part2Dist = 263153213781851;
            long Part2Time = 49979494;
     /*       long Part2Dist = 940200;
            long Part2Time = 71530;*/

            long minSpeed = (Part2Dist / Part2Time)+1;



            for (global::System.Int64 j = minSpeed; j < Part2Time; j++)
            {
                WaysToWinCurrent = j * (Part2Time - j) > Part2Dist ? WaysToWinCurrent + 1 : WaysToWinCurrent;
                if (j * (Part2Time - j) < Part2Time) {
                    break; };

            }

            /*           for (int i = 0; i < time.Length; i++)
                       {
                           var TempTime = time[i];
                           var TempDist = Distance[i];

                           for (global::System.Int32 j = 0; j < TempTime; j++)
                           {
                               Console.WriteLine(j * (TempTime - j));
                               WaysToWinCurrent = j * (TempTime-j) > TempDist ? WaysToWinCurrent+1 : WaysToWinCurrent;
                           }

                           totalWaysMultiplied = totalWaysMultiplied == 0 ? totalWaysMultiplied + WaysToWinCurrent : totalWaysMultiplied * WaysToWinCurrent;
                           WaysToWinCurrent = 0;
                       }*/
            Console.WriteLine(WaysToWinCurrent);
        }
        public string[] ReadFile()
        {
            var file = @"C:\Users\sanmat04\source\repos\CodeAdvent\AoC2023\AoC2023\input\6a.txt";
            string[] lines = File.ReadAllLines(file);
            return lines;
        }
       
    }
}             
