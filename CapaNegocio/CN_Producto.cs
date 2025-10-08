using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Producto
    {  
        private CD_Producto object_producto = new CD_Producto();

        public List<Producto> Listar()
        {
            return object_producto.Listar();
        }

        // 1 [AGREGADO] Método para generar código interno (delegado a CapaDatos)
        private string GenerarCodigoInterno()
        {
            return object_producto.GenerarCodigoInternoUnico(); // Esto separamos la lógica de cómo se genera el código
        }

        // [MODIFICADO] Método Registrar
        //traemos registrar de CN_Producto
        public int Registrar(Producto obj, out string Mensaje)
        {
            //el mensaje va a ir como vacio
            Mensaje = string.Empty;
            // 1. [MODIFICACIÓN CLAVE] Manejo del Código Interno
            if (obj.codigo == "GENERAR_INTERNO")
            {
                // Llama al método que acabamos de crear en la Capa de Datos
                obj.codigo = object_producto.GenerarCodigoInternoUnico();
            }

            // 2. [MODIFICACIÓN DE VALIDACIÓN] Ajuste para aceptar el código autogenerado
            // Solo validamos si el código no se pudo generar (no debería pasar)
            // o si el campo está vacío (aunque el frmProducto ya lo evita).
            if (obj.nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }
            if (obj.descripcion == "")
            {
                Mensaje += "Es necesario agregar la descripcion del Producto\n";
            }
            // 3. Chequeo de Mensaje y llamada a Capa de Datos
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return object_producto.Registrar(obj, out Mensaje);
            }
        }

        // [MODIFICADO] Método Editar
        //traemos editar de CN_Producto
        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }
            // [ATENCIÓN] En la edición, el código SIEMPRE debe venir con un valor,
            // por lo que si llega vacío, se trata como un error.
            if (string.IsNullOrWhiteSpace(obj.codigo) || obj.codigo == "GENERAR_INTERNO")
            {
                Mensaje += "El código del Producto no puede ser vacío al editar\n";
            }

            //Esto no va porque el codigo ya se genera solo
            /*if (obj.codigo == "")
            {
                Mensaje += "Es necesario agregar el codigo del Producto\n";
            }*/

            if (obj.descripcion == "")
            {
                Mensaje += "Es necesario agregar la descripcion del Producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return object_producto.Editar(obj, out Mensaje);
            }

        }

        //traemos eliminar de CN_Producto
        public bool Eliminar(Producto obj, out string Mensaje)
        {
            return object_producto.Eliminar(obj, out Mensaje);
        }
    }
}
