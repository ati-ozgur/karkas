﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;

namespace Karkas.Core.DataUtil
{
    public class CommandFactory
    {
        public static DbCommand getDatabaseCommand(string sql, DbConnection conn)
        {
            DbCommand command = conn.CreateCommand();
            command.CommandText = sql;
            return command;
        }
        public static DbCommand getDatabaseCommand(DbConnection conn)
        {
            DbCommand command = conn.CreateCommand();
            return command;
        }

        public static DbDataAdapter getDatabaseAdapter(DbCommand cmd)
        {
            DbDataAdapter adapter = null;
            if (cmd is SqlCommand)
            {
                return new SqlDataAdapter((SqlCommand)cmd);
            }
            else
            {
                adapter = new DbProviderFactoryHelper().Factory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
            }
                return adapter;
        }



    }
}

