using Dapper;
using IpApi.Interfaces;
using IpApi.Types.Request;
using IpApi.Types.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpApi.Implementation
{
    public class DataBaseImplementation : IDataBaseService
    {
        public GetIpDetailsResponse GetIpDetails(GetIpRequest request)
        {
            string sql = @"Select * From ipdetails Where Ip=@ip";
            var parameters = new { ip = request.Ip };
            using (var con = GetSqlConnection())
            {
                return con.Query<GetIpDetailsResponse>(sql, parameters).FirstOrDefault(); 
            }
        }

        private SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.AppSettings["myConnectionString"]);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }


    }
}
