﻿namespace Stacks_And_Queues_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercises_04_Basic_Queue_Operations
    {
        public static void Main()
        {
            // Number of opperations
            // [0] - enqueue
            // [1] - dequeue
            // whether contains [2] = element
            int[] opp = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // Sequence of numbers
            int[] seq = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(seq);

            for (int i = 0; i < opp[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count != 0)
            {
                if (queue.Contains(opp[2]))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
