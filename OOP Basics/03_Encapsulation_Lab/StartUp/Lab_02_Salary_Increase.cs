﻿namespace Encapsulation_Lab.StartUp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Lab_02_Salary_Increase
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(
                    cmdArgs[0],
                    cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    double.Parse(cmdArgs[3]));

                persons.Add(person);
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
