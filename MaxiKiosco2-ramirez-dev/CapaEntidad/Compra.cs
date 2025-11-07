namespace CapaEntidad
{
    public class Compra
    {
        public int id { get; set; }                         // compra.id_compra
        public DateTime fecharegistro { get; set; }         // lo setea la DB/SP
        public decimal montototal { get; set; }             // lo calcula el SP

        // IDs que usa el SP
        public int empleadoid { get; set; }                 // compra.empleado_id
        public int proveedorid { get; set; }                // compra.proveedor_id

        public string tipodocumento { get; set; } = "";     // compra.tipodocumento
        public string numerodocumento { get; set; } = "";   // compra.numerodocumento

        // Compatibilidad con código previo (evita NRE):
        public Usuario ousuario { get; set; } = new Usuario();
        public Proveedor oproveedor { get; set; } = new Proveedor();
    }
}