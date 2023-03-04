using ProOffice.BookingAPI.Models;
using ProOffice.BookingAPI.Models.Dto;
using ProOffice.BookingAPI.Repository;

namespace ProOffice.BookingAPI.Services
{
    public class BookResourceService : IBookResourceService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IResourceRepository _resourceRepository;
        private readonly IMessageSenderService _messageSenderService;

        public BookResourceService(IBookingRepository bookingRepository, IResourceRepository resourceRepository, IMessageSenderService messageSenderService)
        {
            _bookingRepository = bookingRepository;
            _resourceRepository = resourceRepository;
            _messageSenderService = messageSenderService;
        }

        public async Task<bool> BookResourceAndUpdateResourceQuantity(BookingDto bookingDto)
        {
            if(bookingDto == null)
            {
                return false;
            }
            var resourceDto = await _resourceRepository.GetResourceDtoById(bookingDto.ResourceId);
            if (resourceDto.Id < 1)
            {
                return false;
            }
            else
            {
                Booking? bookingObj = await _bookingRepository.BookResource(bookingDto, resourceDto);
                if (bookingObj == null)
                {
                    return false;
                }
                else
                {
                    _messageSenderService.SendMessage($"EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {bookingObj.Id}");
                    resourceDto.Quantity -= bookingDto.BookedQuantity;
                    bool isUpdateSuccesfull = await _resourceRepository.UpdateResource(resourceDto);

                    return isUpdateSuccesfull;
                }
            }
        }
    }
}
