using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    
    namespace Airbnb.Models
    

{
public class GetAlojamientosModel
    {
        public int Id {get; set;}
        public string NOMBRE {get; set;}
        public string Descripcion {get; set;}
        public decimal Precio {get; set;}
        public string Ubicacion {get; set;}
        public string Imagen {get; set;}
    }
    public class InsertAlojamientosModel
    {
        public string NOMBRE {get; set;}
        public string Descripcion {get; set;}
        public decimal Precio {get; set;}
        public string Ubicacion {get; set;}
        public string Imagen {get; set;}

    }
    public class UpdateAlojamientosModel
    {
        public int Id {get; set;}
        public string NOMBRE {get; set;}
        public string Descripcion {get; set;}
        public decimal Precio {get; set;}
        public string Ubicacion {get; set;}
        public string Imagen {get; set;}
    }
    }