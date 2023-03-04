﻿using ProOffice.BookingAPI.Models.Dto;
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
                BookingDto bookedDto = await _bookingRepository.BookResource(bookingDto, resourceDto);
                if (bookedDto.ResourceId < 1)
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
