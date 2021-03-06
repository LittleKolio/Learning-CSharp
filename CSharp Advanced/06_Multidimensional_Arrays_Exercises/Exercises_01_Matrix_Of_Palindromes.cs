﻿namespace Multidimensional_Arrays_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercises_01_Matrix_Of_Palindromes
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //var watch = System.Diagnostics.Stopwatch.StartNew();

            int row = input[0];
            int col = input[1];

            string[][] matrix = new string[row][];

            char start = 'a';

            for (int i = 0; i < row; i++)
            {
                matrix[i] = new string[col];

                for (int j = 0; j < col; j++)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append(Convert.ToChar(start + i));
                    str.Append(Convert.ToChar(start + i +j));
                    str.Append(Convert.ToChar(start + i));
                    matrix[i][j] = str.ToString();
                }

                Console.WriteLine(string.Join(" ", matrix[i]));
            }

            //watch.Stop();
            //Console.WriteLine(watch.ElapsedTicks);
        }
    }
}
