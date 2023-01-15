using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using Pitshop.Models;

namespace Pitshop.Data
{
    public class NotificationDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public NotificationDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Notification>().Wait();
        }
        public Task<List<Notification>> GetNotificationAsync()
        {
            return _database.Table<Notification>().ToListAsync();
        }
        public Task<Notification> GetNotificationAsync(int id)
        {
            return _database.Table<Notification>()
            .Where(i => i.Id == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveNotificationAsync(Notification slist)
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
        public Task<int> DeleteNotificationAsync(Notification slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
