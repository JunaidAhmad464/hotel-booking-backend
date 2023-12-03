using HodHodBackend.Dtos.AuthDtos;
using hotel_booking_api.Models.UserManagemnt;
using Microsoft.AspNetCore.Identity;

namespace HodHodBackend.Services.AuthenticationServices
{
    public interface IAuthService
    {
        Task<string> Register(RegisterDto dto, string createdBy);
        Task<SignInResult> Login(LoginDto model);
        Task<ApplicationUser> GetUser(string Id, bool isCurrentUser);
        ApplicationUser GetUserByEmail(string email);
        Task<bool> SaveAll();
        Task<SignInResult> ValidateUser(string email, string password);
        IList<string> CatchIdentityErrors(IdentityResult identityResult);
    }
}
