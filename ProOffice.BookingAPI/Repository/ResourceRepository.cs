using AutoMapper;
using Newtonsoft.Json;
using ProOffice.BookingAPI.DbContexts;
using ProOffice.BookingAPI.Models.Dto;
using System.Text;

namespace ProOffice.BookingAPI.Repository
{
    public class ResourceRepository : IResourceRepository
    {
        private ApplicationDbContext _db;
        private IMapper _mapper;
        private readonly HttpClient _httpClient;

        public ResourceRepository(ApplicationDbContext db, IMapper mapper, HttpClient httpClient)
        {
            _db = db;
            _mapper = mapper;
            _httpClient = httpClient;
        }
        public async Task<ResourceDto> GetResourceDtoById(int id)
        {
            var response = await _httpClient.GetAsync($"api/resources/{id}");

            var apiContent = await response.Content.ReadAsStringAsync();

            var responseDtoObj = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

            if (responseDtoObj.IsRequestSuccessful)
            {
                return JsonConvert.DeserializeObject<ResourceDto>(Convert.ToString(responseDtoObj.Result));
            }

            return new ResourceDto();
        }
        public async Task<bool> UpdateResource(ResourceDto resourceDto)
        {
            try
            {
                var resourceDtoJson = JsonConvert.SerializeObject(resourceDto);

                var content = new StringContent(resourceDtoJson, Encoding.UTF8, "application/json");

                var responseFromApi = await _httpClient.PutAsync($"api/resources", content);

                var apiContent = await responseFromApi.Content.ReadAsStringAsync();

                var responseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }

            return true;
        }
    }
}
