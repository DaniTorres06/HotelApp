using HotelAppModel.DTO;
using HotelAppModel.ModelRsp;

namespace HotelAppBusiness.Interfaces
{
    public interface IPassengerBusiness
    {
        Task<Response> PassengerAddAsync(PassengerAddDTO vPassengerAdd);
    }
}