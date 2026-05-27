using System;
using System.Collections.Generic;
using System.Text;
using SistemaAsistenciaEscolar.Models.Enums;

namespace SistemaAsistenciaEscolar.Models.Entities
{
    // Esta clase representa un registro de asistencia para un estudiante específico.
    // Contiene una propiedad para el ID del registro y una referencia al estudiante asociado.
    // Este modelo se puede utilizar para almacenar y
    // gestionar la información de asistencia de los estudiantes en el sistema escolar.
    public class RegistroAsistencia
    {
        public int Id { get; set; }
        public Estudiante Estudiante { get; set; } 
        public DateTime Fecha { get; set; }
        public EstadoAsistencia Estado { get; set; }
        public string Excusa { get; set; }

        // CONSTRUCTOR
        public RegistroAsistencia(int id, Estudiante estudiante, DateTime fecha, EstadoAsistencia estado, string excusa = "")
        {
            this.Id = id;
            this.Estudiante = estudiante;
            this.Fecha = fecha;
            this.Estado = estado;
            this.Excusa = excusa;
        }
        // TIENE EXCUSA
        public bool TieneExcusa()
        {
            return !string.IsNullOrEmpty(Excusa);
        }
    }
}
