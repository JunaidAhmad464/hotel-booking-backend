using HodHodBackend.Dtos.RoleDtos;
using hotel_booking_api.Models.UserManagemnt;
using Microsoft.AspNetCore.Identity;

namespace HodHodBackend.Services.RoleManagementServices
{
    public interface IRoleService
    {
        Task<string> CreateRole(CreateRoleDto role, string createdBy);
        Task<IdentityResult> AssignRoleToUser(List<string> roleIds,ApplicationUser applicationUser);
        Task<ApplicationRole> FindRoleNameById(string roleId);
        List<string> GetUserRoleIds(string id);
        Task<string> DeActivate(string id);
        Task<string> Activate(string id);
        List<string> GetUserRole(string id);
    }
}
