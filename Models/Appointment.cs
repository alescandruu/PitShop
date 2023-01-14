using PitShop.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Pitshop.Models
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Username { get; set; }
        public Car? Car { get; set; }
        public string Mechanic { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
