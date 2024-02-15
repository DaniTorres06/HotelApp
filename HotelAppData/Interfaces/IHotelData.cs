using HotelAppModel;
using HotelAppModel.ModelRsp;

namespace HotelAppData.Interfaces
{
    public interface IHotelData
    {
        public Task<Response> HotelAddAsync(Hotel vHotelAdd);
        public Task<RspHotelList> HotelGetLst();
        public Task<Response> HotelEditAsync(Hotel vHotel);
        public Task<Response> HotelEditStateAsync(int vIdHotel, int vState);
        public Task<RspHotelReserve> HotelReserveLstAsync(int vIdHotel);
        public Task<RspHotelReserveDetail> HotelReserveDetailLstAsync(int vIdHotel, int vIdBedRoom);
    }
}