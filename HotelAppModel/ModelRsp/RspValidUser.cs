using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppModel.ModelRsp
{
    public class RspValidUser
    {
        public List<ValidateUser> Users { get; set; }
        public Response Response { get; set; }

        public RspValidUser()
        {
            Users = new();
            Response = new();
        }
    }
}
