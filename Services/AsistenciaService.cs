using SistemaAsistenciaEscolar.Data;
using SistemaAsistenciaEscolar.Models.Entities;
using SistemaAsistenciaEscolar.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAsistenciaEscolar.Services
{
    public class AsistenciaService
    {
        private List<RegistroAsistencia> asistencias;
        private JsonStorage storage;
        private string rutaArchivo = "asistencias.json";

        public AsistenciaService()
        {
            storage = new JsonStorage();
            asistencias = storage.Load<RegistroAsistencia>(rutaArchivo);
        }

        public void RegistrarAsistencia(RegistroAsistencia asistencia)
        {
            bool existe = asistencias.Any(a =>
                a.Estudiante.Id == asistencia.Estudiante.Id &&
                a.Fecha.Date == asistencia.Fecha.Date);

            if (existe)
            {
                Console.WriteLine(" Ya existe asistencia para este estudiante en esa fecha.");
                return;
            }

            asistencias.Add(asistencia);
            storage.Save(rutaArchivo, asistencias);
        }

        public List<RegistroAsistencia> ObtenerAsistencias()
        {
            return asistencias;
        }

        public List<RegistroAsistencia> ConsultarPorFecha(DateTime fecha)
        {
            return asistencias
                .Where(a => a.Fecha.Date == fecha.Date)
                .ToList();
        }

        public int TotalPresentes()
        {
            return asistencias.Count(a => a.Estado == EstadoAsistencia.Presente);
        }

        public int TotalAusentes()
        {
            return asistencias.Count(a => a.Estado == EstadoAsistencia.Ausente);
        }

        public int TotalConExcusa()
        {
            return asistencias.Count(a =>
                a.Estado == EstadoAsistencia.Ausente &&
                !string.IsNullOrEmpty(a.Excusa));
        }
    }
}