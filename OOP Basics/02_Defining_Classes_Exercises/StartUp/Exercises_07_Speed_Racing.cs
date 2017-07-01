﻿namespace Defining_Classes_Exercises.StartUp
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Exercises_07_Speed_Racing
    {
        static void Main()
        {
            List<Car> list = new List<Car>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] car = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                list.Add(new Car(
                    car[0], double.Parse(car[1]), double.Parse(car[2])
                    ));
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] car = input
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                list
                    .Where(c => c.Model == car[1])
                    .FirstOrDefault()
                    .DistanceTraveled(double.Parse(car[2]));
            }

            list.ForEach(car => Console.WriteLine(car.CarInfo()));
        }
    }
}
