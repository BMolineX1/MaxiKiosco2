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
    public class CD_Proveedor
    {
        public List<Proveedor> Listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select p.id, p.nombre, p.cuit, p.telefono, p.direccion, p.estado, p.email,p.razonsocial from proveedor p";
                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedor()
                            {

                                id = Convert.ToInt32(dr["id"]),
                                cuit = dr["cuit"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                direccion = dr["direccion"].ToString(),
                                razonsocial = dr["razonsocial"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                estado = Convert.ToBoolean(dr["estado"]),
                                email = dr["email"].ToString(),

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Proveedor>();
                }

            }
            return lista;
        }

        public int Registrar(Proveedor obj, out string Mensaje)
        {
            int idproveedorgenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_REGISTRARPROVEEDOR", oconexion);
                    cmd.Parameters.AddWithValue("p_cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("p_nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("p_razonsocial", obj.razonsocial); // <--- NUEVO
                    cmd.Parameters.AddWithValue("p_email", obj.email);
                    cmd.Parameters.AddWithValue("p_telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("p_direccion", obj.direccion);
                    
                    cmd.Parameters.AddWithValue("p_estado", obj.estado);
                    cmd.Parameters.Add("resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", MySqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idproveedorgenerado = Convert.ToInt32(cmd.Parameters["resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                idproveedorgenerado = 0;
                Mensaje = ex.Message;
            }
            return idproveedorgenerado;
        }
        public bool Editar(Proveedor obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_EDITARPROVEEDOR", oconexion);
                    cmd.Parameters.AddWithValue("p_id", obj.id);
                    cmd.Parameters.AddWithValue("p_cuit", obj.cuit);
                    cmd.Parameters.AddWithValue("p_nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("p_razonsocial", obj.razonsocial);
                    cmd.Parameters.AddWithValue("p_direccion", obj.direccion);
                    cmd.Parameters.AddWithValue("p_telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("p_email", obj.email);
                    cmd.Parameters.AddWithValue("p_estado", obj.estado);
                    cmd.Parameters.Add("resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", MySqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;

        }
        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_ELIMINARPROVEEDOR", oconexion);
                    cmd.Parameters.AddWithValue("p_id", obj.id);
                    cmd.Parameters.Add("resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", MySqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
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