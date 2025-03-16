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
    public class FavoritosController: ControllerBase
    {
   
        private readonly FavoritosService _FavoritosService;
        private readonly ILogger<FavoritosController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public FavoritosController(FavoritosService FavoritosService, ILogger<FavoritosController> logger, IJwtAuthenticationService authService) {
            _FavoritosService = FavoritosService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertFavorito")]
        public IActionResult InsertFavoritos([FromBody] InsertFavoritosModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _FavoritosService.InsertFavoritos(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

      [HttpGet("GetFavoritos")]
        public IActionResult GetFavoritos([FromQuery] int IdUsuario)
        {
            var objectResponse = Helper.GetStructResponse();

            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Favoritos cargados exitosamente";
                var resultado = _FavoritosService.GetFavorioId(IdUsuario);
               
               

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

    

        // [HttpPut("UpdateDestino")]
        // public IActionResult UpdateDestino([FromBody] UpdateDestinoModel req )
        // {
        //     var objectResponse = Helper.GetStructResponse();
        //     try
        //     {
        //         objectResponse.StatusCode = (int)HttpStatusCode.OK;
        //         objectResponse.success = true;
        //         objectResponse.message = _DestinoService.UpdateDestino(req);

                

        //     }

        //     catch (System.Exception ex)
        //     {
        //         objectResponse.message = ex.Message;
        //     }

        //     return new JsonResult(objectResponse);
        // }

        [HttpDelete("DeleteFavoritos/{id}")]
        public IActionResult DeleteFavoritos([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _FavoritosService.DeleteFavorito(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}