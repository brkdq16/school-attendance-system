using SistemaAsistenciaEscolar.Models.Entities;
using SistemaAsistenciaEscolar.Data;

namespace SistemaAsistenciaEscolar.Services
{
    public class AulaService
    {
        private List<Aula> aulas;

        private JsonStorage storage;

        private string rutaArchivo = "aulas.json";

        // CONSTRUCTOR

        public AulaService()
        {
            storage = new JsonStorage();

            aulas = storage.Cargar<Aula>(rutaArchivo);
        }

        // AGREGAR

        public void AgregarAula(Aula aula)
        {
            aulas.Add(aula);

            storage.Guardar(rutaArchivo, aulas);
        }

        // OBTENER TODAS

        public List<Aula> ObtenerAulas()
        {
            return aulas;
        }

        // BUSCAR POR ID

        public Aula BuscarPorId(int id)
        {
            return aulas.FirstOrDefault(a => a.Id == id);
        }

        // ELIMINAR

        public void EliminarAula(int id)
        {
            Aula aula = BuscarPorId(id);

            if (aula != null)
            {
                aulas.Remove(aula);

                storage.Guardar(rutaArchivo, aulas);
            }
        }

        // EDITAR

        public void EditarAula(int id, string nuevoNombre, int nuevaCapacidad)
        {
            Aula aula = BuscarPorId(id);

            if (aula != null)
            {
                aula.Nombre = nuevoNombre;
                aula.Capacidad = nuevaCapacidad;

                storage.Guardar(rutaArchivo, aulas);
            }
        }
    }
}