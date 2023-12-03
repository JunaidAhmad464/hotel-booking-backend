namespace hotel_booking_api.Dtos.HotelDtos
{
    public class GetCustomerBookingDto
    {
        public string Room { get; set; } = string.Empty;
        public string CheckIn { get; set; } = string.Empty;
        public string CheckOut { get; set; } = string.Empty;
        public string BookingDate { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
    }
}
