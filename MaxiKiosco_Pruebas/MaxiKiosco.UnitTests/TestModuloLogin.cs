
using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using MaxiKiosco.UnitTests.Fakes; // Referencia a nuestra capa Fake
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq; // Necesario para el .Where()

[TestClass]
public class TestModuloLogin
{

    // PRUEBA 1: Login con usuario valido 
    [TestMethod]
    public void Login_ConCredencialesAdminValidas_DeberiaRetornarUsuario()
    {
        // ARRANGE (Preparar)
        var fakeRepo = new FakeUsuarioRepository();

        // Inyectamos el repositorio falso a la Capa de Negocio (CN)
        var cnUsuario = new CN_Usuario(fakeRepo);

        string usuarioTest = "admin";
        string claveTest = "12345";

        // ACT (Actuar)
        // Llamamos al mismo patrón de lógica que tienes en tu Login.cs: Listar y filtrar
        Usuario ousuario = cnUsuario.Listar()
            .Where(u => u.cuenta_usuario == usuarioTest && u.contrasena == claveTest)
            .FirstOrDefault();

        // ASSERT (Afirmar)
        // 1. Verificar que se encontró un usuario
        Assert.IsNotNull(ousuario, "ERROR: La CN debería haber encontrado al usuario 'admin'.");

        // 2. Verificar que el usuario tiene el rol correcto (si aplica)
        Assert.IsTrue(ousuario.esAdmin, "ERROR: El usuario 'admin' no fue reconocido como administrador.");
    }

    // PRUEBA 2: Login con usuario no valido
    [TestMethod]
    public void Login_ConCredencialesInvalidas_DeberiaRetornarNull()
    {
        // ARRANGE (Preparar)
        var fakeRepo = new FakeUsuarioRepository();
        var cnUsuario = new CN_Usuario(fakeRepo);

        string usuarioTest = "usuario_invalido";
        string claveTest = "clave_erronea";

        // ACT (Actuar)
        Usuario ousuario = cnUsuario.Listar()
            .Where(u => u.cuenta_usuario == usuarioTest && u.contrasena == claveTest)
            .FirstOrDefault();

        // ASSERT (Afirmar)
        // Esperamos que no haya encontrado a nadie
        Assert.IsNull(ousuario, "ERROR: No se debería haber encontrado ningún usuario con credenciales inválidas.");
    }

    // PRUEBA 3:Login con Credenciales de Usuario No-Administrador
    [TestMethod]
    public void Login_ConCredencialesUsuarioNormal_DeberiaRetornarUsuarioYNoSerAdmin()
    {
        // ARRANGE
        var fakeRepo = new FakeUsuarioRepository();
        var cnUsuario = new CN_Usuario(fakeRepo);

        string usuarioTest = "user";
        string claveTest = "pass";

        // ACT
        Usuario ousuario = cnUsuario.Listar()
            .Where(u => u.cuenta_usuario == usuarioTest && u.contrasena == claveTest)
            .FirstOrDefault();

        // ASSERT
        // 1. Debe encontrar al usuario
        Assert.IsNotNull(ousuario, "ERROR: No se encontró al usuario normal 'user'.");

        // 2. Debe verificar que NO es administrador (el caso de uso específico)
        Assert.IsFalse(ousuario.esAdmin, "ERROR: El usuario 'user' no debe ser reconocido como administrador.");
    }

    // PRUEBA 4:Login con contraseña vacia o null
    [TestMethod]
    public void Login_ConContrasenaVacia_DeberiaRetornarNull()
    {
        // ARRANGE
        var fakeRepo = new FakeUsuarioRepository();
        var cnUsuario = new CN_Usuario(fakeRepo);

        string usuarioTest = "admin";
        string claveTest = ""; // Contraseña vacía

        // ACT
        Usuario ousuario = cnUsuario.Listar()
            .Where(u => u.cuenta_usuario == usuarioTest && u.contrasena == claveTest)
            .FirstOrDefault();

        // ASSERT
        // Se espera que, al no coincidir la contraseña vacía con el valor real ("12345"),
        // el filtro no encuentre nada.
        Assert.IsNull(ousuario, "ERROR: El login no debe permitir acceso con contraseña vacía.");
    }


    // PRUEBA 5: Login con Datos Parciales (Usuario que coincide con la clave de otro)
    [TestMethod]
    public void Login_ConUsuarioExistentePeroClaveAjena_DeberiaRetornarNull()
    {
        // ARRANGE
        var fakeRepo = new FakeUsuarioRepository();
        var cnUsuario = new CN_Usuario(fakeRepo);

        // El usuario existe en el Fake
        string usuarioTest = "inactivo";
        // La clave pertenece a 'admin' y NO a 'inactivo'
        string claveTest = "12345";

        // ACT
        Usuario ousuario = cnUsuario.Listar()
            .Where(u => u.cuenta_usuario == usuarioTest && u.contrasena == claveTest)
            .FirstOrDefault();

        // ASSERT
        // Esperamos que el filtro compuesto (AND) no encuentre coincidencias.
        Assert.IsNull(ousuario, "ERROR: La CN no está validando la combinación exacta usuario/contraseña.");
    }

