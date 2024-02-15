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
    public class HotelData : IHotelData
    {
        private readonly ILogger<HotelData> _logger;
        private readonly IConfiguration _config;

        public HotelData(ILogger<HotelData> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        private const string HotelAdd = "Hotel_add";
        private const string HotelLst = "Hotel_list";
        private const string HotelEdit = "Hotel_edit";
        private const string HotelEdtitState = "Hotel_edtit_state";
        private const string HotelListReserve = "Hotel_List_Reserve";
        private const string HotelListReserveDetail = "Hotel_List_Reserve_detail";


        public async Task<Response> HotelAddAsync(Hotel vHotelAdd)
        {
            Response vObjRsp = new();
            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(HotelAdd, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = vHotelAdd.Name;
                StoreProc_enc.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = vHotelAdd.Location;
                StoreProc_enc.Parameters.Add("@RoomsNumber", SqlDbType.Int).Value = vHotelAdd.RoomsNumber;
                StoreProc_enc.Parameters.Add("@Phone", SqlDbType.Int).Value = vHotelAdd.Phone;
                StoreProc_enc.Parameters.Add("@State", SqlDbType.Int).Value = vHotelAdd.State;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            vObjRsp.Status = true;
                            vObjRsp.Message = "Hotel " + vHotelAdd.Name + " registrado";
                        }
                        else
                        {
                            vObjRsp.Status = false;
                            vObjRsp.Message = "El registro no se logro guardar";
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

        public async Task<RspHotelList> HotelGetLst()
        {
            RspHotelList vObjHotelLst = new();
            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);

            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(HotelLst, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            HotelList vObjLstHotel = new();
                            vObjLstHotel.IdHotel = reader["IdHotel"] != DBNull.Value ? Convert.ToInt32(reader["IdHotel"].ToString()) : 0;
                            vObjLstHotel.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty;

                            vObjHotelLst.Response.Status = true;
                            vObjHotelLst.Response.Message = "Registros de hotel";

                            vObjHotelLst.HotelList.Add(vObjLstHotel);
                        }
                        else
                        {
                            vObjHotelLst.Response.Status = false;
                            vObjHotelLst.Response.Message = "No existen registros de hotel";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjHotelLst.Response.Status = false;
                vObjHotelLst.Response.Message = "Problemas al buscar el registro " + ex.Message;
                return vObjHotelLst;
            }

            finally
            {
                conn.Close();
            }

            return vObjHotelLst;
        }

        public async Task<Response> HotelEditAsync(Hotel vHotel)
        {
            Response vObjRsp = new();
            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);

            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(HotelEdit, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@IdHotel", SqlDbType.Int).Value = vHotel.Idhotel;
                StoreProc_enc.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = vHotel.Name;
                StoreProc_enc.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = vHotel.Location;
                StoreProc_enc.Parameters.Add("@RoomsNumber", SqlDbType.Int).Value = vHotel.RoomsNumber;
                StoreProc_enc.Parameters.Add("@Phone", SqlDbType.Float).Value = vHotel.Phone;
                StoreProc_enc.Parameters.Add("@State", SqlDbType.Int).Value = vHotel.State;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            vObjRsp.Status = true;
                            vObjRsp.Message = "Se edito el registro";
                        }
                        else
                        {
                            vObjRsp.Status = false;
                            vObjRsp.Message = "El registro no existe";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRsp.Status = false;
                vObjRsp.Message = "Problemas al buscar el registro " + ex.Message;
                return vObjRsp;
            }

            finally
            {
                conn.Close();
            }

            return vObjRsp;
        }

        public async Task<Response> HotelEditStateAsync(int vIdHotel, int vState)
        {
            Response vObjRsp = new();
            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);

            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(HotelEdtitState, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@IdHotel", SqlDbType.Int).Value = vIdHotel;
                StoreProc_enc.Parameters.Add("@state", SqlDbType.VarChar, 50).Value = vState;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            vObjRsp.Status = true;
                            vObjRsp.Message = "Se edito el registro";
                        }
                        else if (Convert.ToInt32(reader["HasErrors"]) == 2)
                        {
                            vObjRsp.Status = false;
                            vObjRsp.Message = "El hotel cuenta con habitaciones ocupadas o reservadas";
                        }
                        else
                        {
                            vObjRsp.Status = false;
                            vObjRsp.Message = "El hotel no esta registrado";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRsp.Status = false;
                vObjRsp.Message = "Problemas al buscar el registro " + ex.Message;
                return vObjRsp;
            }

            finally
            {
                conn.Close();
            }

            return vObjRsp;
        }

        public async Task<RspHotelReserve> HotelReserveLstAsync(int vIdHotel)
        {
            RspHotelReserve vObjRsp = new();
            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);

            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(HotelListReserve, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@IdHotel", SqlDbType.Int).Value = vIdHotel;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            HotelReserveDTO vObjLstReserved = new();
                            vObjLstReserved.IdBedRoom = reader["IdBedRoom"] != DBNull.Value ? Convert.ToInt32(reader["IdBedRoom"].ToString()) : 0;
                            vObjLstReserved.NameHotel = reader["NameHotel"] != DBNull.Value ? reader["NameHotel"].ToString() : string.Empty;
                            vObjLstReserved.NumberRoom = reader["NumberRoom"] != DBNull.Value ? Convert.ToInt32(reader["NumberRoom"].ToString()) : 0;
                            vObjLstReserved.TypeBedrooms = reader["TypeBedrooms"] != DBNull.Value ? reader["TypeBedrooms"].ToString() : string.Empty;
                            vObjLstReserved.State = reader["State"] != DBNull.Value ? reader["State"].ToString() : string.Empty;
                            vObjLstReserved.ReservetionState = reader["ReservetionState"] != DBNull.Value ? reader["ReservetionState"].ToString() : string.Empty;

                            vObjRsp.HotelReserveLst.Add(vObjLstReserved);
                            vObjRsp.Response.Status = true;
                            vObjRsp.Response.Message = "Se lista las habitaciones reservadas";

                        }
                        else
                        {
                            vObjRsp.Response.Status = false;
                            vObjRsp.Response.Message = "No se encontraron reservas para este hotel";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRsp.Response.Status = false;
                vObjRsp.Response.Message = "Problemas al buscar el registro " + ex.Message;
                return vObjRsp;
            }

            finally
            {
                conn.Close();
            }

            return vObjRsp;
        }

        public async Task<RspHotelReserveDetail> HotelReserveDetailLstAsync(int vIdHotel, int vIdBedRoom)
        {
            RspHotelReserveDetail vObjRsp = new();
            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);

            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(HotelListReserveDetail, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@IdHotel", SqlDbType.Int).Value = vIdHotel;
                StoreProc_enc.Parameters.Add("@IdBedRoom", SqlDbType.Int).Value = vIdBedRoom;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            HotelReserveDetailDTO vObjLstReserved = new();
                            vObjLstReserved.IdBedRoom = reader["IdBedRoom"] != DBNull.Value ? Convert.ToInt32(reader["IdBedRoom"].ToString()) : 0;
                            vObjLstReserved.NameHotel = reader["NameHotel"] != DBNull.Value ? reader["NameHotel"].ToString() : string.Empty;
                            vObjLstReserved.NumberRoom = reader["NumberRoom"] != DBNull.Value ? Convert.ToInt32(reader["NumberRoom"].ToString()) : 0;
                            vObjLstReserved.TypeBedrooms = reader["TypeBedrooms"] != DBNull.Value ? reader["TypeBedrooms"].ToString() : string.Empty;
                            vObjLstReserved.State = reader["State"] != DBNull.Value ? reader["State"].ToString() : string.Empty;
                            vObjLstReserved.ReservetionState = reader["ReservetionState"] != DBNull.Value ? reader["ReservetionState"].ToString() : string.Empty;
                            vObjLstReserved.CostBase = reader["CostBase"] != DBNull.Value ? Convert.ToInt32(reader["CostBase"].ToString()) : 0;
                            vObjLstReserved.TaxAmount = reader["TaxAmount"] != DBNull.Value ? Convert.ToInt32(reader["TaxAmount"].ToString()) : 0;
                            vObjLstReserved.CostTotal = reader["CostTotal"] != DBNull.Value ? Convert.ToInt32(reader["CostTotal"].ToString()) : 0;

                            vObjRsp.HotelReserveDetLst.Add(vObjLstReserved);
                            vObjRsp.Response.Status = true;
                            vObjRsp.Response.Message = "Se lista el detalle de la habitacion reservada";

                        }
                        else
                        {
                            vObjRsp.Response.Status = false;
                            vObjRsp.Response.Message = "No se encontraron reservas para este hotel";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRsp.Response.Status = false;
                vObjRsp.Response.Message = "Problemas al buscar el registro " + ex.Message;
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
