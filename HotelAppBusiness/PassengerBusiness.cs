using HotelAppData.Interfaces;
using HotelAppModel.ModelRsp;
using HotelAppModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelAppModel.DTO;
using HotelAppBusiness.Interfaces;
using System.Net.Mail;
using System.Net;

namespace HotelAppBusiness
{
    public class PassengerBusiness : IPassengerBusiness
    {
        private readonly ILogger<PassengerBusiness> _logger;
        private readonly IPassengerData _data;

        public PassengerBusiness(ILogger<PassengerBusiness> logger,
                            IPassengerData passengerData)
        {
            _logger = logger;
            _data = passengerData;
        }

        public async Task<Response> PassengerAddAsync(PassengerAddDTO vPassengerAdd)
        {
            Response vObjResp = new();

            try
            {
                
                return await _data.PassengerAddAsync(vPassengerAdd);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjResp.Status = false;
                vObjResp.Message = "Problemas en capa de negocio";
                return vObjResp;
            }
        }

        

    }
}
