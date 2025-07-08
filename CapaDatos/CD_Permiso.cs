using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using CapaEntidad;
using System.Data.SqlTypes;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int idusuario)
        {

            List<Permiso> lista = new List<Permiso>();

            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.idrol,p.nombremenu from permiso p ");
                    query.AppendLine("inner join rol on rol.idrol = p.idrol");
                    query.AppendLine("inner join usuario u on u.rol_id = rol.idrol ");
                    query.AppendLine("where u.idusuario = @idusuario");

                    MySqlCommand cmd = new MySqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idusuario",idusuario);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                nombremenu = dr["nombremenu"].ToString(),
                                oRol = new Rol() { idrol = Convert.ToInt32(dr["idrol"]) }

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();
                }

            }
            return lista;
        }
    }
}