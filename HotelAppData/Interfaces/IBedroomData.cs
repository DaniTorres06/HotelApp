using HotelAppModel;
using HotelAppModel.DTO;
using HotelAppModel.ModelRsp;

namespace HotelAppData.Interfaces
{
    public interface IBedroomData
    {
        public Task<Response> BedroomEditAsync(RoomEditDTO vRoom);
        public Task<RspRoomLstDTO> RoomXHotelAsync(int vIdHotel);
        public Task<RspRoomAvailable> RoomAvailableAsync(int vIdHotel);
    }
}