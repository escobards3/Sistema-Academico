using SistemaAcademico.Models;

namespace SistemaAcademico.Data{}
public static class DatosCompartidos
{
    public static List<Carrera> ListCarreras { get; private set; }
    public static List<Alumno> ListaAlumnos { get; private set; }

    private static int _ultimoCarreaId = 0;
    private static int _ultimoAlumnoId = 0;

    static DatosCompartidos()
    {
        // Precarga de datos de prueba
        ListCarreras = new List<Carrera>
        {
            new Carrera
            {
                Id = ObtenerNuevoCarreraId(),
                Nombre = "Ingeniería en Sistemas",
                Modalidad = "Presencial",
                DuracionAnios = 5,
                TituloOtorgado = "Ingeniero en Sistemas"
            },
            new Carrera
            {
                Id = ObtenerNuevoCarreraId(),
                Nombre = "Licenciatura en Administración",
                Modalidad = "Virtual",
                DuracionAnios = 4,
                TituloOtorgado = "Licenciado en Administración"
            }
        };

        ListaAlumnos = new List<Alumno>(); // Puedes cargar también si lo deseas
    }

    public static int ObtenerNuevoCarreraId()
    {
        _ultimoCarreaId++;
        return _ultimoCarreaId;
    }

    public static int ObtenerNuevoAlumnoId()
    {
        _ultimoAlumnoId++;
        return _ultimoAlumnoId;
    }
}
