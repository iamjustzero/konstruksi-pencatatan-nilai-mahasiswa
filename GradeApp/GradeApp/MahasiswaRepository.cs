using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GradeApp
{
    public static class MahasiswaRepository
    {
        private static string filePath = "mahasiswa.json";

        public static void SaveData(List<Mahasiswa> list)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static List<Mahasiswa> LoadData()
        {
            if (!File.Exists(filePath))
            {
                return new List<Mahasiswa>();
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
        }

        public static void Add(Mahasiswa mhs)
        {
            List<Mahasiswa> list = LoadData();
            var existing = list.Find(x => x.NIM == mhs.NIM);
            if (existing != null)
            {
                foreach (var mk in mhs.DaftarNilai)
                {
                    if (!existing.DaftarNilai.Any(x => x.Nama_MK.Equals(mk.Nama_MK, StringComparison.OrdinalIgnoreCase)))
                    {
                        existing.DaftarNilai.Add(mk);
                    }
                }
            }
            else
            {
                list.Add(mhs);
            }
            SaveData(list);
        }

        public static void SaveAll(List<Mahasiswa> semuaData)
        {
            SaveData(semuaData);
        }

        public static void Delete(string nim)
        {
            List<Mahasiswa> list = LoadData();
            list.RemoveAll(x => x.NIM == nim);
            SaveData(list);
        }

        public static void Update(Mahasiswa mhsLama, Mahasiswa mhsBaru)
        {
            List<Mahasiswa> list = LoadData();
            int index = list.FindIndex(x => x.NIM == mhsLama.NIM);
            if (index != -1)
            {
                list[index] = mhsBaru;
                SaveData(list);
            }
        }
    }
}
