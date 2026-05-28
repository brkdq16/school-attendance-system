using SistemaAsistenciaEscolar.Models.Entities;
using SistemaAsistenciaEscolar.Models.Enums;
using SistemaAsistenciaEscolar.Services;

namespace SistemaAsistenciaEscolar.UI
{
    public class Menu
    {
        private AulaService aulaService;
        private EstudianteService estudianteService;
        private AsistenciaService asistenciaService;

        public Menu()
        {
            aulaService = new AulaService();
            estudianteService = new EstudianteService();
            asistenciaService = new AsistenciaService();
        }

        public void Mostrar()
        {
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== SISTEMA ASISTENCIA ESCOLAR =====");
                Console.WriteLine("1. Gestión de Aulas");
                Console.WriteLine("2. Gestión de Estudiantes");
                Console.WriteLine("3. Gestión de Asistencia");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuAulas();
                        break;

                    case "2":
                        MenuEstudiantes();
                        break;

                    case "3":
                        MenuAsistencia();
                        break;
                }

            } while (opcion != "4");
        }

        // =========================
        // AULAS
        // =========================

        private void MenuAulas()
        {
            Console.Clear();
            Console.WriteLine("===== AULAS =====");
            Console.WriteLine("1. Crear");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Editar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");

            string op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    CrearAula();
                    break;

                case "2":
                    ListarAulas();
                    break;

                case "3":
                    EditarAula();
                    break;

                case "4":
                    EliminarAula();
                    break;
            }
        }

        private void CrearAula()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Capacidad: ");
            int capacidad = int.Parse(Console.ReadLine());

            aulaService.AgregarAula(new Aula(id, nombre, capacidad));

            Console.WriteLine("Aula creada.");
            Console.ReadKey();
        }

        private void ListarAulas()
        {
            foreach (var a in aulaService.ObtenerAulas())
            {
                Console.WriteLine($"{a.Id} - {a.Nombre} - {a.Capacidad}");
            }
            Console.ReadKey();
        }

        private void EditarAula()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nuevo nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Nueva capacidad: ");
            int cap = int.Parse(Console.ReadLine());

            aulaService.EditarAula(id, nombre, cap);

            Console.WriteLine("Actualizado.");
            Console.ReadKey();
        }

        private void EliminarAula()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            aulaService.EliminarAula(id);

            Console.WriteLine("Eliminado.");
            Console.ReadKey();
        }

        // =========================
        // ESTUDIANTES
        // =========================

        private void MenuEstudiantes()
        {
            Console.Clear();
            Console.WriteLine("===== ESTUDIANTES =====");
            Console.WriteLine("1. Crear");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Editar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Volver");

            string op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    RegistrarEstudiante();
                    break;

                case "2":
                    ListarEstudiantes();
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

            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine();

            Console.Write("Fecha nacimiento (yyyy-mm-dd): ");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            Console.Write("Sexo (1 M / 2 F): ");
            Sexo sexo = (Console.ReadLine() == "1") ? Sexo.Masculino : Sexo.Femenino;

            Console.Write("ID Aula: ");
            int aulaId = int.Parse(Console.ReadLine());

            Aula aula = aulaService.BuscarPorId(aulaId);

            estudianteService.AgregarEstudiante(
                new Estudiante(id, nombre, apellido, sexo, fecha, matricula, aula)
            );

            Console.WriteLine("Estudiante creado.");
            Console.ReadKey();
        }

        private void ListarEstudiantes()
        {
            foreach (var e in estudianteService.ObtenerEstudiantes())
            {
                Console.WriteLine($"{e.Id} - {e.ObtenerNombreCompleto()} - {e.Matricula}");
            }
            Console.ReadKey();
        }

        // =========================
        // ASISTENCIA (base)
        // =========================

        private void MenuAsistencia()
        {
            Console.Clear();
            Console.WriteLine("===== ASISTENCIA =====");
            Console.WriteLine("1. Registrar");
            Console.WriteLine("2. Consultar por fecha");
            Console.WriteLine("3. Estadísticas");

            string op = Console.ReadLine();

            if (op == "1")
            {
                Console.WriteLine("Aquí conectarás RegistroAsistencia");
            }
        }
    }
}