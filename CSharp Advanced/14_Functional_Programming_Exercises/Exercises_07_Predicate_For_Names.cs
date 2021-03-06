﻿namespace Functional_Programming_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_07_Predicate_For_Names
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            Func<string, bool> isRgihtLen = name => name.Length <= length;

            Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Where(isRgihtLen)
                .ToList()
                .ForEach(str => Console.WriteLine(str));
        }
    }
}
