using hotel_booking_api.Dtos.HotelDtos;

namespace hotel_booking_api.Services.HotelServices
{
    public interface IBookingService
    {
        Task<List<GetCustomerBookingDto>> GetCustomerBooking(string customerId);
        Task<string> CreateBooking(BookingDto bookingDto);
    }
}
