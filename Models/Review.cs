namespace PitShop.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? MechanicId { get; set; }
        public Mechanic? Mechanic { get; set; }
        public string? BookingDescription { get; set; }
        public Booking? Booking { get; set; }
        public string ReviewDescription { get; set; }
    }
}
