using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProOffice.BookingAPI.DbContexts;
using ProOffice.BookingAPI.Models;
using ProOffice.BookingAPI.Models.Dto;
using ProOffice.ValidationLogic;

namespace ProOffice.BookingAPI.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private ApplicationDbContext _db;
        private IMapper _mapper;
        private IValidate _validate;

        public BookingRepository(ApplicationDbContext db, IMapper mapper, IValidate validate)
        {
            _db = db;
            _mapper = mapper;
            _validate = validate;
        }


        public async Task<Booking?> BookResource(BookingDto bookingDto, ResourceDto resourceDto)
        {
            var booking = _mapper.Map<BookingDto, Booking>(bookingDto);

            var bookedResources = _db.Bookings.Where(x => x.ResourceId == bookingDto.ResourceId).ToList();

            if (bookedResources == null)
            {
                if (resourceDto.Quantity >= bookingDto.BookedQuantity)
                {
                    _db.Bookings.Add(booking);

                    await _db.SaveChangesAsync();

                    return booking;
                }
                return null;
            }
            else
            {
                var alreadyBookedTimeSlots = bookedResources.Select(x => new TimeSlot { DateFrom = x.DateFrom, DateTo = x.DateTo }).ToList();

                bool isResourceAvailableForTheDateRange =
                    _validate.isRequestedTimeRangeAvailable(bookingDto.DateFrom, bookingDto.DateTo, alreadyBookedTimeSlots);

                if (!isResourceAvailableForTheDateRange)
                {
                    return null;
                }

                if (bookingDto.BookedQuantity <= resourceDto.Quantity)
                {
                    _db.Bookings.Add(booking);

                    await _db.SaveChangesAsync();

                    return booking;
                }
                return null;
            }
        }
    }
}
