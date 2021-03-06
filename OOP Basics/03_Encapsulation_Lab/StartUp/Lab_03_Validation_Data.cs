﻿namespace Encapsulation_Lab.StartUp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Lab_03_Validation_Data
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    var person = new Person(
                        cmdArgs[0],
                        cmdArgs[1],
                        int.Parse(cmdArgs[2]),
                        double.Parse(cmdArgs[3]));

                    persons.Add(person);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            var percent = double.Parse(Console.ReadLine());

            persons
                .Select(p =>
                {
                    p.IncreaseSalary(percent);
                    return p;
                })
                .ToList()
                .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
