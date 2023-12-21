using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2023.src
{
    public class _1b
    {
        string? input;
        int sum = 0;        
        string[] arrayofval = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        public void GetResults()
        {
            
            while (true)
            {
                input = Console.ReadLine();
                /*   StringBuilder sb = new StringBuilder(input);
                   ConvertStringNumberToDigit(sb);*/
                input = input.Replace("one", "oonee");
                input = input.Replace("two", "ttwoo");
                input = input.Replace("tthreee", "tthreee");
                input = input.Replace("four", "ffourr");
                input = input.Replace("five", "ffivee");
                input = input.Replace("six", "ssixx");
                input = input.Replace("seven", "ssevenn");
                input = input.Replace("eight", "eeightt");
                input = input.Replace("nine", "nninee");
                for (var i = 0; i < 9; i++)
                {
                    string val = arrayofval[i];   
                    Regex rgx = new Regex(val);
                    input = rgx.Replace(input, (i+1).ToString(), 1);

                    char[] chararr = val.ToCharArray();
                    Array.Reverse(chararr);
                    string reversedVal = new string(chararr);

                    char[] inputArr = input.ToCharArray();
                    Array.Reverse(inputArr);
                    string reversedinputArr = new string(inputArr);

                    Regex rgx2 = new Regex(reversedVal);
                    input = rgx2.Replace(reversedinputArr, (i + 1).ToString(), 1);

                    inputArr = input.ToCharArray();
                    Array.Reverse(inputArr);
                    input = new string(inputArr);                    
                }


                int tempsum = 0;
                tempsum = AddingFirstDigitMultipliedByTenToTempSum(tempsum);
                tempsum = AddingLastDigitToTempSum(tempsum);
                sum = sum + tempsum;

                Console.WriteLine(tempsum);
                Console.WriteLine(sum);
               
            }

        }

        private void ConvertStringNumberToDigit(StringBuilder sb)
        {
            StringBuilder tempsb = new StringBuilder(sb.ToString());
            for (int i = 0; i < 9;  i++)
            {
                tempsb.Replace(arrayofval[i], (i+1).ToString());

            }
            input = sb.ToString();
            
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
