using SistemaAsistenciaEscolar.Models.Entities;
using SistemaAsistenciaEscolar.Data;

namespace SistemaAsistenciaEscolar.Services
{
    public class EstudianteService
    {
        private List<Estudiante> estudiantes;

        private JsonStorage storage;

        private string rutaArchivo = "estudiantes.json";

        // CONSTRUCTOR

        public EstudianteService()
        {
            storage = new JsonStorage();

            estudiantes = storage.Cargar<Estudiante>(rutaArchivo);
        }

        // AGREGAR

        public void AgregarEstudiante(Estudiante estudiante)
        {
            estudiantes.Add(estudiante);

            storage.Guardar(rutaArchivo, estudiantes);
        }

        // OBTENER TODOS

        public List<Estudiante> ObtenerEstudiantes()
        {
            return estudiantes;
        }

        // BUSCAR POR ID

        public Estudiante BuscarPorId(int id)
        {
            return estudiantes.FirstOrDefault(e => e.Id == id);
        }

        // ELIMINAR

        public void EliminarEstudiante(int id)
        {
            Estudiante estudiante = BuscarPorId(id);

            if (estudiante != null)
            {
                estudiantes.Remove(estudiante);

                storage.Guardar(rutaArchivo, estudiantes);
            }
        }

        // EDITAR

        public void EditarEstudiante(
            int id,
            string nombre,
            string apellido)
        {
            Estudiante estudiante = BuscarPorId(id);

            if (estudiante != null)
            {
                estudiante.Nombre = nombre;
                estudiante.Apellido = apellido;

                storage.Guardar(rutaArchivo, estudiantes);
            }
        }
    }
}