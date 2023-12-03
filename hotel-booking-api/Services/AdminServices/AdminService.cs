using hotel_booking_api.Dtos.AdminDtos;
using hotel_booking_api.Dtos.HotelDtos;
using hotel_booking_api.Models.Hotel;
using hotel_booking_api.Services.EmailHelperService;
using Microsoft.EntityFrameworkCore;

namespace hotel_booking_api.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly HotelBookingContext _context;
        private readonly EmailService _emailService;
        public AdminService(HotelBookingContext context, EmailService emailService) 
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<string> AddRoom(createRoomDto room)
        {
            try
            {
                var newRoom = new Room
                {
                    Name = room.Name,
                    Description = room.Description,
                    Price = room.Price,
                    RoomType = room.RoomType,
                    IsBooked = false
                };
                await _context.Rooms.AddAsync(newRoom);
                await _context.SaveChangesAsync();
                return "ROOM_ADDED";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> ConfirmBooking(ConfirmBookingDto confirmBooking)
        {
            try
            {
                var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.BookingId == confirmBooking.BookingId);
                if(booking != null)
                {
                    booking.Status = confirmBooking.Status;
                }
                var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == confirmBooking.RoomId);
                if(room != null)
                {
                    room.IsBooked = true;
                }
                await _context.SaveChangesAsync();
                var customerData = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == confirmBooking.CustomerId);
                bool isEmailSend = false;
                if (confirmBooking.Status == "Approved")
                {
                    isEmailSend = _emailService.SendEmail(customerData!.Email, "Request Approved", "Congrats! Your request for room booking has been approved");
                    return "BOOKING_CONFIRMED";
                }
                isEmailSend = _emailService.SendEmail(customerData!.Email, "Request Rejected", "Sorry! Your request for room booking has been rejected");
                return "REQUEST_REJECTED";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetCustomerRequestDto>> GetCustomerRequests()
        {
            try
            {
                var customerRequest = await(from r in _context.Rooms
                                        join b in _context.Bookings on r.Id equals b.RoomId
                                        join a in _context.ApplicationUsers on b.CustomerId equals a.Id
                                        join rt in _context.RoomsTypes on r.RoomType equals rt.RoomTypeId
                                        select new GetCustomerRequestDto
                                        {
                                            BookingId = b.BookingId,
                                            RoomId = b.RoomId,
                                            RoomName = r.Name,
                                            CustomerId = b.CustomerId,
                                            CustomerName = a.FullName,
                                            CheckIn = b.CheckInDate.ToString("dd-mm-yyyy hh:mm"),
                                            CheckOut = b.CheckOutDate.ToString("dd-mm-yyyy hh:mm"),
                                            BookingDate = b.CreatedOn.ToString("dd-mm-yyyy hh:mm"),
                                            Status = b.Status,
                                            RoomType = rt.Name
                                        }).ToListAsync();
                if(customerRequest == null) { return new List<GetCustomerRequestDto>(); }
                return customerRequest;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetRoomsDto>> GetRooms()
        {
            try
            {
                var rooms = await _context.Rooms.Select(x => new GetRoomsDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ImageUrl = "images/room2.jpg",
                    Price = x.Price,
                    IsBooked = x.IsBooked
                }).ToListAsync();
                if (rooms == null) return new List<GetRoomsDto>();
                return rooms;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetRoomTypesDto>> GetRoomTypes()
        {
            try
            {
                var roomTypes = await _context.RoomsTypes.Select(x => new GetRoomTypesDto
                {
                    Id = x.RoomTypeId,
                    Name = x.Name,
                }).ToListAsync();
                if (roomTypes == null) return new List<GetRoomTypesDto>();
                return roomTypes;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
