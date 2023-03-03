using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProOffice.BookingAPI.DbContexts;
using ProOffice.BookingAPI.Models;
using ProOffice.BookingAPI.Models.Dto;

namespace ProOffice.BookingAPI.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private ApplicationDbContext _db;
        private IMapper _mapper;

        public BookingRepository(ApplicationDbContext db, IMapper mapper, HttpClient httpClient)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<object> BookResource(BookingDto bookingDto, ResourceDto resourceDto)
        {
            var booking = _mapper.Map<BookingDto, Booking>(bookingDto);
            // find if there is a booked reservation for that resource
            var bookedResourceDto = await _db.Bookings.FirstOrDefaultAsync(x => x.ResourceId == bookingDto.ResourceId);
            // if there isn't:
            if (bookedResourceDto == null)
            {
                //and the booked quantity is smaller that the quantity we have in stock:
                if (resourceDto.Quantity >= bookingDto.BookedQuantity)
                {
                    _db.Bookings.Add(booking);

                    await _db.SaveChangesAsync();

                    return bookingDto;
                }
                return new BookingDto();
            }
            else // if there is a booked reservation for that resource
            {
                if (bookingDto.BookedQuantity + bookedResourceDto.BookedQuantity <= resourceDto.Quantity)
                {
                    _db.Bookings.Add(booking);

                    await _db.SaveChangesAsync();

                    return bookingDto;
                }
                return new BookingDto();
            }
            // another check needs to be done if the resource is booked for that requested period. If it's booked then it can not
            // be be booked again no metter the quantity, if it booked but not for that period, then we are checking quantity.
        }
    }
}
