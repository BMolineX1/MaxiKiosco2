using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Negocio
    {
        public Negocio ObtenerDatos()
        {
            Negocio objeto = new Negocio();
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "SELECT idnegocio, nombre, ruc, direccion FROM negocio where idnegocio = 1";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new Negocio()
                            {
                                idnegocio = Convert.ToInt32(dr["idnegocio"]),
                                nombre = dr["nombre"].ToString(),
                                ruc = dr["ruc"].ToString(),
                                direccion = dr["direccion"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception)
            {
                objeto = new Negocio();
            }
            return objeto;
        }
        public bool GuardarDatos(Negocio obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "UPDATE negocio SET nombre = @nombre, ruc = @ruc, direccion = @direccion WHERE idnegocio = 1";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("@ruc", obj.ruc);
                    cmd.Parameters.AddWithValue("@direccion", obj.direccion);
                    cmd.CommandType = CommandType.Text;
                    respuesta = cmd.ExecuteNonQuery() > 0;
                    if (respuesta)
                    {
                        Mensaje = "Los datos se han actualizado correctamente.";
                    }
                    else
                    {
                        Mensaje = "No se pudo actualizar los datos.";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] LogoBytes = new byte[0];
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "SELECT logo FROM negocio WHERE idnegocio = 1";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr["logo"] != DBNull.Value)
                            {
                                LogoBytes = (byte[])dr["logo"];
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                obtenido = false;
                LogoBytes = new byte[0];
            }
            return LogoBytes;
        }

        public bool ActualizarLogo(byte[] logo, out string Mensaje)
        {
            bool respuesta = true;
            Mensaje = string.Empty;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "UPDATE negocio SET logo = @logo WHERE idnegocio = 1";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@logo", logo);
                    cmd.CommandType = CommandType.Text;
                    respuesta = cmd.ExecuteNonQuery() > 0;
                    if (respuesta)
                    {
                        Mensaje = "El logo se ha actualizado correctamente.";
                    }
                    else
                    {
                        Mensaje = "No se pudo actualizar el logo.";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}
