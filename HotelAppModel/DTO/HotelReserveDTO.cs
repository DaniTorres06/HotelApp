using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppModel.DTO
{
    public class HotelReserveDTO
    {
        public int IdBedRoom { get; set; }
        public string? NameHotel { get; set; }
        public int NumberRoom { get; set; }
        public string? TypeBedrooms { get; set; }
        public string? State { get; set; }
        public string? ReservetionState { get; set; }

        public HotelReserveDTO()
        {
            IdBedRoom = 0;
            NameHotel = string.Empty;
            NumberRoom = 0;
            TypeBedrooms = string.Empty;
            ReservetionState = string.Empty;
        }
    }
}
