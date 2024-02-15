using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppModel.DTO
{
    public class RoomEditDTO
    {
        public int IdBedRoom { get; set; }
        public int NumberRoom { get; set; }
        public int State { get; set; }
        public int TypeRoom { get; set; }
        public int ReservetionState { get; set; }
        public double CostBase { get; set; }


        public RoomEditDTO()
        {
            IdBedRoom = 0;
            NumberRoom = 0;
            TypeRoom = 0;
            ReservetionState = 0;
            CostBase = 0;
        }
    }
}
