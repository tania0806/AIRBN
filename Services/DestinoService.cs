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
    public class DestinoService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public DestinoService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetDestinoModel> GetDestino()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetDestinoModel sedes = new GetDestinoModel();

            List<GetDestinoModel> lista = new List<GetDestinoModel>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_destinos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetDestinoModel {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        Nombre = dataRow["Nombre"].ToString(),
                        Descripcion = dataRow["Descripcion"].ToString(),
                        PrecioTour = decimal.Parse(dataRow["PrecioTour"].ToString()),
                        Ubicacion = dataRow["Ubicacion"].ToString(),
                        Imagen = dataRow["Imagen"].ToString(),
                       
                       
                        
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        public string InsertDestino(InsertDestinoModel destino)
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = destino.Nombre});
            parametros.Add(new SqlParameter { ParameterName = "@Descripcion", SqlDbType = System.Data.SqlDbType.VarChar, Value = destino.Descripcion});
            parametros.Add(new SqlParameter { ParameterName = "@PrecioTour", SqlDbType = System.Data.SqlDbType.Decimal, Value = destino.PrecioTour});
            parametros.Add(new SqlParameter { ParameterName = "@Ubicacion", SqlDbType = System.Data.SqlDbType.VarChar, Value = destino.Ubicacion});
            parametros.Add(new SqlParameter { ParameterName = "@Imagen", SqlDbType = System.Data.SqlDbType.VarChar, Value = destino.Imagen});



            try
            {
                DataSet ds = dac.Fill("sp_insert_destinos", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["Mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public string UpdateDestino(UpdateDestinoModel destino)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = System.Data.SqlDbType.Int, Value = destino.Id});
            parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = destino.Nombre});
            parametros.Add(new SqlParameter { ParameterName = "@Descripcion", SqlDbType = System.Data.SqlDbType.VarChar, Value = destino.Descripcion});
            parametros.Add(new SqlParameter { ParameterName = "@PrecioTour", SqlDbType = System.Data.SqlDbType.Decimal, Value = destino.PrecioTour});
            parametros.Add(new SqlParameter { ParameterName = "@Ubicacion", SqlDbType = System.Data.SqlDbType.VarChar, Value = destino.Ubicacion});
            parametros.Add(new SqlParameter { ParameterName = "@Imagen", SqlDbType = System.Data.SqlDbType.VarChar, Value = destino.Imagen});

            try
            {
                DataSet ds = dac.Fill("sp_update_destinos", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteDestino(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_destinos", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}