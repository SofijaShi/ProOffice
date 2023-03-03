using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProOffice.ResourceAPI.DbContexts;
using ProOffice.ResourceAPI.Models;
using ProOffice.ResourceAPI.Models.Dto;

namespace ProOffice.ResourceAPI.Repository
{
    public class ResourceRepository : IResourceRepository
    {
        private ApplicationDbContext _db;
        private IMapper _mapper;
        public ResourceRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResourceDto> GetResourceById(int id)
        {
            var resource = await _db.Resources.FirstOrDefaultAsync(r => r.Id == id);
            
            return _mapper.Map<ResourceDto>(resource);
        }

        public async Task<IEnumerable<ResourceDto>> GetResources()
        {
            IEnumerable<Resource> resources = await _db.Resources.ToListAsync();
            
            return _mapper.Map<List<ResourceDto>>(resources);
        }

        public async Task<ResourceDto> UpdateResource(ResourceDto resourceDto)
        {
            var resource = _mapper.Map<ResourceDto, Resource>(resourceDto);

            if (resourceDto.Id > 0 && resourceDto != null)
            {
                _db.Resources.Update(resource);
                await _db.SaveChangesAsync();
            }

            return _mapper.Map<Resource, ResourceDto>(resource);
        }
    }
}
