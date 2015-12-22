using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Survery.Website.Infrastructure
{
    public class WebConfig
    {
        private static string mongodb = string.Empty;
        public static string MongoDb
        {
            get
            {
                if (string.IsNullOrEmpty(mongodb))
                {
                    mongodb = ConfigurationManager.AppSettings.Get("MongoDb");
                }
                return mongodb;
            }
        }

        private static string dbName = string.Empty;
        public static string DbName
        {
            get
            {
                if (string.IsNullOrEmpty(dbName))
                {
                    dbName = ConfigurationManager.AppSettings.Get("DbName");
                }
                return dbName;
            }
        }
    }
}