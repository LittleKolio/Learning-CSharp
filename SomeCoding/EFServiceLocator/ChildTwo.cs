﻿using System;

namespace EFServiceLocator
{
    public class ChildTwo : Something
    {
        public override void Print(string text)
        {
            Console.WriteLine($"This is second child: {text}");
        }
    }
}
