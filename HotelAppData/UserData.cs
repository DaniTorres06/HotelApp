using HotelAppData.Interfaces;
using HotelAppModel;
using HotelAppModel.ModelRsp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace HotelAppData
{
    public class UserData : IUserData
    {
        private readonly ILogger<UserData> _logger;
        private readonly IConfiguration _config;

        public UserData(ILogger<UserData> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        private const string ValidUser = "ValidateUser";


        public async Task<RspValidUser> ValidateUser(string vUser, string vPass)
        {
            RspValidUser vObjValUser = new();
            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);


            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(ValidUser, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;
                StoreProc_enc.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = vUser;
                StoreProc_enc.Parameters.Add("@pass", SqlDbType.VarChar, 50).Value = vPass;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            ValidateUser vObjUser = new();
                            vObjUser.IdUsuario = reader["IdUsuario"] != DBNull.Value ? Convert.ToInt32(reader["IdUsuario"].ToString()) : 0;
                            vObjUser.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty;
                            vObjUser.State = reader["State"] != DBNull.Value ? Convert.ToInt32(reader["State"].ToString()) : 0;
                            vObjUser.TypeRol = reader["TypeRol"] != DBNull.Value ? reader["TypeRol"].ToString() : string.Empty;

                            if (vObjUser.State == 0)
                            {
                                vObjValUser.Response.Status = false;
                                vObjValUser.Response.Message = "El usuario no esta activo";
                                return vObjValUser;
                            }

                            vObjValUser.Response.Status = true;
                            vObjValUser.Response.Message = "Usuario registrado";

                            vObjValUser.Users.Add(vObjUser);
                        }
                        else
                        {
                            vObjValUser.Response.Status = false;
                            vObjValUser.Response.Message = "El usuario no esta registrado";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjValUser.Response.Status = false;
                vObjValUser.Response.Message = "Problemas al buscar el registro " + ex.Message;
                return vObjValUser;
            }

            finally
            {
                conn.Close();
            }

            return vObjValUser;

        }

    }
}
