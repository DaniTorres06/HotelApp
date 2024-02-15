using HotelAppBusiness.Interfaces;
using HotelAppModel.DTO;
using HotelAppModel.ModelRsp;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingBusiness _service;

        public BookingController(ILogger<BookingController> logger, IBookingBusiness bookingBusiness)
        {
            _logger = logger;
            _service = bookingBusiness;
        }


        [HttpPost("BookingAddAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspBookingAddLst))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspBookingAddLst>> BookingAddAsync([FromBody] BookingAddDTO vBookingAdd)
        {
            try
            {
                var response = await _service.BookingAddAsync(vBookingAdd);
                if (response is null)
                    return BadRequest();
                if (!response.Response.Status)
                    return BadRequest(response);
                else
                    return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }
    }
}
