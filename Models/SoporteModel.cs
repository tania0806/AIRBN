using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models
{
    public class GetSoporteModel
    {
        public  int IdSoporte {get; set;}
        public string NombreCompleto {get; set;}
        public string CorreoElectronico {get; set;}
        public string TipoProblema {get;set;}
        public string NivelPrioridad {get;set;}
        public string DescripcionProblema {get;set;}
        public string ArchivoAdjunto {get; set;}
        public string FechaSolicitud {get; set;}

    }
    public class InsertSoporteModel
    {
        public string NombreCompleto {get; set;}
        public string CorreoElectronico {get; set;}
        public string TipoProblema {get;set;}
        public string NivelPrioridad {get; set;}
        public string DescripcionProblema {get;set;}
        public string ArchivoAdjunto {get; set;}
    }
    public class UpdateSoporteModel
    {
        public  int IdSoporte {get; set;}
        public string NombreCompleto {get; set;}
        public string CorreoElectronico {get; set;}
        public string TipoProblema {get;set;}
        public string NivelPrioridad {get; set;}
        public string DescripcionProblema {get;set;}
        public string ArchivoAdjunto {get; set;}
    }
}