using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


using Infrastructure;

namespace DataBaseFactory
{
    public class SQLFactory : IDataBaseFactory
    {
        private const string _constr = "Constr";


        public DbConnection GetConnection()
        { return new SqlConnection(ConfigurationSettings.AppSettings[_constr]); }

        public DbCommand GetCommand()
        { return new SqlCommand(); }


        public DbDataAdapter GetAdapter()
        {
            return new SqlDataAdapter();
        }


        public DbDataAdapter GetAdapter(SqlCommand cmd)
        {

            return new SqlDataAdapter(cmd);

        }

        public DbTransaction GetTransaction(DbConnection con)
        {
            return con.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public DbParameter GetParameter(string parameter, object value)
        {
            return new SqlParameter(parameter, value);
        }
    }
}

