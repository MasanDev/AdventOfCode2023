using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2023.src
{
    public class _3a
    {

        int step = 0;
        int value = 0;
        int total = 0;
        bool isValid = false;
        public _3a()
        {
            var input = File.ReadAllText(@"C:\Users\matti\source\repos\AdventOfCode2023\AoC2023\AoC2023\src\_3a.txt");
            var rows = input.Split("\r\n");
            char[,] chararray = new char[rows[0].Length, rows.Length];
            FillCharArrayWithInputData(rows, chararray);

            for (int i = 0; i < rows.Length; i++)
            {
                for (global::System.Int32 j = 0; j < rows[0].Length; j++)
                {
                    if (char.IsNumber(chararray[i,j]))
                    {
                        value = 0;
                        step = 0;
                        SetLocalValue(rows, chararray, i, j);
                        isValid = false;
                        SetToTrueIfTouchingSymbol(rows, chararray, i, j);

                        if (isValid)
                        {
                            total += value;
                        }
                        j = j + step;
                    }
                }
            }
            Console.WriteLine(total);

        }

        private void SetToTrueIfTouchingSymbol(string[] rows, char[,] chararray, int i, int j)
        {
            for (int columns = j - 1; columns <= j + step; columns++)
            {
                for (int rowsnum = i - 1; rowsnum <= i + 1; rowsnum++)
                {
                    if (InBounds(rowsnum, columns, rows[0].Length, rows.Length) && IsSymbol(chararray[rowsnum,columns]))
                    {
                        isValid = true;
                    }
                }
            }
        }

        private void SetLocalValue(string[] rows, char[,] chararray, int i, int j)
        {
            while ( j + step < rows.Length && Int32.TryParse(chararray[i,j+ step].ToString(), out int val) )
            {
                value = value * 10 + val;
                Console.WriteLine(value);
                step++;
            }
        }
        private static void FillCharArrayWithInputData(string[] rows, char[,] chararray)
        {
            for (int i = 0; i < rows[0].Length; i++)
            {
                for (global::System.Int32 j = 0; j < rows.Length; j++)
                {
                    chararray[i, j] = rows[i][j];
                }
            }
        }

        private bool InBounds(int i, int j, int rows, int column)
        {
            return i >= 0 && i < column && j >= 0 && j < rows;
        }
        private bool IsSymbol(char ch)
        {
            return !Char.IsDigit(ch) && !(ch == '.');
        }
    }
}
