namespace HotelAppModel.ModelRsp
{
    public class RspHotelList
    {
        public List<HotelList> HotelList { get; set; }
        public Response Response { get; set; }

        public RspHotelList()
        {
            HotelList = new();
            Response = new();
        }
    }
}
