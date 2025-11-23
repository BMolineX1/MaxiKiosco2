// Proyecto de Tests / Fakes/FakeReporteRepository.cs
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MaxiKiosco.Tests.Fakes
{
    public class FakeReporteRepository : IReporteRepository
    {
        private readonly List<ReporteVenta> _ventas;
        private readonly List<ReporteCompra> _compras;

        public FakeReporteRepository()
        {
            _ventas = new List<ReporteVenta>
            {
                new ReporteVenta
                {
                    FechaRegistro = new DateTime(2024, 01, 10),
                    NumeroDocumento = "V001",
                    TipoDocumento = "Factura A",
                    DocumentoCliente = "111",
                    NombreCliente = "Cliente 1",
                    UsuarioRegistro = "User1",
                    CodigoProducto = "P1",
                    NombreProducto = "Prod1",
                    Categoria = "Bebidas",
                    PrecioVenta = 100m,
                    Cantidad = 10m,
                    SubTotal = 1000m,
                    MontoTotal = 1000m,
                    ClienteCondicionIva = "Responsable Inscripto"
                },
                new ReporteVenta
                {
                    FechaRegistro = new DateTime(2024, 01, 20),
                    NumeroDocumento = "V002",
                    TipoDocumento = "Factura B",
                    DocumentoCliente = "222",
                    NombreCliente = "Cliente 2",
                    UsuarioRegistro = "User2",
                    CodigoProducto = "P2",
                    NombreProducto = "Prod2",
                    Categoria = "Snacks",
                    PrecioVenta = 200m,
                    Cantidad = 10m,
                    SubTotal = 2000m,
                    MontoTotal = 2000m,
                    ClienteCondicionIva = "Monotributo"
                },
                new ReporteVenta
                {
                    FechaRegistro = new DateTime(2024, 02, 10),
                    NumeroDocumento = "V003",
                    TipoDocumento = "Ticket",
                    DocumentoCliente = "",
                    NombreCliente = "Consumidor Final",
                    UsuarioRegistro = "User1",
                    CodigoProducto = "P3",
                    NombreProducto = "Prod3",
                    Categoria = "Bebidas",
                    PrecioVenta = 50m,
                    Cantidad = 10m,
                    SubTotal = 500m,
                    MontoTotal = 500m,
                    ClienteCondicionIva = "Consumidor Final"
                }
            };

            _compras = new List<ReporteCompra>
            {
                new ReporteCompra
                {
                    FechaRegistro = new DateTime(2024, 01, 05),
                    TipoDocumento = "Factura A",
                    NumeroDocumento = "C001",
                    MontoTotal = 1500m,
                    UsuarioRegistro = "User1",
                    DocumentoProveedor = "30-123",
                    RazonSocial = "Proveedor 1",
                    CodigoProducto = "P1",
                    NombreProducto = "Prod1",
                    Categoria = "Bebidas",
                    PrecioCompra = 50m,
                    PrecioVenta = 100m,
                    Cantidad = 30m,
                    SubTotal = 1500m
                },
                new ReporteCompra
                {
                    FechaRegistro = new DateTime(2024, 01, 25),
                    TipoDocumento = "Factura B",
                    NumeroDocumento = "C002",
                    MontoTotal = 3000m,
                    UsuarioRegistro = "User2",
                    DocumentoProveedor = "30-456",
                    RazonSocial = "Proveedor 2",
                    CodigoProducto = "P2",
                    NombreProducto = "Prod2",
                    Categoria = "Snacks",
                    PrecioCompra = 100m,
                    PrecioVenta = 200m,
                    Cantidad = 30m,
                    SubTotal = 3000m
                },
                new ReporteCompra
                {
                    FechaRegistro = new DateTime(2024, 02, 03),
                    TipoDocumento = "Factura A",
                    NumeroDocumento = "C003",
                    MontoTotal = 500m,
                    UsuarioRegistro = "User1",
                    DocumentoProveedor = "30-123",
                    RazonSocial = "Proveedor 1",
                    CodigoProducto = "P3",
                    NombreProducto = "Prod3",
                    Categoria = "Bebidas",
                    PrecioCompra = 20m,
                    PrecioVenta = 50m,
                    Cantidad = 25m,
                    SubTotal = 500m
                }
            };
        }

        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            var fi = DateTime.ParseExact(fechainicio, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var ff = DateTime.ParseExact(fechafin, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            return _ventas
                .Where(v => v.FechaRegistro.Date >= fi.Date && v.FechaRegistro.Date <= ff.Date)
                .ToList();
        }

        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            var fi = DateTime.ParseExact(fechainicio, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var ff = DateTime.ParseExact(fechafin, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            IEnumerable<ReporteCompra> query = _compras
                .Where(c => c.FechaRegistro.Date >= fi.Date && c.FechaRegistro.Date <= ff.Date);

            // Mapeamos idproveedor ficticio:
            // 0 = TODOS, 1 = Proveedor 1, 2 = Proveedor 2
            if (idproveedor == 1)
                query = query.Where(c => c.RazonSocial == "Proveedor 1");
            else if (idproveedor == 2)
                query = query.Where(c => c.RazonSocial == "Proveedor 2");

            return query.ToList();
        }

        public List<ReporteVentaDetalle> DetalleVentaPorNumero(string numeroDocumento)
        {
            var venta = _ventas.FirstOrDefault(v => v.NumeroDocumento == numeroDocumento);
            if (venta == null) return new List<ReporteVentaDetalle>();

            return new List<ReporteVentaDetalle>
            {
                new ReporteVentaDetalle
                {
                    VentaId = 1,
                    NumeroDocumento = venta.NumeroDocumento,
                    TipoDocumento = venta.TipoDocumento,
                    Fecha = venta.FechaRegistro,
                    ClienteDni = venta.DocumentoCliente,
                    ClienteNombre = venta.NombreCliente,
                    ClienteCondicionIva = venta.ClienteCondicionIva,
                    ProductoId = 1,
                    ProductoCodigo = venta.CodigoProducto,
                    ProductoNombre = venta.NombreProducto,
                    Categoria = venta.Categoria,
                    Cantidad = venta.Cantidad,
                    PrecioUnitario = venta.PrecioVenta,
                    Subtotal = venta.SubTotal
                }
            };
        }
    }
}
