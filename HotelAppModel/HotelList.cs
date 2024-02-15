using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppModel
{
    public class HotelList
    {
        public int IdHotel { get; set; }
        public string? Name { get; set; }

        public HotelList()
        {
            IdHotel = 0;
            Name = string.Empty;
        }
    }
}
