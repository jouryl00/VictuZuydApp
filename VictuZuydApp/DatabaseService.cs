using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace VictuZuydApp
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitializeAsync()
        {
            await _database.CreateTableAsync<Models.Event>();
            await _database.CreateTableAsync<Models.Activity>();
            await _database.CreateTableAsync<Models.User>();
        }

        public SQLiteAsyncConnection GetConnection()
        {
            return _database;
        }
    }
}
