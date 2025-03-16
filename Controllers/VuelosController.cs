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
    public class VuelosController: ControllerBase
    {
   
        private readonly VuelosService _VuelosService;
        private readonly ILogger<VuelosController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public VuelosController(VuelosService vuelosService, ILogger<VuelosController> logger, IJwtAuthenticationService authService) {
            _VuelosService = vuelosService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertVuelos")]
        public IActionResult InsertVuelos([FromBody] InsertVuelosModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _VuelosService.InsertVuelos(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

          [HttpGet("GetVuelosId")]
        public IActionResult GetVuelos()
        {
            var objectResponse = Helper.GetStructResponse();
            var resultado = _VuelosService.GetVuelos();

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

    //   [HttpGet("GetVuelosId")]
    //     public IActionResult GetVuelosId([FromQuery] int IdVuelo)
    //     {
    //         var objectResponse = Helper.GetStructResponse();

    //         try
    //         {
    //             objectResponse.StatusCode = (int)HttpStatusCode.OK;
    //             objectResponse.success = true;
    //             objectResponse.message = "MetodoPago cargados exitosamente";
    //             var resultado = _VuelosService.GetVuelosId(IdVuelo);
               
               

    //             // Llamando a la función y recibiendo los dos valores.
               
    //              objectResponse.response = resultado;
    //         }

    //         catch (System.Exception ex)
    //         {
    //             objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
    //             objectResponse.success = false;
    //             objectResponse.message = ex.Message;
    //         }

    //         return new JsonResult(objectResponse);
    //     }

    

        [HttpPut("UpdateVuelos")]
        public IActionResult UpdateVuelos([FromBody] UpdateVuelosModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _VuelosService.UpdateVuelos(req);

                

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteVuelos/{id}")]
        public IActionResult DeleteVuelos([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _VuelosService.DeleteVuelos(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}