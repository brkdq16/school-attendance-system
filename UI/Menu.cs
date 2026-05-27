using SistemaAsistenciaEscolar.Models.Entities;
using SistemaAsistenciaEscolar.Models.Enums;
using SistemaAsistenciaEscolar.Services;

namespace SistemaAsistenciaEscolar.UI
{
    public class Menu
    {
        // SERVICES

        private AulaService aulaService;
        private EstudianteService estudianteService;
        private AsistenciaService asistenciaService;

        // CONSTRUCTOR

        public Menu()
        {
            aulaService = new AulaService();
            estudianteService = new EstudianteService();
            asistenciaService = new AsistenciaService();
        }

        // MÉTODO PRINCIPAL DEL MENÚ

        public void Mostrar()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();

                Console.WriteLine("===== SISTEMA DE ASISTENCIA ESCOLAR =====");
                Console.WriteLine("1. Registrar aula");
                Console.WriteLine("2. Listar aulas");
                Console.WriteLine("3. Registrar estudiante");
                Console.WriteLine("4. Listar estudiantes");
                Console.WriteLine("5. Salir");

                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarAula();
                        break;

                    case "2":
                        ListarAulas();
                        break;

                    case "3":
                        RegistrarEstudiante();
                        break;

                    case "4":
                        ListarEstudiantes();
                        break;

                    case "5":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        // REGISTRAR AULA

        private void RegistrarAula()
        {
            Console.Write("ID del aula: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nombre del aula: ");
            string nombre = Console.ReadLine();

            Console.Write("Capacidad: ");
            int capacidad = int.Parse(Console.ReadLine());

            Aula aula = new Aula(id, nombre, capacidad);

            aulaService.AgregarAula(aula);

            Console.WriteLine("Aula registrada correctamente.");
        }

        // LISTAR AULAS

        private void ListarAulas()
        {
            List<Aula> aulas = aulaService.ObtenerAulas();

            if (aulas.Count == 0)
            {
                Console.WriteLine("No hay aulas registradas.");
                return;
            }

            foreach (Aula aula in aulas)
            {
                Console.WriteLine($"ID: {aula.Id}");
                Console.WriteLine($"Nombre: {aula.Nombre}");
                Console.WriteLine($"Capacidad: {aula.Capacidad}");
                Console.WriteLine("----------------------------");
            }
        }

        // REGISTRAR ESTUDIANTE

        private void RegistrarEstudiante()
        {
            Console.Write("ID del estudiante: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine();

            Console.Write("Fecha de nacimiento (yyyy-mm-dd): ");
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Sexo (1 = Masculino, 2 = Femenino): ");
            int opcionSexo = int.Parse(Console.ReadLine());

            Sexo sexo;

            if (opcionSexo == 1)
            {
                sexo = Sexo.Masculino;
            }
            else
            {
                sexo = Sexo.Femenino;
            }

            // MOSTRAR AULAS DISPONIBLES

            ListarAulas();

            Console.Write("ID del aula: ");
            int aulaId = int.Parse(Console.ReadLine());

            Aula aula = aulaService.BuscarPorId(aulaId);

            if (aula == null)
            {
                Console.WriteLine("Aula no encontrada.");
                return;
            }

            Estudiante estudiante = new Estudiante(
                id,
                nombre,
                apellido,
                sexo,
                fechaNacimiento,
                matricula,
                aula
            );

            estudianteService.AgregarEstudiante(estudiante);

            Console.WriteLine("Estudiante registrado correctamente.");
        }

        // LISTAR ESTUDIANTES

        private void ListarEstudiantes()
        {
            List<Estudiante> estudiantes = estudianteService.ObtenerEstudiantes();

            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            foreach (Estudiante estudiante in estudiantes)
            {
                Console.WriteLine($"ID: {estudiante.Id}");
                Console.WriteLine($"Nombre: {estudiante.ObtenerNombreCompleto()}");
                Console.WriteLine($"Edad: {estudiante.ObtenerEdad()}");
                Console.WriteLine($"Matrícula: {estudiante.Matricula}");
                Console.WriteLine($"Aula: {estudiante.Aula.Nombre}");
                Console.WriteLine("----------------------------");
            }
        }
    }
}
