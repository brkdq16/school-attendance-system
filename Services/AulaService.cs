using SistemaAsistenciaEscolar.Models.Entities;
using System;

namespace SistemaAsistenciaEscolar.Services
{
    public class AulaService
    {
        private List<Aula> aulas;

        public AulaService()
        {
            aulas = new List<Aula>();
        }

        // CREATE

        public void AgregarAula(Aula aula)
        {
            aulas.Add(aula);
        }

        // READ

        public List<Aula> ObtenerAulas()
        {
            return aulas;
        }

        // BUSCAR POR ID

        public Aula BuscarPorId(int id)
        {
            foreach (Aula aula in aulas)
            {
                if (aula.Id == id)
                {
                    return aula;
                }
            }

            return null;
        }

        // UPDATE

        public bool EditarAula(int id, string nuevoNombre, int nuevaCapacidad)
        {
            Aula aula = BuscarPorId(id);

            if (aula != null)
            {
                aula.Nombre = nuevoNombre;
                aula.Capacidad = nuevaCapacidad;

                return true;
            }

            return false;
        }

        // DELETE

        public bool EliminarAula(int id)
        {
            Aula aula = BuscarPorId(id);

            if (aula != null)
            {
                aulas.Remove(aula);

                return true;
            }

            return false;
        }
    }
}
