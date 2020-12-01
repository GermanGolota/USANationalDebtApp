﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    interface ISQLDataAccess
    {
        string ConnectionStringName { get; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
    }
}