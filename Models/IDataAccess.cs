using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DependencyInjection.Models
{
    public interface IDataAccess :IDisposable
    {
        DataSet Excute(CommandType _CommandType, string Sql, params SqlParameter[] Param);
        Task ExcuteNonQuery(CommandType _CommandType, string Sql, params SqlParameter[] Param);
    }
}