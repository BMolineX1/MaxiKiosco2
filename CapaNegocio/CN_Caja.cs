using System;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Caja
    {
        private readonly CD_Caja _cd;
        // 🎯 CORRECCIÓN CLAVE: Declarar '_datos' como CAMPO de la clase
        private readonly CD_Caja _datos = new CD_Caja();

        public CN_Caja(string cadenaConexion = null)
        {
            _cd = new CD_Caja(cadenaConexion);
        }

        // 🎯 Método público para verificar si la caja está abierta
        public int ObtenerIdCajaAbierta(int empleadoId)
        {
            // Usamos la hora actual para la verificación de la caja.
            return _datos.GetAperturaAbiertaIdPorEmpleado(DateTime.Now, empleadoId);
        }

        public bool AbrirCaja(DateTime fecha, int empleadoId, decimal montoInicial, string observaciones, out string mensaje)
            => _cd.AbrirCaja(fecha, empleadoId, montoInicial, observaciones, out mensaje);

        // ====== NUEVOS WRAPPERS por empleado + timestamp ======
        public AperturaCaja GetAperturaAbierta(DateTime ts, int empleadoId)
            => _cd.GetAperturaAbierta(ts, empleadoId);

        public int GetAperturaAbiertaIdPorEmpleado(DateTime ts, int empleadoId)
            => _cd.GetAperturaAbiertaIdPorEmpleado(ts, empleadoId);

        public bool HayCajaAbierta(DateTime ts, int empleadoId)
            => _cd.GetAperturaAbiertaIdPorEmpleado(ts, empleadoId) > 0;

        // (Opcional) mantener compatibilidad con firmas antiguas si las usás en otros lados
        // public AperturaCaja GetAperturaAbierta(DateTime fecha) => null;
        // public bool HayCajaAbierta(DateTime fecha) => false;

        public bool CerrarCaja(DateTime fecha, int empleadoId, decimal saldoReal, string observaciones, out string mensaje)
            => _cd.CerrarCaja(fecha, empleadoId, saldoReal, observaciones, out mensaje);
    }
}
