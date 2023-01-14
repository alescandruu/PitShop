using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using Pitshop.Models;
using PitShop.Models;

namespace Pitshop.Data
{
    public class CarDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public CarDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Car>().Wait();
        }

        public Task<List<Car>> GetCarAsync()
        {
            return _database.Table<Car>().ToListAsync();
        }

        public Task<Car> GetCarAsync(int id)
        {
            return _database.Table<Car>()
            .Where(i => i.Id == id)
           .FirstOrDefaultAsync();
        }

        public Task<int> SaveCarAsync(Car slist)
        {
            if (slist.Id != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteCarAsync(Car slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
