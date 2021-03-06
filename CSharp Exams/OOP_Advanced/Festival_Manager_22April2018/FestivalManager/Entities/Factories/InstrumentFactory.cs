﻿namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            Type instrumentType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            //if (instrumentType == null)
            //{
            //    throw new ArgumentException();
            //}

            //if (!typeof(IInstrument).IsAssignableFrom(instrumentType))
            //{
            //    throw new InvalidOperationException();
            //}

            IInstrument instrument = (IInstrument)Activator.CreateInstance(instrumentType);

            return instrument;
        }
	}
}