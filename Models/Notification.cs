using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Pitshop.Models
{
    public class Notification
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullCarName { get; set; }
        public DateTime Date { get; set; }
        public DateTime SendDate { get; set; }
        public string Description { get; set; }
        public double Distance { get; set; }
    }
}
