using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2023.src
{
    public class _5a
    {
        public int winlength = 10;
        public int mylength = 25;
        public int totalPoints = 0;
        public int currentScratchboard = 0;
        public long lowestval = 1000000000000000000;
        public long counter = 0;
        public void GetResults()
        {
            string type = "";
            List<String> Seeds = new List<String>();
            var input = ReadFile();
            Solve(input, 2);


           /* Seeds = input.ElementAt(0).Split(' ', ':').ToList();
*//*            List<string> SeedToSoilMapper = input.Skip(3).Take(5 - 3).ToList();
            List<string> SoilToFertilizeMapper = input.Skip(7).Take(10 - 7).ToList();
            List<string> FertToWaterMapper = input.Skip(12).Take(16 - 12).ToList();
            List<string> WaterToLightMapper = input.Skip(18).Take(20 - 18).ToList();
            List<string> LightToTemperatureMapper = input.Skip(22).Take(25 - 22).ToList();
            List<string> TemperatureToHumidityMapper = input.Skip(27).Take(29 - 27).ToList();
            List<string> HumidityToLocMapper = input.Skip(31).Take(33 - 31).ToList();*//*
            List<string> SeedToSoilMapper = input.Skip(3).Take(6 - 3).ToList();
            List<string> SoilToFertilizeMapper = input.Skip(8).Take(37 - 8).ToList();
            List<string> FertToWaterMapper = input.Skip(39).Take(82 - 39).ToList();
            List<string> WaterToLightMapper = input.Skip(84).Take(125 - 84).ToList();
            List<string> LightToTemperatureMapper = input.Skip(127).Take(158 - 127).ToList();
            List<string> TemperatureToHumidityMapper = input.Skip(160).Take(207 - 160).ToList();
            List<string> HumidityToLocMapper = input.Skip(209).Take(250 - 209).ToList();

            long soilValue = 0;
            long FertValue = 0;
            long WaterValue = 0;
            long LightValue = 0;
            long TemperatureValue = 0;
            long HumidValue = 0;
            long LocValu = 0;


            for (int i = 2; i < Seeds.Count(); i+=2)
            {
                for (global::System.Int64 j = Int64.Parse(Seeds.ElementAt(i)); j < Int64.Parse(Seeds.ElementAt(i))+Int64.Parse(Seeds.ElementAt(i+1)); j++)
                {
                    counter++;
                    string seed = j.ToString(); 

                    foreach (var item in SeedToSoilMapper)
                    {
                        string[] tempString = item.Split(" ");
                    
                        if (Int64.Parse(tempString[1]) <= Int64.Parse(seed) && Int64.Parse(seed) <= Int64.Parse(tempString[1]) + Int64.Parse(tempString[2]))
                        {
                            soilValue = Int64.Parse(tempString[0]) + (Int64.Parse(seed) - Int64.Parse(tempString[1]));
                            break;
                        }
                        if (item == SeedToSoilMapper.Last())
                        {
                            soilValue = Int64.Parse(seed);
                        }
                    
                    }
                    foreach (var item in SoilToFertilizeMapper)
                    {
                        string[] tempString = item.Split(" ");
                    
                        if (Int64.Parse(tempString[1]) <= soilValue && soilValue <= Int64.Parse(tempString[1]) + Int64.Parse(tempString[2]))
                        {
                            FertValue = Int64.Parse(tempString[0]) + (soilValue - Int64.Parse(tempString[1]));
                            break;
                        }
                        if (item == SoilToFertilizeMapper.Last())
                        {
                            FertValue = soilValue;
                        }
                    }

                    foreach (var item in FertToWaterMapper)
                    {
                        string[] tempString = item.Split(" ");
                    
                        if (Int64.Parse(tempString[1]) <= FertValue && FertValue <= Int64.Parse(tempString[1]) + Int64.Parse(tempString[2]))
                        {
                            WaterValue = Int64.Parse(tempString[0]) + (FertValue - Int64.Parse(tempString[1]));
                            break;
                        }
                        if (item == FertToWaterMapper.Last())
                        {
                            WaterValue = FertValue;
                        }
                    }       
                    foreach (var item in WaterToLightMapper)
                    {
                        string[] tempString = item.Split(" ");
                    
                        if (Int64.Parse(tempString[1]) <= WaterValue && WaterValue <= Int64.Parse(tempString[1]) + Int64.Parse(tempString[2]))
                        {
                            LightValue = Int64.Parse(tempString[0]) + (WaterValue - Int64.Parse(tempString[1]));
                            break;
                        }
                        if (item == WaterToLightMapper.Last())
                        {
                            LightValue = WaterValue;
                        }
                    }
                    foreach (var item in LightToTemperatureMapper)
                    {
                        string[] tempString = item.Split(" ");
                    
                        if (Int64.Parse(tempString[1]) <= LightValue && LightValue <= Int64.Parse(tempString[1]) + Int64.Parse(tempString[2]))
                        {
                            TemperatureValue = Int64.Parse(tempString[0]) + (LightValue - Int64.Parse(tempString[1]));
                            break;
                        }
                        if (item == LightToTemperatureMapper.Last())
                        {
                            TemperatureValue = LightValue;
                        }
                    }
                    foreach (var item in TemperatureToHumidityMapper)
                    {
                        string[] tempString = item.Split(" ");
                    
                        if (Int64.Parse(tempString[1]) <= TemperatureValue && TemperatureValue <= Int64.Parse(tempString[1]) + Int64.Parse(tempString[2]))
                        {
                            HumidValue = Int64.Parse(tempString[0]) + (TemperatureValue - Int64.Parse(tempString[1]));
                            break;
                        }
                        if (item == TemperatureToHumidityMapper.Last())
                        {
                            HumidValue = TemperatureValue;
                        }
                    }
                    foreach (var item in HumidityToLocMapper)
                    {
                        string[] tempString = item.Split(" ");
                    
                        if (Int64.Parse(tempString[1]) <= HumidValue && HumidValue <= Int64.Parse(tempString[1]) + Int64.Parse(tempString[2]))
                        {
                            LocValu = Int64.Parse(tempString[0]) + (HumidValue - Int64.Parse(tempString[1]));
                            break;
                        }
                        if (item == HumidityToLocMapper.Last())
                        {
                            LocValu = HumidValue;
                        }
                    }
                    lowestval = lowestval < LocValu ? lowestval : LocValu;
                }
            }
                Console.WriteLine(lowestval);
        */
    }

        public string[] ReadFile()
        {
            var file = @"C:\Users\sanmat04\Desktop\4b.txt.txt";
            string[] lines = File.ReadAllLines(file);
            return lines;
        }
        private long Solve(string[] input, int part)
        {
            var seeds = input[0].Split(" ").Skip(1).Select(long.Parse).ToArray();
            var values = part == 1
                ? seeds.Select(x => (Start: x, Length: 1L)).ToList()
                : Enumerable.Range(0, seeds.Length / 2).Select(x => (Start: seeds[2 * x], Length: seeds[2 * x + 1])).ToList();

            var curIndex = 2;
            while (true)
            {
                var nextIndex = Array.IndexOf(input, input.Skip(curIndex + 1).FirstOrDefault(x => x.Contains("map")));
                var mapRows = input.Skip(curIndex + 1).Take(nextIndex == -1 ? input.Length : nextIndex - curIndex - 2);
                var map = mapRows.Select(x => x.Split(" ").Select(long.Parse).ToArray()).OrderBy(x => x[1]).ToArray();
                values = Transform(values, map);
                curIndex = nextIndex;
                if (nextIndex == -1) break;
            }

            return values.MinBy(x => x.Start).Start;
        }

        private static List<(long Start, long Length)> Transform(List<(long Start, long Length)> values, long[][] mapRows)
        {
            var result = new List<(long Start, long Length)>();

            foreach (var value in values)
            {
                var cur = value.Start;
                var length = value.Length;
                while (length > 0)
                {
                    var map = mapRows.SingleOrDefault(x => x[1] <= cur && cur < x[1] + x[2]);
                    long next;
                    long lengthToTake;

                    if (map == null)
                    {
                        var nextMap = mapRows.FirstOrDefault(x => x[1] >= cur);
                        next = cur;
                        lengthToTake = nextMap == null ? length : Math.Min(length, nextMap[1] - cur);
                    }
                    else
                    {
                        next = map[0] + cur - map[1];
                        lengthToTake = Math.Min(length, map[1] + map[2] - cur);
                    }

                    result.Add((next, lengthToTake));
                    length -= lengthToTake;
                    cur += lengthToTake;
                }
            }

            return result.ToList();
        }
    }
}             
