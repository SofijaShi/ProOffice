using Microsoft.AspNetCore.Mvc;
using ProOffice.ResourceAPI.Models.Dto;
using ProOffice.ResourceAPI.Repository;

namespace ProOffice.ResourceAPI.Controllers
{
    [Route("api/resources")]
    public class ResourceApiController : Controller
    {
        private IResourceRepository _resourceRepository;
        protected ResponseDto _response;

        public ResourceApiController(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ResourceDto> resourceDtos = await _resourceRepository.GetResources();
                _response.Result = resourceDtos;
            }
            catch (Exception ex)
            {
                _response.IsRequestSuccessful = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ResourceDto resourceDto = await _resourceRepository.GetResourceById(id);
                _response.Result = resourceDto;
            }
            catch (Exception ex)
            {
                _response.IsRequestSuccessful = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPut]
        public async Task<object> Update([FromBody] ResourceDto resourceDto)
        {
            try
            {
                ResourceDto model = await _resourceRepository.UpdateResource(resourceDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsRequestSuccessful = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
