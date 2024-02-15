using HotelAppBusiness.Interfaces;
using HotelAppModel.DTO;
using HotelAppModel.ModelRsp;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers
{
    public class PassengerController : Controller
    {
        private readonly ILogger<PassengerController> _logger;
        private readonly IPassengerBusiness _service;

        public PassengerController(ILogger<PassengerController> logger, IPassengerBusiness passengerBusiness)
        {
            _logger = logger;
            _service = passengerBusiness;
        }


        [HttpPost("PassengerAddAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response>> PassengerAddAsync([FromBody] PassengerAddDTO vPassengerAdd)
        {
            try
            {
                var response = await _service.PassengerAddAsync(vPassengerAdd);
                if (response is null)
                    return BadRequest();
                if (!response.Status)
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
