using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Testing
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaNegocio;
using CapaEntidad;
using MaxiKiosco.UnitTests.Fakes;

[TestClass]
public class TestModuloCategoria
{
    // PRUEBA 1: Verificar que se listen TODAS las categorías (Activas e Inactivas)
    [TestMethod]
    public void Listar_DebeRetornarTodasLasCategorias()
    {
        // ARRANGE
        var fakeRepo = new FakeCategoriaRepository();
        var cnCategoria = new CN_Categoria(fakeRepo); // Inyección del Fake

        // ACT
        List<Categoria> resultado = cnCategoria.Listar();

        // ASSERT
        // Asumiendo que el Fake tiene 4 categorías en total (como se definió arriba)
        Assert.AreEqual(4, resultado.Count, "ERROR: El método Listar() debe retornar la lista completa.");
    }

    // PRUEBA 2: Verificar que se listen SÓLO las categorías Activas
    [TestMethod]
    public void ListarActivos_DebeRetornarSoloCategoriasActivas()
    {
        // ARRANGE
        var fakeRepo = new FakeCategoriaRepository();
        var cnCategoria = new CN_Categoria(fakeRepo);

        // ACT
        List<Categoria> resultado = cnCategoria.ListarActivos();

        // ASSERT
        // Asumiendo que 2 de las 4 categorías son Activas
        Assert.AreEqual(2, resultado.Count, "ERROR: El método ListarActivos() debe retornar solo las categorías con estado=true.");
    }

    // PRUEBA 3: Verificar que la CN ejecute el registro correctamente
    [TestMethod]
    public void Registrar_DebeRetornarUnIdValido()
    {
        // ARRANGE
        var fakeRepo = new FakeCategoriaRepository();
        var cnCategoria = new CN_Categoria(fakeRepo);

        Categoria nuevaCategoria = new Categoria()
        {
            nombre_categoria = "Limpieza",
            estado = true,
            p_aumento = 15.00m
        };

        string mensaje;

        // ACT
        int idGenerado = cnCategoria.Registrar(nuevaCategoria, out mensaje);

        // ASSERT
        // El Fake devuelve un ID mayor que el ID máximo actual (> 4).
        Assert.IsTrue(idGenerado > 0, "ERROR: El registro debe retornar un ID de categoría válido (mayor a 0).");
        Assert.AreEqual("Fake: Categoría registrada.", mensaje, "ERROR: La CN no está devolviendo el mensaje de éxito del repositorio.");
    }

    // PRUEBA 4: Verificar que la CN ejecute la edición correctamente
    [TestMethod]
    public void Editar_DebeRetornarTrue()
    {
        // ARRANGE
        var fakeRepo = new FakeCategoriaRepository();
        var cnCategoria = new CN_Categoria(fakeRepo);

        Categoria categoriaAEditar = new Categoria() { id_categoria = 1, nombre_categoria = "Bebidas Frias" };
        string mensaje;

        // ACT
        bool resultado = cnCategoria.Editar(categoriaAEditar, out mensaje);

        // ASSERT
        Assert.IsTrue(resultado, "ERROR: La CN debe retornar True al editar la categoría.");
    }

    // PRUEBA 5: Verificar que la CN ejecute la eliminación correctamente
    [TestMethod]
    public void Eliminar_DebeRetornarTrue()
    {
        // ARRANGE
        var fakeRepo = new FakeCategoriaRepository();
        var cnCategoria = new CN_Categoria(fakeRepo);

        Categoria categoriaAEliminar = new Categoria() { id_categoria = 1 };
        string mensaje;

        // ACT
        bool resultado = cnCategoria.Eliminar(categoriaAEliminar, out mensaje);

        // ASSERT
        Assert.IsTrue(resultado, "ERROR: La CN debe retornar True al eliminar la categoría.");
    }

