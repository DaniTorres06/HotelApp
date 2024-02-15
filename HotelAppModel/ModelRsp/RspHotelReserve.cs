using HotelAppModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppModel.ModelRsp
{
    public class RspHotelReserve
    {
        public List<HotelReserveDTO> HotelReserveLst { get; set; }
        public Response Response { get; set; }

        public RspHotelReserve()
        {
            HotelReserveLst = new();
            Response = new();
        }
    }
}
