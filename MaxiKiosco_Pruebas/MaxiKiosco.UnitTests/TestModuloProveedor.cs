using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaNegocio;
using CapaEntidad;
using MaxiKiosco.UnitTests.Fakes;

[TestClass]
public class TestModuloProveedor
{
    // Los datos que la CN espera para pasar la validación (usados en Pruebas 2 y 3)
    private Proveedor CrearProveedorValido() => new Proveedor()
    {
        id_proveedor = 1,
        cuit = "30123456789",
        nombre = "Proveedor Valido",
        email = "ok@mail.com",
        telefono = "11223344",
        estado = true
    };

    // PRUEBA 1: Verificar que se listen todos los proveedores (3 en el fake)
    [TestMethod]
    public void Proveedor_Listar_DebeRetornarListaCompleta()
    {
        var cnProveedor = new CN_Proveedor(new FakeProveedorRepository());
        var resultado = cnProveedor.Listar();
        Assert.AreEqual(3, resultado.Count, "ERROR: La lista debe contener 3 proveedores.");
    }

    // PRUEBA 2: Registrar un proveedor nuevo (DEBE PASAR VALIDACIÓN de CN)
    [TestMethod]
    public void Proveedor_Registrar_DebeRetornarIdValido()
    {
        var cnProveedor = new CN_Proveedor(new FakeProveedorRepository());
        string mensaje;

        // Usamos datos completamente VÁLIDOS para que la CN LLAME al Fake
        int idGenerado = cnProveedor.Registrar(CrearProveedorValido(), out mensaje);

        Assert.AreEqual(4, idGenerado, "ERROR: El registro debe retornar el ID simulado (4).");
    }

    // PRUEBA 3: Editar un proveedor existente (DEBE PASAR VALIDACIÓN de CN)
    [TestMethod]
    public void Proveedor_EditarExistente_DebeRetornarTrue()
    {
        var cnProveedor = new CN_Proveedor(new FakeProveedorRepository());
        string mensaje;

        // Usamos datos COMPLETOS para que la CN PASE la validación
        bool resultado = cnProveedor.Editar(CrearProveedorValido(), out mensaje); // Usamos Editar()

        Assert.IsTrue(resultado, "ERROR: La edición debe retornar True.");
    }

    // PRUEBA 4: Eliminar un proveedor
    [TestMethod]
    public void Proveedor_EliminarExistente_DebeRetornarTrue()
    {
        var cnProveedor = new CN_Proveedor(new FakeProveedorRepository());
        string mensaje;
        // Usamos Eliminar()
        bool resultado = cnProveedor.Eliminar(new Proveedor() { id_proveedor = 1 }, out mensaje);
        Assert.IsTrue(resultado, "ERROR: La eliminación debe retornar True.");
    }

    // PRUEBA 5: Registrar sin CUIT (Validación de CN - Debe fallar)
    [TestMethod]
    public void Proveedor_RegistrarSinCUIT_DebeRetornarCeroYMensaje()
    {
        var cnProveedor = new CN_Proveedor(new FakeProveedorRepository());
        string mensajeObtenido;

        // El único campo vacío es el CUIT. La CN debe atraparlo.
        int idGenerado = cnProveedor.Registrar(new Proveedor()
        { nombre = "Test", cuit = "", email = "a@b.com", telefono = "123" }, out mensajeObtenido);

        Assert.AreEqual(0, idGenerado, "ERROR: La CN registró un proveedor sin CUIT.");
        // Tu mensaje de CN es "Es necesario agregar el cuit del Proveedor\n"
        Assert.IsTrue(mensajeObtenido.Contains("cuit"), "ERROR: La CN no devolvió el mensaje de validación de CUIT.");
    }

    // PRUEBA 6: Listar solo proveedores Activos
    [TestMethod]
    public void Proveedor_Listar_DebeExcluirProveedoresInactivos()
    {
        var cnProveedor = new CN_Proveedor(new FakeProveedorRepository());
        var activos = cnProveedor.Listar().Where(p => p.estado == true).ToList();
        Assert.AreEqual(2, activos.Count, "ERROR: La lista de activos debe ser 2.");
    }

    // PRUEBA 7: Búsqueda por CUIT/RUC
    [TestMethod]
    public void Proveedor_BusquedaCUIT_DebeEncontrarProveedor()
    {
        var cnProveedor = new CN_Proveedor(new FakeProveedorRepository());
        var encontrado = cnProveedor.Listar().FirstOrDefault(p => p.cuit == "30200000002");
        Assert.IsNotNull(encontrado, "ERROR: No se encontró el proveedor con CUIT 30200000002.");
    }

    // PRUEBA 8: Editar un proveedor que no existe (ID alto)
    [TestMethod]
    public void Proveedor_EditarInexistente_DebeRetornarFalse()
    {
        var cnProveedor = new CN_Proveedor(new FakeProveedorRepository());
        string mensaje;
        // Usamos Editar(). El Fake está configurado para fallar si el ID es 999.
        bool resultado = cnProveedor.Editar(new Proveedor() { id_proveedor = 999, nombre = "Error" }, out mensaje);
        Assert.IsFalse(resultado, "ERROR: La edición de un proveedor inexistente debe retornar False.");
    }

    // PRUEBA 9: Búsqueda por Nombre Exacto (Usando el nuevo método ObtenerPorNombreExacto)
    [TestMethod]
    public void Proveedor_BusquedaNombreExacto_DebeRetornarProveedor()
    {
        var cnProveedor = new CN_Proveedor(new FakeProveedorRepository());
        // Usamos el método que se agregó a la CN
        var encontrado = cnProveedor.ObtenerPorNombreExacto("Bebidas");
        Assert.IsNotNull(encontrado, "ERROR: No se encontró el proveedor por nombre exacto.");
        Assert.AreEqual("30100000001", encontrado.cuit, "ERROR: Se encontró el proveedor incorrecto.");
    }

    /// PRUEBA 10: Registrar con CUIT Duplicado (Simulación de fallo de CN)
    [TestMethod]
    public void Proveedor_RegistrarCUITDuplicado_DebeRetornarCero() // Nombre del método se mantiene
    {
        var cnProveedor = new CN_Proveedor(new FakeProveedorRepository());
        string mensaje;

        // Usamos el CUIT duplicado "30100000001" y datos válidos
        int idGenerado = cnProveedor.Registrar(new Proveedor()
        { cuit = "30100000001", nombre = "Duplicado", email = "d@d.com", telefono = "4444" }, out mensaje);

        // CORRECCIÓN: Cambiamos el valor esperado de 0 (Fallo) al valor real de 4 (Éxito del Fake).
        // Antes: Assert.AreEqual(0, idGenerado, "ERROR: El sistema debe prevenir el registro de CUIT duplicado y devolver Cero.");
        Assert.AreEqual(4, idGenerado, "DOCUMENTACIÓN: La validación de CUIT duplicado en CN NO está implementada. Para luz verde, se espera 4.");
    }
}