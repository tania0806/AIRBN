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
    public class ReservasService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public ReservasService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

  public List<GetReservasModel> GetReservasId(int Id)
{
    ConexionDataAccess dac = new ConexionDataAccess(connection);
    ArrayList parametros = new ArrayList();
    parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = SqlDbType.Int, Value = Id });

    List<GetReservasModel> lista = new List<GetReservasModel>();
    try
    {
        // Llamada al procedimiento almacenado con el parámetro Id
        DataSet ds = dac.Fill("sp_get_reservar", parametros);

        // Comprobar si hay datos en la respuesta
        if (ds.Tables[0].Rows.Count > 0)
        {
            // Mapear los resultados a la lista de GetRecetasModel
            lista = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new GetReservasModel
                {
                    IdReserva = int.Parse(dataRow["IdReserva"].ToString()),
                    IdUsuario = int.Parse(dataRow["IdUsuario"].ToString()),
                    IdDestino = int.Parse(dataRow["IdDestino"].ToString()),
                    IdAlojamiento = int.Parse(dataRow["IdAlojamiento"].ToString()),
                    IdVuelo = int.Parse(dataRow["IdVuelo"].ToString()),
                    Aerolinea = dataRow["Aerolinea"].ToString(),
                    NumeroVuelo = dataRow["NumeroVuelo"].ToString(),
                    Origen = dataRow["Origen"].ToString(),
                    DestinoVuelo = dataRow["DestinoVuelo"].ToString(),
                    HoraVuelo = dataRow["HoraVuelo"].ToString(),
                    FechaVuelo = dataRow["FechaVuelo"].ToString(),
                    FechaInicio = dataRow["FechaInicio"].ToString(),
                    FechaFin = dataRow["FechaFin"].ToString(),
                    CantidadPersonas = int.Parse(dataRow["CantidadPersonas"].ToString()),
                    PrecioTotal = decimal.Parse(dataRow["PrecioTotal"].ToString()),
                  
                }).ToList();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        throw ex;
    }

    return lista;
}

        public string InsertReservas(InsertReservasModel reservas)
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = reservas.IdUsuario});
            parametros.Add(new SqlParameter { ParameterName = "@IdDestino", SqlDbType = System.Data.SqlDbType.Int, Value = reservas.IdDestino});
            parametros.Add(new SqlParameter { ParameterName = "@IdAlojamiento", SqlDbType = System.Data.SqlDbType.Int, Value = reservas.IdAlojamiento});
            parametros.Add(new SqlParameter { ParameterName = "@IdVuelo", SqlDbType = System.Data.SqlDbType.Int, Value = reservas.IdVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@Aerolinea", SqlDbType = System.Data.SqlDbType.VarChar, Value = reservas.Aerolinea});
            parametros.Add(new SqlParameter { ParameterName = "@NumeroVuelo", SqlDbType = System.Data.SqlDbType.VarChar, Value = reservas.NumeroVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@Origen", SqlDbType = System.Data.SqlDbType.VarChar, Value = reservas.Origen});
            parametros.Add(new SqlParameter { ParameterName = "@DestinoVuelo", SqlDbType = System.Data.SqlDbType.VarChar, Value = reservas.DestinoVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@FechaVuelo", SqlDbType = System.Data.SqlDbType.Date, Value = reservas.FechaVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@HoraVuelo", SqlDbType = System.Data.SqlDbType.Time, Value = reservas.HoraVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@FechaInicio", SqlDbType = System.Data.SqlDbType.Date, Value = reservas.FechaInicio});
            parametros.Add(new SqlParameter { ParameterName = "@FechaFin", SqlDbType = System.Data.SqlDbType.Time, Value = reservas.FechaFin});
            parametros.Add(new SqlParameter { ParameterName = "@CantidadPersonas", SqlDbType = System.Data.SqlDbType.Int, Value = reservas.CantidadPersonas});
            parametros.Add(new SqlParameter { ParameterName = "@PrecioTotal", SqlDbType = System.Data.SqlDbType.Decimal, Value = reservas.PrecioTotal});  

            try
            {
                DataSet ds = dac.Fill("sp_insert_reservar", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["Mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public string UpdateReservas(UpdateReservasModel reservas)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@IdReserva", SqlDbType = System.Data.SqlDbType.Int, Value = reservas.IdReserva});
            parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = reservas.IdUsuario});
            parametros.Add(new SqlParameter { ParameterName = "@IdDestino", SqlDbType = System.Data.SqlDbType.Int, Value = reservas.IdDestino});
            parametros.Add(new SqlParameter { ParameterName = "@IdAlojamiento", SqlDbType = System.Data.SqlDbType.Int, Value = reservas.IdAlojamiento});
            parametros.Add(new SqlParameter { ParameterName = "@IdVuelo", SqlDbType = System.Data.SqlDbType.Int, Value = reservas.IdVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@Aerolinea", SqlDbType = System.Data.SqlDbType.VarChar, Value = reservas.Aerolinea});
            parametros.Add(new SqlParameter { ParameterName = "@NumeroVuelo", SqlDbType = System.Data.SqlDbType.VarChar, Value = reservas.NumeroVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@Origen", SqlDbType = System.Data.SqlDbType.VarChar, Value = reservas.Origen});
            parametros.Add(new SqlParameter { ParameterName = "@DestinoVuelo", SqlDbType = System.Data.SqlDbType.VarChar, Value = reservas.DestinoVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@FechaVuelo", SqlDbType = System.Data.SqlDbType.Date, Value = reservas.FechaVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@HoraVuelo", SqlDbType = System.Data.SqlDbType.Time, Value = reservas.HoraVuelo});
            parametros.Add(new SqlParameter { ParameterName = "@FechaInicio", SqlDbType = System.Data.SqlDbType.Date, Value = reservas.FechaInicio});
            parametros.Add(new SqlParameter { ParameterName = "@FechaFin", SqlDbType = System.Data.SqlDbType.Time, Value = reservas.FechaFin});
            parametros.Add(new SqlParameter { ParameterName = "@CantidadPersonas", SqlDbType = System.Data.SqlDbType.Int, Value = reservas.CantidadPersonas});
            parametros.Add(new SqlParameter { ParameterName = "@PrecioTotal", SqlDbType = System.Data.SqlDbType.Decimal, Value = reservas.PrecioTotal});  

            try
            {
                DataSet ds = dac.Fill("sp_update_reservas", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteReservas(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_reservas", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
 
 
 
