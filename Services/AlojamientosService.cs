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
    public class AlojamientosService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public AlojamientosService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetAlojamientosModel> GetAlojamientos()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetAlojamientosModel sedes = new GetAlojamientosModel();

            List<GetAlojamientosModel> lista = new List<GetAlojamientosModel>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_alojamientos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetAlojamientosModel {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        NOMBRE = dataRow["Nombre"].ToString(),
                        Descripcion = dataRow["Descripcion"].ToString(),
                        Precio = decimal.Parse(dataRow["Perfil"].ToString()),
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


        public string InsertAlojamientos(InsertAlojamientosModel alojamientos)
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = alojamientos.NOMBRE});
            parametros.Add(new SqlParameter { ParameterName = "@Descripcion", SqlDbType = System.Data.SqlDbType.VarChar, Value = alojamientos.Descripcion});
            parametros.Add(new SqlParameter { ParameterName = "@Precio", SqlDbType = System.Data.SqlDbType.Decimal, Value = alojamientos.Precio});
            parametros.Add(new SqlParameter { ParameterName = "@Ubicacion", SqlDbType = System.Data.SqlDbType.VarChar, Value = alojamientos.Ubicacion});
            parametros.Add(new SqlParameter { ParameterName = "@Imagen", SqlDbType = System.Data.SqlDbType.VarChar, Value = alojamientos.Imagen});



            try
            {
                DataSet ds = dac.Fill("sp_insert_alojamientos", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public string UpdateAlojameintos(UpdateAlojamientosModel alojamientos)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = System.Data.SqlDbType.Int, Value = alojamientos.Id});
            parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = alojamientos.NOMBRE});
            parametros.Add(new SqlParameter { ParameterName = "@Descripcion", SqlDbType = System.Data.SqlDbType.VarChar, Value = alojamientos.Descripcion});
            parametros.Add(new SqlParameter { ParameterName = "@Precio", SqlDbType = System.Data.SqlDbType.Decimal, Value = alojamientos.Precio});
            parametros.Add(new SqlParameter { ParameterName = "@Ubicacion", SqlDbType = System.Data.SqlDbType.VarChar, Value = alojamientos.Ubicacion});
            parametros.Add(new SqlParameter { ParameterName = "@Imagen", SqlDbType = System.Data.SqlDbType.VarChar, Value = alojamientos.Imagen});
            
            try
            {
                DataSet ds = dac.Fill("sp_update_alojamientos", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteAlojamientos(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_alojamientos", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}