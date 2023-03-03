using ProOffice.BookingAPI.Models.Dto;
using ProOffice.BookingAPI.Repository;

namespace ProOffice.BookingAPI.Services
{
    public class BookResourceService : IBookResourceService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IResourceRepository _resourceRepository;

        public BookResourceService(IBookingRepository bookingRepository, IResourceRepository resourceRepository)
        {
            _bookingRepository = bookingRepository;
            _resourceRepository = resourceRepository;
        }
        
        public async Task<bool> BookResourceAndUpdateResourceQuantity(BookingDto bookingDto)
        {
            var resourceDto = await _resourceRepository.GetResourceDtoById(bookingDto.ResourceId);
            if (resourceDto == null)
            {
                return false;
            }
            else
            {
                var bookedDto = await _bookingRepository.BookResource(bookingDto, resourceDto);
                if (bookedDto == null)
                {
                    return false;
                }
                else
                {
                    resourceDto.Quantity -= bookingDto.BookedQuantity;
                    bool isUpdateSuccesfull = await _resourceRepository.UpdateResource(resourceDto);
                    
                    return isUpdateSuccesfull;
                }         
            }
        }
    }
}
