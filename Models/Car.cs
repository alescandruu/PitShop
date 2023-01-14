using System.ComponentModel.DataAnnotations;

namespace PitShop.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
        public int EngineCapacity { get; set; }
        public string Fuel {get; set; }
        public int Power { get; set; }

        public string FullName
        {
            get
            {
                return Brand + " " + Model;
            }
        }
    }
}
