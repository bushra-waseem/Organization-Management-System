using Dapper_Company.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dapper_Company.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }

        //public class DatabaseContext
        //{
        //    private readonly string _connectionString;

        //    public DatabaseContext(IConfiguration configuration)
        //    {
        //        _connectionString = configuration.GetConnectionString("DefaultConnection");
        //    }

        //    public SqlConnection GetConnection()
        //    {
        //        return new SqlConnection(_connectionString);
        //    }

        //}
    }
