﻿namespace Generics_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Lab_01_Box_Of_T
    {
        static void Main()
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());
            box.Add(4);
            box.Add(5);
            Console.WriteLine(box.Remove());
        }
    }
}