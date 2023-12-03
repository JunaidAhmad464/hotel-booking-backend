namespace hotel_booking_api.Dtos.HotelDtos
{
    public class BookingDto
    {
        public int RoomId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
