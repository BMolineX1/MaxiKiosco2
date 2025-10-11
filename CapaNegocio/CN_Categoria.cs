using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Categoria

    {
        private CD_Categoria object_categoria = new CD_Categoria();
        public List<Categoria> Listar()
        {
            return object_categoria.Listar();
        }

        // Método para cargar el ComboBox en el formulario de Producto
        public List<Categoria> ListarActivos()
        {
            // Llama al método filtrado de la Capa de Datos
            return object_categoria.ListarActivos();
        }

        //traemos registrar de CD_Categoria
        public int Registrar(Categoria obj, out string Mensaje)
        {
            
            //el mensaje va a ir como vacio
            Mensaje = string.Empty;

            if (obj.nombre_categoria == "")
            {
                Mensaje += "Es necesario el nombre de la Categoria\n";
                return 0;
            }
            if (obj.porcentaje_aumento < 0)
            {
                Mensaje += "El Porcentaje de Aumento no puede ser negativo.\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }

            else
            {
                return object_categoria.Registrar(obj, out Mensaje);
            }
        }


        //traemos editar de CN_Categoria
        public bool Editar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.nombre_categoria == "")
            {
                Mensaje += "Es necesario el nombre de la Categoria\n";
            }
            if (obj.porcentaje_aumento < 0)
            {
                Mensaje += "El Porcentaje de Aumento no puede ser negativo.\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return object_categoria.Editar(obj, out Mensaje);
            }

        }
        //traemos eliminar de CN_Categoria
        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            return object_categoria.Eliminar(obj, out Mensaje);
        }

    }
}
