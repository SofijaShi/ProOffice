using AutoMapper;
using ProOffice.ResourceAPI.Models;
using ProOffice.ResourceAPI.Models.Dto;

namespace ProOffice.ResourceAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ResourceDto, Resource>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
