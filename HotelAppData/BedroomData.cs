using HotelAppData.Interfaces;
using HotelAppModel;
using HotelAppModel.DTO;
using HotelAppModel.ModelRsp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace HotelAppData
{
    public class BedroomData : IBedroomData
    {
        private readonly ILogger<BedroomData> _logger;
        private readonly IConfiguration _config;

        public BedroomData(ILogger<BedroomData> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        private const string RoomEdit = "Bedrooms_edit";
        private const string BedroomsListXHotel = "BedroomsListXHotel";
        private const string BedroomsAvailable = "BedroomsLstAvailable";

        public async Task<Response> BedroomEditAsync(RoomEditDTO vRoom)
        {
            Response vObjRsp = new();
            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(RoomEdit, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@IdBedRoom", SqlDbType.Int).Value = vRoom.IdBedRoom;
                StoreProc_enc.Parameters.Add("@NumberRoom", SqlDbType.Int).Value = vRoom.NumberRoom;
                StoreProc_enc.Parameters.Add("@State", SqlDbType.Int).Value = vRoom.State;
                StoreProc_enc.Parameters.Add("@TypeRoom", SqlDbType.Int).Value = vRoom.IdBedRoom;
                StoreProc_enc.Parameters.Add("@ReservetionState", SqlDbType.Int).Value = vRoom.ReservetionState;
                StoreProc_enc.Parameters.Add("@CostBase", SqlDbType.Decimal).Value = vRoom.CostBase;
                


                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            vObjRsp.Status = true;
                            vObjRsp.Message = "Habitacion numero " + vRoom.NumberRoom + " modificada";
                        }
                        else
                        {
                            vObjRsp.Status = false;
                            vObjRsp.Message = "El registro no se logro editar";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRsp.Status = false;
                vObjRsp.Message = "Problemas al editar el registro " + ex.Message;
                return vObjRsp;
            }

            finally
            {
                conn.Close();
            }

            return vObjRsp;
        }

        public async Task<RspRoomLstDTO> RoomXHotelAsync(int vIdHotel)
        {
            RspRoomLstDTO vObjRsp = new();
            
            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(BedroomsListXHotel, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@IdHotel", SqlDbType.Int).Value = vIdHotel;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            RoomLstDTO vObjRoomLst = new();
                            vObjRoomLst.IdBedRoom = reader["IdBedRoom"] != DBNull.Value ? Convert.ToInt32(reader["IdBedRoom"].ToString()) : 0;
                            vObjRoomLst.NumberRoom = reader["NumberRoom"] != DBNull.Value ? Convert.ToInt32(reader["NumberRoom"].ToString()) : 0;
                            vObjRoomLst.State = reader["State"] != DBNull.Value ? reader["State"].ToString() : string.Empty;
                            vObjRoomLst.TypeBedrooms = reader["TypeBedrooms"] != DBNull.Value ? reader["TypeBedrooms"].ToString() : string.Empty;
                            vObjRoomLst.ReservetionState = reader["ReservetionState"] != DBNull.Value ? reader["ReservetionState"].ToString() : string.Empty;
                            vObjRoomLst.CostBase = reader["CostBase"] != DBNull.Value ? Convert.ToDouble(reader["CostBase"].ToString()) : 0;
                            vObjRoomLst.TaxAmount = reader["NumberRoom"] != DBNull.Value ? Convert.ToDouble(reader["NumberRoom"].ToString()) : 0;
                            vObjRoomLst.CostTotal = reader["NumberRoom"] != DBNull.Value ? Convert.ToDouble(reader["NumberRoom"].ToString()) : 0;
                            vObjRoomLst.Location = reader["Location"] != DBNull.Value ? reader["Location"].ToString() : string.Empty;

                            vObjRsp.RoomLst.Add(vObjRoomLst);
                            vObjRsp.Response.Status = true;
                            vObjRsp.Response.Message = "Listado de habitaciones";
                        }
                        else
                        {
                            vObjRsp.Response.Status = false;
                            vObjRsp.Response.Message = "El hotel no esta registrado";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRsp.Response.Status = false;
                vObjRsp.Response.Message = "Problemas al editar el registro " + ex.Message;
                return vObjRsp;
            }

            finally
            {
                conn.Close();
            }
            return vObjRsp;
        }

        public async Task<RspRoomAvailable> RoomAvailableAsync(int vIdHotel)
        {
            RspRoomAvailable vObjRsp = new();

            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(BedroomsAvailable, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@IdHotel", SqlDbType.Int).Value = vIdHotel;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            RoomLstAvailableDTO vObjRoomLst = new();
                            vObjRoomLst.IdBedRoom = reader["IdBedRoom"] != DBNull.Value ? Convert.ToInt32(reader["IdBedRoom"].ToString()) : 0;
                            vObjRoomLst.NumberRoom = reader["NumberRoom"] != DBNull.Value ? Convert.ToInt32(reader["NumberRoom"].ToString()) : 0;                            
                            vObjRoomLst.TypeBedrooms = reader["TypeBedrooms"] != DBNull.Value ? reader["TypeBedrooms"].ToString() : string.Empty;
                            vObjRoomLst.ReservetionState = reader["ReservetionState"] != DBNull.Value ? reader["ReservetionState"].ToString() : string.Empty;                            
                            vObjRoomLst.CostTotal = reader["CostTotal"] != DBNull.Value ? Convert.ToDouble(reader["CostTotal"].ToString()) : 0;                            

                            vObjRsp.RoomLst.Add(vObjRoomLst);
                            vObjRsp.Response.Status = true;
                            vObjRsp.Response.Message = "Listado de habitaciones disponibles";
                        }
                        else
                        {
                            vObjRsp.Response.Status = false;
                            vObjRsp.Response.Message = "El hotel no esta registrado";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRsp.Response.Status = false;
                vObjRsp.Response.Message = "Problemas al editar el registro " + ex.Message;
                return vObjRsp;
            }

            finally
            {
                conn.Close();
            }
            return vObjRsp;
        }
    }
}
