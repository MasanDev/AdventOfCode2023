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
    public class _9
    {
        int StepNumber = 0;
        public void GetResults()
        {
            var input = ReadFile();
            List<List<string>> results = new List<List<string>>();
            char[] Directions = input[0].ToCharArray();

            foreach (var item in input)
            {
                results.Add(item.Split(" ").ToList());
            };

            List<string> NewSeqVal = new List<string>();
             foreach (var item in results)
            {
                NewSeqVal.Add(Int32.Parse(GetNextValueInSequence(item)).ToString());
            }

            int Extrapolated = 0;
            for (int i = 0; i < NewSeqVal.Count(); i++)
            {
                Extrapolated = Extrapolated + Int32.Parse(NewSeqVal[i]);
            }
            Console.WriteLine(Extrapolated);
        }

        public string GetNextValueInSequence(List<string> RowInput)
        {
            List<string> tempLine = new List<string>();
            for (global::System.Int32 i = 0; i < RowInput.Count() - 1; i++)
            {

                tempLine.Add((Int32.Parse(RowInput[i + 1]) - Int32.Parse(RowInput[i])).ToString());
            }

            if (tempLine.GroupBy(x => x).Count() == 1)
            {
                return (Int32.Parse(RowInput.Last()) + Int32.Parse(tempLine.Last())).ToString();
            }
            return (Int32.Parse(RowInput.Last()) + Int32.Parse(GetNextValueInSequence(tempLine))).ToString();

        }

        public string[] ReadFile()
        {
            var file = @"C:\Users\sanmat04\source\repos\CodeAdvent\AoC2023\AoC2023\input\9a.txt";
            string[] lines = File.ReadAllLines(file);
            return lines;
        }
       
    }
}             
