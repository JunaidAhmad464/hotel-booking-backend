using hotel_booking_api.Dtos.HotelDtos;
using hotel_booking_api.Models.Hotel;
using Microsoft.EntityFrameworkCore;

namespace hotel_booking_api.Services.HotelServices
{
    public class BookingService : IBookingService
    {
        private readonly HotelBookingContext _bookingContext;
        public BookingService(HotelBookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }

        public async Task<string> CreateBooking(BookingDto bookingDto)
        {
            try
            {
                var booking = new Booking
                {
                    RoomId = bookingDto.RoomId,
                    CustomerId = bookingDto.CustomerId,
                    CheckInDate = bookingDto.CheckIn,
                    CheckOutDate = bookingDto.CheckOut,
                    CreatedOn = DateTime.Now,
                    Status = "Pending"
                };
                await _bookingContext.Bookings.AddAsync(booking);
                await _bookingContext.SaveChangesAsync();
                return "ROOM_BOOKED";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetCustomerBookingDto>> GetCustomerBooking(string customerId)
        {
            try
            {
                var bookingData = await (from r in _bookingContext.Rooms
                                         join b in _bookingContext.Bookings on r.Id equals b.RoomId
                                         join rt in _bookingContext.RoomsTypes on r.RoomType equals rt.RoomTypeId
                                         where b.CustomerId == customerId
                                         select new GetCustomerBookingDto
                                         {
                                             Room = r.Name,
                                             CheckIn = b.CheckInDate.ToString("dd-mm-yyyy hh:mm"),
                                             CheckOut = b.CheckOutDate.ToString("dd-mm-yyyy hh:mm"),
                                             BookingDate = b.CreatedOn.ToString("dd-mm-yyyy hh:mm"),
                                             Status = b.Status,
                                             RoomType = rt.Name
                                         }).ToListAsync();
                if(bookingData == null || bookingData.Count == 0 ) { return new List<GetCustomerBookingDto>(); }
                return bookingData;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
