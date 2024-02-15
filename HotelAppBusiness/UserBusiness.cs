using HotelAppBusiness.Interfaces;
using HotelAppData.Interfaces;
using HotelAppModel.ModelRsp;
using Microsoft.Extensions.Logging;

namespace HotelAppBusiness
{
    public class UserBusiness : IUserBusiness
    {
        private readonly ILogger<UserBusiness> _logger;
        private readonly IUserData _userData;

        
        public UserBusiness(ILogger<UserBusiness> logger,
                            IUserData userData)
        {
            _logger = logger;
            _userData = userData;
        }

        public async Task<RspValidUser> ValidateUserAsync(string vUser, string vPass)
        {
            RspValidUser vObjRespValidUser = new();

            try
            {
                return await _userData.ValidateUser(vUser,vPass);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjRespValidUser.Response.Status = false;
                vObjRespValidUser.Response.Message = "Problemas en capa de negocio";
                return vObjRespValidUser;
            }
        }
        

    }
}
