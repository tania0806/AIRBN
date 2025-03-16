using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models
{
    public class GetMetodoPagoModel
    {
        public int IdMetodoPago {get; set;}
        public int IdUsuario {get; set;}
        public string Tipo {get;set;}
        public string NumeroTarjeta {get;set;}
        public string FechaVencimiento {get;set;}
        public string CodigoSeguridad {get; set;}
        public string Titular {get;set;}
        public int Estado {get; set;}
 

    }
    public class InsertMetodoPagoModel
    {
        public int IdUsuario {get; set;}
        public string Tipo {get;set;}
        public string NumeroTarjeta {get;set;}
        public string FechaVencimiento {get;set;}
        public string CodigoSeguridad {get; set;}
        public string Titular {get;set;}

    }
    public class UpdateMetodoPagoModel
    {
        public  int IdMetodoPago {get; set;}
        public int IdUsuario {get; set;}
        public string Tipo {get;set;}
        public string NumeroTarjeta {get;set;}
        public string FechaVencimiento {get;set;}
        public string CodigoSeguridad {get; set;}
        public string Titular {get;set;}
    }
}