﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    public class DbProviderFactoryHelper
    {
        public const string DbProviderSqlServer = "System.Data.SqlClient";

        public static DbProviderFactoryHelper Create(string dbProviderName)
        {
            DbProviderFactoryHelper helper = new DbProviderFactoryHelper(dbProviderName);
            return helper;
        }


        private DbProviderFactoryHelper()
        {
            if (String.IsNullOrEmpty(ConnectionSingleton.Instance.ProviderName))
            {
                factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            }
            else
            {
                factory = DbProviderFactories.GetFactory(ConnectionSingleton.Instance.ProviderName);
            }
        }
        private DbProviderFactoryHelper(String providerName)
        {
            if (String.IsNullOrEmpty(providerName) || string.IsNullOrWhiteSpace(providerName)) 
            {
                throw new ArgumentException("ProviderName can not be empty or null"); 
            }
            factory = DbProviderFactories.GetFactory(providerName);
        }


        DbProviderFactory factory;

        public DbProviderFactory Factory
        {
            get { return factory; }
            set { factory = value; }
        }


        public DbParameter GetParameter()
        {
            return this.factory.CreateParameter();
        }

    }
}
