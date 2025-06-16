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
            if (list == null) return;

            try
            {
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static List<UC_Subject.Matkul> Load()
        {
            try
            {
                if (!File.Exists(filePath))
                    return new List<UC_Subject.Matkul>();

                string json = File.ReadAllText(filePath);

                var result = JsonConvert.DeserializeObject<List<UC_Subject.Matkul>>(json);

                return result ?? new List<UC_Subject.Matkul>();
            }
            catch
            {
                return new List<UC_Subject.Matkul>();
            }
        }
    }
}