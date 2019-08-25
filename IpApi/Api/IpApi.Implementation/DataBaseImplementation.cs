using Dapper;
using ExternalApi.Types;
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

        public void WriteIpDetailsinDataBase(WriteIpInDbRequest request)
        {
            string sql = @"INSERT INTO ipdetails (Ip,City,Continent,Country,Latitude,Longitude) VALUES (@Ip,@City,@Continent,@Country,@Latitude,@Longitude) ";
            var parameters = new {request.Ip, request.City, request.Continent, request.Country, request.Latitude, request.Longitude };

            using (var con = GetSqlConnection())
            {
                con.Execute(sql, parameters);
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
