using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppModel.DTO
{
    public class RoomLstAvailableDTO
    {
        public int IdBedRoom { get; set; }
        public int NumberRoom { get; set; }
        public string? TypeBedrooms { get; set; }
        public string? ReservetionState { get; set; }
        public double CostTotal { get; set; }
        
        public RoomLstAvailableDTO()
        {
            IdBedRoom = 0;
            NumberRoom = 0;
            TypeBedrooms = string.Empty;
            ReservetionState = string.Empty; 
            CostTotal = 0;

        }
    }
}
