using PitShop.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitshop.Data
{
    class MechanicDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public MechanicDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Mechanic>().Wait();
        }
        public Task<List<Mechanic>> GetMechanicAsync()
        {
            return _database.Table<Mechanic>().ToListAsync();
        }
        public Task<Mechanic> GetMechanicAsync(int id)
        {
            return _database.Table<Mechanic>()
            .Where(i => i.Id == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveMechanicAsync(Mechanic slist)
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
        public Task<int> DeleteMechanicAsync(Mechanic slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
