using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2023.src
{
    public class _1a
    {
        string? input;
        int sum = 0;


        public void GetResults()
        {
            while(true)
            {
                input = Console.ReadLine();

                int tempsum = 0;
                tempsum = AddingFirstDigitMultipliedByTenToTempSum(tempsum);
                tempsum = AddingLastDigitToTempSum(tempsum);
                sum = sum + tempsum;
                Console.WriteLine(sum);
            }

        }

        private int AddingLastDigitToTempSum(int tempsum)
        {
            foreach (char ch in input.Reverse())
            {
                if (Int32.TryParse(ch.ToString(), out int results))
                {
                    tempsum = tempsum + (results);
                    break;
                }
            }

            return tempsum;
        }

        private int AddingFirstDigitMultipliedByTenToTempSum(int tempsum)
        {
            foreach (char ch in input)
            {
                if (Int32.TryParse(ch.ToString(), out int results))
                {
                    tempsum = tempsum + (results * 10);
                    break;
                }
            }

            return tempsum;
        }
    }
}
