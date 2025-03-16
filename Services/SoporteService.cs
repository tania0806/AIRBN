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
    public class SoporteService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public SoporteService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetSoporteModel> GetSoporte()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetSoporteModel sedes = new GetSoporteModel();

            List<GetSoporteModel> lista = new List<GetSoporteModel>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_soporte", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetSoporteModel {
                        IdSoporte = int.Parse(dataRow["Id"].ToString()),
                        NombreCompleto = dataRow["NombreCompleto"].ToString(),
                        CorreoElectronico = dataRow["CorreoElectronico"].ToString(),
                        TipoProblema = dataRow["TipoConsulta"].ToString(),
                        NivelPrioridad = dataRow["NivelPrioridad"].ToString(),
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


        public string InsertSoporte(InsertSoporteModel soporte)
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@NombreCompleto", SqlDbType = System.Data.SqlDbType.VarChar, Value = soporte.NombreCompleto});
            parametros.Add(new SqlParameter { ParameterName = "@CorreoElectronico", SqlDbType = System.Data.SqlDbType.VarChar, Value = soporte.CorreoElectronico});
            parametros.Add(new SqlParameter { ParameterName = "@TipoConsulta", SqlDbType = System.Data.SqlDbType.VarChar, Value = soporte.TipoProblema});
            parametros.Add(new SqlParameter { ParameterName = "@NivelPrioridad", SqlDbType = System.Data.SqlDbType.VarChar, Value = soporte.NivelPrioridad});
            parametros.Add(new SqlParameter { ParameterName = "@DescripcionProblema", SqlDbType = System.Data.SqlDbType.VarChar, Value = soporte.DescripcionProblema});
            parametros.Add(new SqlParameter { ParameterName = "@ArchivoAdjunto", SqlDbType = System.Data.SqlDbType.VarChar, Value = soporte.ArchivoAdjunto});



            try
            {
                DataSet ds = dac.Fill("sp_insert_soporte", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["Mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public string UpdateSoporte(UpdateSoporteModel soporte)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@IdSoporte", SqlDbType = System.Data.SqlDbType.Int, Value = soporte.IdSoporte});
            parametros.Add(new SqlParameter { ParameterName = "@NombreCompleto", SqlDbType = System.Data.SqlDbType.VarChar, Value = soporte.NombreCompleto});
            parametros.Add(new SqlParameter { ParameterName = "@CorreoElectronico", SqlDbType = System.Data.SqlDbType.VarChar, Value = soporte.CorreoElectronico});
            parametros.Add(new SqlParameter { ParameterName = "@TipoConsulta", SqlDbType = System.Data.SqlDbType.VarChar, Value = soporte.TipoProblema});
            parametros.Add(new SqlParameter { ParameterName = "@NivelPrioridad", SqlDbType = System.Data.SqlDbType.VarChar, Value = soporte.NivelPrioridad});
            parametros.Add(new SqlParameter { ParameterName = "@DescripcionProblema", SqlDbType = System.Data.SqlDbType.VarChar, Value = soporte.DescripcionProblema});
            parametros.Add(new SqlParameter { ParameterName = "@ArchivoAdjunto", SqlDbType = System.Data.SqlDbType.VarChar, Value = soporte.ArchivoAdjunto});

            try
            {
                DataSet ds = dac.Fill("sp_update_soporte", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteSoporte(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@IdSoporte", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_soporte", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}