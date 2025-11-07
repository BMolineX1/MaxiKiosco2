using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_ReportesCaja
    {
        private readonly CD_ReportesCaja _cd = new CD_ReportesCaja();

        public DataTable Aperturas(DateTime desde, DateTime hasta, int? empleadoId = null)
            => _cd.ListarAperturas(desde, hasta, empleadoId);

        public DataTable ResumenPorAperturaId(int aperturaId)
            => _cd.ResumenPorAperturaId(aperturaId);

        public DataTable VentasPorApertura(int aperturaId)
            => _cd.ListarVentasPorApertura(aperturaId);

        public DataTable RetirosPorApertura(int aperturaId)
            => _cd.ListarRetirosPorApertura(aperturaId);
    }
}
