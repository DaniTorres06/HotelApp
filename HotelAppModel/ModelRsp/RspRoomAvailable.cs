using HotelAppModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppModel.ModelRsp
{
    public class RspRoomAvailable
    {
        public List<RoomLstAvailableDTO> RoomLst { get; set; }
        public Response Response { get; set; }

        public RspRoomAvailable()
        {
            RoomLst = new();
            Response = new();
        }
    }
}
