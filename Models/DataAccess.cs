using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DependencyInjection.Models
{
    public class DataAccess : IDataAccess
    {
        private SqlConnection Conn;
        private SqlCommand Conm;

        private void OpenConnection(string ConnectString)
        {
            AuditLogs.WriteLog("OpenConnection: {ConnectString}");
            Conn = new SqlConnection();
            Conn.ConnectionString = ConnectString;
            Conn.Open();
            Conm = new SqlCommand();
            Conm.Connection = Conn;
        }
        public DataAccess()
        {
            OpenConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
        public void Dispose()
        {
            AuditLogs.WriteLog("OpenConnection -> Dispose");
            if (Conm != null)
            {
                Conm.Dispose();
            }
            if(Conn != null)
            {
                if (Conn.State != ConnectionState.Closed) Conn.Close();
                Conn.Dispose();
            }
        }

        public DataSet Excute(CommandType _CommandType, string Sql, params SqlParameter[] Param)
        {
            AuditLogs.WriteLog($"Excute -> DataSet({_CommandType.ToString()}, {Sql}, {JsonConvert.SerializeObject(Param)})");
            DataSet ds = new DataSet();
            Conm.CommandType = _CommandType;
            Conm.CommandText = Sql;
            Conm.Parameters.Add(Param);
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand = Conm;                
                da.Fill(ds);
            }
            return ds;
        }

        public async Task ExcuteNonQuery(CommandType _CommandType, string Sql, params SqlParameter[] Param)
        {
            using (var tran = Conn.BeginTransaction())
            {
                Conm.CommandType = _CommandType;
                Conm.CommandText = Sql;
                Conm.Parameters.Add(Param);
                Conm.Transaction = tran;
                try
                {
                    await Conm.ExecuteNonQueryAsync();
                }
                catch
                {
                    tran.Rollback();
                    await AuditLogs.WriteLog($"ExcuteNonQuery({_CommandType.ToString()}, {Sql}, {JsonConvert.SerializeObject(Param)}): False");
                    return;
                }
                tran.Commit();
            }
            await AuditLogs.WriteLog($"ExcuteNonQuery({_CommandType.ToString()}, {Sql}, {JsonConvert.SerializeObject(Param)}): OK");
        }
    }
}