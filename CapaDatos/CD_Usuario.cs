﻿using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    // 1. MODIFICACIÓN: Agregar las columnas de roles y la columna CALCULADA
                    string query = "SELECT u.idusuario, u.dni, u.nombre, u.apellido, u.usuario_cuenta, " +
                                   "u.contrasenia, u.estado, u.telefono, u.email, u.rol_id, " +
                                   "u.escliente, u.esproveedor, " + // ⬅️ Nuevas columnas BIT/TINYINT
                                   "r.idrol, r.nombre AS rol_nombre, " +
                                   "CASE " +
                                       "WHEN u.escliente = 1 AND u.esproveedor = 1 THEN 'Cliente y Proveedor' " +
                                       "WHEN u.escliente = 1 THEN 'Cliente' " +
                                       "WHEN u.esproveedor = 1 THEN 'Proveedor' " +
                                       "ELSE 'Ninguno' " + // ⬅️ Lógica de la Columna Calculada
                                   "END AS TipoRolCalculado " + // ⬅️ Nombre del campo calculado
                                   "FROM usuario u " +
                                   "INNER JOIN rol r ON r.idrol = u.rol_id";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {

                                idusuario = Convert.ToInt32(dr["idusuario"]),
                                dni = dr["dni"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                apellido = dr["apellido"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                cuenta_usuario = dr["usuario_cuenta"].ToString(),
                                contrasena = dr["contrasenia"].ToString(),
                                estado = Convert.ToBoolean(dr["estado"]),
                                email = dr["email"].ToString(),
                                // 2. MODIFICACIÓN: Leer los nuevos campos de roles (para edición)
                                EsCliente = Convert.ToBoolean(dr["escliente"]),
                                EsProveedor = Convert.ToBoolean(dr["esproveedor"]),

                                // 3. MODIFICACIÓN: Leer el campo calculado (para visualización)
                                TipoRolCalculado = dr["TipoRolCalculado"].ToString(),

                                oRol = new Rol()
                                {
                                    idrol = Convert.ToInt32(dr["idrol"]),
                                    nombre = Convert.ToString(dr["rol_nombre"])
                                }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Usuario>();
                }

            }
            return lista;
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            int idusuariogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_REGISTRARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("p_documento", obj.dni);
                    cmd.Parameters.AddWithValue("p_nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("p_apellido", obj.apellido);
                    cmd.Parameters.AddWithValue("p_telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("p_rol_id", obj.oRol.idrol);
                    cmd.Parameters.AddWithValue("p_usuario_cuenta", obj.cuenta_usuario);
                    cmd.Parameters.AddWithValue("p_contrasenia", obj.contrasena);
                    cmd.Parameters.AddWithValue("p_email", obj.email);
                    cmd.Parameters.AddWithValue("p_estado", obj.estado);

                    // ⬇️ NUEVOS PARÁMETROS AGREGADOS ⬇️
                    cmd.Parameters.AddWithValue("p_escliente", obj.EsCliente ? 1 : 0);
                    cmd.Parameters.AddWithValue("p_esproveedor", obj.EsProveedor ? 1 : 0);

                    cmd.Parameters.Add("idusuarioresultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", MySqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idusuariogenerado = Convert.ToInt32(cmd.Parameters["idusuarioresultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    
                }

            }
            catch (Exception ex)
            {
                idusuariogenerado = 0;
                Mensaje = ex.Message;
            }
            return idusuariogenerado;
        }
        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_EDITARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("p_idusuario", obj.idusuario);
                    cmd.Parameters.AddWithValue("p_documento", obj.dni);
                    cmd.Parameters.AddWithValue("p_nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("p_apellido", obj.apellido);
                    cmd.Parameters.AddWithValue("p_telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("p_rol_id", obj.oRol.idrol);
                    cmd.Parameters.AddWithValue("p_usuario_cuenta", obj.cuenta_usuario);
                    cmd.Parameters.AddWithValue("p_contrasenia", obj.contrasena);
                    cmd.Parameters.AddWithValue("p_email", obj.email);
                    cmd.Parameters.AddWithValue("p_estado", obj.estado);

                    // ⬇️ NUEVOS PARÁMETROS AGREGADOS ⬇️
                    cmd.Parameters.AddWithValue("p_escliente", obj.EsCliente ? 1 : 0);
                    cmd.Parameters.AddWithValue("p_esproveedor", obj.EsProveedor ? 1 : 0);

                    cmd.Parameters.Add("respuesta", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", MySqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
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
        
        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {

                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_ELIMINARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("p_idusuario", obj.idusuario);
                    cmd.Parameters.Add("respuesta", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", MySqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
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


