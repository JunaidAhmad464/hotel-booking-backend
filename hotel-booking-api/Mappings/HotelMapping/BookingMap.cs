using hotel_booking_api.Models.Hotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotel_booking_api.Mappings.HotelMapping
{
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder) 
        {
            builder.HasKey(x => x.BookingId);
            builder.Property(x => x.BookingId);
            builder.Property(x => x.CustomerId).IsRequired(true);
            builder.Property(x => x.CheckInDate).IsRequired(true);
            builder.Property(x => x.CheckOutDate).IsRequired(true);
            builder.Property(x => x.CreatedOn).IsRequired(true);
            builder.Property(x => x.Status).IsRequired(true);

            // foriegn key relation
            builder.HasOne(x => x.Room).WithMany(x => x.Bookings).HasForeignKey(x => x.RoomId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
