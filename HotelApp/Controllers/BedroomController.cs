using HotelAppBusiness;
using HotelAppBusiness.Interfaces;
using HotelAppModel.ModelRsp;
using HotelAppModel;
using Microsoft.AspNetCore.Mvc;
using HotelAppModel.DTO;

namespace HotelApp.Controllers
{
    public class BedroomController : Controller
    {
        private readonly ILogger<BedroomController> _logger;
        private readonly IBedroomBusiness _service;

        public BedroomController(ILogger<BedroomController> logger, IBedroomBusiness bedroomBusiness)
        {
            _logger = logger;
            _service = bedroomBusiness;
        }

        [HttpPut("BedroomEditAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response>> BedroomEditAsync([FromBody] RoomEditDTO vRoom)
        {
            try
            {
                var response = await _service.BedroomEditAsync(vRoom);

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

        [HttpGet("RoomXHotelAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspRoomLstDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspRoomLstDTO>> RoomXHotelAsync(int vIdHotel)
        {
            try
            {
                var response = await _service.RoomXHotelAsync(vIdHotel);

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

        [HttpGet("RoomAvailableAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspRoomAvailable))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspRoomAvailable>> RoomAvailableAsync( int vIdHotel)
        {
            try
            {
                var response = await _service.RoomAvailableAsync(vIdHotel);

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
