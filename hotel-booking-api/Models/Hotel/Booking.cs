namespace hotel_booking_api.Models.Hotel
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; } = string.Empty;

        public Room? Room { get; set; }
    }
}
