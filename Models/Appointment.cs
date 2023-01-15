using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Pitshop.Models
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public int EngineCapacity { get; set; }
        public string Fuel { get; set; }
        public int Power { get; set; }
        public string Mechanic { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
