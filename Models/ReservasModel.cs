using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models
{
    public class GetReservasModel
    {
        public int IdReserva {get; set;}
        public int IdUsuario {get; set;}
        public int IdDestino {get; set;}
        public int IdAlojamiento {get; set;}
        public int IdVuelo {get; set;}
        public string Aerolinea {get;set;}
        public string NumeroVuelo {get;set;}
        public string Origen {get;set;}
        public string DestinoVuelo {get;set;}
        public string HoraVuelo {get;set;}
        public string FechaVuelo {get;set;}
        public string FechaInicio {get;set;}
        public string FechaFin {get;set;}
        public int CantidadPersonas {get; set;}
        public decimal PrecioTotal {get;set;}
 

    }
    public class InsertReservasModel
    {
        public int IdUsuario {get; set;}
        public int IdDestino {get; set;}
        public int IdAlojamiento {get; set;}
        public int IdVuelo {get; set;}
        public string Aerolinea {get;set;}
        public string NumeroVuelo {get;set;}
        public string Origen {get;set;}
        public string DestinoVuelo {get;set;}
        public string HoraVuelo {get;set;}
        public string FechaVuelo {get;set;}
        public string FechaInicio {get;set;}
        public string FechaFin {get;set;}
        public int CantidadPersonas {get; set;}
        public decimal PrecioTotal {get;set;}

    }
    public class UpdateReservasModel
    {
        public  int IdReserva {get; set;}
        public int IdUsuario {get; set;}
        public int IdDestino {get; set;}
        public int IdAlojamiento {get; set;}
        public int IdVuelo {get; set;}
        public string Aerolinea {get;set;}
        public string NumeroVuelo {get;set;}
        public string Origen {get;set;}
        public string DestinoVuelo {get;set;}
        public string HoraVuelo {get;set;}
        public string FechaVuelo {get;set;}
        public string FechaInicio {get;set;}
        public string FechaFin {get;set;}
        public int CantidadPersonas {get; set;}
        public decimal PrecioTotal {get;set;}
    }
}