    // PRUEBA 6: Editar con porcentaje de aumento inválido (Validación de Negocio)
    [TestMethod]
    public void Categoria_EditarPorcentajeInvalido_DebeRetornarFalse()
    {
        // ARRANGE
        var fakeRepo = new FakeCategoriaRepository();
        var cnCategoria = new CN_Categoria(fakeRepo);
        string mensajeEsperado = "El porcentaje debe ser mayor o igual a 0"; // Asumida
        string mensajeObtenido;

        // ACT
        // Si la CN valida el porcentaje antes de llamar al Repositorio, debe retornar false.
        bool resultado = cnCategoria.Editar(new Categoria() { id_categoria = 1, nombre_categoria = "Bebidas", p_aumento = -5.00m }, out mensajeObtenido);

        // ASSERT
        Assert.IsFalse(resultado, "ERROR: La CN editó una categoría con porcentaje negativo.");
        // NOTA: Esta prueba asume que la CN_Categoria tiene la lógica: IF p_aumento < 0 THEN return false.
    }

    // PRUEBA 7: Eliminar una categoría no existente
    [TestMethod]
    public void Categoria_EliminarNoExistente_DebeRetornarFalse()
    {
        // ARRANGE
        var fakeRepo = new FakeCategoriaRepository();
        var cnCategoria = new CN_Categoria(fakeRepo);
        string mensaje;

        // ACT
        // En el Fake, simulamos que el Repositorio de Datos real no encontró la categoría a borrar, 
        // y por lo tanto devuelve 'false'
        // En la práctica, el Fake necesitaría lógica para verificar si el ID existe, pero 
        // para este nivel de prueba, asumimos que si la CN falla en la validación, retorna false.

        // **NOTA DE MODIFICACIÓN DEL FAKE:** Para que esta prueba sea precisa, deberías modificar
        // el FakeCategoriaRepository.Eliminar() para que devuelva 'false' si el ID es muy alto (ej: 999).
        bool resultado = cnCategoria.Eliminar(new Categoria() { id_categoria = 999 }, out mensaje);

        // ASSERT
        // Si la CN tiene una validación que dice "sólo se elimina si se encuentra", esto debería fallar.
        Assert.IsFalse(resultado, "ERROR: La CN eliminó una categoría con un ID irreal (999).");
    }

    // PRUEBA 8: ListarActivos debe filtrar correctamente el estado
    [TestMethod]
    public void Categoria_ListarActivos_DebeTenerEstadoTrue()
    {
        // ARRANGE
        var fakeRepo = new FakeCategoriaRepository();
        var cnCategoria = new CN_Categoria(fakeRepo);

        // ACT
        var activas = cnCategoria.ListarActivos();

        // ASSERT
        // Verifica que NINGUNA categoría listada tenga el estado 'false'
        Assert.IsFalse(activas.Any(c => c.estado == false), "ERROR: ListarActivos retornó una categoría con estado Inactivo.");
    }

    // PRUEBA 9: Registrar con nombre de categoría vacío (Validación de Negocio)
    [TestMethod]
    public void Categoria_RegistrarNombreVacio_DebeRetornarCero()
    {
        // ARRANGE
        var fakeRepo = new FakeCategoriaRepository();
        var cnCategoria = new CN_Categoria(fakeRepo);
        string mensajeObtenido;

        // ACT
        // Si la CN valida antes de llamar al Repositorio, debe retornar 0 y un mensaje de error
        int idGenerado = cnCategoria.Registrar(new Categoria() { nombre_categoria = "", estado = true }, out mensajeObtenido);

        // ASSERT
        Assert.AreEqual(0, idGenerado, "ERROR: La CN registró una categoría con nombre vacío.");
    }

    // PRUEBA 10: Editar solo el estado (Desactivar una categoría)
    [TestMethod]
    public void Categoria_EditarSoloEstado_DebeRetornarTrue()
    {
        // ARRANGE
        var fakeRepo = new FakeCategoriaRepository();
        var cnCategoria = new CN_Categoria(fakeRepo);
        string mensaje;

        // ACT
        // Editamos la categoría 3 (Fiambreria) y la ponemos Inactiva (false)
        bool resultado = cnCategoria.Editar(new Categoria() { id_categoria = 3, nombre_categoria = "Fiambreria", estado = false }, out mensaje);

        // ASSERT
        Assert.IsTrue(resultado, "ERROR: La CN no pudo editar solo el campo de estado.");
    }
}
