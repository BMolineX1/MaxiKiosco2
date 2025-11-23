using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Retiro
    {
        private readonly CD_Retiro _cd = new CD_Retiro();

        public int Registrar(Retiro r, out string mensaje) => _cd.Registrar(r, out mensaje);

        public List<Retiro> Listar(DateTime? desde, DateTime? hasta) => _cd.Listar(desde, hasta);
    }
}
