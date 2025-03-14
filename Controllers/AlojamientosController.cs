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
    public class AlojamientosController: ControllerBase
    {
   
        private readonly AlojamientosService _AlojamientosService;
        private readonly ILogger<AlojamientosController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public AlojamientosController(AlojamientosService alojamientosService, ILogger<AlojamientosController> logger, IJwtAuthenticationService authService) {
            _AlojamientosService = alojamientosService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertAlojamiento")]
        public IActionResult InsertAlojamiento([FromBody] InsertAlojamientosModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _AlojamientosService.InsertAlojamientos(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetAlojamiento")]
        public IActionResult GetAlojamiento()
        {
            var objectResponse = Helper.GetStructResponse();
            var resultado = _AlojamientosService.GetAlojamientos();

            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";
                
                 objectResponse.response = resultado;
            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

    

        [HttpPut("UpdateAlojamiento")]
        public IActionResult UpdateAlojamiento([FromBody] UpdateAlojamientosModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _AlojamientosService.UpdateAlojameintos(req);

                

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteAlojamiento/{id}")]
        public IActionResult DeleteAlojamiento([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _AlojamientosService.DeleteAlojamientos(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}