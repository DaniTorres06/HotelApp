using HotelAppData.Interfaces;
using HotelAppModel.ModelRsp;
using HotelAppModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelAppBusiness.Interfaces;
using HotelAppModel.DTO;

namespace HotelAppBusiness
{
    public class BedroomBusiness : IBedroomBusiness
    {
        private readonly ILogger<BedroomBusiness> _logger;
        private readonly IBedroomData _data;

        public BedroomBusiness(ILogger<BedroomBusiness> logger, IBedroomData bedroomData)
        {
            _logger = logger;
            _data = bedroomData;
        }

        public async Task<Response> BedroomEditAsync(RoomEditDTO vRoom)
        {
            Response vObjRsp = new();
            try
            {
                return await _data.BedroomEditAsync(vRoom);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjRsp.Status = false;
                vObjRsp.Message = "Problemas en capa de negocio";
                return vObjRsp;
            }
        }

        public async Task<RspRoomLstDTO> RoomXHotelAsync(int vIdHotel)
        {
            RspRoomLstDTO vObjRsp = new();
            try
            {
                return await _data.RoomXHotelAsync(vIdHotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjRsp.Response.Status = false;
                vObjRsp.Response.Message = "Problemas en capa de negocio";
                return vObjRsp;
            }
        }
        public async Task<RspRoomAvailable> RoomAvailableAsync(int vIdHotel)
        {
            RspRoomAvailable vObjRsp = new();
            try
            {
                return await _data.RoomAvailableAsync(vIdHotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjRsp.Response.Status = false;
                vObjRsp.Response.Message = "Problemas en capa de negocio";
                return vObjRsp;
            }
        }

    }
}
