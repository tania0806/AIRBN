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
    public class UsuarioService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public UsuarioService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetUsuarioModel> GetUsuarios()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetUsuarioModel sedes = new GetUsuarioModel();

            List<GetUsuarioModel> lista = new List<GetUsuarioModel>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_usuario", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetUsuarioModel {
                        IdUsuario = int.Parse(dataRow["IdUsuario"].ToString()),
                        Nombre = dataRow["Nombre"].ToString(),
                        Email = dataRow["Email"].ToString(),
                        FotoPerfil = dataRow["FotoPerfil"].ToString(),
                        MetodoAutenticacion = dataRow["MetodoAutenticacion"].ToString(),
                        Contraseña = dataRow["Contraseña"].ToString(),
                        FechaRegistro = dataRow["FechaRegistro"].ToString(),
                        
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        public string InsertUsuario(InsertUsuarioModel usuarios)
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = usuarios.Nombre});
            parametros.Add(new SqlParameter { ParameterName = "@Email", SqlDbType = System.Data.SqlDbType.VarChar, Value = usuarios.Email});
            parametros.Add(new SqlParameter { ParameterName = "@FotoPerfil", SqlDbType = System.Data.SqlDbType.VarChar, Value = usuarios.FotoPerfil});
            parametros.Add(new SqlParameter { ParameterName = "@MetodoAutenticacion", SqlDbType = System.Data.SqlDbType.VarChar, Value = usuarios.MetodoAutenticacion});
            parametros.Add(new SqlParameter { ParameterName = "@Contraseña", SqlDbType = System.Data.SqlDbType.VarChar, Value = usuarios.Contraseña});



            try
            {
                DataSet ds = dac.Fill("sp_insert_usuarios", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["Mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public string UpdateUsuarios(UpdateUsuarioModel usuarios)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = usuarios.IdUsuario});
            parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = usuarios.Nombre});
            parametros.Add(new SqlParameter { ParameterName = "@Email", SqlDbType = System.Data.SqlDbType.VarChar, Value = usuarios.Email});
            parametros.Add(new SqlParameter { ParameterName = "@FotoPerfil", SqlDbType = System.Data.SqlDbType.VarChar, Value = usuarios.FotoPerfil});
            parametros.Add(new SqlParameter { ParameterName = "@MetodoAutenticacion", SqlDbType = System.Data.SqlDbType.VarChar, Value = usuarios.MetodoAutenticacion});
            parametros.Add(new SqlParameter { ParameterName = "@Contraseña", SqlDbType = System.Data.SqlDbType.VarChar, Value = usuarios.Contraseña});
            
            try
            {
                DataSet ds = dac.Fill("sp_update_usuario", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteUsuario(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_usuarios", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}