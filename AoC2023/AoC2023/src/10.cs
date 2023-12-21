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
    public class _10
    {
        int StepNumber = 0;
        int starty = 0;
        int startx = 0;
        int Steps = 0;
        public List<char[]> results = new List<char[]>();
        public List<char[]> OriginalResults = new List<char[]>();
        int[,] intResults;
        int resultsCounter;
        public void GetResults()
        {


            var input = ReadFile();

            foreach (var item in input)
            {
                results.Add(item.ToCharArray());
                OriginalResults.Add(item.ToCharArray());
            };
         
            intResults = new int[results.Count(),results[0].Length];
            for (int i = 0; i < results.Count(); i++)
            {
                if (results[i].Contains('S'))
                {
                    startx = Array.IndexOf(results[i], 'S');
                    starty = i;
                    break;
                }
            }
            OriginalResults[74][18] = 'L';
            int counterFlatt = 0;
            char[] flattenResults = new char[results.Count()*results[0].Length];
            Steps = (StepThroughMaze(startx, starty) + 1) / 2;
            PrintMatrix(1, 1);


            int numberOfTiles = 0;
            for (int i = 0; i < results.Count(); i++)
            {
                for (global::System.Int32 j = 0; j < results[0].Length; j++)
                {
                    if (results[i][j] != 'X')
                    {
                        numberOfTiles += Shoot(i,j);
                    }
                }
            }



            


            //PrintMatrix(1, 1);
        }


         public int Shoot(int ytile, int xtile)
         {

            int NumberOfEx = 0;
   /*         var temp = results[ytile].Take(xtile);
            if (!results[ytile].Take(xtile).Contains('X'))
            {
                return 0;
            }*/

            while (ytile < results.Count && xtile < results[1].Length)
            {
                if ((results[ytile][xtile] == 'X' && OriginalResults[ytile][xtile] != 'L' && OriginalResults[ytile][xtile] != '7'))
                {
                    NumberOfEx++;
                }
                ytile++;
                xtile++;
            }     
           
            if(NumberOfEx % 2 == 1) { 
             return 1;
            } else {
                return 0;
            }
        }  

        public int StepThroughMaze(int startx, int starty)
        {

            if (IsValid(results, startx, starty-1) && NorthHasPath(results[starty - 1][startx]) && CanConnectToNorth(results[starty][startx]))
            {
                Steps++;
                if (IsEnd(results[starty - 1][startx]))
                {
                    return Steps;
                }
                results[starty][startx] = 'X';
                intResults[starty, startx] = resultsCounter;
                resultsCounter = resultsCounter + 1;
                return StepThroughMaze( startx, starty-1);
            }
            if (IsValid(results, startx+1, starty) && EastHasPath(results[starty][startx + 1]) && CanConnectToEast(results[starty][startx]))
            {
                Steps++;
                if (IsEnd(results[starty][startx + 1]))
                {
                    return Steps;
                }
                results[starty][startx] = 'X';
                intResults[starty, startx] = resultsCounter;
                resultsCounter = resultsCounter + 1;
                return StepThroughMaze(startx+1, starty);
            
            }           
            if (IsValid(results, startx-1, starty) && WestHasPath(results[starty][startx-1]) && CanConnectToWest(results[starty][startx]) )
            {
                Steps++;
                if (IsEnd(results[starty][startx-1]))
                {
                    return Steps;
                }
                results[starty][startx] = 'X';
                intResults[starty, startx] = resultsCounter;
                resultsCounter = resultsCounter + 1;
                return StepThroughMaze( startx-1, starty);
            }
            if (IsValid(results, startx, starty+1) && SouthHasPath(results[starty + 1][startx]) && CanConnectToSouth(results[starty][startx]))
            {
                Steps++;
                if (IsEnd(results[starty + 1][startx]))
                {
                    return Steps;
                }
                results[starty][startx] = 'X';
                intResults[starty, startx] = resultsCounter;
                resultsCounter = resultsCounter + 1;
                return StepThroughMaze( startx,starty + 1 );
            }
            results[starty][startx] = 'X';
            return Steps;
        }

        public void PrintMatrix( int x, int y)
        {
            for (int i = 0; i < results.Count(); i++)
            {
                for (global::System.Int32 j = 0; j < results[0].Length; j++)
                {
                    Console.Write(results[i][j]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
            Console.Write("\n");
        }

        public bool IsValid(List<char[]> results, int startx, int starty)
        {
            return startx >= 0 && starty >= 0 && startx < results[0].Length && starty < results.Count();
        }
        public bool NorthHasPath(char symbol)
        {
           
            return (symbol == '|' || symbol == 'F' || symbol == '7') && symbol != 'X';
        }
        public bool CanConnectToNorth(char symbol)
        {
            return symbol == '|' || symbol == 'L' || symbol == 'J' || symbol == 'S';
        }
        public bool CanConnectToEast(char symbol)
        {
            return symbol == '-' || symbol == 'L' || symbol == 'F' || symbol == 'S';
        }
        public bool CanConnectToWest(char symbol)
        {
            return symbol == '-' || symbol == 'J' || symbol == '7' || symbol == 'S';
        }
        public bool CanConnectToSouth(char symbol)
        {
            return symbol == '|' || symbol == '7' || symbol == 'F' || symbol == 'S';
        }
        public bool EastHasPath(char symbol)
        {
            return (symbol == '-' || symbol == '7' || symbol == 'J') && symbol != 'X';
        }
        public bool WestHasPath(char symbol)
        {
            return (symbol == '-' || symbol == 'L' || symbol == 'F') && symbol != 'X';
        }
        public bool SouthHasPath(char symbol)
        {
            return (symbol == '|' || symbol == 'L' || symbol == 'J') && symbol != 'X';
        }
        public bool IsEnd(char symbol)
        {
            return symbol == 'X';
        }

        public string[] ReadFile()
        {
            var file = @"C:\Users\sanmat04\source\repos\CodeAdvent\AoC2023\AoC2023\input\10a.txt";
            string[] lines = File.ReadAllLines(file);
            return lines;
        }
       
    }
}             
