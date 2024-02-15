using HotelAppModel;
using HotelAppModel.DTO;
using HotelAppModel.ModelRsp;

namespace HotelAppBusiness.Interfaces
{
    public interface IBedroomBusiness
    {
        public Task<Response> BedroomEditAsync(RoomEditDTO vRoom);
        public Task<RspRoomLstDTO> RoomXHotelAsync(int vIdHotel);
        public Task<RspRoomAvailable> RoomAvailableAsync(int vIdHotel);
    }
}