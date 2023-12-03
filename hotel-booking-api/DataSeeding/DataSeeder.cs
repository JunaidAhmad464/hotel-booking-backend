using hotel_booking_api;
using hotel_booking_api.Models.Hotel;
using hotel_booking_api.Models.UserManagemnt;
using Microsoft.AspNetCore.Identity;

namespace HodHodBackend.Context.DataSeeding
{
    public class DataSeeder
    {
        private readonly HotelBookingContext _dBContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataSeeder(HotelBookingContext dBContext, UserManager<ApplicationUser> userManager)
        {
            _dBContext = dBContext;
            _userManager = userManager;
        }

        public void Seed()
        {
            if (!_dBContext.ApplicationUsers.Any() && !_dBContext.ApplicationRoles.Any())
            {
                UserAndRoleSeeding();
            }

            if (!_dBContext.RoomsTypes.Any())
            {
                RoomTypesSeeding();
            }
        }

        public void UserAndRoleSeeding()
        {
            try
            {
                var roles = RolesSeed();
                _dBContext.ApplicationRoles.AddRange(roles);
                _dBContext.SaveChanges();
                var user = new ApplicationUser
                {
                    FullName = "Super Admin",
                    FirstName = "Super",
                    LastName = "Admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    UserImage = "",
                    Status = "ACTIVE",
                    UserName = "superadmin@hotel.com.sa",
                    Email = "superadmin@hotel.com.sa",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                };
                _userManager.CreateAsync(user, "hotel@123").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(user, "admin").GetAwaiter().GetResult();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ApplicationRole> RolesSeed()
        {
            var roles = new List<ApplicationRole>()
            {
                new ApplicationRole()
                {
                    Name = "admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    Status = "ACTIVE",
                    NormalizedName = "ADMIN"
                },
                new ApplicationRole()
                {
                    Name = "customer",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    Status = "ACTIVE",
                    NormalizedName = "CUSTOMER"
                }
            };
            return roles;
        }

        public void RoomTypesSeeding()
        {
            var roomTypes = new List<RoomType>()
            {
                new RoomType()
                {
                    Name = "Standard Room"
                },
                new RoomType()
                {
                    Name = "Deluxe Room"
                }
            };
            _dBContext.RoomsTypes.AddRange(roomTypes);
            _dBContext.SaveChanges();
        }
    }
}
