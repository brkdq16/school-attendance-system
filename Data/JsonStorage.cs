using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SistemaAsistenciaEscolar.Data
{
    public class JsonStorage
    {
        private readonly string basePath = "Data/";

        public JsonStorage()
        {
            // Asegura que la carpeta exista
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
        }

        public void Save<T>(string fileName, List<T> data)
        {
            string path = Path.Combine(basePath, fileName);

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);
        }

        public List<T> Load<T>(string fileName)
        {
            string path = Path.Combine(basePath, fileName);

            if (!File.Exists(path))
                return new List<T>();

            string json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
    }
}