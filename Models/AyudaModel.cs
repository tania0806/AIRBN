using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models
{
    public class GetAyudaModel
    {
        public  int Id {get; set;}
        public string NombreCompleto {get; set;}
        public string CorreoElectronico {get; set;}
        public string TipoConsulta {get;set;}
        public string DescripcionProblema {get;set;}
        public string ArchivoAdjunto {get; set;}
        public string FechaSolicitud {get; set;}

    }
    public class InsertAyudaModel
    {
        public string NombreCompleto {get; set;}
        public string CorreoElectronico {get; set;}
        public string TipoConsulta {get;set;}
        public string DescripcionProblema {get;set;}
        public string ArchivoAdjunto {get; set;}
    }
    public class UpdateAyudaModel
    {
        public  int Id {get; set;}
        public string NombreCompleto {get; set;}
        public string CorreoElectronico {get; set;}
        public string TipoConsulta {get;set;}
        public string DescripcionProblema {get;set;}
        public string ArchivoAdjunto {get; set;}
    }
}