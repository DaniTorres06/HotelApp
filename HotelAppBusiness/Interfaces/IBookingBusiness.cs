using HotelAppModel.DTO;
using HotelAppModel.ModelRsp;

namespace HotelAppBusiness.Interfaces
{
    public interface IBookingBusiness
    {
        Task<RspBookingAddLst> BookingAddAsync(BookingAddDTO vBookingAdd);
    }
}