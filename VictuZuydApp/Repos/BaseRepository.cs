using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace VictuZuydApp.Repos
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Models.TableData, new()
    {
        private readonly SQLiteAsyncConnection _database;

        public BaseRepository(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public Task<int> InsertAsync(T entity)
        {
            return _database.InsertAsync(entity);
        }

        public Task<int> UpdateAsync(T entity)
        {
            return _database.UpdateAsync(entity);
        }

        public Task<int> DeleteAsync(T entity)
        {
            return _database.DeleteAsync(entity);
        }

        public Task<List<T>> GetAllAsync()
        {
            return _database.Table<T>().ToListAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _database.FindAsync<T>(id);
        }

    }
}
