using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Retiro
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }
        public string Referencia { get; set; }
    }
}
