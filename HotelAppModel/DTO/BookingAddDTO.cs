namespace HotelAppModel.DTO
{
    public class BookingAddDTO
    {
        public int IdPassenger { get; set; }
        public int IdHotel { get; set; }
        public int IdRoom { get; set; }
        public DateTime DateInitial { get; set; }
        public DateTime DateFinal { get; set; }
        public int PaymentForm { get; set; }
        public string? Notas { get; set; }

        public BookingAddDTO()
        {
            IdPassenger = 0;
            IdHotel = 0;
            IdRoom = 0;
            DateInitial = new DateTime();
            DateFinal = new DateTime();
            PaymentForm = 0;
            Notas = string.Empty;
        }
    }
}
