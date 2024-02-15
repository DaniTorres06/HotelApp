using HotelAppModel.ModelRsp;

namespace HotelAppData.Interfaces
{
    public interface IUserData
    {
        public Task<RspValidUser> ValidateUser(string vUser, string vPass);
    }
}