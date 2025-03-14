using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models
{
    public class GetDestinoModel
    {
        public  int Id {get; set;}
        public string Nombre {get; set;}
        public string Descripcion {get; set;}
        public decimal PrecioTour {get;set;}
        public string Ubicacion {get;set;}
        public string Imagen {get; set;}

    }
    public class InsertDestinoModel
    {
        public string Nombre {get; set;}
        public string Descripcion {get; set;}
        public decimal PrecioTour {get;set;}
        public string Ubicacion {get;set;}
        public string Imagen {get; set;}
    }
    public class UpdateDestinoModel
    {
        public  int Id {get; set;}
        public string Nombre {get; set;}
        public string Descripcion {get; set;}
        public decimal PrecioTour {get;set;}
        public string Ubicacion {get;set;}
        public string Imagen {get; set;}
    }
}