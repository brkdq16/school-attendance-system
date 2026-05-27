using SistemaAsistenciaEscolar.Models.Entities;
using SistemaAsistenciaEscolar.Models.Enums;

namespace SistemaAsistenciaEscolar.Services
{
    public class AsistenciaService
    {
        private List<RegistroAsistencia> registros;

        // CONSTRUCTOR

        public AsistenciaService()
        {
            registros = new List<RegistroAsistencia>();
        }

        // REGISTRAR ASISTENCIA

        public void RegistrarAsistencia(RegistroAsistencia registro)
        {
            registros.Add(registro);
        }

        // OBTENER TODOS LOS REGISTROS

        public List<RegistroAsistencia> ObtenerRegistros()
        {
            return registros;
        }

        // CONSULTAR POR FECHA

        public List<RegistroAsistencia> ConsultarPorFecha(DateTime fecha)
        {
            List<RegistroAsistencia> resultados = new List<RegistroAsistencia>();

            foreach (RegistroAsistencia registro in registros)
            {
                if (registro.Fecha.Date == fecha.Date)
                {
                    resultados.Add(registro);
                }
            }

            return resultados;
        }

        // CONSULTAR AUSENTES

        public List<RegistroAsistencia> ObtenerAusentes()
        {
            List<RegistroAsistencia> ausentes = new List<RegistroAsistencia>();

            foreach (RegistroAsistencia registro in registros)
            {
                if (registro.Estado == EstadoAsistencia.Ausente)
                {
                    ausentes.Add(registro);
                }
            }

            return ausentes;
        }

        // ESTADÍSTICAS

        public int TotalPresentes()
        {
            int total = 0;

            foreach (RegistroAsistencia registro in registros)
            {
                if (registro.Estado == EstadoAsistencia.Presente)
                {
                    total++;
                }
            }

            return total;
        }
       
        public int TotalAusentes()
        {
            int total = 0;

            foreach (RegistroAsistencia registro in registros)
            {
                if (registro.Estado == EstadoAsistencia.Ausente)
                {
                    total++;
                }
            }

            return total;
        }

        public int TotalConExcusa()
        {
            int total = 0;

            foreach (RegistroAsistencia registro in registros)
            {
                if (!string.IsNullOrWhiteSpace(registro.Excusa))
                {
                    total++;
                }
            }

            return total;
        }
    }
}
