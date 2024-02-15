using HotelAppData.Interfaces;
using HotelAppModel.DTO;
using HotelAppModel.ModelRsp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace HotelAppData
{
    public class PassengerData : IPassengerData
    {
        private readonly ILogger<PassengerData> _logger;
        private readonly IConfiguration _config;

        public PassengerData(ILogger<PassengerData> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        private const string PassengerAdd = "Passenger_add";

        public async Task<Response> PassengerAddAsync(PassengerAddDTO vPassengerAdd)
        {
            Response vObjRsp = new();
            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(PassengerAdd, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = vPassengerAdd.Name;
                StoreProc_enc.Parameters.Add("@Birthdate", SqlDbType.Date).Value = vPassengerAdd.Birthdate;
                StoreProc_enc.Parameters.Add("@Genero", SqlDbType.Int).Value = vPassengerAdd.Genero;
                StoreProc_enc.Parameters.Add("@DocumentType", SqlDbType.Int).Value = vPassengerAdd.DocumentType;
                StoreProc_enc.Parameters.Add("@DocumentNumber", SqlDbType.Int).Value = vPassengerAdd.DocumentNumber;
                StoreProc_enc.Parameters.Add("@Email", SqlDbType.VarChar, 150).Value = vPassengerAdd.Email;
                StoreProc_enc.Parameters.Add("@phone", SqlDbType.Int).Value = vPassengerAdd.Phone;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            vObjRsp.Status = true;
                            vObjRsp.Message = "Pasajero " + vPassengerAdd.Name + " registrado";
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


    }
}
