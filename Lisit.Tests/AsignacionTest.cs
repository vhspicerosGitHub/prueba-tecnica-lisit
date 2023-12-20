namespace Lisit.Tests; 
public class AsignacionTest {

    private AyudaSocialAsignacionServices _service;
    private Mock<IAyudaSocialAsignacionRepository> _repository;

    [SetUp]
    public void Setup() {
        _repository = new Mock<IAyudaSocialAsignacionRepository>();
        _service = new AyudaSocialAsignacionServices(_repository.Object);
    }

    [Test]
    public void No_permite_crear_dos_asignaciones_iguales_el_mismo_año() {
        //Setup
        var asignacion = new AyudaSocialAsignacion {
            AyudaSocialId = 1,
            ResidenteId = 100,
            AñoAsignacion = 2023
        };
        _repository.Setup(x => x.ObtieneAsignaciones(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(new List<AyudaSocialAsignacion> { asignacion });

        //Act
        var ex = Assert.ThrowsAsync<BusinessException>(code: () => _service.Crear(asignacion));

        //Assert
        _repository.Verify(x => x.Create(It.IsAny<AyudaSocialAsignacion>()), Times.Never());
        _repository.Verify(x => x.ObtieneAsignaciones(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        _repository.VerifyNoOtherCalls();
        Assert.That(ex.Message, Is.EqualTo("Ya tiene una asignacion el mismo año"));
    }

    [Test]
    public async Task Crea_Asignacion_exitosamente() {
        //Setup
        var asignacion = new AyudaSocialAsignacion {
            AyudaSocialId = 1,
            ResidenteId = 100,
            AñoAsignacion = 2023
        };
        _repository.Setup(x => x.ObtieneAsignaciones(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(new List<AyudaSocialAsignacion>());

        _repository.Setup(x => x.Create(It.IsAny<AyudaSocialAsignacion>())).ReturnsAsync(1);

        //Act
        var id = await _service.Crear(asignacion);

        //Assert
        Assert.That(id, Is.EqualTo(1));
        _repository.Verify(x => x.ObtieneAsignaciones(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        _repository.Verify(x => x.Create(It.IsAny<AyudaSocialAsignacion>()), Times.Once());
        _repository.VerifyNoOtherCalls();

    }
}
