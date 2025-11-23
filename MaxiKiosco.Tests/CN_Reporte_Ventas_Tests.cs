// Proyecto de Tests / CN_Reporte_Ventas_Tests.cs
using CapaEntidad;
using CapaNegocio;
using MaxiKiosco.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxiKiosco.Tests
{
    [TestClass]
    public class CN_Reporte_Ventas_Tests
    {
        private CN_Reporte _cn;

        [TestInitialize]
        public void Setup()
        {
            var fakeRepo = new FakeReporteRepository();
            _cn = new CN_Reporte(fakeRepo);
        }

        [TestMethod]
        public void Venta_RangoCompleto2024_DeberiaDevolverTresVentas()
        {
            // Arrange
            string desde = "2024-01-01";
            string hasta = "2024-12-31";

            // Act
            string mensaje;
            List<ReporteVenta> lista = _cn.Venta(desde, hasta, out mensaje);

            // Assert
            Assert.AreEqual(3, lista.Count, "El rango completo debería devolver las 3 ventas fake.");
            Assert.IsTrue(string.IsNullOrEmpty(mensaje) || !mensaje.Contains("No se encontraron"),
                "Con datos no debería mostrar mensaje de 'No se encontraron ventas'.");
        }

        [TestMethod]
        public void Venta_RangoSoloEnero_DeberiaDevolverDosVentas()
        {
            string desde = "2024-01-01";
            string hasta = "2024-01-31";

            string mensaje;
            var lista = _cn.Venta(desde, hasta, out mensaje);

            Assert.AreEqual(2, lista.Count, "En enero deberían existir exactamente 2 ventas de prueba.");
        }

        [TestMethod]
        public void Venta_RangoSinDatos_DeberiaDevolverListaVaciaYMensaje()
        {
            string desde = "2023-01-01";
            string hasta = "2023-01-31";

            string mensaje;
            var lista = _cn.Venta(desde, hasta, out mensaje);

            Assert.AreEqual(0, lista.Count, "No debería haber ventas en 2023.");
            Assert.IsTrue(mensaje.Contains("No se encontraron", StringComparison.OrdinalIgnoreCase),
                "Debe indicar que no se encontraron ventas.");
        }

        [TestMethod]
        public void Venta_FechasVacias_DeberiaFallarValidacion()
        {
            string mensaje;
            var lista = _cn.Venta("", "", out mensaje);

            Assert.AreEqual(0, lista.Count);
            Assert.IsTrue(mensaje.Contains("obligatorias", StringComparison.OrdinalIgnoreCase),
                "Debe advertir que las fechas son obligatorias.");
        }

        [TestMethod]
        public void Venta_FormatoFechaIncorrecto_DeberiaFallarValidacion()
        {
            string mensaje;
            var lista = _cn.Venta("01-01-2024", "31-01-2024", out mensaje); // mal formato

            Assert.AreEqual(0, lista.Count);
            Assert.IsTrue(mensaje.Contains("formato", StringComparison.OrdinalIgnoreCase),
                "Debe advertir que el formato debe ser yyyy-MM-dd.");
        }

        [TestMethod]
        public void Venta_FechaInicioMayorQueFin_DeberiaFallarValidacion()
        {
            string mensaje;
            var lista = _cn.Venta("2024-02-01", "2024-01-01", out mensaje);

            Assert.AreEqual(0, lista.Count);
            Assert.IsTrue(mensaje.Contains("inicio no puede ser mayor", StringComparison.OrdinalIgnoreCase)
                          || mensaje.Contains("inicio no puede ser mayor que la fecha de fin", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void Venta_MontoTotalAcumuladoEnero_DeberiaSer3000()
        {
            string mensaje;
            var lista = _cn.Venta("2024-01-01", "2024-01-31", out mensaje);

            decimal total = lista.Sum(v => v.MontoTotal);
            Assert.AreEqual(3000m, total, "La suma de montos de enero debe ser 3000 (1000 + 2000).");
        }

        [TestMethod]
        public void Venta_ClienteCondicionIva_NoDebeVenirVacia()
        {
            string mensaje;
            var lista = _cn.Venta("2024-01-01", "2024-12-31", out mensaje);

            Assert.IsTrue(lista.Any(v => !string.IsNullOrWhiteSpace(v.ClienteCondicionIva)),
                "Al menos una venta debe tener Condición IVA seteada.");
        }

        [TestMethod]
        public void Venta_SiempreDevuelveListaNoNula()
        {
            string mensaje;
            var lista = _cn.Venta("2023-01-01", "2023-01-31", out mensaje);

            Assert.IsNotNull(lista, "Nunca debería devolver null, siempre una lista (quizás vacía).");
        }

        [TestMethod]
        public void Venta_UsoDeOverloadSinMensaje_DeberiaFuncionarIgual()
        {
            // Este usa la firma que usa la UI
            var lista = _cn.Venta("2024-01-01", "2024-01-31");

            Assert.AreEqual(2, lista.Count, "El overload sin mensaje debe comportarse igual que el de pruebas.");
        }
    }
}
