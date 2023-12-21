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
    public class _8
    {
        int StepNumber = 0;
        public void GetResults()
        {
            var input = ReadFile();

            char[] Directions = input[0].ToCharArray();
            List<List<string>> mapInput = new List<List<string>>();

            for (int i = 2; i < input.Length; i++)
            {
                mapInput.Add(input[i].Remove(4, 1).Remove(5,1).Remove(8,1).Remove(12,1).Split(" ").ToList());
            }
            //string CurrentPlaceA = mapInput.Where(x => x[0] == "QKA").Select(x => x[0]).First();
            string CurrentPlaceA = mapInput.Where(x => x[0] == "JMA").Select(x => x[0]).First();
/*            string CurrentPlaceB = mapInput.Where(x => x[0] == "VMA").Select(x => x[0]).First();
            string CurrentPlaceC = mapInput.Where(x => x[0] == "AAA").Select(x => x[0]).First();
            string CurrentPlaceD = mapInput.Where(x => x[0] == "RKA").Select(x => x[0]).First();
            string CurrentPlaceE = mapInput.Where(x => x[0] == "LBA").Select(x => x[0]).First();
            string CurrentPlaceF = mapInput.Where(x => x[0] == "JMA").Select(x => x[0]).First();*/
            char NextDirection;
             /* 
              * 
              * Använder LCD
              * 
              *
              */

            while(CurrentPlaceA[2] != 'Z') { 
                for (int i = 0; i < Directions.Length; i++)
                {
                    NextDirection = Directions[i];
                    if (NextDirection == 'R')
                    {
                        CurrentPlaceA = mapInput.Where(x => x[0] == CurrentPlaceA).Select(x => x[3]).First();
                    } else
                    {
                        CurrentPlaceA = mapInput.Where(x => x[0] == CurrentPlaceA).Select(x => x[2]).First();
                    }
                    StepNumber++;
                    if (CurrentPlaceA[2] == 'Z') { 
                    Console.WriteLine(StepNumber);
                    Console.WriteLine(CurrentPlaceA);
                    Console.WriteLine(" ");
                    }
                }
            }
            /* List<List<string>> countNumber = mapInput.Where(x => x[0][2] == 'A').ToList();
             while (CurrentPlaceA[2] != 'Z' 
                 || CurrentPlaceB[2] != 'Z'
                 || CurrentPlaceC[2] != 'Z'
                 || CurrentPlaceD[2] != 'Z'
                 || CurrentPlaceE[2] != 'Z'
                 || CurrentPlaceF[2] != 'Z')
             {
                 for (global::System.Int32 i = 0; i < Directions.Length; i++)
                 {
                     NextDirection = Directions[i];
                     if (NextDirection == 'R')
                     {
                         CurrentPlaceA = mapInput.Where(x => x[0] == CurrentPlaceA).Select(x => x[3]).First();
                         CurrentPlaceB = mapInput.Where(x => x[0] == CurrentPlaceB).Select(x => x[3]).First();
                         CurrentPlaceC = mapInput.Where(x => x[0] == CurrentPlaceC).Select(x => x[3]).First();
                         CurrentPlaceD = mapInput.Where(x => x[0] == CurrentPlaceD).Select(x => x[3]).First();
                         CurrentPlaceE = mapInput.Where(x => x[0] == CurrentPlaceE).Select(x => x[3]).First();
                         CurrentPlaceF = mapInput.Where(x => x[0] == CurrentPlaceF).Select(x => x[3]).First();
                     } else {
                         CurrentPlaceA = mapInput.Where(x => x[0] == CurrentPlaceA).Select(x => x[2]).First();
                         CurrentPlaceB = mapInput.Where(x => x[0] == CurrentPlaceB).Select(x => x[2]).First();
                         CurrentPlaceC = mapInput.Where(x => x[0] == CurrentPlaceC).Select(x => x[2]).First();
                         CurrentPlaceD = mapInput.Where(x => x[0] == CurrentPlaceD).Select(x => x[2]).First();
                         CurrentPlaceE = mapInput.Where(x => x[0] == CurrentPlaceE).Select(x => x[2]).First();
                         CurrentPlaceF = mapInput.Where(x => x[0] == CurrentPlaceF).Select(x => x[2]).First();
                     }
                     StepNumber++;
                     if (CurrentPlaceA[2] != 'Z'
                 && CurrentPlaceB[2] != 'Z'
                 && CurrentPlaceC[2] != 'Z'
                 && CurrentPlaceD[2] != 'Z'
                 && CurrentPlaceE[2] != 'Z'
                 && CurrentPlaceF[2] != 'Z') { break; }
                 }
             }
             Console.WriteLine(StepNumber);*/



        }

        public string[] ReadFile()
        {
            var file = @"C:\Users\sanmat04\source\repos\CodeAdvent\AoC2023\AoC2023\input\8a.txt";
            string[] lines = File.ReadAllLines(file);
            return lines;
        }
       
    }
}             
