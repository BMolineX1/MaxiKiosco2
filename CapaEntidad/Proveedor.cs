﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Proveedor
    {
        public int id {  get; set; }
        public string nombre { get; set; }
        public string cuit { get; set; }
        public string telefono { get; set; }
        public string razonsocial { get; set; }   // <--- NUEVO
        public string direccion {  get; set; }
        public string email { get; set; }
        public bool estado { get; set; }
        public string fecharegistro { get; set; }
    }
}
