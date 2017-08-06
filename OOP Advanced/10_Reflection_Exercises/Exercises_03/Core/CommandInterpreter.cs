﻿namespace Reflection_Exercises
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(
            IRepository repository,
            IUnitFactory unitFactory
            )
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            //first char to upper
            string cmdName = CultureInfo
                .CurrentCulture
                .TextInfo
                .ToTitleCase(commandName) +
                "Command";

            object[] cmdParams =
            {
                data,
                this.repository,
                this.unitFactory
            };

            Type commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == cmdName);

            if (commandType == null)
            {
                throw new InvalidOperationException(
                    "Invalid command");
            }

            return (IExecutable)Activator.CreateInstance(commandType, cmdParams);
        }
    }
}
