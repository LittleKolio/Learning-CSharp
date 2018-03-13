﻿using System;
using System.Linq;
using System.Collections.Generic;

public static class InputParser
{
    public static List<string> SplitInput(string input, string delimiter)
    {
        return input.Split(delimiter.ToCharArray(),
            StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }
}