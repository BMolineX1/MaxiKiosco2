using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaNegocio;
using CapaEntidad;
using MaxiKiosco.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxiKiosco.Tests
{
    [TestClass]
    public class CN_Reporte_Compras_Tests
    {
        private CN_Reporte _cn;

        [TestInitialize]
        public void Setup()
        {
            // Usamos el fake para no depender de la BD real
            var fakeRepo = new FakeReporteRepository();
            _cn = new CN_Reporte(fakeRepo);
        }

        // 1) Rango completo, todos los proveedores
        [TestMethod]
        public void Compra_RangoCompleto2024_TodosProveedores_DeberiaDevolverCuatroCompras()
        {
            // Arrange
            string desde = "2024-01-01";
            string hasta = "2024-12-31";
            int idProveedor = 0; // 0 = TODOS
            string mensaje;

            // Act
            List<ReporteCompra> lista = _cn.Compra(desde, hasta, idProveedor, out mensaje);

            // Assert
            Assert.AreEqual(4, lista.Count, "Debería devolver las 4 compras del fake en 2024.");
            Assert.IsTrue(string.IsNullOrEmpty(mensaje), "No debería haber mensaje de error en un caso correcto.");
        }

        // 2) Solo enero, todos los proveedores
        [TestMethod]
        public void Compra_RangoSoloEnero_TodosProveedores_DeberiaDevolverUnaCompra()
        {
            // Arrange
            string desde = "2024-01-01";
            string hasta = "2024-01-31";
            int idProveedor = 0;
            string mensaje;

            // Act
            List<ReporteCompra> lista = _cn.Compra(desde, hasta, idProveedor, out mensaje);

            // Assert
            Assert.AreEqual(1, lista.Count, "En enero solo debería haber una compra.");
            Assert.IsTrue(string.IsNullOrEmpty(mensaje));
        }

        // 3) Solo febrero, todos los proveedores
        [TestMethod]
        public void Compra_RangoFebrero_TodosProveedores_DeberiaDevolverDosCompras()
        {
            // Arrange
            string desde = "2024-02-01";
            string hasta = "2024-02-29";
            int idProveedor = 0;
            string mensaje;

            // Act
            List<ReporteCompra> lista = _cn.Compra(desde, hasta, idProveedor, out mensaje);

            // Assert
            Assert.AreEqual(2, lista.Count, "En febrero debería haber dos compras.");
            Assert.IsTrue(string.IsNullOrEmpty(mensaje));
        }

        // 4) Rango completo, solo proveedor 1
        [TestMethod]
        public void Compra_RangoCompleto2024_Proveedor1_DeberiaDevolverDosCompras()
        {
            // Arrange
            string desde = "2024-01-01";
            string hasta = "2024-12-31";
            int idProveedor = 1;
            string mensaje;

            // Act
            List<ReporteCompra> lista = _cn.Compra(desde, hasta, idProveedor, out mensaje);

            // Assert
            Assert.AreEqual(2, lista.Count, "Proveedor 1 debería tener dos compras en el rango.");
            Assert.IsTrue(lista.All(c => c.RazonSocial == "Proveedor 1" || c.DocumentoProveedor == "P1"),
                          "Todas las compras deben ser del proveedor 1 (ajustar según campos del fake).");
            Assert.IsTrue(string.IsNullOrEmpty(mensaje));
        }

        // 5) Rango completo, solo proveedor 2
        [TestMethod]
        public void Compra_RangoCompleto2024_Proveedor2_DeberiaDevolverUnaCompra()
        {
            // Arrange
            string desde = "2024-01-01";
            string hasta = "2024-12-31";
            int idProveedor = 2;
            string mensaje;

            // Act
            List<ReporteCompra> lista = _cn.Compra(desde, hasta, idProveedor, out mensaje);

            // Assert
            Assert.AreEqual(1, lista.Count, "Proveedor 2 debería tener una sola compra en el rango.");
            Assert.IsTrue(string.IsNullOrEmpty(mensaje));
        }

        // 6) Rango sin resultados
        [TestMethod]
        public void Compra_RangoSinResultados_DeberiaDevolverListaVaciaYMensaje()
        {
            // Arrange
            string desde = "2030-01-01";
            string hasta = "2030-12-31";
            int idProveedor = 0;
            string mensaje;

            // Act
            List<ReporteCompra> lista = _cn.Compra(desde, hasta, idProveedor, out mensaje);

            // Assert
            Assert.AreEqual(0, lista.Count, "En 2030 no debería haber compras en el fake.");
            Assert.IsTrue(mensaje.Contains("no se encontraron", StringComparison.OrdinalIgnoreCase)
                          || mensaje.Contains("sin resultados", StringComparison.OrdinalIgnoreCase),
                          "Debería devolver un mensaje indicando que no se encontraron compras.");
        }

        // 7) Fechas vacías
        [TestMethod]
        public void Compra_FechasVacias_DeberiaDevolverErrorDeValidacion()
        {
            // Arrange
            string desde = "";
            string hasta = "";
            int idProveedor = 0;
            string mensaje;

            // Act
            List<ReporteCompra> lista = _cn.Compra(desde, hasta, idProveedor, out mensaje);

            // Assert
            Assert.AreEqual(0, lista.Count, "Con fechas vacías no se debe devolver ninguna compra.");
            Assert.IsFalse(string.IsNullOrEmpty(mensaje), "Debe devolver un mensaje de error.");
            Assert.IsTrue(mensaje.Contains("fecha", StringComparison.OrdinalIgnoreCase),
                          "El mensaje debería hacer referencia a las fechas.");
        }

        // 8) Formato de fecha inválido
        [TestMethod]
        public void Compra_FormatoFechaInvalido_DeberiaDevolverErrorDeFormato()
        {
            // Arrange
            string desde = "01-2024-01";  // formato incorrecto
            string hasta = "2024/12/31";  // formato incorrecto
            int idProveedor = 0;
            string mensaje;

            // Act
            List<ReporteCompra> lista = _cn.Compra(desde, hasta, idProveedor, out mensaje);

            // Assert
            Assert.AreEqual(0, lista.Count);
            Assert.IsFalse(string.IsNullOrEmpty(mensaje));
            Assert.IsTrue(mensaje.Contains("formato", StringComparison.OrdinalIgnoreCase)
                          || mensaje.Contains("yyyy-MM-dd", StringComparison.OrdinalIgnoreCase),
                          "El mensaje debería indicar el formato esperado de la fecha.");
        }

        // 9) Fecha inicio > fecha fin
        [TestMethod]
        public void Compra_FechaInicioMayorQueFin_DeberiaDevolverErrorDeRango()
        {
            // Arrange
            string desde = "2024-12-31";
            string hasta = "2024-01-01";
            int idProveedor = 0;
            string mensaje;

            // Act
            List<ReporteCompra> lista = _cn.Compra(desde, hasta, idProveedor, out mensaje);

            // Assert
            Assert.AreEqual(0, lista.Count);
            Assert.IsFalse(string.IsNullOrEmpty(mensaje));
            Assert.IsTrue(mensaje.Contains("inicio", StringComparison.OrdinalIgnoreCase)
                          || mensaje.Contains("mayor", StringComparison.OrdinalIgnoreCase),
                          "El mensaje debería indicar que la fecha de inicio no puede ser mayor que la final.");
        }

        // 10) Id de proveedor negativo
        [TestMethod]
        public void Compra_IdProveedorNegativo_DeberiaDevolverErrorDeProveedor()
        {
            // Arrange
            string desde = "2024-01-01";
            string hasta = "2024-12-31";
            int idProveedor = -1;
            string mensaje;

            // Act
            List<ReporteCompra> lista = _cn.Compra(desde, hasta, idProveedor, out mensaje);

            // Assert
            Assert.AreEqual(0, lista.Count, "Con id de proveedor negativo no se deben devolver compras.");
            Assert.IsFalse(string.IsNullOrEmpty(mensaje));
            Assert.IsTrue(mensaje.Contains("proveedor", StringComparison.OrdinalIgnoreCase)
                          || mensaje.Contains("válido", StringComparison.OrdinalIgnoreCase),
                          "El mensaje debería indicar que el proveedor es inválido.");
        }
        // 11) Sobrecarga sin mensaje: fechas vacías => lista vacía
        [TestMethod]
        public void Compra_SinMensaje_FechasVacias_DeberiaDevolverListaVacia()
        {
            // Arrange
            string desde = "";
            string hasta = "";
            int idProveedor = 0;

            // Act
            List<ReporteCompra> lista = _cn.Compra(desde, hasta, idProveedor);

            // Assert
            Assert.IsNotNull(lista, "Nunca debe devolver null.");
            Assert.AreEqual(0, lista.Count, "Con fechas vacías, la lista debe quedar vacía.");
        }

        // 12) Sobrecarga sin mensaje: rango válido => no null
        [TestMethod]
        public void Compra_SinMensaje_RangoValido_NoDeberiaDevolverNull()
        {
            // Arrange
            string desde = "2024-01-01";
            string hasta = "2024-12-31";
            int idProveedor = 0;

            // Act
            List<ReporteCompra> lista = _cn.Compra(desde, hasta, idProveedor);

            // Assert
            Assert.IsNotNull(lista, "La sobrecarga sin mensaje también debe devolver siempre una lista, nunca null.");
        }

        // 13) Proveedor existente pero sin compras en el rango => lista vacía y mensaje
        [TestMethod]
        public void Compra_RangoValido_ProveedorSinCompras_DeberiaDevolverListaVaciaYMensaje()
        {
            // Arrange
            string desde = "2035-01-01";
            string hasta = "2035-12-31";
            int idProveedor = 1; // proveedor "válido", pero fuera del rango configurado en el fake
            string mensaje;

            // Act
            List<ReporteCompra> lista = _cn.Compra(desde, hasta, idProveedor, out mensaje);

            // Assert
            Assert.IsNotNull(lista);
            Assert.AreEqual(0, lista.Count, "En un año futuro el fake no debería devolver compras.");
            Assert.AreEqual("No se encontraron compras en el rango indicado.", mensaje);
        }
    }
}
