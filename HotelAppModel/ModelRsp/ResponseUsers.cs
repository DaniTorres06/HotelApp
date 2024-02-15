namespace HotelAppModel.ModelRsp
{
    public class ResponseUsers
    {
        public List<Users> Users { get; set; }
        public Response Response { get; set; }

        public ResponseUsers()
        {
            Users = new();
            Response = new();
        }
    }
}
