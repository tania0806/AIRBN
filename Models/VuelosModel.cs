using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models
{
    public class GetVuelosModel
    {
        public int IdVuelo {get; set;}
        public string Aerolinea {get;set;}
        public string NumeroVuelo {get;set;}
        public string Origen {get;set;}
        public string DestinoVuelo {get;set;}
        public string HoraVuelo {get;set;}
        public string FechaVuelo {get;set;}
        public string FechaInicio {get;set;}
        public decimal Precio {get;set;}
 

    }
    public class InsertVuelosModel
    {
        public string Aerolinea {get;set;}
        public string NumeroVuelo {get;set;}
        public string Origen {get;set;}
        public string DestinoVuelo {get;set;}
        public string HoraVuelo {get;set;}
        public string FechaVuelo {get;set;}
        public decimal Precio {get;set;}

    }
    public class UpdateVuelosModel
    {
        public  int IdVuelo {get; set;}
        public string Aerolinea {get;set;}
        public string NumeroVuelo {get;set;}
        public string Origen {get;set;}
        public string DestinoVuelo {get;set;}
        public string HoraVuelo {get;set;}
        public string FechaVuelo {get;set;}
        public string FechaInicio {get;set;}
        public decimal Precio {get;set;}
    }
}