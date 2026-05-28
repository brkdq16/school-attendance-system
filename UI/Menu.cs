using SistemaAsistenciaEscolar.Models.Entities;
using SistemaAsistenciaEscolar.Models.Enums;
using SistemaAsistenciaEscolar.Services;
using System;

namespace SistemaAsistenciaEscolar.UI
{
    public class Menu
    {
        private AulaService aulaService = new AulaService();
        private EstudianteService estudianteService = new EstudianteService();
        private AsistenciaService asistenciaService = new AsistenciaService();

        public void MostrarMenu()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== SISTEMA DE ASISTENCIA ESCOLAR =====");
                Console.WriteLine("1. Gestión de Aulas");
                Console.WriteLine("2. Gestión de Estudiantes");
                Console.WriteLine("3. Registro de Asistencia");
                Console.WriteLine("4. Consultas de Asistencia");
                Console.WriteLine("5. Estadísticas");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        MenuAulas();
                        break;
                    case 2:
                        MenuEstudiantes();
                        break;
                    case 3:
                        MenuAsistencia();
                        break;
                    case 4:
                        MenuConsultas();
                        break;
                    case 5:
                        MenuEstadisticas();
                        break;
                }

            } while (opcion != 0);
        }

        // ===================== AULAS =====================

        private void MenuAulas()
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE AULAS ===");
            Console.WriteLine("1. Registrar Aula");
            Console.WriteLine("2. Listar Aulas");
            Console.WriteLine("3. Editar Aula");
            Console.WriteLine("4. Eliminar Aula");
            Console.WriteLine("0. Volver");

            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    RegistrarAula();
                    break;
                case 2:
                    ListarAulas();
                    break;
                case 3:
                    EditarAula();
                    break;
                case 4:
                    EliminarAula();
                    break;
            }
        }

        private void RegistrarAula()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Capacidad: ");
            int capacidad = int.Parse(Console.ReadLine());

            aulaService.AgregarAula(new Aula(id, nombre, capacidad));

            Console.WriteLine(" Aula registrada");
            Console.ReadKey();
        }

        private void ListarAulas()
        {
            var aulas = aulaService.ObtenerAulas();

            if (aulas.Count == 0)
            {
                Console.WriteLine(" No hay aulas registradas");
            }
            else
            {
                foreach (var a in aulas)
                {
                    Console.WriteLine($"ID: {a.Id} | Nombre: {a.Nombre} | Capacidad: {a.Capacidad}");
                }
            }

            Console.ReadKey();
        }

        private void EditarAula()
        {
            Console.Write("ID aula: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nuevo nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Nueva capacidad: ");
            int cap = int.Parse(Console.ReadLine());

            aulaService.EditarAula(id, nombre, cap);

            Console.WriteLine(" Aula actualizada");
            Console.ReadKey();
        }

        private void EliminarAula()
        {
            Console.Write("ID aula: ");
            int id = int.Parse(Console.ReadLine());

            aulaService.EliminarAula(id);

            Console.WriteLine(" Aula eliminada");
            Console.ReadKey();
        }

        // ===================== ESTUDIANTES =====================

        private void MenuEstudiantes()
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE ESTUDIANTES ===");
            Console.WriteLine("1. Registrar Estudiante");
            Console.WriteLine("2. Listar Estudiantes");
            Console.WriteLine("3. Editar Estudiante");
            Console.WriteLine("4. Eliminar Estudiante");
            Console.WriteLine("0. Volver");

            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    RegistrarEstudiante();
                    break;
                case 2:
                    ListarEstudiantes();
                    break;
                case 3:
                    EditarEstudiante();
                    break;
                case 4:
                    EliminarEstudiante();
                    break;
            }
        }

        private void RegistrarEstudiante()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Sexo (1=Masculino, 2=Femenino): ");
            Sexo sexo = Console.ReadLine() == "1" ? Sexo.Masculino : Sexo.Femenino;

            Console.Write("Fecha nacimiento (yyyy-mm-dd): ");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine();

            Console.Write("ID Aula: ");
            int idAula = int.Parse(Console.ReadLine());

            Aula aula = aulaService.BuscarPorId(idAula);

            if (aula == null)
            {
                Console.WriteLine(" Aula no existe");
                return;
            }

            estudianteService.AgregarEstudiante(
                new Estudiante(id, nombre, apellido, sexo, fecha, matricula, aula)
            );

            Console.WriteLine(" Estudiante registrado");
            Console.ReadKey();
        }

        private void ListarEstudiantes()
        {
            var lista = estudianteService.ObtenerEstudiantes();

            if (lista.Count == 0)
            {
                Console.WriteLine(" No hay estudiantes");
            }
            else
            {
                foreach (var e in lista)
                {
                    Console.WriteLine($"ID: {e.Id} | {e.Nombre} {e.Apellido} | Aula: {e.Aula.Nombre}");
                }
            }

            Console.ReadKey();
        }

        private void EditarEstudiante()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nuevo nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Nuevo apellido: ");
            string apellido = Console.ReadLine();

            estudianteService.EditarEstudiante(id, nombre, apellido);

            Console.WriteLine(" Actualizado");
            Console.ReadKey();
        }

        private void EliminarEstudiante()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            estudianteService.EliminarEstudiante(id);

            Console.WriteLine(" Eliminado");
            Console.ReadKey();
        }

        // ===================== ASISTENCIA =====================

        private void MenuAsistencia()
        {
            Console.Clear();
            Console.WriteLine("=== ASISTENCIA ===");
            Console.WriteLine("1. Registrar asistencia");
            Console.WriteLine("0. Volver");

            int op = int.Parse(Console.ReadLine());

            if (op == 1)
                RegistrarAsistencia();
        }

        private void RegistrarAsistencia()
        {
            Console.Write("ID Estudiante: ");
            int idEst = int.Parse(Console.ReadLine());

            var estudiante = estudianteService.BuscarPorId(idEst);

            if (estudiante == null)
            {
                Console.WriteLine(" Estudiante no existe");
                return;
            }

            Console.Write("Fecha: ");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            Console.Write("Estado (1=Presente, 2=Ausente): ");
            EstadoAsistencia estado = Console.ReadLine() == "1"
                ? EstadoAsistencia.Presente
                : EstadoAsistencia.Ausente;

            string excusa = "";

            if (estado == EstadoAsistencia.Ausente)
            {
                Console.Write("Excusa: ");
                excusa = Console.ReadLine();
            }

            asistenciaService.RegistrarAsistencia(
                new RegistroAsistencia(idEst, estudiante, fecha, estado, excusa)
            );

            Console.WriteLine(" Asistencia registrada");
            Console.ReadKey();
        }

        // ===================== CONSULTAS =====================

        private void MenuConsultas()
        {
            Console.Clear();
            Console.Write("Fecha (yyyy-mm-dd): ");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            var lista = asistenciaService.ConsultarPorFecha(fecha);

            if (lista.Count == 0)
            {
                Console.WriteLine(" No hay registros");
            }
            else
            {
                foreach (var a in lista)
                {
                    Console.WriteLine($"{a.Estudiante.Nombre} - {a.Estado}");
                }
            }

            Console.ReadKey();
        }

        // ===================== ESTADÍSTICAS =====================

        private void MenuEstadisticas()
        {
            Console.Clear();

            Console.WriteLine("=== ESTADÍSTICAS ===");
            Console.WriteLine($"Presentes: {asistenciaService.TotalPresentes()}");
            Console.WriteLine($"Ausentes: {asistenciaService.TotalAusentes()}");
            Console.WriteLine($"Con excusa: {asistenciaService.TotalConExcusa()}");

            Console.ReadKey();
        }
    }
}