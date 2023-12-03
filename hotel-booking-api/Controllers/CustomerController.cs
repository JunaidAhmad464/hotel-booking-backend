using hotel_booking_api.Dtos.HotelDtos;
using hotel_booking_api.Services.HotelServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hotel_booking_api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public CustomerController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [Authorize]
        [HttpGet("getCustomerBookingData/{customerId}")]
        public async Task<IActionResult> GetCustomerBookingData(string customerId)
        {
            try
            {
                if (String.IsNullOrEmpty(customerId)) return BadRequest(new { message = "Invalid data" });
                var customerData = await _bookingService.GetCustomerBooking(customerId);
                return Ok(new { data = customerData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost("bookRoom")]
        public async Task<IActionResult> BookRoom([FromBody] BookingDto dto)
        {
            try
            {
                if (dto == null) return BadRequest(new { message = " Invalid data" });
                string response = await _bookingService.CreateBooking(dto);
                if (response != "ROOM_BOOKED") return BadRequest(new { message = "Room not booked, please try again later" });
                return Ok(new { message = "Room booking request send" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
