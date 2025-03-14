using System;
using Microsoft.AspNetCore.Mvc;
using Airbnb.Services;
using Airbnb.Utilities;
using Microsoft.AspNetCore.Authorization;
using Airbnb.Models;
using Microsoft.Extensions.Logging;
using System.Net;


namespace Airbnb.Controllers
{
   
    [Route("api")]
    public class LoginController: ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly ILogger<LoginController> _logger;
  
        private readonly IJwtAuthenticationService _authService;


        Encrypt enc = new Encrypt();

        public LoginController(LoginService loginservice, ILogger<LoginController> logger, IJwtAuthenticationService authService) {
            _loginService = loginservice;
            _logger = logger;
       
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public JsonResult SignIn([FromBody] AuthInfo user)
        {
            ResponseLogin result = new ResponseLogin();
            result.Response = new ResponseBody();
            result.Response.data = new DataResponseLogin();
            result.Response.data.Usuario = new UsuarioModel();
          
                string cryptedPass = enc.GetSHA256(user.Userpassword);
           
            var loginResponse = _loginService.Login(user.Username, user.Userpassword);

         
           
                if (loginResponse.IdUsuario != 0)
                {
                    result.StatusCode = (int)HttpStatusCode.OK;
                    result.Error = false;
                    result.Success = true;
                    result.Message = "Bienvenido";
                    result.Response.data.Usuario = loginResponse;
                    result.Response.data.Status = true;
                    result.Response.data.Mensaje = "Bienvenido";
                    var token = _authService.Authenticate(user.Username, cryptedPass);
                    result.Response.data.Token = token;
                }
                else
                {
                    result.Error = true;
                    result.Success = false;
                    result.Message = "Usuario o contraseña incorrecto,";

                }

            
           
          
           
            
            return new JsonResult(result);

        }

    }
}