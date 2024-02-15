using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppModel
{
    public class Hotel
    {
        public int @Idhotel { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int RoomsNumber { get; set; }
        public float Phone { get; set; }
        public int? State { get; set; }

        public Hotel()
        {
            Name = string.Empty;
            Location = string.Empty;
            RoomsNumber = 0;
            Phone = 0;
            State = 0;
        }
    }
}
