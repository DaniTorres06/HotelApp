using HotelAppBusiness.Interfaces;
using HotelAppData.Interfaces;
using HotelAppModel;
using HotelAppModel.ModelRsp;
using Microsoft.Extensions.Logging;

namespace HotelAppBusiness
{
    public class HotelBusiness : IHotelBusiness
    {
        private readonly ILogger<HotelBusiness> _logger;
        private readonly IHotelData _hotelData;

        public HotelBusiness(ILogger<HotelBusiness> logger,
                            IHotelData hotelData)
        {
            _logger = logger;
            _hotelData = hotelData;
        }

        public async Task<Response> HotelAddAsync(Hotel vHotelAdd)
        {
            Response vObjResp = new();

            try
            {
                return await _hotelData.HotelAddAsync(vHotelAdd);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjResp.Status = false;
                vObjResp.Message = "Problemas en capa de negocio";
                return vObjResp;
            }
        }

        public async Task<RspHotelList> HotelGetLst()
        {
            RspHotelList vObjList = new();

            try
            {
                return await _hotelData.HotelGetLst();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjList.Response.Status = false;
                vObjList.Response.Message = "Problemas en capa de negocio";
                return vObjList;
            }
        }

        public async Task<Response> HotelEditAsync(Hotel vHotel)
        {
            Response vObjResp = new();

            try
            {
                return await _hotelData.HotelEditAsync(vHotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjResp.Status = false;
                vObjResp.Message = "Problemas en capa de negocio";
                return vObjResp;
            }
        }

        public async Task<Response> HotelEditStateAsync(int vIdHotel, int vState)
        {
            Response vObjResp = new();

            try
            {
                return await _hotelData.HotelEditStateAsync(vIdHotel, vState);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjResp.Status = false;
                vObjResp.Message = "Problemas en capa de negocio";
                return vObjResp;
            }
        }

        public async Task<RspHotelReserve> HotelReserveLstAsync(int vIdHotel)
        {
            RspHotelReserve vObjResp = new();

            try
            {
                return await _hotelData.HotelReserveLstAsync(vIdHotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjResp.Response.Status = false;
                vObjResp.Response.Message = "Problemas en capa de negocio";
                return vObjResp;
            }
        }

        public async Task<RspHotelReserveDetail> HotelReserveDetailLstAsync(int vIdHotel, int vIdBedRoom)
        {
            RspHotelReserveDetail vObjResp = new();

            try
            {
                return await _hotelData.HotelReserveDetailLstAsync(vIdHotel, vIdBedRoom);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjResp.Response.Status = false;
                vObjResp.Response.Message = "Problemas en capa de negocio";
                return vObjResp;
            }
        }


    }
}
