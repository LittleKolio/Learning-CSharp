﻿namespace BashSoft_OOP.IO
{
    using Interfaces;
    using StaticData;
    using System;
    using System.IO;

    public class CompareFiles : ICompareFiles
    {
        //private IFileWriter fileWriter;
        private IWriter consoleWriter;

        public CompareFiles(IWriter consoleWriter)
        {
            //this.fileWriter = fileWriter;
            this.consoleWriter = consoleWriter;
        }

        public void CompareTwoFiles(string fileOnePath, string fileTwoPath)
        {
            if (!File.Exists(fileOnePath))
            {
                this.consoleWriter.WriteException(string.Format(
                    ExceptionMessages.file_DoseNotExist, fileOnePath));
            }

            if (!File.Exists(fileTwoPath))
            {
                this.consoleWriter.WriteException(string.Format(
                    ExceptionMessages.file_DoseNotExist, fileTwoPath));
            }

            this.consoleWriter.WriteOneLineMessage("Reading files...");

            string[] fileOneLines = File.ReadAllLines(fileOnePath);
            string[] fileTwoLines = File.ReadAllLines(fileTwoPath);

            string mismatchPath = GetMismatchPath(fileTwoPath);

            bool isMismatch;
            string[] mismatches = GetMismates(fileOneLines, fileTwoLines, out isMismatch);

            PrintMismatches(mismatches, isMismatch, mismatchPath);

            this.consoleWriter.WriteOneLineMessage("Files readed");
        }

        private void PrintMismatches(
            string[] mismatches, bool isMismatch, string mismatchPath)
        {
            if (isMismatch)
            {
                foreach (string line in mismatches)
                {
                    this.consoleWriter.WriteOneLineMessage(line);
                }

                try
                {
                    File.WriteAllLines(mismatchPath, mismatches);
                }
                catch
                {
                    this.consoleWriter.WriteOneLineMessage(ExceptionMessages.file_ForbiddenSymbols);
                }
            }
            else
            {
                this.consoleWriter.WriteOneLineMessage(Constants.File_IdenticalFiles);
            }
        }

        private string[] GetMismates(
            string[] fileOneLines, 
            string[] fileTwoLines, 
            out bool isMismatch
            )
        {
            int mismatchesLength = Math.Max(fileOneLines.Length, fileTwoLines.Length);
            isMismatch = false;
            string[] mismatches = new string[mismatchesLength];

            this.consoleWriter.WriteOneLineMessage("Comparing files...");

            for (int index = 0; index < mismatchesLength; index++)
            {
                string output = string.Empty;

                string fileOneLine = index < fileOneLines.Length 
                    ? fileOneLines[index] 
                    : "NONE";

                string fileTwoLine = index < fileTwoLines.Length 
                    ? fileTwoLines[index]
                    : "NONE";

                if (!fileOneLine.Equals(fileTwoLine))
                {
                    isMismatch = true;
                    output = string.Format(Constants.Format_MismatchFiles, 
                        index, "\u2500\u2524", fileTwoLine, fileOneLine);
                }
                else
                {
                    output = fileOneLine;
                }
                mismatches[index] = output;
            }

            return mismatches;
        }

        private string GetMismatchPath(string fileTwoPath)
        {
            return Path.Combine(
                Path.GetDirectoryName(fileTwoPath), Constants.File_MismatchFileName);

            //int index = expectedOutputPath.LastIndexOf('\\');
            //return expectedOutputPath.Substring(0, index) + @"\Mismatches.txt";
        }
    }
}
