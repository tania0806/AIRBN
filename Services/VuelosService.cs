 using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using Airbnb.Models;
using System.Collections.Generic;
using OfficeOpenXml;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
namespace Airbnb.Services
{
    public class VuelosService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public VuelosService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

     public List<GetVuelosModel> GetVuelos()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetVuelosModel sedes = new GetVuelosModel();

            List<GetVuelosModel> lista = new List<GetVuelosModel>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_vuelos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetVuelosModel {
                    IdVuelo = int.Parse(dataRow["IdReserva"].ToString()),
                    Aerolinea = dataRow["Aerolinea"].ToString(),
                    NumeroVuelo = dataRow["NumeroVuelo"].ToString(),
                    Origen = dataRow["Origen"].ToString(),
                    DestinoVuelo = dataRow["DestinoVuelo"].ToString(),
                    FechaVuelo = dataRow["FechaVuelo"].ToString(),
                    HoraVuelo = dataRow["HoraVuelo"].ToString(),
                    Precio = decimal.Parse(dataRow["Precio"].ToString()),
                       
                        
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

//   public List<GetVuelosModel> GetVuelosId(int Id)
// {
//     ConexionDataAccess dac = new ConexionDataAccess(connection);
//     ArrayList parametros = new ArrayList();
//     parametros.Add(new SqlParameter { ParameterName = "@IdVuelo", SqlDbType = SqlDbType.Int, Value = Id });

//     List<GetVuelosModel> lista = new List<GetVuelosModel>();
//     try
//     {
//         // Llamada al procedimiento almacenado con el parámetro Id
//         DataSet ds = dac.Fill("sp_get_vuelos", parametros);

//         // Comprobar si hay datos en la respuesta
//         if (ds.Tables[0].Rows.Count > 0)
//         {
//             // Mapear los resultados a la lista de GetRecetasModel
//             lista = ds.Tables[0].AsEnumerable()
//                 .Select(dataRow => new GetVuelosModel
//                 {
//                     IdVuelo = int.Parse(dataRow["IdReserva"].ToString()),
//                     Aerolinea = dataRow["Aerolinea"].ToString(),
//                     NumeroVuelo = dataRow["NumeroVuelo"].ToString(),
//                     Origen = dataRow["Origen"].ToString(),
//                     DestinoVuelo = dataRow["DestinoVuelo"].ToString(),
//                     FechaVuelo = dataRow["FechaVuelo"].ToString(),
//                     HoraVuelo = dataRow["HoraVuelo"].ToString(),
//                     Precio = decimal.Parse(dataRow["Precio"].ToString()),
                  
//                 }).ToList();
//         }
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine(ex.Message);
//         throw ex;
//     }

//     return lista;
// }

        public string InsertVuelos(InsertVuelosModel vuelos)
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@Aerolinea", SqlDbType = System.Data.SqlDbType.VarChar, Value = vuelos.Aerolinea});
            parametros.Add(new SqlParameter { ParameterName = "@NumeroVuelo", SqlDbType = System.Data.SqlDbType.VarChar, Value = vuelos.NumeroVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@Origen", SqlDbType = System.Data.SqlDbType.VarChar, Value = vuelos.Origen});
            parametros.Add(new SqlParameter { ParameterName = "@DestinoVuelo", SqlDbType = System.Data.SqlDbType.VarChar, Value = vuelos.DestinoVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@FechaVuelo", SqlDbType = System.Data.SqlDbType.Date, Value = vuelos.FechaVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@HoraVuelo", SqlDbType = System.Data.SqlDbType.Time, Value = vuelos.HoraVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@Precio", SqlDbType = System.Data.SqlDbType.Decimal, Value = vuelos.Precio});  

            try
            {
                DataSet ds = dac.Fill("sp_insert_vuelo", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["Mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public string UpdateVuelos(UpdateVuelosModel vuelos)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@IdVuelo", SqlDbType = System.Data.SqlDbType.Int, Value = vuelos.IdVuelo});
             parametros.Add(new SqlParameter { ParameterName = "@Aerolinea", SqlDbType = System.Data.SqlDbType.VarChar, Value = vuelos.Aerolinea});
            parametros.Add(new SqlParameter { ParameterName = "@NumeroVuelo", SqlDbType = System.Data.SqlDbType.VarChar, Value = vuelos.NumeroVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@Origen", SqlDbType = System.Data.SqlDbType.VarChar, Value = vuelos.Origen});
            parametros.Add(new SqlParameter { ParameterName = "@DestinoVuelo", SqlDbType = System.Data.SqlDbType.VarChar, Value = vuelos.DestinoVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@FechaVuelo", SqlDbType = System.Data.SqlDbType.Date, Value = vuelos.FechaVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@HoraVuelo", SqlDbType = System.Data.SqlDbType.Time, Value = vuelos.HoraVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@Precio", SqlDbType = System.Data.SqlDbType.Decimal, Value = vuelos.Precio});  
            try
            {
                DataSet ds = dac.Fill("sp_update_vuelo", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteVuelos(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@IdVuelo", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_vuelo", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
 
 
 
