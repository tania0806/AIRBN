using System;
namespace Airbnb.Models
{
    public class GetUsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string FotoPerfil { get; set; }        
        public string MetodoAutenticacion { get; set; }
        public string Contraseña { get; set; }
        public string FechaRegistro { get; set; }
    }
    public class InsertUsuarioModel
    {

        public string Nombre { get; set; }
        public string Email { get; set; }
        public string FotoPerfil { get; set; }        
        public string MetodoAutenticacion { get; set; }
        public string Contraseña { get; set; }
    
    }
    public class UpdateUsuarioModel
    {
      public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string FotoPerfil { get; set; }        
        public string MetodoAutenticacion { get; set; }
        public string Contraseña { get; set; }
    }
}
