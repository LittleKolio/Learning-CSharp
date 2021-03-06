﻿namespace BashSoft_OOP.StaticData
{
    public static class ExceptionMessages
    {
        public const string data_IsInitialized = "Data structure is already initialized!";
        public const string data_IsNotInitialized = "The data structure must be initialized first.";
        public const string data_Cours_NotExist = "Course: \"{0}\" does not exist in the data base!";
        public const string data_Cours_Exist = "Course: \"{0}\" already exist in the data base!";
        public const string data_Filter_Invalid = "Filter is not one of the following: excellent/average/poor";
        public const string data_Order_Invalid = "Order: \"{0}\" is not one of the following: ascending/descending";
        public const string data_Student_Requirements = "No student meets the requirements.";
        public const string data_Student_NoStudents = "There is no student in course: \"{0}\".";
        public const string data_Student_NotInCourse = "Student: \"{0}\" does not exist in this course: \"{1}\".";
        public const string data_Student_InvalidScores = "Student: \"{0}\" has invalid scores.";
        public const string data_Student_NumberOfScores = "Number of scores must be {0}.";

        public const string file_DoseNotExist = "File: \"{0}\" does not exist!";
        public const string file_DontHaveAccess = "You don't have access to tose file!";
        public const string file_ForbiddenSymbols = "File name contains not allowed symbols.";
        public const string file_WriteMismatche = "Line {0} -- expected: \"{1}\", actual: \"{2}\"";


        public const string dir_DoseNotExist = "Folder: \"{0}\" does not exist!";
        public const string dir_DontHaveAccess = "You don't have access to tose folder!";
        public const string dir_ForbiddenSymbols = "Folder name contains not allowed symbols.";

        public const string params_InvalidNumber = "Expect {0} number of parameters.";
        public const string params_InvalidParameter = "The parameter: \"{0}\" is invalid.";

        public const string command_Null = "Insert command.";
        public const string command_IsNotExecutable = "Command: \"{0}\" is not executable!";
        public const string command_DoseNotExist = "Command: \"{0}\" dose not exist!";
    }
}
