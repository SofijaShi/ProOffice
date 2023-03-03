using ProOffice.BookingAPI.Models.Dto;

namespace ProOffice.BookingAPI.Repository
{
    public interface IResourceRepository
    {
        Task<ResourceDto> GetResourceDtoById(int id);
        Task<bool> UpdateResource(ResourceDto resourceDto);
    }
}
