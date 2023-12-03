using Microsoft.AspNetCore.Identity;

namespace hotel_booking_api.Models.UserManagemnt
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationUser? ApplicationUser { get; set; }
        public ApplicationRole? ApplicationRole { get; set; }
    }
}
