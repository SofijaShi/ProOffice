using ProOffice.BookingAPI.Models.Dto;

namespace ProOffice.BookingAPI.Repository
{
    public interface IBookingRepository
    {
        Task<object> BookResource(BookingDto bookingDto, ResourceDto resourceDto);
    }
}
