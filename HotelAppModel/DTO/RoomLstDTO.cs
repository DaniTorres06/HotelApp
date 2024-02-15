using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppModel.DTO
{
    public class RoomLstDTO
    {
        public int IdBedRoom { get; set; }
        public int NumberRoom { get; set; }
        public string? State { get; set; }
        public string? TypeBedrooms { get; set; }
        public string? ReservetionState { get; set; }
        public double CostBase { get; set; }
        public double TaxAmount { get; set; }
        public double CostTotal { get; set; }
        public string? Location { get; set; }

        public RoomLstDTO()
        {
            IdBedRoom = 0;
            NumberRoom = 0;
            State = string.Empty;
            TypeBedrooms = string.Empty;
            TaxAmount = 0;
            CostTotal = 0;
            Location = string.Empty;
        }
    }
}
