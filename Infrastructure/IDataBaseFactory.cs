using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
namespace Infrastructure
{
    public interface IDataBaseFactory
    {
        DbConnection GetConnection();
        DbCommand GetCommand();
        DbDataAdapter GetAdapter();
        DbTransaction GetTransaction(DbConnection con);
        DbParameter GetParameter(string parameter, object value);
    }
}
