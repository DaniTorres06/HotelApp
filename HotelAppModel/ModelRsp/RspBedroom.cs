using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppModel.ModelRsp
{
    public class RspBedroom
    {
        public List<Room> BedroomLst { get; set; }
        public Response Response { get; set; }

        public RspBedroom()
        {
            BedroomLst = new();
            Response = new();
        }
    }
}
