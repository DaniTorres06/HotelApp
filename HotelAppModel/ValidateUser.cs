namespace HotelAppModel
{
    public class ValidateUser
    {
        public int IdUsuario { get; set; }
        public string? Name { get; set; }
        public int State { get; set; }
        public string? TypeRol { get; set; }

        public ValidateUser()
        {
            IdUsuario = 0;
            Name = string.Empty;
            State = 0;
            TypeRol = string.Empty;
        }
    }
}
