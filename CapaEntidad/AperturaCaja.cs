using System;

namespace CapaEntidad
{
    public class AperturaCaja
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public decimal MontoInicial { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; } // opcional si lo querés mapear

        
    }
}
