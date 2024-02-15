using HotelAppBusiness.Interfaces;
using HotelAppModel;
using HotelAppModel.ModelRsp;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers
{
    public class HotelController : Controller
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IHotelBusiness _service;

        public HotelController(ILogger<HotelController> logger, IHotelBusiness hotelBusiness)
        {
            _logger = logger;
            _service = hotelBusiness;
        }

        [HttpPost("HotelAddAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response>> HotelAddAsync([FromBody] Hotel vHotelAdd)
        {
            try
            {
                var response = await _service.HotelAddAsync(vHotelAdd);

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

        [HttpGet("HotelGetLst")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspHotelList))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspHotelList>> HotelGetLst()
        {
            try
            {
                var response = await _service.HotelGetLst();

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

        [HttpPut("HotelEditAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response>> HotelEditAsync([FromBody] Hotel vHotel)
        {
            try
            {
                var response = await _service.HotelEditAsync(vHotel);

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

        [HttpPost("HotelEditStateAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response>> HotelEditStateAsync(int vIdHotel, int vState)
        {
            try
            {
                var response = await _service.HotelEditStateAsync(vIdHotel, vState);

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

        [HttpGet("HotelReserveLstAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspHotelReserve))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspHotelReserve>> HotelReserveLstAsync(int vIdHotel)
        {
            try
            {
                var response = await _service.HotelReserveLstAsync(vIdHotel);

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

        [HttpGet("HotelReserveDetailLstAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspHotelReserveDetail))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspHotelReserveDetail>> HotelReserveDetailLstAsync(int vIdHotel, int vIdBedRoom)
        {
            try
            {
                var response = await _service.HotelReserveDetailLstAsync(vIdHotel,vIdBedRoom);

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
