using System.Text.Json;

namespace SistemaAsistenciaEscolar.Data
{
    public class JsonStorage
    {
        // GUARDAR DATOS

        public void Guardar<T>(string rutaArchivo, List<T> datos)
        {
            // CONVERTIR OBJETOS A JSON

            string json = JsonSerializer.Serialize(
                datos,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            // ESCRIBIR ARCHIVO

            File.WriteAllText(rutaArchivo, json);
        }

        // CARGAR DATOS

        public List<T> Cargar<T>(string rutaArchivo)
        {
            // SI EL ARCHIVO NO EXISTE

            if (!File.Exists(rutaArchivo))
            {
                return new List<T>();
            }

            // LEER JSON

            string json = File.ReadAllText(rutaArchivo);

            // CONVERTIR JSON A OBJETOS

            List<T> datos = JsonSerializer.Deserialize<List<T>>(json);

            // SI VIENE NULL

            if (datos == null)
            {
                return new List<T>();
            }

            return datos;
        }
    }
}
