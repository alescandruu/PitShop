using Pitshop.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitshop.Data
{
    public class AppointmentDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public AppointmentDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Appointment>().Wait();
        }
        public Task<List<Appointment>> GetAppointmentAsync()
        {
            return _database.Table<Appointment>().ToListAsync();
        }
        public Task<Appointment> GetAppointmentAsync(int id)
        {
            return _database.Table<Appointment>()
            .Where(i => i.Id == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveAppointmentAsync(Appointment slist)
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
        public Task<int> DeleteAppointmentAsync(Appointment slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
