using Microsoft.AspNetCore.Mvc;
using ProOffice.BookingAPI.Models.Dto;
using ProOffice.BookingAPI.Repository;
using ProOffice.BookingAPI.Services;

namespace ProOffice.ResourceAPI.Controllers
{
    [Route("api/book")]
    public class BookingApiController : Controller
    {
        private IBookResourceService _bookResourceService;
        protected ResponseDto _response;

        public BookingApiController(IBookResourceService bookResourceService)
        {
            _bookResourceService = bookResourceService;
            _response = new ResponseDto();
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] BookingDto bookingDto)
        {
            try
            {
                var isBookingSuccessfull = await _bookResourceService.BookResourceAndUpdateResourceQuantity(bookingDto);

                _response.Result = isBookingSuccessfull;
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
