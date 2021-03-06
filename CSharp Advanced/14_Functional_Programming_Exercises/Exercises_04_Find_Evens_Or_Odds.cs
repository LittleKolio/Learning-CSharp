﻿namespace Functional_Programming_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_04_Find_Evens_Or_Odds
    {
        static void Main()
        {
            int[] range = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Func<int, bool> odd = num => num % 2 != 0;
            Func<int, bool> even = num => num % 2 == 0;

            List<int> nums = null;

            if (command == "odd")
            {
                nums = Enumerable
                    .Range(input[0], input[1] - input[0] + 1)
                    .Where(odd)
                    .ToList();
            }
            else if (command == "even")
            {
                nums = Enumerable
                    .Range(input[0], input[1] - input[0] + 1)
                    .Where(even)
                    .ToList();
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
