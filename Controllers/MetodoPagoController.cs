using System;
using Microsoft.AspNetCore.Mvc;
using Airbnb.Services;
using Airbnb.Utilities;
using Microsoft.AspNetCore.Authorization;
using Airbnb.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using reportesApi.Helpers;
using Newtonsoft.Json;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.AspNetCore.Hosting;

namespace Airbnb.Controllers
{
   
    [Route("api")]
    public class MetodoPagoController: ControllerBase
    {
   
        private readonly MetodoPagoService _MetodoPagoService;
        private readonly ILogger<MetodoPagoController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public MetodoPagoController(MetodoPagoService metodoPagoService, ILogger<MetodoPagoController> logger, IJwtAuthenticationService authService) {
            _MetodoPagoService = metodoPagoService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertMetodoPago")]
        public IActionResult InsertMetodoPago([FromBody] InsertMetodoPagoModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _MetodoPagoService.InsertMetodoPago(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

      [HttpGet("GetMetodoPago")]
        public IActionResult GetMetodoPago([FromQuery] int IdUsuario)
        {
            var objectResponse = Helper.GetStructResponse();

            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "MetodoPago cargados exitosamente";
                var resultado = _MetodoPagoService.GetMetodoPagoId(IdUsuario);
               
               

                // Llamando a la función y recibiendo los dos valores.
               
                 objectResponse.response = resultado;
            }

            catch (System.Exception ex)
            {
                objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

    

        [HttpPut("UpdateMetodoPago")]
        public IActionResult UpdateMetodoPago([FromBody] UpdateMetodoPagoModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _MetodoPagoService.UpdateMetodoPago(req);

                

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteMetodoPago/{id}")]
        public IActionResult DeleteMetodoPago([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _MetodoPagoService.DeleteMetodoPago(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}