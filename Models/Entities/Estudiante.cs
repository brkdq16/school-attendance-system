using System;
using System.Collections.Generic;
using System.Text;
using SistemaAsistenciaEscolar.Models.Enums;

namespace SistemaAsistenciaEscolar.Models.Entities
{
    public class Estudiante : Persona
    {
        public string Matricula { get; set; }

        public Aula Aula { get; set; }

        // CONSTRUCTOR

        public Estudiante(
            int id,
            string nombre,
            string apellido,
            Sexo sexo,
            DateTime fechaNacimiento,
            string matricula,
            Aula aula)

            : base(id, nombre, apellido, sexo, fechaNacimiento)// Llamada al constructor de la clase base (Persona),
                                                               // antes de inicializar las propiedades específicas de Estudiante
        {
            this.Matricula = matricula;
            this.Aula = aula;
        }
    }
}   