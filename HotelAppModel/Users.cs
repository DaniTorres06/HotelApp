using System.Xml.Linq;

namespace HotelAppModel
{
    public class Users
    {
        public int IdUsuario { get; set; }
        public string? UserDesc { get; set; }
        public string? Pass { get; set;}
        public string? Name { get; set; }
        public int IdRol { get; set; }
        public int State { get; set; }

        public Users()
        {
            IdUsuario = 0;
            UserDesc = string.Empty;
            Pass = string.Empty;
            Name = string.Empty;
            IdRol = 0;
            State = 0;
        }
        

    }
}
