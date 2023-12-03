namespace hotel_booking_api.Dtos.AdminDtos
{
    public class ConfirmBookingDto
    {
        public string CustomerId { get; set; } = string.Empty;
        public int RoomId { get; set; }
        public int BookingId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
