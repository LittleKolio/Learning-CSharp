﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional_Programming_Lab
{
    class Lab_01_Sort_Even_Numbers
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new[] { ", " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToArray();

            Console.WriteLine(string.Join(", ", input));
        }
    }
}