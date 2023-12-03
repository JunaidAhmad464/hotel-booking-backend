namespace hotel_booking_api.Dtos.HotelDtos
{
    public class GetRoomsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Price { get; set; }
        public bool IsBooked { get; set; }
    }
}
