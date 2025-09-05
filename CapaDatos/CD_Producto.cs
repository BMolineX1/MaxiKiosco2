using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaDatos
{
    public class CD_Producto
    {
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT p.id, " +
               "categoria.id AS cate_id, " +
               "p.nombre, " +
               "p.stock, " +
               "p.precioventa, " +
               "p.categoria_id, " +
               "p.preciocompra, " +
               "p.descripcion, " +
               "p.fecharegistro, " +
               "p.estado, " +
               "p.codigo, " +
               "categoria.nombre_categoria AS nom_categoria " +
               "FROM producto p " +
               "INNER JOIN categoria ON categoria.id = p.categoria_id";
                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto()
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                stock = Convert.ToInt32(dr["stock"]),
                                precioventa = Convert.ToDecimal(dr["precioventa"]),
                                ocategoria = new Categoria() { Id = Convert.ToInt32(dr["cate_id"]), nombre_categoria = dr["nom_categoria"].ToString() }, 
                                preciocompra = Convert.ToDecimal(dr["preciocompra"]),
                                descripcion = dr["descripcion"].ToString(),
                                fecharegistro = Convert.ToString(dr["fecharegistro"]),
                                estado = Convert.ToBoolean(dr["estado"]),
                                codigo = dr["codigo"].ToString(),
                                
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Producto>();
                }

            }
            return lista;
        }

        public int Registrar(Producto obj, out string Mensaje)
        {
            int idProductogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_REGISTRARProducto", oconexion);
                    cmd.Parameters.AddWithValue("p_nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("p_stock", obj.stock);
                    cmd.Parameters.AddWithValue("p_precioventa", obj.precioventa);
                    cmd.Parameters.AddWithValue("p_categoria_id", obj.ocategoria.Id);
                    cmd.Parameters.AddWithValue("p_preciocompra", obj.preciocompra);
                    cmd.Parameters.AddWithValue("p_descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("p_fecharegistro", obj.fecharegistro);
                    cmd.Parameters.AddWithValue("p_estado", obj.estado);
                    cmd.Parameters.AddWithValue("p_codigo", obj.codigo);
                    cmd.Parameters.Add("resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", MySqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idProductogenerado = Convert.ToInt32(cmd.Parameters["resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idProductogenerado = 0;
                Mensaje = ex.Message;
            }
            return idProductogenerado;
        }
        public bool Editar(Producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_EDITARProducto", oconexion);
                    cmd.Parameters.AddWithValue("p_id", obj.Id);
                    cmd.Parameters.AddWithValue("p_nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("p_stock", obj.stock);
                    cmd.Parameters.AddWithValue("p_precioventa", obj.precioventa);
                    cmd.Parameters.AddWithValue("p_categoria_id", obj.ocategoria.Id);
                    cmd.Parameters.AddWithValue("p_preciocompra", obj.preciocompra);
                    cmd.Parameters.AddWithValue("p_descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("p_fecharegistro", obj.fecharegistro);
                    cmd.Parameters.AddWithValue("p_estado", obj.estado);
                    cmd.Parameters.AddWithValue("p_codigo", obj.codigo);
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
        public bool Eliminar(Producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_ELIMINARProducto", oconexion);
                    cmd.Parameters.AddWithValue("p_id", obj.Id);
                    cmd.Parameters.Add("resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", MySqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
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
