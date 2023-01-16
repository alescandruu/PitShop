﻿namespace PitShop.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public String UserId { get; set; }
        public int? CarId { get; set; }
        public Car? Car { get; set; }
        public string? MechanicName { get; set; }
        public Mechanic? Mechanic { get; set; }
        public DateTime Date { get; set; }
        public string Description{ get; set; }
    }
}
