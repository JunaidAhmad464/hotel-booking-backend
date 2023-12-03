namespace hotel_booking_api.Models.Hotel
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public bool IsBooked { get; set; }
        public int RoomType { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
