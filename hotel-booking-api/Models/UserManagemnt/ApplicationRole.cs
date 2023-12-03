using Microsoft.AspNetCore.Identity;

namespace hotel_booking_api.Models.UserManagemnt
{
    public class ApplicationRole : IdentityRole<string>
    {
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public Nullable<DateTime> CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Status { get; set; } = string.Empty;

        public ICollection<ApplicationUserRole>? ApplicationUserRoles { get; set; }
    }
}
