using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models
{
    public class GetFavoritosModel
    {
        public  int IdFavoritos {get; set;}
        public int IdUsuario {get; set;}
        public int IdAlojamiento {get; set;}
        public string Alojamiento {get;set;}
        public decimal PrecioAlojamiento {get;set;}
        public string ImagenAlojamiento {get;set;}
        public string UbiAlo {get; set;}
        public int IdDestino {get; set;}
        public string Destino {get; set;}
        public decimal PrecioTour {get; set;}
        public string ImagenDestino {get; set;}
        public string UbiDes {get; set;}

    }
    public class InsertFavoritosModel
    {
        public int IdUsuario {get; set;}
        public int IdAlojamiento {get; set;}
        public int IdDestino {get;set;}

    }
    // public class UpdateFavoritosModel
    // {
    //     public  int Id {get; set;}
    //     public int IdUsuario {get; set;}
    //     public int IdAlojamiento {get; set;}
    //     public int IdDestino {get;set;}
    // }
}