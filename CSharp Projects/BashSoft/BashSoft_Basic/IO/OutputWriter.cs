﻿namespace BashSoft_Basic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class OutputWriter
    {
        public static void WriteMessage(string message) => Console.Write(message);
        public static void WriteOneLineMessage(string message) => Console.WriteLine(message);
        public static void WriteEmptyLine() => Console.WriteLine();
        public static void DisplayException(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        public static void PrintStudent(KeyValuePair<string, List<int>> student)
        {
            WriteOneLineMessage($"{student.Key} - {string.Join(", ", student.Value)}");
        }
    }
}
