using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GradeApp
{
    public static class MataKuliahRepository
    {
        private static string filePath = "matakuliah.json";

        public static void Save(List<UC_Subject.Matkul> list)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static List<UC_Subject.Matkul> Load()
        {
            if (!File.Exists(filePath))
                return new List<UC_Subject.Matkul>();

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<UC_Subject.Matkul>>(json);
        }
    }
}
