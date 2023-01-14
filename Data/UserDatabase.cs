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
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public UserDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public int ValidateUser(string Username, string Password)
        {   
            var username = _database.Table<User>()
            .Where(i => i.Username == Username)
           .FirstOrDefaultAsync();

            var password = _database.Table<User>()
            .Where(i => i.Password == Password)
           .FirstOrDefaultAsync();

            if (username.Result == null) return 1;
            if (password.Result == null) return 1;
            return 0;
        }

        public Task<List<User>> GetUserAsync()
        {
            return _database.Table<User>().ToListAsync();
        }
        public Task<User> GetUserAsync(string Email)
        {
            return _database.Table<User>()
            .Where(i => i.Email == Email)
           .FirstOrDefaultAsync();
        }
        public int SaveUserAsync(User slist)
        {
            var res = GetUserAsync(slist.Email);
            if (res.Result != null) return 1;
            
            _database.InsertAsync(slist);
            return 0;
        }
        public Task<int> DeleteUserAsync(User slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
