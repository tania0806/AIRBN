using System;


public class ResponseLogin
{
    public int StatusCode { get; set; }
    public bool Success { get; set; }
    public bool Error { get; set; }
    public string Message { get; set; }
    public ResponseBody Response { get; set; }


}

public class ResponseBody
{
    public DataResponseLogin data { get; set; }
}

public class DataResponseLogin
{
  
    public bool Status { get; set; }
    public string Mensaje { get; set; }
    public string Token { get; set; }
    public UsuarioModel Usuario { get; set; }

}

public class UserModel
{
    public int Id {get; set; }
    public string Nombre { get; set;}
    public string User { get; set;}
    public string Email { get; set; }
    public string MetodoAutenticacion {get; set;}
    public string Contraseña {get; set;}
    public string Pwd { get; set; }
}

public class UsuarioModel
    {
       
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string FotoPerfil { get; set; }        
        public string MetodoAutenticacion { get; set; }
        public string Contraseña { get; set; }
        public string FechaRegistro { get; set; }
    }