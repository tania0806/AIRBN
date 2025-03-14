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

        public List<GetDestinoModel> GetAyuda()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetDestinoModel sedes = new GetDestinoModel();

            List<GetDestinoModel> lista = new List<GetDestinoModel>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_ayuda", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetDestinoModel {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        NombreCompleto = dataRow["NombreCompleto"].ToString(),
                        CorreoElectronico = dataRow["CorreoElectronico"].ToString(),
                        TipoConsulta = dataRow["TipoConsulta"].ToString(),
                        DescripcionProblema = dataRow["DescripcionProblema"].ToString(),
                        ArchivoAdjunto = dataRow["ArchivoAjunto"].ToString(),
                        FechaSolicitud = dataRow["FechaSolicitud"].ToString(),
                       
                        
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        public string InsertAyuda(InsertAyudaModel ayuda)
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@NombreCompleto", SqlDbType = System.Data.SqlDbType.VarChar, Value = ayuda.NombreCompleto});
            parametros.Add(new SqlParameter { ParameterName = "@CorreoElectronico", SqlDbType = System.Data.SqlDbType.VarChar, Value = ayuda.CorreoElectronico});
            parametros.Add(new SqlParameter { ParameterName = "@TipoConsulta", SqlDbType = System.Data.SqlDbType.VarChar, Value = ayuda.TipoConsulta});
            parametros.Add(new SqlParameter { ParameterName = "@DescripcionProblema", SqlDbType = System.Data.SqlDbType.VarChar, Value = ayuda.DescripcionProblema});
            parametros.Add(new SqlParameter { ParameterName = "@ArchivoAdjunto", SqlDbType = System.Data.SqlDbType.VarChar, Value = ayuda.ArchivoAdjunto});



            try
            {
                DataSet ds = dac.Fill("sp_insert_ayuda", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["Mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public string UpdateAyuda(UpdateAyudaModel ayuda)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = System.Data.SqlDbType.Int, Value = ayuda.Id});
            parametros.Add(new SqlParameter { ParameterName = "@NombreCompleto", SqlDbType = System.Data.SqlDbType.VarChar, Value = ayuda.NombreCompleto});
            parametros.Add(new SqlParameter { ParameterName = "@CorreoElectronico", SqlDbType = System.Data.SqlDbType.VarChar, Value = ayuda.CorreoElectronico});
            parametros.Add(new SqlParameter { ParameterName = "@TipoConsulta", SqlDbType = System.Data.SqlDbType.VarChar, Value = ayuda.TipoConsulta});
            parametros.Add(new SqlParameter { ParameterName = "@DescripcionProblema", SqlDbType = System.Data.SqlDbType.VarChar, Value = ayuda.DescripcionProblema});
            parametros.Add(new SqlParameter { ParameterName = "@ArchivoAdjunto", SqlDbType = System.Data.SqlDbType.VarChar, Value = ayuda.ArchivoAdjunto});
            
            try
            {
                DataSet ds = dac.Fill("sp_update_ayuda", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteAyuda(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_ayuda", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}