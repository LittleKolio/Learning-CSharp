﻿namespace BashSoft_OOP.IO
{
    using Interfaces;
    using StaticData;
    using System;
    using System.Diagnostics;
    using System.IO;

    public class FilesystemManager : IFilesystemManager
    {
        private string currentDirectory;

        public FilesystemManager()
        {
            this.currentDirectory = Directory.GetCurrentDirectory();
        }

        public string CurrentDirectory => this.currentDirectory;

        //public static string ParenetOfCurrentFolder(int step)
        //{
        //    string path = currentDirectory;
        //    for (int i = 0; i < step; i++)
        //    {
        //        path = Directory.GetParent(path).ToString();
        //    }
        //    return path;
        //}

        public void ChangeDirectory(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                throw new ArgumentException(string.Format(
                        ExceptionMessages.dir_DoseNotExist, Path.GetDirectoryName(absolutePath)));
            }

            this.currentDirectory = absolutePath;
        }

        public void ChangeDirectoryByRelativePath(string relativePath)
        {
            //Throw exception for incorect path format
            string path = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));

            if (!Directory.Exists(path))
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.dir_DoseNotExist, Path.GetDirectoryName(path)));
            }

            this.currentDirectory = path;
        }

        public void CreateDirectory(string directoryName)
        {
            string path = Path.Combine(currentDirectory, directoryName);

            Directory.CreateDirectory(path);

            this.currentDirectory = path;
        }

        //public string CreateTextFile(string name, string[] text)
        //{
        //    string path = Path.Combine(currentDirectory, name);
        //    try
        //    {
        //        File.WriteAllLines(path, text);
        //    }
        //    catch
        //    {
        //        throw new ArgumentException(
        //            ExceptionMessages.file_ForbiddenSymbols);
        //    }
        //    return path;
        //}

        public string CreateTextFile(string fileName, string extension)
        {
            string path = Path.Combine(currentDirectory, fileName, extension);

            File.CreateText(path);

            return path;
        }

        public void OpenFile(string fileName)
        {
            string filePath = Path.Combine(this.currentDirectory, fileName);

            if (!File.Exists(filePath))
            {
                throw new ArgumentException(
                    ExceptionMessages.file_DoseNotExist);
            }

            Process.Start(filePath);
        }
    }
}
