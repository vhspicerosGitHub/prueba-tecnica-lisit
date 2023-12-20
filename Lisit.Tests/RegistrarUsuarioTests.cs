namespace Lisit.Tests;

public class RegistrarUsuarioTests {
    private AuthServices _service;
    private Mock<IUsuarioRepository> _repository;

    [SetUp]
    public void Setup() {
        _repository = new Mock<IUsuarioRepository>();
        _service = new AuthServices(_repository.Object);
    }

    [Test]
    public void Registrar_usuario_con_Email_duplicado_lanza_excepcion() {
        // Setup
        var usuario = new Usuario {
            Email = "vhspiceros@gmail.com"
        };
        _repository.Setup(x => x.GetByEmail(It.IsAny<string>())).ReturnsAsync(usuario);

        //Act
        var ex = Assert.ThrowsAsync<BusinessException>(code: () => _service.Registrar(usuario));

        //Assert
        Assert.That(ex.Message, Is.EqualTo("Ya existe un usuario con ese correo"));
        _repository.Verify(x => x.Create(It.IsAny<Usuario>()), Times.Never());
        _repository.Verify(x => x.GetByEmail(It.IsAny<string>()), Times.Once());
        _repository.VerifyNoOtherCalls();
    }

    [Test]
    [TestCase("aaa")]
    [TestCase("aaa@aaa")]
    [TestCase("aaaaaa@.cl")]
    [TestCase("aaaaaa@aaaa,cl")]
    public void Registrar_usuario_con_Email_invalido_lanza_excepcion(string email) {
        // Setup
        var usuario = new Usuario {
            Email = email
        };

        //Act
        var ex = Assert.ThrowsAsync<BusinessException>(code: () => _service.Registrar(usuario));

        //Assert
        Assert.That(ex.Message, Is.EqualTo("El correo es Invalido"));
        _repository.Verify(x => x.Create(It.IsAny<Usuario>()), Times.Never());
        _repository.Verify(x => x.GetByEmail(It.IsAny<string>()), Times.Once());
        _repository.VerifyNoOtherCalls();
    }

    public async Task Registra_usuario_exitosamente() {
        // Setup
        var usuario = new Usuario {
            Email = "vhspiceros@gmail.com",
            Nombre = "victor Hugo Saavedra",
            Password = "123",
            ComunaId = 1
        };
        _repository.Setup(x => x.Create(It.IsAny<Usuario>())).ReturnsAsync(1);

        //Act
        var id = await _service.Registrar(usuario);

        //Assert
        Assert.That(id, Is.EqualTo(1));
        _repository.Verify(x => x.Create(It.IsAny<Usuario>()), Times.Once());
        _repository.Verify(x => x.GetByEmail(It.IsAny<string>()), Times.Once());
        _repository.VerifyNoOtherCalls();
    }
}
