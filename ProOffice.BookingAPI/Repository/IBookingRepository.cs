using ProOffice.BookingAPI.Models;
using ProOffice.BookingAPI.Models.Dto;

namespace ProOffice.BookingAPI.Repository
{
    public interface IBookingRepository
    {
        Task<Booking?> BookResource(BookingDto bookingDto, ResourceDto resourceDto);
    }
}
