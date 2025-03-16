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
    public class FavoritosService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public FavoritosService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

  public List<GetFavoritosModel> GetFavorioId(int Id)
{
    ConexionDataAccess dac = new ConexionDataAccess(connection);
    ArrayList parametros = new ArrayList();
    parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = SqlDbType.Int, Value = Id });

    List<GetFavoritosModel> lista = new List<GetFavoritosModel>();
    try
    {
        // Llamada al procedimiento almacenado con el parámetro Id
        DataSet ds = dac.Fill("sp_get_favoritos", parametros);

        // Comprobar si hay datos en la respuesta
        if (ds.Tables[0].Rows.Count > 0)
        {
            // Mapear los resultados a la lista de GetRecetasModel
            lista = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new GetFavoritosModel
                {
                    IdFavoritos = int.Parse(dataRow["IdFavorito"].ToString()),
                    IdUsuario = int.Parse(dataRow["IdUsuario"].ToString()),
                    IdAlojamiento = int.Parse(dataRow["IdAlojamiento"].ToString()),
                    Alojamiento = dataRow["Alojamiento"].ToString(),
                    PrecioAlojamiento = decimal.Parse(dataRow["PrecioALojamiento"].ToString()),
                    ImagenAlojamiento = dataRow["ImagenAlojamiento"].ToString(),
                    UbiAlo = dataRow["UbiAlo"].ToString(),
                    IdDestino = int.Parse(dataRow["Alojamiento"].ToString()),
                    Destino = dataRow["Destino"].ToString(),
                    PrecioTour = decimal.Parse(dataRow["PrecioTour"].ToString()),
                    ImagenDestino = dataRow["ImagenDestino"].ToString(),
                    UbiDes = dataRow["UbiDes"].ToString(),
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

        public string InsertFavoritos(InsertFavoritosModel favorito)
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = favorito.IdUsuario});
            parametros.Add(new SqlParameter { ParameterName = "@IdAlojamiento", SqlDbType = System.Data.SqlDbType.Int, Value = favorito.IdAlojamiento});
            parametros.Add(new SqlParameter { ParameterName = "@Idestino", SqlDbType = System.Data.SqlDbType.Int, Value = favorito.IdDestino});

            try
            {
                DataSet ds = dac.Fill("sp_insert_favoritos", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["Mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        // public string UpdateDestino(UpdateDestinoModel destino)
        // {
        //     ConexionDataAccess dac = new ConexionDataAccess(connection);
        //     parametros = new ArrayList();
        //     string mensaje;

        //     parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = System.Data.SqlDbType.Int, Value = destino.Id});
        //     parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = destino.Nombre});
        //     parametros.Add(new SqlParameter { ParameterName = "@Descripcion", SqlDbType = System.Data.SqlDbType.VarChar, Value = destino.Descripcion});
        //     parametros.Add(new SqlParameter { ParameterName = "@PrecioTour", SqlDbType = System.Data.SqlDbType.Decimal, Value = destino.PrecioTour});
        //     parametros.Add(new SqlParameter { ParameterName = "@Ubicacion", SqlDbType = System.Data.SqlDbType.VarChar, Value = destino.Ubicacion});
        //     parametros.Add(new SqlParameter { ParameterName = "@Imagen", SqlDbType = System.Data.SqlDbType.VarChar, Value = destino.Imagen});

        //     try
        //     {
        //         DataSet ds = dac.Fill("sp_update_destinos", parametros);
        //         mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }

        //     return mensaje;
        // }

      public void DeleteFavorito(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_favoritos", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
 
 
 
