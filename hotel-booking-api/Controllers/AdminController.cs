using hotel_booking_api.Dtos.AdminDtos;
using hotel_booking_api.Services.AdminServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hotel_booking_api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService) 
        {
            _adminService = adminService;
        }

        #region confirm booking

        [Authorize(Roles = "admin")]
        [HttpPost("confirmBooking")]
        public async Task<IActionResult> ConfirmBooking([FromBody] ConfirmBookingDto confirmBooking)
        {
            try
            {
                if(confirmBooking == null) { return BadRequest(new { message = "Invalid data" }); }
                string response = await _adminService.ConfirmBooking(confirmBooking);
                if(response != "BOOKING_CONFIRMED" && response != "REQUEST_REJECTED") { return BadRequest(new { message = "Booking not confirmed, please try again later" }); }
                if (response == "REQUEST_REJECTED") return Ok(new { message = "Request Rejected Successfully" });
                return Ok(new { message = "Booking confirmed" });
            }
            catch (NullReferenceException)
            {
                return BadRequest(new { message = "Null value not allowed" });
            }
            catch (InvalidCastException)
            {
                return BadRequest(new { message = "Invalid casting" });
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion

        #region customer requests
        [Authorize(Roles = "admin")]
        [HttpGet("getCustomerRequest")]
        public async Task<IActionResult> GetCustomerRequest()
        {
            try
            {
                var customerRequest = await _adminService.GetCustomerRequests();
                return Ok(new { data = customerRequest });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion

        #region rooms
        [Authorize(Roles = "admin")]
        [HttpPost("addRoom")]
        public async Task<IActionResult> AddRoom([FromBody] createRoomDto roomDto)
        {
            try
            {
                if(roomDto == null) return BadRequest(new { message = "Invalid data" });
                var response = await _adminService.AddRoom(roomDto);
                if (response != "ROOM_ADDED") return BadRequest(new { message = "Room not added, try again" });
                return Ok(new { message = "Room Added Successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("getRooms")]
        public async Task<IActionResult> GetRooms()
        {
            try
            {
                var response = await _adminService.GetRooms();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "admin")]
        [HttpGet("getRoomTypes")]
        public async Task<IActionResult> GetRoomTypes()
        {
            try
            {
                var response = await _adminService.GetRoomTypes();
                return Ok(new {data = response});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion
    }
}
