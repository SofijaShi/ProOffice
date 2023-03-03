using ProOffice.BookingAPI.Models.Dto;

namespace ProOffice.BookingAPI.Services
{
    public interface IBookResourceService
    {
        Task<bool> BookResourceAndUpdateResourceQuantity(BookingDto bookingDto);
    }
}
