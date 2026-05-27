using SistemaAsistenciaEscolar.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaAsistenciaEscolar.Models.Entities
{
    public abstract class  Persona
    {
        // PROPIEDADES
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }

        // CONSTRUCTOR
        protected Persona(int id, string nombre, string apellido, Sexo sexo, DateTime FechaNacimiento)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Sexo = sexo;
            this.FechaNacimiento = FechaNacimiento;
        }

        // OBTENER NOMBRE COMPLETO
        public string ObtenerNombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }

        // CALCULAR EDAD
        public int ObtenerEdad()
        {
            int edad = DateTime.Now.Year - FechaNacimiento.Year;

            if (DateTime.Now.DayOfYear < FechaNacimiento.DayOfYear)
            {
                edad--;
            }

            return edad;
        }
    }
    
}
