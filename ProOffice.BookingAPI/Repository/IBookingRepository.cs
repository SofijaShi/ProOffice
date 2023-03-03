using ProOffice.BookingAPI.Models.Dto;

namespace ProOffice.BookingAPI.Repository
{
    public interface IBookingRepository
    {
        Task<BookingDto> BookResource(BookingDto bookingDto, ResourceDto resourceDto);
    }
}
