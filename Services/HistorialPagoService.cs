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
    public class HistorialPagoService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public HistorialPagoService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

  public List<GetHistorialPagoModel> GetHistorialPagoId(int Id)
{
    ConexionDataAccess dac = new ConexionDataAccess(connection);
    ArrayList parametros = new ArrayList();
    parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = SqlDbType.Int, Value = Id });

    List<GetHistorialPagoModel> lista = new List<GetHistorialPagoModel>();
    try
    {
        // Llamada al procedimiento almacenado con el parámetro Id
        DataSet ds = dac.Fill("sp_get_historialpago", parametros);

        // Comprobar si hay datos en la respuesta
        if (ds.Tables[0].Rows.Count > 0)
        {
            // Mapear los resultados a la lista de GetRecetasModel
            lista = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new GetHistorialPagoModel
                {
                    Id = int.Parse(dataRow["Id"].ToString()),
                    IdUsuario = int.Parse(dataRow["IdUsuario"].ToString()),
                    Nombre = dataRow["Nombre"].ToString(),
                    IdMetodoPago = int.Parse(dataRow["IdMetodoPago"].ToString()),
                    Titular = dataRow["Titular"].ToString(),
                    Monto = decimal.Parse(dataRow["Monto"].ToString()),
                    FechaPago = dataRow["FechaPago"].ToString(),
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

        public string InsertHistorialPago(InsertHistorialPagoModel hp)
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = hp.IdUsuario});
            parametros.Add(new SqlParameter { ParameterName = "@IdMetodoPago", SqlDbType = System.Data.SqlDbType.Int, Value = hp.IdMetodoPago});
            parametros.Add(new SqlParameter { ParameterName = "@Monto", SqlDbType = System.Data.SqlDbType.Decimal, Value = hp.Monto});

            try
            {
                DataSet ds = dac.Fill("sp_insert_historialpago", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public string UpdateHistorialPago(UpdateHistorialPagoModel hp)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = System.Data.SqlDbType.Int, Value = hp.Id});
           parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = hp.IdUsuario});
            parametros.Add(new SqlParameter { ParameterName = "@IdMetodoPago", SqlDbType = System.Data.SqlDbType.Int, Value = hp.IdMetodoPago});
            parametros.Add(new SqlParameter { ParameterName = "@Monto", SqlDbType = System.Data.SqlDbType.Decimal, Value = hp.Monto});

            try
            {
                DataSet ds = dac.Fill("sp_update_historialpago", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteHistorialPago(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_historialpago", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
 
 
 
