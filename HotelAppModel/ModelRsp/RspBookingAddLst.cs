using HotelAppModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppModel.ModelRsp
{
    public class RspBookingAddLst
    {
        public List<BookingAddLstDTO> BookingAddLst { get; set; }
        public Response Response { get; set; }

        public RspBookingAddLst()
        {
            BookingAddLst = new();
            Response = new();
        }
    }
}
