using HotelAppBusiness.Interfaces;
using HotelAppModel.ModelRsp;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserBusiness _service;

        public UserController(ILogger<UserController> logger, IUserBusiness userBusiness)
        {
            _logger = logger;
            _service = userBusiness;
        }

        
        [HttpPost("ValidateUserAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspValidUser))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspValidUser>> ValidateUserAsync(string vUser, string vPass)
        {
            try
            {
                var response = await _service.ValidateUserAsync(vUser, vPass);
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
