using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public interface IReporteRepository
    {
        List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor);
        List<ReporteVenta> Venta(string fechainicio, string fechafin);
        List<ReporteVentaDetalle> DetalleVentaPorNumero(string numeroDocumento);
    }
}
