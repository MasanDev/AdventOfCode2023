using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2023.src
{
    public class _4a
    {
        public int winlength = 10;
        public int mylength = 25;
        public int totalPoints = 0;
        public int currentScratchboard = 0;

        public void GetResults()
        {
            //List<String> WinningPart = new List<String>();
            // List<String> MyPart = new List<String>();
            // IEnumerable<string> intersection = new List<string>();
            var input = ReadFile();
            List<List<string>> StringList = new List<List<string>>();
            for (int i = 0; i < input.Length; i++)
            {
                StringList.Add(input[i].Split(':', '|').ToList());
                StringList.ElementAt(i).Add("1");
                StringList.ElementAt(i).ElementAt(0).Split(" ");
                StringList.ElementAt(i).ElementAt(1).Split(" ");
                StringList.ElementAt(i).ElementAt(2).Split(" ");
            }

            int starter = 0;
            var AllEntires = StringList.Count();
            CalculateAll(StringList, AllEntires, starter);

/*            if (intersection.Count() == 1)
            {
                totalPoints += 1;
            }
            else if (intersection.Count() == 2)
            {
                totalPoints += 2;
            }
            else if (intersection.Count() != 0)
            {
                totalPoints += (int)Math.Pow(2, intersection.Count() - 1);
            }*/
            Console.WriteLine(totalPoints);

        }

        private void CalculateAll(List<List<string>> StringList, int AllEntires, int starter)
        {
            for (int i = starter; i < AllEntires; i++)
            {
                List<String> WinningPart = StringList[i].ElementAt(1).Split(" ").Where(x => x != "").ToList();
                List<String> MyPart = StringList[i].ElementAt(2).Split(" ").Where(x => x != "").ToList().ToList();
                IEnumerable<string> intersection = WinningPart.Intersect(MyPart);
                totalPoints++;
                if (intersection.Count() > 0 && i <= 202)
                {
                    CalculateAll(StringList,i+intersection.Count()+1,i+1);
                }
            }
        }


        public string[] ReadFile()
        {
            var file = @"C:\Users\sanmat04\Desktop\4b.txt.txt";
            string[] lines = File.ReadAllLines(file);
            return lines;
        }
    }
}
                   
