using hotel_booking_api.Dtos.AdminDtos;
using hotel_booking_api.Dtos.HotelDtos;

namespace hotel_booking_api.Services.AdminServices
{
    public interface IAdminService
    {
        Task<List<GetCustomerRequestDto>> GetCustomerRequests();
        Task<string> ConfirmBooking(ConfirmBookingDto confirmBooking);
        Task<string> AddRoom(createRoomDto room);
        Task<List<GetRoomTypesDto>> GetRoomTypes();
        Task<List<GetRoomsDto>> GetRooms();
    }
}
