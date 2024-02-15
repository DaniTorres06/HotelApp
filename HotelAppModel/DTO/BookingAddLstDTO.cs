namespace HotelAppModel.DTO
{
    public class BookingAddLstDTO
    {
        public int IdPassenger { get; set; }
        public string? Name { get; set; }
        public int NumberRoom { get; set; }
        public DateTime DateInitial { get; set; }
        public DateTime DateFinal { get; set; }
        public string? ReservetionState { get; set; }
        public decimal CostTotal { get; set; }
        public string? PaymentForm { get; set; }
        public string? Notas { get; set; }

        public BookingAddLstDTO()
        {
            IdPassenger = 0;
            Name = string.Empty;
            NumberRoom = 0;
            DateInitial = DateTime.MinValue;
            DateFinal = DateTime.MaxValue;
            ReservetionState = string.Empty;
            CostTotal = 0;
            PaymentForm = string.Empty;
            Notas = string.Empty;

        }

    }
}
