using ProOffice.ResourceAPI.Models.Dto;

namespace ProOffice.ResourceAPI.Repository
{
    public interface IResourceRepository
    {
        Task<IEnumerable<ResourceDto>> GetResources();
        Task<ResourceDto> GetResourceById(int id);
        Task<ResourceDto> UpdateResource(ResourceDto resourceDto);
    }
}
