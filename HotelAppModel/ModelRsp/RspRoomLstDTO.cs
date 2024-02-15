using HotelAppModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppModel.ModelRsp
{
    public class RspRoomLstDTO
    {
        public List<RoomLstDTO> RoomLst { get; set; }
        public Response Response { get; set; }

        public RspRoomLstDTO()
        {
            RoomLst = new();
            Response = new();
        }
    }
}
