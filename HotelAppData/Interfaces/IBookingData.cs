using HotelAppModel.DTO;
using HotelAppModel.ModelRsp;

namespace HotelAppData.Interfaces
{
    public interface IBookingData
    {
        Task<RspBookingAddLst> BookingAddAsync(BookingAddDTO vBookingAdd);
    }
}