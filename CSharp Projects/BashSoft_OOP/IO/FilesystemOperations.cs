﻿namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class FilesystemOperations
    {
        public static string currentDirectory = Directory.GetCurrentDirectory();

        //public static string ParenetOfCurrentFolder(int step)
        //{
        //    string path = currentDirectory;
        //    for (int i = 0; i < step; i++)
        //    {
        //        path = Directory.GetParent(path).ToString();
        //    }
        //    return path;
        //}

        public static void ChangeCurrentDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                OutputWriter.WriteException(
                        ExceptionMessages.dir_DoseNotExist);
                return;
            }
            currentDirectory = path;
        }

        public static void ChangeCurrentDirectoryByRelativePath(string path)
        {
            if (!Directory.Exists(path))
            {
                OutputWriter.WriteException(
                        ExceptionMessages.dir_DoseNotExist);
                return;
            }
            currentDirectory = Path.GetFullPath(
                Path.Combine(currentDirectory, path));
        }

        public static void CreateDirectoryInCurrentDirectory(string directoryName)
        {
            //if (directoryName.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            //{
            //    OutputWriter.DisplayException(
            //        ExceptionMessages.dir_ForbiddenSymbols);
            //    return null;
            //}

            string path = Path.Combine(currentDirectory, directoryName);
            try
            {
                Directory.CreateDirectory(path);
            }
            catch
            {
                OutputWriter.WriteException(
                    ExceptionMessages.dir_ForbiddenSymbols);
                return;
            }

            currentDirectory = path;
        }

        public static string CreateTextFileInCurrentDirectory(string name, string[] text)
        {
            string path = Path.Combine(currentDirectory, name);
            try
            {
                File.WriteAllLines(path, text);
            }
            catch
            {
                OutputWriter.WriteException(
                    ExceptionMessages.file_ForbiddenSymbols);
                return null;
            }
            return path;
        }
    }
}
