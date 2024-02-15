using HotelAppBusiness.Interfaces;
using HotelAppData.Interfaces;
using HotelAppModel.DTO;
using HotelAppModel.ModelRsp;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppBusiness
{
    public class BookingBusiness : IBookingBusiness
    {
        private readonly ILogger<BookingBusiness> _logger;
        private readonly IBookingData _data;

        public BookingBusiness(ILogger<BookingBusiness> logger,
                            IBookingData bookingData)
        {
            _logger = logger;
            _data = bookingData;
        }

        public async Task<RspBookingAddLst> BookingAddAsync(BookingAddDTO vBookingAdd)
        {
            RspBookingAddLst vObjResp = new();

            try
            {
                vObjResp = await _data.BookingAddAsync(vBookingAdd);
                if(vObjResp.BookingAddLst.Count > 0) 
                {
                    
                    foreach (BookingAddLstDTO vObjBookLstData in vObjResp.BookingAddLst)
                    {
                        BookingAddLstDTO vObjBookLst = new();
                        vObjBookLst.Name = vObjBookLstData.Name;
                        vObjBookLst.NumberRoom = vObjBookLstData.NumberRoom;
                        vObjBookLst.DateInitial = vObjBookLstData.DateInitial;
                        vObjBookLst.DateFinal = vObjBookLstData.DateFinal;
                        vObjBookLst.CostTotal = vObjBookLstData.CostTotal;
                        vObjBookLst.PaymentForm = vObjBookLstData.PaymentForm;
                        SendEmail(vObjBookLst);
                    }
                }

                return vObjResp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjResp.Response.Status = false;
                vObjResp.Response.Message = "Problemas en capa de negocio";
                return vObjResp;
            }
        }

        private void SendEmail(BookingAddLstDTO vBookingAddLst)
        {
            string remitente = "danny_544@hotmail.com";            
            string contraseña = "";

            
            string destinatario = "einer.torres@hotmail.com";            
            string asunto = "Confirmacionde reserva de hotel App";            
            string cuerpo = "Se acaba de realizar una reserva en el hotel " + vBookingAddLst.Name + " numero de habitacion " + vBookingAddLst.NumberRoom +
                " desde el " + vBookingAddLst.DateInitial + " hasta el " + vBookingAddLst.DateFinal + " por un total de " + vBookingAddLst.CostTotal+
                " por el medio de pago " + vBookingAddLst.PaymentForm + " por favor tener en cuenta la fecha de la reserva.";

            MailMessage correo = new MailMessage(remitente, destinatario, asunto, cuerpo);
            SmtpClient clienteSmtp = new SmtpClient("smtp.office365.com");
            clienteSmtp.Port = 587;
            clienteSmtp.EnableSsl = true;
            clienteSmtp.Credentials = new NetworkCredential(remitente, contraseña);

            try
            {
                // Enviar el correo electrónico
                clienteSmtp.Send(correo);
                Console.WriteLine("Correo electrónico enviado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo electrónico: " + ex.Message);
            }
        }
    }
}
