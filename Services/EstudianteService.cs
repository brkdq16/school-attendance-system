using System;
using System.Collections.Generic;
using System.Linq;
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
            estudiantes = storage.Load<Estudiante>(rutaArchivo);
        }

        // AGREGAR
        public void AgregarEstudiante(Estudiante estudiante)
        {
            if (estudiantes.Any(e => e.Id == estudiante.Id))
            {
                Console.WriteLine("⚠ Ya existe un estudiante con ese ID.");
                return;
            }

            estudiantes.Add(estudiante);
            storage.Save(rutaArchivo, estudiantes);
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
                storage.Save(rutaArchivo, estudiantes);
            }
        }

        // EDITAR
        public void EditarEstudiante(int id, string nombre, string apellido)
        {
            Estudiante estudiante = BuscarPorId(id);

            if (estudiante != null)
            {
                estudiante.Nombre = nombre;
                estudiante.Apellido = apellido;

                storage.Save(rutaArchivo, estudiantes);
            }
        }
    }
}