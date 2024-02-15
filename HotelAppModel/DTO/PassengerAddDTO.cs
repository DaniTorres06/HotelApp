using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppModel.DTO
{
    public class PassengerAddDTO
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public int Genero {  get; set; }
        public int DocumentType { get; set; }
        public int DocumentNumber { get; set; }
        public string? Email { get; set; }
        public Int64 Phone { get; set; }

        public PassengerAddDTO()
        {
            Name = string.Empty;
            Birthdate = new DateTime();
            Genero = 0;
            DocumentType = 0;
            DocumentNumber = 0;
            Email = string.Empty;
            Phone = 0;
        }

    }
}
