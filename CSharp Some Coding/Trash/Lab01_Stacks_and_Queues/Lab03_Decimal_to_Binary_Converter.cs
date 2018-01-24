﻿namespace Trash
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab03_Decimal_to_Binary_Converter
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            if (input == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (input > 0)
                {
                    stack.Push(input % 2);
                    input /= 2;
                }
            }

            Console.WriteLine(string.Join("", stack));
        }
    }
}
