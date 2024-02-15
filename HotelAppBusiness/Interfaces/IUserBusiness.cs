using HotelAppModel.ModelRsp;

namespace HotelAppBusiness.Interfaces
{
    public interface IUserBusiness
    {
        public Task<RspValidUser> ValidateUserAsync(string vUser, string vPass);
    }
}