    // PRUEBA 6: Registrar un usuario nuevo
    [TestMethod]
    public void Usuario_RegistrarNuevoUsuario_DebeRetornarIdValido()
    {
        // ARRANGE
        var fakeRepo = new FakeUsuarioRepository();
        var cnUsuario = new CN_Usuario(fakeRepo);
        string mensaje;

        // ACT
        // El fake retorna un ID > 0 simulando el éxito de la BD
        int idGenerado = cnUsuario.Registrar(new Usuario() { cuenta_usuario = "nuevo", contrasena = "xyz" }, out mensaje);

        // ASSERT
        Assert.IsTrue(idGenerado > 0, "ERROR: La CN no está registrando correctamente el usuario.");
        // NOTA: Si la CN tiene lógica para 'usuario ya existe', aquí se debe probar la validación.
    }

    // PRUEBA 7: Registrar sin DNI
    [TestMethod]
    public void Usuario_RegistrarSinDni_DebeRetornarCeroYMensaje()
    {
        // ARRANGE
        var fakeRepo = new FakeUsuarioRepository();
        var cnUsuario = new CN_Usuario(fakeRepo);
        string mensajeObtenido;

        // Usuario con DNI vacío, lo que debe activar la validación en la CN
        Usuario usuarioSinDni = new Usuario()
        {
            nombre = "Test",
            apellido = "Test",
            dni = "",
            contrasena = "123"
        };

        // ACT
        // Esperamos que la CN falle en la validación y retorne 0 (int)
        int idGenerado = cnUsuario.Registrar(usuarioSinDni, out mensajeObtenido);

        // ASSERT
        // 1. Debe fallar el registro
        Assert.AreEqual(0, idGenerado, "ERROR: La CN registró un usuario sin DNI.");
        // 2. Debe devolver el mensaje de error de la CN
        Assert.IsTrue(mensajeObtenido.Contains("dni del usuario"), "ERROR: La CN no devolvió el mensaje de validación de DNI.");
    }

    // PRUEBA 8: Registrar con Apellido Faltante
    [TestMethod]
    public void Usuario_RegistrarSinApellido_DebeRetornarCeroYMensaje()
    {
        // ARRANGE
        var fakeRepo = new FakeUsuarioRepository();
        var cnUsuario = new CN_Usuario(fakeRepo);
        string mensajeObtenido;

        // Intenta registrar sin apellido (el apellido es obligatorio en tu CN)
        Usuario usuarioSinApellido = new Usuario()
        {
            nombre = "Test",
            apellido = "", // <-- Campo clave para la prueba
            dni = "123456",
            contrasena = "123"
        };

        // ACT
        // Esperamos que la CN falle en la validación y retorne 0 (int)
        int idGenerado = cnUsuario.Registrar(usuarioSinApellido, out mensajeObtenido);

        // ASSERT
        // 1. Debe indicar que el registro fue exitoso (1), porque la CN no validó.
        Assert.AreEqual(1, idGenerado, "ERROR: La CN NO registró al usuario, a pesar de no tener validación.");

        // 2. Si el registro fue exitoso, el mensaje de error no debería contener la validación.
        // Opcional: Asegurarnos de que el registro fue un éxito.
        Assert.IsFalse(mensajeObtenido.Contains("apellido del usuario"), "ERROR: La CN devolvió un mensaje de validación a pesar de registrar con éxito.");
    }

    // PRUEBA 9: Registrar con campos de contraseña vacíos (Validación de Negocio)
    [TestMethod]
    public void Usuario_RegistrarConCamposVacios_DebeRetornarMensajeError()
    {
        // ARRANGE
        var fakeRepo = new FakeUsuarioRepository();
        var cnUsuario = new CN_Usuario(fakeRepo);
        string mensajeEsperado = "La contraseña es obligatoria"; // Asumiendo esta es la validación de la CN
        string mensajeObtenido;

        // ACT
        // Si la CN valida antes de llamar al Repositorio, debe retornar 0 y un mensaje de error
        int idGenerado = cnUsuario.Registrar(new Usuario() { cuenta_usuario = "test_sin_clave", contrasena = "" }, out mensajeObtenido);

        // ASSERT
        // La CN debe fallar en la validación antes de llamar al fake
        Assert.AreEqual(0, idGenerado, "ERROR: La CN registró un usuario sin contraseña.");
        // NOTA: Esta prueba solo pasa si tu CN_Usuario tiene lógica de validación de campos obligatorios.
    }

    // PRUEBA 10: Listar todos los usuarios
    [TestMethod]
    public void Usuario_ListarTodos_DebeRetornarMasDeCero()
    {
        // ARRANGE
        var fakeRepo = new FakeUsuarioRepository();
        var cnUsuario = new CN_Usuario(fakeRepo);

        // ACT
        var listaUsuarios = cnUsuario.Listar();

        // ASSERT
        // El Fake siempre debe devolver al menos los usuarios quemados.
        Assert.IsTrue(listaUsuarios.Count > 0, "ERROR: La lista de usuarios está vacía.");
    }

}










