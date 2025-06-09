using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GradeApp
{

    public static class MahasiswaRepository
    {
        private static string filePath = "mahasiswa.json";

        // Simpan data ke file JSON
        //public static void SaveData(List<Mahasiswa> list)
        //{
        //    string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        //    File.WriteAllText(filePath, json);
        //}

        // Baca data dari file JSON
        //public static List<Mahasiswa> LoadData()
        //{
        //    if (!File.Exists(filePath))
        //    {
        //        return new List<Mahasiswa>();
        //    }

        //    string json = File.ReadAllText(filePath);
        //    return JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
        //}

        // Tambah data baru
        //public static void Add(Mahasiswa mhs)
        //{
        //    List<Mahasiswa> list = LoadData();
        //    list.Add(mhs);
        //    SaveData(list);
        //}

        // Hapus data berdasarkan NIM
        public static void Delete(string nim)
        {
            List<Mahasiswa> list = LoadData();
            list.RemoveAll(x => x.NIM == nim);
            SaveData(list);
        }

        // Update data
        //public static void Update(Mahasiswa mhsLama, Mahasiswa mhsBaru)
        //{
        //    List<Mahasiswa> list = LoadData();
        //    int index = list.FindIndex(x => x.NIM == mhsLama.NIM);
        //    if (index != -1)
        //    {
        //        list[index] = mhsBaru;
        //        SaveData(list);
        //    }
        //}
    }
}
