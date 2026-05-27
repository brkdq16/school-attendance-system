using SistemaAsistenciaEscolar.Models.Entities;
using SistemaAsistenciaEscolar.Models.Enums;
using SistemaAsistenciaEscolar.Data;

namespace SistemaAsistenciaEscolar.Services
{
    public class AsistenciaService
    {
        private List<RegistroAsistencia> asistencias;

        private JsonStorage storage;

        private string rutaArchivo = "asistencias.json";

        // CONSTRUCTOR

        public AsistenciaService()
        {
            storage = new JsonStorage();

            asistencias = storage.Cargar<RegistroAsistencia>(rutaArchivo);
        }

        // REGISTRAR ASISTENCIA

        public void RegistrarAsistencia(RegistroAsistencia asistencia)
        {
            asistencias.Add(asistencia);

            storage.Guardar(rutaArchivo, asistencias);
        }

        // OBTENER TODAS

        public List<RegistroAsistencia> ObtenerAsistencias()
        {
            return asistencias;
        }

        // CONSULTAR POR FECHA

        public List<RegistroAsistencia> ConsultarPorFecha(DateTime fecha)
        {
            return asistencias
                .Where(a => a.Fecha.Date == fecha.Date)
                .ToList();
        }

        // ESTADÍSTICAS

        public int TotalPresentes()
        {
            return asistencias.Count(a =>
                a.Estado == EstadoAsistencia.Presente);
        }

        public int TotalAusentes()
        {
            return asistencias.Count(a =>
                a.Estado == EstadoAsistencia.Ausente);
        }

        public int TotalConExcusa()
        {
            return asistencias.Count(a =>
                !string.IsNullOrWhiteSpace(a.Excusa));
        }
    }
}