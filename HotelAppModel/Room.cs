namespace HotelAppModel
{
    public class Room
    {
        public int IdBedRoom { get; set; }
        public int NumberRoom { get; set; }
        public int State { get; set; }
        public int TypeRoom { get; set; }
        public int ReservetionState { get; set; }
        public double CostBase { get; set; }
        public double CostTotal { get; set; }
        public string? Location { get; set; }
        public double TaxAmount { get; set; }
        public int IdHotel { get; set; }


        public Room()
        {
            IdBedRoom = 0;
            NumberRoom = 0;
            TypeRoom = 0;
            ReservetionState = 0;
            CostBase = 0;
            CostTotal = 0;
            Location = string.Empty;
            TaxAmount = 0;
            IdHotel = 0;            
        }
    }
}
