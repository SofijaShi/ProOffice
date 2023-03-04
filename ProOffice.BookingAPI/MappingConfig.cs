using AutoMapper;
using ProOffice.BookingAPI.Models;
using ProOffice.BookingAPI.Models.Dto;

namespace ProOffice.BookingAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<BookingDto, Booking>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
