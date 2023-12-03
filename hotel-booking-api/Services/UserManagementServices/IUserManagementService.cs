using hotel_booking_api.Models.UserManagemnt;
using Microsoft.AspNetCore.Identity;

namespace HodHodBackend.Services.UserManagementServices
{
    public interface IUserManagementService
    {
        Task<IdentityResult> RegisterNewUser(ApplicationUser applicationUser,string Password);
        Task<bool> userExists(string Email);
        Task<SignInResult> AuthenticateUser(string Email,string Password);
        Task<ApplicationUser> FindUserByEmail(string Email);
    }
}