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
    public class _11b
    {

        public List<char[]> results = new List<char[]>();
        List<int[]> coordinates = new List<int[]>();
        public List<char[]> RotatedResults = new List<char[]>();
        int resultsCounter;
        int expansion = 10;
        public void GetResults()
        {


            var input = ReadFile();



            foreach (var item in input)
            {
                results.Add(item.ToCharArray());

/*                if (item.Contains('#'))
                {
                    results.Add(item.ToCharArray());
                }
                else
                {
                        results.Add(item.ToCharArray());
                        results.Add(item.ToCharArray());
                }*/

            };

            
            int counter = 0;
            for (int i = 0; i < results.Count(); i++)
            {

                for (global::System.Int32 j = 0; j < results[0].Length; j++)
                {
                    if (results[i][j] == '#')
                    {
                        coordinates.Add(new int[2]);
                        coordinates[counter][0] = i;
                        coordinates[counter][1] = j;
                        counter++;
                    }
                }
            }

            IncrementCoordinatesY(results);
            PrintMatrix();
            RotateList();
            IncrementCoordinatesX(RotatedResults);
            PrintMatrix2();

            var distance = 0;
            for (int i = 0; i < coordinates.Count(); i++)
            {
                for (global::System.Int32 j = i+1; j < coordinates.Count(); j++)
                {
                    distance += manhattanDist(coordinates[i][1], coordinates[i][0], coordinates[j][1], coordinates[j][0]);
                }
            }

            //PrintMatrix(1, 1);
        }
        static int manhattanDist(int X1, int Y1,
                                  int X2, int Y2)
        {
            int dist = Math.Abs(X2 - X1) + Math.Abs(Y2 - Y1);
            return dist;
        }
        private void IncrementCoordinatesY(List<char[]> MapsInput)
        {
            for (int i = MapsInput.Count(); i < MapsInput.Count(); i--)
            {
                if (!MapsInput[i].Contains('#'))
                {
                    for (global::System.Int32 j = 0; j < coordinates.Count(); j++)
                    {
                        if (coordinates[j][0] > i)
                        {
                            coordinates[j][0] = coordinates[j][0]+expansion;
                        }
                    }
                }
            }
        }
        private void IncrementCoordinatesX(List<char[]> MapsInput)
        {
            for (int i = 0; i < MapsInput.Count(); i++)
            {
                if (!MapsInput[i].Contains('#'))
                {
                    for (global::System.Int32 j = 0; j < coordinates.Count(); j++)
                    {
                        if (coordinates[j][1] > i)
                        {
                            coordinates[j][1] = coordinates[j][1]+expansion;
                        }
                    }
                }
            }
        }

        private void RotateList()
        {
            for (int i = 0; i < results[0].Length; i++)
            {
                RotatedResults.Add(new char[results.Count()]);

                for (global::System.Int32 j = 0; j < results.Count(); j++)
                {
                    RotatedResults[i][j] = results[j][i];
                }
            }
        }
        private bool CheckIfColumnHasValue(int column)
        {
            for (int row = 0; row < results.Count(); row++)
            {
                if (results[row][column] != '.')
                {
                    return true;
                }
            }
            return false;
        }

        private void AddValueToColumn(int column)
        {
            for (int row = 0; row < results.Count(); row++)
            {
                results.Insert(row, results[column - 1].Append('.').ToArray());
            }
        }
        private void PrintMatrix()
        {
            for (int i = 0; i < results.Count(); i++)
            {
                for (global::System.Int32 j = 0; j < results[0].Length; j++)
                {
                    Console.Write(results[i][j]);   
                }
                Console.WriteLine();
            }
            Console.WriteLine(); 
            Console.WriteLine();
        }
        private void PrintMatrix2()
        {
            for (int i = 0; i < RotatedResults.Count(); i++)
            {
                for (global::System.Int32 j = 0; j < RotatedResults[0].Length; j++)
                {
                    Console.Write(RotatedResults[i][j]);   
                }
                Console.WriteLine();
            }
            Console.WriteLine(); 
            Console.WriteLine();
        }




        public string[] ReadFile()
        {
            var file = @"C:\Users\sanmat04\source\repos\CodeAdvent\AoC2023\AoC2023\input\11.txt";
            string[] lines = File.ReadAllLines(file);
            return lines;
        }
       
    }
}             
