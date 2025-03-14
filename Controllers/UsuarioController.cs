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
    public class UsuarioController: ControllerBase
    {
   
        private readonly UsuarioService _UsuarioService;
        private readonly ILogger<UsuarioController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public UsuarioController(UsuarioService UsuarioService, ILogger<UsuarioController> logger, IJwtAuthenticationService authService) {
            _UsuarioService = UsuarioService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertUsuario")]
        public IActionResult InsertUsuario([FromBody] InsertUsuarioModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _UsuarioService.InsertUsuario(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetUsuario")]
        public IActionResult GetUsuario()
        {
            var objectResponse = Helper.GetStructResponse();
            var resultado = _UsuarioService.GetUsuarios();

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

    

        [HttpPut("UpdateUsuario")]
        public IActionResult UpdateUsuario([FromBody] UpdateUsuarioModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _UsuarioService.UpdateUsuarios(req);

                

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteUsuario/{id}")]
        public IActionResult DeleteUsuario([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _UsuarioService.DeleteUsuario(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}