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
                       "p.stock_minimo, " +
                       "p.precioventa, " +
                       "p.categoria_id, " +
                       "p.preciocompra, " +
                       "p.descripcion, " +
                       "p.fecharegistro, " +
                       "p.estado, " +
                       "p.codigo, " +
                       "categoria.nombre_categoria AS nom_categoria, " +
                       "categoria.porcentaje_aumento AS porc_aumento " +
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
                                // Aplicamos la verificación de DBNull a campos numéricos críticos:
                                stock = dr["stock"] is DBNull ? 0 : Convert.ToInt32(dr["stock"]),
                                stockminimo = dr["stock_minimo"] is DBNull ? 0 : Convert.ToInt32(dr["stock_minimo"]),

                                // Usa GetDecimal()
                                precioventa = dr.IsDBNull(dr.GetOrdinal("precioventa")) ? 0m : dr.GetDecimal(dr.GetOrdinal("precioventa")),

                                ocategoria = new Categoria()
                                {
                                    Id = Convert.ToInt32(dr["cate_id"]),
                                    nombre_categoria = dr["nom_categoria"].ToString(),
                                    porcentaje_aumento = dr["porc_aumento"] is DBNull ? 0m : Convert.ToDecimal(dr["porc_aumento"])
                                },

                                // Usa GetDecimal()
                                preciocompra = dr.IsDBNull(dr.GetOrdinal("preciocompra")) ? 0m  : dr.GetDecimal(dr.GetOrdinal("preciocompra")),

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
                    Console.WriteLine("ERROR EN LISTAR: " + ex.Message);

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
                    cmd.Parameters.AddWithValue("p_descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("p_fecharegistro", obj.fecharegistro);
                    cmd.Parameters.AddWithValue("p_estado", obj.estado);
                    cmd.Parameters.AddWithValue("p_codigo", obj.codigo);
                    cmd.Parameters.AddWithValue("p_stock_minimo", obj.stockminimo); // ✅ AGREGAR STOCK MINIMO


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
                    cmd.Parameters.AddWithValue("p_descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("p_fecharegistro", obj.fecharegistro);
                    cmd.Parameters.AddWithValue("p_estado", obj.estado);
                    cmd.Parameters.AddWithValue("p_codigo", obj.codigo);
                    cmd.Parameters.AddWithValue("p_stock_minimo", obj.stockminimo); // ✅ AGREGAR STOCK MINIMO

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
                Console.WriteLine("hbubo un error");
                respuesta = false;
                Mensaje = ex.Message;
            }

            Console.WriteLine("todo ok");
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

        // [AGREGADO] Método para generar un código interno único
        public string GenerarCodigoInternoUnico()
        {
            string nuevoCodigo = "INT-1"; // Valor por defecto si no hay ninguno.

            // Consulta para obtener el último código interno (INT-XXX)
            // Asumo que el código interno siempre tiene el prefijo 'INT-' y que lo guardas en la columna 'codigo'.
            string query = "SELECT codigo FROM producto WHERE codigo LIKE 'INT-%' ORDER BY id DESC LIMIT 1";

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    object resultado = cmd.ExecuteScalar(); // Ejecuta la consulta y devuelve el primer resultado

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        string ultimoCodigo = resultado.ToString(); // Ejemplo: "INT-10"

                        // 1. Extraer el número (lo que está después de "INT-")
                        // Se asume que el formato es siempre "INT-" seguido del número.
                        string[] partes = ultimoCodigo.Split('-');
                        if (partes.Length == 2 && int.TryParse(partes[1], out int ultimoNumero))
                        {
                            // 2. Incrementar el número
                            ultimoNumero++;

                            // 3. Formatear el nuevo código (Ej: "INT-11")
                            nuevoCodigo = $"INT-{ultimoNumero}";
                        }
                    }
                }
                catch (Exception)
                {
                    // Si hay un error de conexión/consulta, devolvemos el valor por defecto
                    // para que no falle la aplicación, aunque es mejor registrar el error.
                }
            }
            return nuevoCodigo;
        }

        // Metodo para el modulo Suba de Precio
        public bool AplicarAumento(string tipoFiltro, int idFiltro, decimal nuevoPorcentaje, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                MySqlTransaction transaccion = null;

                try
                {
                    oconexion.Open();
                    transaccion = oconexion.BeginTransaction();

                    string query = string.Empty;

                    if (tipoFiltro == "Categoria")
                    {
                        query = @"
                    UPDATE producto 
                    SET precioventa = ROUND(precioventa * (1 + @nuevoPorcentaje / 100), 2) 
                    WHERE categoria_id = @idFiltro";
                    }
                    else if (tipoFiltro == "Proveedor")
                    {
                        query = @"
                    UPDATE producto p
                    INNER JOIN detalle_compra dc ON p.id = dc.producto_id
                    INNER JOIN compra c ON dc.compra_id = c.id_compra
                    SET p.precioventa = ROUND(p.precioventa * (1 + @nuevoPorcentaje / 100), 2) 
                    WHERE c.proveedor_id = @idFiltro;";
                    }
                    else if (tipoFiltro == "Unidad")
                    {
                        // Aumento solo a un producto (unidad)
                        query = @"
                    UPDATE producto 
                    SET precioventa = ROUND(precioventa * (1 + @nuevoPorcentaje / 100), 2)
                    WHERE id = @idFiltro";
                    }
                    else
                    {
                        mensaje = "Tipo de filtro no válido.";
                        return false;
                    }

                    MySqlCommand cmd = new MySqlCommand(query, oconexion, transaccion);
                    cmd.Parameters.AddWithValue("@nuevoPorcentaje", nuevoPorcentaje);
                    cmd.Parameters.AddWithValue("@idFiltro", idFiltro);
                    cmd.CommandType = CommandType.Text;

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    transaccion.Commit();
                    resultado = true;
                    mensaje = $"Precios actualizados para {tipoFiltro} ID {idFiltro}. Productos modificados: {filasAfectadas}";
                }
                catch (Exception ex)
                {
                    if (transaccion != null)
                    {
                        try { transaccion.Rollback(); }
                        catch (Exception rbEx)
                        {
                            mensaje = "Error de BD y fallo al revertir: " + rbEx.Message;
                        }
                    }

                    resultado = false;
                    mensaje = "Error de BD al aplicar aumento (Transacción revertida): " + ex.Message;
                }
            }
            return resultado;
        }
        public bool ActualizarPrecioVenta(int idProducto, decimal nuevoPrecio, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "UPDATE producto SET precioventa = @precio WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@precio", nuevoPrecio);
                    cmd.Parameters.AddWithValue("@id", idProducto);

                    oconexion.Open();
                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        resultado = true;
                        mensaje = "Precio actualizado correctamente.";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "No se encontró el producto a actualizar.";
                    }
                }
                catch (Exception ex)
                {
                    resultado = false;
                    mensaje = "Error de BD al actualizar precio: " + ex.Message;
                }
            }

            return resultado;
        }
        public bool ActualizarPrecioUnitario(int idProducto, decimal nuevoPrecio, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    string query = "UPDATE producto SET precioventa = @precio WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, oconexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@precio", nuevoPrecio);
                        cmd.Parameters.AddWithValue("@id", idProducto);

                        oconexion.Open();
                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            resultado = true;
                            mensaje = "Precio actualizado correctamente.";
                        }
                        else
                        {
                            resultado = false;
                            mensaje = "No se encontró el producto para actualizar.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = "Error al actualizar el precio: " + ex.Message;
            }

            return resultado;
        }

        // Cambiar el tipo de retorno a DataTable
        public DataTable PrevisualizarAumento(string tipoFiltro, int idFiltro, decimal nuevoPorcentaje)
        {
            DataTable dt = new DataTable();

            string condicion = "";

            switch (tipoFiltro)
            {
                case "Categoria":
                    condicion = "WHERE p.categoria_id = @idFiltro";
                    break;
                case "Proveedor":
                    condicion = "WHERE pr.id = @idFiltro";
                    break;
                case "Unidad":
                    condicion = "WHERE p.id = @idFiltro";
                    break;
                default:
                    condicion = "";
                    break;
            }

            string query = $@"
        SELECT 
            p.id AS IdProducto,
            p.nombre AS Producto,
            c.nombre_categoria AS Categoria,
            pr.razonsocial AS Proveedor,
            p.precioventa AS PrecioActual,
            ROUND(p.precioventa * (1 + @nuevoPorcentaje / 100), 2) AS NuevoPrecio,
            @nuevoPorcentaje AS PorcentajeAplicado
        FROM producto p
        INNER JOIN categoria c ON c.id = p.categoria_id
        LEFT JOIN detalle_compra dc ON dc.producto_id = p.id
        LEFT JOIN compra co ON co.id_compra = dc.compra_id
        LEFT JOIN proveedor pr ON pr.id = co.proveedor_id
        {condicion}
        GROUP BY p.id, p.nombre, c.nombre_categoria, pr.razonsocial, p.precioventa
        ORDER BY p.nombre;
    ";

            using (var conexion = new MySqlConnection(Conexion.cadena))
            using (var cmd = new MySqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@nuevoPorcentaje", nuevoPorcentaje);
                cmd.Parameters.AddWithValue("@idFiltro", idFiltro);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                conexion.Open();
                da.Fill(dt);
            }

            return dt;
        }


    }
}
