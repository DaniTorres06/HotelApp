using HotelAppModel.DTO;

namespace HotelAppModel.ModelRsp
{
    public class RspHotelReserveDetail
    {
        public List<HotelReserveDetailDTO> HotelReserveDetLst { get; set; }
        public Response Response { get; set; }

        public RspHotelReserveDetail()
        {
            HotelReserveDetLst = new();
            Response = new();
        }
    }
}
