﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string level, double points)
    {
        Type missionType = Assembly
            .GetCallingAssembly()
            //.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == level);

        if (missionType == null)
        {
            throw new ArgumentException(
                "Invalid MissionType!");
        }

        if (!typeof(IMission).IsAssignableFrom(missionType))
        {
            throw new InvalidOperationException(
                "MissionType don't inherit IMission!");
        }

        //object[] parameters = new object[] { points };

        //IMission mission = (IMission)Activator.CreateInstance(
        //    missionType, parameters);

        IMission mission = (IMission)Activator.CreateInstance(
            missionType, points);

        return mission;
    }
}
