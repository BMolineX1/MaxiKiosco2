using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace CapaDatos
{
    public class CD_Categoria
    {

        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();
            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select Id,nombre_categoria,porcentaje_aumento,estado from categoria";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria()
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                nombre_categoria = dr["nombre_categoria"].ToString(),
                                porcentaje_aumento = dr["porcentaje_aumento"] != DBNull.Value ? Convert.ToDecimal(dr["porcentaje_aumento"])
                                : 0, // valor por defecto si está nulo
                                estado = Convert.ToBoolean(dr["estado"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Categoria>();
                }

            }
            return lista;
        }

        // NUEVO MÉTODO: Trae SOLO las categorías Activas (para el ComboBox de Producto)
        public List<Categoria> ListarActivos()
        {
            List<Categoria> lista = new List<Categoria>();
            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    // Consulta que SOLO trae los Activos (estado = 1)
                    string query = "select Id,nombre_categoria from categoria WHERE estado = 1";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria()
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                nombre_categoria = dr["nombre_categoria"].ToString(),
                                // Aquí solo necesitas el Id y el Nombre para el ComboBox
                            });
                        }
                    }
                }
                catch
                {
                    lista = new List<Categoria>();
                }
            }
            return lista;
        }

        public int Registrar(Categoria obj, out string Mensaje)
        {
            int idCategoriagenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_RegistrarCategoria", oconexion);
                    cmd.Parameters.AddWithValue("p_nombre_categoria", obj.nombre_categoria);
                    cmd.Parameters.AddWithValue("p_porcentaje_aumento", obj.porcentaje_aumento);
                    cmd.Parameters.AddWithValue("p_estado", obj.estado);
                    cmd.Parameters.Add("p_resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("Mensaje", MySqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idCategoriagenerado = Convert.ToInt32(cmd.Parameters["p_resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idCategoriagenerado = 0;
                Mensaje = ex.Message;
            }
            return idCategoriagenerado;
        }
       
        public bool Editar(Categoria obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_EditarCategoria", oconexion);
                    cmd.Parameters.AddWithValue("p_id", obj.Id);
                    cmd.Parameters.AddWithValue("p_nombre_categoria", obj.nombre_categoria);

                    cmd.Parameters.AddWithValue("p_porcentaje_aumento", obj.porcentaje_aumento);

                    cmd.Parameters.AddWithValue("p_estado", obj.estado);
                    cmd.Parameters.Add("p_resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("mensaje", MySqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["p_resultado"].Value);
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
       
        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_EliminarCategoria", oconexion);
                    cmd.Parameters.AddWithValue("p_id", obj.Id);
                    cmd.Parameters.Add("p_resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", MySqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["p_resultado"].Value);
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
