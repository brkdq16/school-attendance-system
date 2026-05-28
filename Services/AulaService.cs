using System;
using System.Collections.Generic;
using System.Linq;
using SistemaAsistenciaEscolar.Models.Entities;
using SistemaAsistenciaEscolar.Data;

namespace SistemaAsistenciaEscolar.Services
{
    public class AulaService
    {
        private List<Aula> aulas;
        private JsonStorage storage;
        private string rutaArchivo = "aulas.json";

        public AulaService()
        {
            storage = new JsonStorage();
            aulas = storage.Load<Aula>(rutaArchivo);
        }

        public void AgregarAula(Aula aula)
        {
            if (aulas.Any(a => a.Id == aula.Id))
            {
                Console.WriteLine("⚠ Ya existe un aula con ese ID.");
                return;
            }

            if (aulas.Any(a => a.Nombre == aula.Nombre))
            {
                Console.WriteLine("⚠ Ya existe un aula con ese nombre.");
                return;
            }

            aulas.Add(aula);
            storage.Save(rutaArchivo, aulas);
        }

        public List<Aula> ObtenerAulas()
        {
            return aulas;
        }

        public Aula BuscarPorId(int id)
        {
            return aulas.FirstOrDefault(a => a.Id == id);
        }

        public void EliminarAula(int id)
        {
            Aula aula = BuscarPorId(id);

            if (aula != null)
            {
                aulas.Remove(aula);
                storage.Save(rutaArchivo, aulas);
            }
        }

        public void EditarAula(int id, string nuevoNombre, int nuevaCapacidad)
        {
            Aula aula = BuscarPorId(id);

            if (aula != null)
            {
                aula.Nombre = nuevoNombre;
                aula.Capacidad = nuevaCapacidad;

                storage.Save(rutaArchivo, aulas);
            }
        }
    }
}