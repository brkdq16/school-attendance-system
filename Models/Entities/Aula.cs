using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAsistenciaEscolar.Models.Entities
{
    public class Aula
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int capacidad { get; set; }

        // CONSTRUCTOR
        public Aula(int id, string nombre, int capacidad)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.capacidad = capacidad;
        }

        // VERIFICAR SI EL AULA ESTÁ LLENA
        public bool VerificarCapacidad(int cantidadEstudiantes)
        {
            if (cantidadEstudiantes > capacidad)
            {
                Console.WriteLine($"El aula {Nombre} está llena. Capacidad máxima: {capacidad} estudiantes.");
                return true;
            }
            else
            {
                Console.WriteLine($"El aula {Nombre} tiene espacio disponible. Capacidad máxima: {capacidad} estudiantes.");
                return false;
            }
        }

    }
}
