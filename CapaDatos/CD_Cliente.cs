using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Cliente
    {
        public List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select * from cliente";
                    //creamos una instancia de MysqlCommand y le agregamos la consulta y la conexion
                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    //se abre la conexion
                    oconexion.Open();
                    //mysqldatareader sirve para leer linea por linea de la consulta sin guardar en el buffer ayudando a optimizar el sistema
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clientes.Add(new Cliente()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                apellido = dr["apellido"].ToString(),
                                dni = dr["dni"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                email = dr["email"].ToString(),
                                domicilio = dr["domicilio"].ToString(),
                                estado = Convert.ToBoolean(dr["estado"]),

                            });
                        }
                    }
                }
                catch
                {
                    clientes = new List<Cliente>();
                }

            }
            return clientes;

        }

        public int Registrar(Cliente objcliente, out string Mensaje)
        {
            int idclientegenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_REGISTRARCLIENTE", oconexion);
                    cmd.Parameters.AddWithValue("p_nombre", objcliente.nombre);
                    cmd.Parameters.AddWithValue("p_apellido", objcliente.apellido);
                    cmd.Parameters.AddWithValue("p_documento", objcliente.dni);
                    cmd.Parameters.AddWithValue("p_telefono", objcliente.telefono);
                    cmd.Parameters.AddWithValue("p_domicilio", objcliente.domicilio);
                    cmd.Parameters.AddWithValue("p_email", objcliente.email);
                    cmd.Parameters.AddWithValue("p_estado", objcliente.estado);
                    cmd.Parameters.Add("idclienteresultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", MySqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idclientegenerado = Convert.ToInt32(cmd.Parameters["idclienteresultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idclientegenerado = 0;
                Mensaje = ex.Message;
            }
            return idclientegenerado;

        }
        public bool EditarCliente(Cliente objcliente,out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try 
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_EDITARCLIENTE", oconexion);
                    cmd.Parameters.AddWithValue("p_idcliente",objcliente.id);
                    cmd.Parameters.AddWithValue("p_nombre", objcliente.nombre);
                    cmd.Parameters.AddWithValue("p_apellido", objcliente.apellido);
                    cmd.Parameters.AddWithValue("p_documento", objcliente.dni);
                    cmd.Parameters.AddWithValue("p_domicilio", objcliente.domicilio);
                    cmd.Parameters.AddWithValue("p_telefono", objcliente.telefono);
                    cmd.Parameters.AddWithValue("p_email", objcliente.email);
                    cmd.Parameters.AddWithValue("p_estado", objcliente.estado);
                    cmd.Parameters.Add("respuesta", MySqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", MySqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
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
        public bool EliminarCliente(Cliente objcliente, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {

                    string query = "delete from cliente where id = @idcliente";
                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@idcliente", objcliente.id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                    if (respuesta) 
                    {
                        Mensaje = "El usuario fue eliminado con exito";
                    }
                    else
                    {
                        Mensaje = "No se puede eliminar ese usuario";
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