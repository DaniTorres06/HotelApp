using HotelAppModel.DTO;
using HotelAppModel.ModelRsp;

namespace HotelAppData.Interfaces
{
    public interface IPassengerData
    {
        Task<Response> PassengerAddAsync(PassengerAddDTO vPassengerAdd);
    }
}