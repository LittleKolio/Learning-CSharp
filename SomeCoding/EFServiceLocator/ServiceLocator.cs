﻿namespace EFServiceLocator
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    public class ServiceLocator
    {
        private static ServiceLocator instance;
        private Dictionary<string, Something> services;

        private ServiceLocator()
        {
            this.services = new Dictionary<string, Something>();
        }

        public static ServiceLocator Instance
        {
            get
            {
                if (instance == null) { instance = new ServiceLocator(); }
                return instance;
            }
        }
        public void AddService(string key, Something some)
        {
            this.services.Add(key, some);
        }
        public Something GetService(string key)
        {
            return this.services.FirstOrDefault(s => s.Key == key).Value;
        }
        public Something GetServiceConfig()
        {
            //add reference system.configuration
            //<appSettings><add key = "bauu" value = "banana" /></appSettings>

            var appKey = ConfigurationManager.AppSettings["bauu"];
            return this.services.FirstOrDefault(s => s.Key == appKey).Value;
        }
    }
}
