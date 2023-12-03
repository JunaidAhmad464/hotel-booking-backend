using HodHodBackend.Context.Mappings.UserManagement;
using hotel_booking_api.Mappings.HotelMapping;
using hotel_booking_api.Mappings.UserManagementMapping;
using hotel_booking_api.Models.Hotel;
using hotel_booking_api.Models.UserManagemnt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace hotel_booking_api
{
    public class HotelBookingContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public HotelBookingContext(DbContextOptions<HotelBookingContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // user managment mapping integrations starts
            builder.ApplyConfiguration<ApplicationUser>(new ApplicationUserMap());
            builder.ApplyConfiguration<ApplicationRole>(new ApplicationRoleMap());
            builder.ApplyConfiguration<ApplicationUserRole>(new ApplicationUserRoleMap());
            // user managment mapping integrations ends

            // hotel mapping integrations starts
            builder.ApplyConfiguration<Room>(new RoomMap());
            builder.ApplyConfiguration<Booking>(new BookingMap());
            builder.ApplyConfiguration<RoomType>(new RoomTypeMap());
            // hotel mapping integrations end
        }

        #region user management
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        #endregion

        #region hotel
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<RoomType> RoomsTypes { get; set;}
        #endregion
    }
}
