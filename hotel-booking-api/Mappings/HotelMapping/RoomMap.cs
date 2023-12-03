using hotel_booking_api.Models.Hotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotel_booking_api.Mappings.HotelMapping
{
    public class RoomMap : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Price).IsRequired(true);
            builder.Property(x => x.IsBooked).IsRequired(true);
            builder.Property(x => x.RoomType).IsRequired(true);
        }
    }
}
