using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    class MySQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _configuration;

        private string ConnectionStringName { get; } = "Standard";

        public MySQLDataAccess(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _configuration.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }
        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = _configuration.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

    }
}
