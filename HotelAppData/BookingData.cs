using HotelAppData.Interfaces;
using HotelAppModel.DTO;
using HotelAppModel.ModelRsp;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HotelAppData
{
    public class BookingData : IBookingData
    {
        private readonly ILogger<BookingData> _logger;
        private readonly IConfiguration _config;

        public BookingData(ILogger<BookingData> logger,
                            IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        private const string BookingAdd = "Booking_add";

        public async Task<RspBookingAddLst> BookingAddAsync(BookingAddDTO vBookingAdd)
        {
            RspBookingAddLst vObjRsp = new();
            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(BookingAdd, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@IdPassenger", SqlDbType.Int).Value = vBookingAdd.IdPassenger;
                StoreProc_enc.Parameters.Add("@IdHotel", SqlDbType.Int).Value = vBookingAdd.IdHotel;
                StoreProc_enc.Parameters.Add("@IdRoom", SqlDbType.Int).Value = vBookingAdd.IdRoom;
                StoreProc_enc.Parameters.Add("@DateInitial", SqlDbType.Date).Value = vBookingAdd.DateInitial;
                StoreProc_enc.Parameters.Add("@DateFinal", SqlDbType.Date).Value = vBookingAdd.DateFinal;                
                StoreProc_enc.Parameters.Add("@PaymentForm", SqlDbType.Int).Value = vBookingAdd.PaymentForm;
                StoreProc_enc.Parameters.Add("@Notas", SqlDbType.VarChar, 200).Value = vBookingAdd.Notas;


                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            BookingAddLstDTO vObjLstBooking = new();
                            vObjLstBooking.IdPassenger = reader["IdPassenger"] != DBNull.Value ? Convert.ToInt32(reader["IdPassenger"].ToString()) : 0;
                            vObjLstBooking.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty;
                            vObjLstBooking.NumberRoom = reader["NumberRoom"] != DBNull.Value ? Convert.ToInt32(reader["NumberRoom"].ToString()) : 0;
                            vObjLstBooking.DateInitial = reader["DateInitial"] != DBNull.Value ? Convert.ToDateTime(reader["DateInitial"].ToString()) : DateTime.Now;
                            vObjLstBooking.DateFinal = reader["DateFinal"] != DBNull.Value ? Convert.ToDateTime(reader["DateFinal"].ToString()) : DateTime.Now;
                            vObjLstBooking.ReservetionState = reader["ReservetionState"] != DBNull.Value ? reader["ReservetionState"].ToString() : string.Empty;
                            vObjLstBooking.CostTotal = reader["CostTotal"] != DBNull.Value ? Convert.ToDecimal(reader["CostTotal"].ToString()) : 0;
                            vObjLstBooking.PaymentForm = reader["PaymentForm"] != DBNull.Value ? reader["PaymentForm"].ToString() : string.Empty;
                            vObjLstBooking.Notas = reader["Notas"] != DBNull.Value ? reader["Notas"].ToString() : string.Empty;

                            vObjRsp.BookingAddLst.Add(vObjLstBooking);
                            vObjRsp.Response.Status = true;
                            vObjRsp.Response.Message = "La reserva se creo con exito";
                        }
                        else
                        {
                            vObjRsp.Response.Status = false;
                            vObjRsp.Response.Message = "El registro no se logro guardar";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRsp.Response.Status = false;
                vObjRsp.Response.Message = "Problemas al crear el registro " + ex.Message;
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
