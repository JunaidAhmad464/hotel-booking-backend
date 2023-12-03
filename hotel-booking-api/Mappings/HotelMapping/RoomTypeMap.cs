using hotel_booking_api.Models.Hotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotel_booking_api.Mappings.HotelMapping
{
    public class RoomTypeMap : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder) 
        {
            builder.HasKey(x => x.RoomTypeId);
            builder.Property(x => x.RoomTypeId);
            builder.Property(x => x.Name).IsRequired(true);
        }
    }
}
