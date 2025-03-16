using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models
{
    public class GetHistorialPagoModel
    {
        public  int Id {get; set;}
        public int IdUsuario {get; set;}
        public string Nombre {get;set;}
        public int IdMetodoPago {get; set;}
        public string Titular {get;set;}
        public decimal Monto {get;set;}
        public string FechaPago {get;set;}

    }
    public class InsertHistorialPagoModel
    {
        public int IdUsuario {get; set;}
        public int IdMetodoPago {get; set;}
        public int Monto {get;set;}

    }
    public class UpdateHistorialPagoModel
    {
        public  int Id {get; set;}
        public int IdUsuario {get; set;}
        public int IdMetodoPago {get; set;}
        public int Monto {get;set;}
    }
}