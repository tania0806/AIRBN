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
    public class MetodoPagoService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public MetodoPagoService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

  public List<GetMetodoPagoModel> GetMetodoPagoId(int Id)
{
    ConexionDataAccess dac = new ConexionDataAccess(connection);
    ArrayList parametros = new ArrayList();
    parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = SqlDbType.Int, Value = Id });

    List<GetMetodoPagoModel> lista = new List<GetMetodoPagoModel>();
    try
    {
        // Llamada al procedimiento almacenado con el parámetro Id
        DataSet ds = dac.Fill("sp_get_metodopago", parametros);

        // Comprobar si hay datos en la respuesta
        if (ds.Tables[0].Rows.Count > 0)
        {
            // Mapear los resultados a la lista de GetRecetasModel
            lista = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new GetMetodoPagoModel
                {
                    IdMetodoPago = int.Parse(dataRow["IdMetodoPago"].ToString()),
                    IdUsuario = int.Parse(dataRow["IdUsuario"].ToString()),
                    Tipo = dataRow["Tipo"].ToString(),
                    NumeroTarjeta = dataRow["NumeroTarjeta"].ToString(),
                    FechaVencimiento = dataRow["FechaPago"].ToString(),
                    CodigoSeguridad = dataRow["CodigoSeguridad"].ToString(),
                    Titular = dataRow["Titular"].ToString(),
                    Estado = int.Parse(dataRow["Estado"].ToString()),
                  
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

        public string InsertMetodoPago(InsertMetodoPagoModel hp)
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = hp.IdUsuario});
            parametros.Add(new SqlParameter { ParameterName = "@Tipo", SqlDbType = System.Data.SqlDbType.VarChar, Value = hp.Tipo});
            parametros.Add(new SqlParameter { ParameterName = "@NumeroTarjeta", SqlDbType = System.Data.SqlDbType.VarChar, Value = hp.NumeroTarjeta});
            parametros.Add(new SqlParameter { ParameterName = "@FechaVencimiento", SqlDbType = System.Data.SqlDbType.VarChar, Value = hp.FechaVencimiento});
            parametros.Add(new SqlParameter { ParameterName = "@CodigoSeguridad", SqlDbType = System.Data.SqlDbType.VarChar, Value = hp.CodigoSeguridad});
            parametros.Add(new SqlParameter { ParameterName = "@Titular", SqlDbType = System.Data.SqlDbType.VarChar, Value = hp.Titular});



            try
            {
                DataSet ds = dac.Fill("sp_insert_metodopago", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["Mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public string UpdateMetodoPago(UpdateMetodoPagoModel hp)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@IdMetodoPago", SqlDbType = System.Data.SqlDbType.Int, Value = hp.IdMetodoPago});
            parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = hp.IdUsuario});
            parametros.Add(new SqlParameter { ParameterName = "@Tipo", SqlDbType = System.Data.SqlDbType.VarChar, Value = hp.Tipo});
            parametros.Add(new SqlParameter { ParameterName = "@NumeroTarjeta", SqlDbType = System.Data.SqlDbType.VarChar, Value = hp.NumeroTarjeta});
            parametros.Add(new SqlParameter { ParameterName = "@FechaVencimiento", SqlDbType = System.Data.SqlDbType.VarChar, Value = hp.FechaVencimiento});
            parametros.Add(new SqlParameter { ParameterName = "@CodigoSeguridad", SqlDbType = System.Data.SqlDbType.VarChar, Value = hp.CodigoSeguridad});
            parametros.Add(new SqlParameter { ParameterName = "@Titular", SqlDbType = System.Data.SqlDbType.VarChar, Value = hp.Titular});

            try
            {
                DataSet ds = dac.Fill("sp_update_metodopago", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteMetodoPago(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_metodopago", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
 
 
 
