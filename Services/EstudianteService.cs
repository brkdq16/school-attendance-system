using SistemaAsistenciaEscolar.Models.Entities;

namespace SistemaAsistenciaEscolar.Services
{
    public class EstudianteService
    {
        private List<Estudiante> estudiantes;

        // CONSTRUCTOR

        public EstudianteService()
        {
            estudiantes = new List<Estudiante>();
        }

        // CREATE

        public void AgregarEstudiante(Estudiante estudiante)
        {
            estudiantes.Add(estudiante);
        }

        // READ

        public List<Estudiante> ObtenerEstudiantes()
        {
            return estudiantes;
        }

        // BUSCAR POR ID

        public Estudiante BuscarPorId(int id)
        {
            foreach (Estudiante estudiante in estudiantes)
            {
                if (estudiante.Id == id)
                {
                    return estudiante;
                }
            }

            return null;
        }

        // UPDATE

        public bool EditarEstudiante(
            int id,
            string nuevoNombre,
            string nuevoApellido,
            Aula nuevaAula)
        {
            Estudiante estudiante = BuscarPorId(id);

            if (estudiante != null)
            {
                estudiante.Nombre = nuevoNombre;
                estudiante.Apellido = nuevoApellido;
                estudiante.Aula = nuevaAula;

                return true;
            }

            return false;
        }

        // DELETE

        public bool EliminarEstudiante(int id)
        {
            Estudiante estudiante = BuscarPorId(id);

            if (estudiante != null)
            {
                estudiantes.Remove(estudiante);

                return true;
            }

            return false;
        }
    }
}