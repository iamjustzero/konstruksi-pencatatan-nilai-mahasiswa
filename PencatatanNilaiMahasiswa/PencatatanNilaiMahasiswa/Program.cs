﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PencatatanNilaiMahasiswa
{
    public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }

    public class NilaiMahasiswa
    {
        public string Username { get; set; }
        public string NamaMahasiswa { get; set; }
        public string MataKuliah { get; set; }
        public double NilaiAngka { get; set; }
    }

    public class JsonDataService<T> where T : class
    {
        private readonly string _filePath;
        public JsonDataService(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> Load()
        {
            if (!File.Exists(_filePath))
                return new List<T>();
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public void Save(List<T> data)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public void Remove(Func<T, bool> predicate)
        {
            var data = Load();
            var toRemove = data.Where(predicate).ToList();
            if (toRemove.Any())
            {
                foreach (var item in toRemove)
                {
                    data.Remove(item);
                }
                Save(data);
            }
        }
    }

    public class Program
    {
        static string filePath = "users.json";
        static string nilaiFilePath = "nilai_mahasiswa.json";
        static List<User> users = new List<User>();
        static User? currentUser;

        static void Main(string[] args)
        {
            users = LoadUsers();
            Welcome();
        }

        static void Welcome()
        {
            Console.WriteLine("- - - Welcome - - -");
            Console.WriteLine("(1)Register");
            Console.WriteLine("(2)Login");
            Console.Write("Pilih: ");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Register();
                }
                else if (choice == 2)
                {
                    Login();
                }
                else
                {
                    Console.WriteLine("Input Tidak Valid");
                    Welcome();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Terjadi Kesalahan : " + e);
                Welcome();
            }
        }

        static void Register()
        {
            Console.WriteLine(" - Register - ");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            try
            {
                if (users.Any(u => u.Username == username))
                {
                    Console.WriteLine("Username sudah ada.");
                    return;
                }
                users.Add(new User { Username = username, PasswordHash = HashPassword(password) });
                SaveUsers(users);
                Console.WriteLine("User berhasil terdaftar.");
                Login();
            }
            catch (Exception e)
            {
                Console.WriteLine("Terjadi Kesalahan : " + e);
                Register();
            }
        }

        static void Login()
        {
            Console.WriteLine(" - Login - ");
            Console.Write("Username: ");
            string username = Console.ReadLine() ;
            Console.Write("Password: ");
            string password = Console.ReadLine();
            var user = users.FirstOrDefault(u => u.Username == username);
            try
            {
                if (user != null && user.PasswordHash == HashPassword(password))
                {
                    currentUser = user;
                    ClearScreen();
                    Console.WriteLine("Login berhasil!");
                    MainApp();
                }
                else
                {
                    Console.WriteLine("Username atau password salah.");
                    Login();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Terjadi kesalahan : " + e);
                Login();
            }
        }

        static void MainApp()
        {
            Console.WriteLine("~ Pencatatan Nilai Mahasiswa ~");
            Console.WriteLine("(1) Input Nilai Mata Kuliah");
            Console.WriteLine("(2) Edit Nilai Mata Kuliah");
            Console.WriteLine("(3) Hapus Nilai Mata Kuliah");
            Console.WriteLine("(4) Hitung IPK");
            Console.WriteLine("(5) Lihat Nilai");
            Console.WriteLine("(6) Tampilkan Rangking");
            Console.WriteLine("(7) Keluar");
            Console.Write("Pilih : ");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ClearScreen();
                        InputNilai();
                        break;
                    case 2:
                        ClearScreen();
                        EditNilai();
                        break;
                    case 3:
                        ClearScreen();
                        HapusNilai();
                        break;
                    case 4:
                        ClearScreen();
                        HitungIPK();
                        break;
                    case 5:
                        ClearScreen();
                        LihatNilai();
                        break;
                    case 6:
                        ClearScreen();
                        TampilkanRangking();
                        break;
                    case 7:
                        ClearScreen();
                        Keluar();
                        break;
                    default:
                        ClearScreen();
                        Console.WriteLine("Pilihan tidak valid.");
                        MainApp();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Terjadi Kesalahan : " + e);
                MainApp();
            }
        }

        static void InputNilai()
        {
            Console.WriteLine("Input Nilai");
            var semuaNilai = LoadNilai();

            Console.Write("Masukkan nama mahasiswa: ");
            string namaMahasiswa = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(namaMahasiswa))
            {
                Console.WriteLine("❌ Nama mahasiswa tidak boleh kosong.");
                MainApp();
                return;
            }

            Console.Write("Masukkan nama mata kuliah: ");
            string mk = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(mk))
            {
                Console.WriteLine("❌ Nama mata kuliah tidak boleh kosong.");
                MainApp();
                return;
            }

            Console.Write("Masukkan nilai angka (0-100): ");
            if (double.TryParse(Console.ReadLine(), out double nilaiAngka))
            {
               
                if (nilaiAngka < 0 || nilaiAngka > 100)
                {
                    Console.WriteLine("❌ Nilai harus antara 0 dan 100.");
                    MainApp();
                    return;
                }

                if (currentUser == null)
                {
                    Console.WriteLine("❌ Error: User belum login.");
                    MainApp();
                    return;
                }

                semuaNilai.Add(new NilaiMahasiswa
                {
                    Username = currentUser.Username,
                    NamaMahasiswa = namaMahasiswa,
                    MataKuliah = mk,
                    NilaiAngka = nilaiAngka
                });

                SaveNilai(semuaNilai);

                var inserted = semuaNilai.Any(n =>
                    n.Username == currentUser.Username &&
                    n.NamaMahasiswa == namaMahasiswa &&
                    n.MataKuliah == mk &&
                    n.NilaiAngka == nilaiAngka
                );

                if (inserted)
                {
                    Console.WriteLine("✅ Nilai berhasil disimpan.");
                }
                else
                {
                    Console.WriteLine("❌ Gagal menyimpan nilai.");
                }
            }
            else
            {
                Console.WriteLine("❌ Nilai harus berupa angka.");
            }

            MainApp();
        }


        static void LihatNilai()
        {
            Console.WriteLine("=== Daftar Nilai ===");
            var semuaNilai = LoadNilai();
            var nilaiUser = semuaNilai.Where(n => n.Username == currentUser?.Username).ToList();

            if (!nilaiUser.Any())
            {
                Console.WriteLine("Belum ada nilai tersimpan.");
            }
            else
            {
                Console.WriteLine("+----+----------------------+----------------------+-----------+");
                Console.WriteLine("| No | Nama Mahasiswa       | Mata Kuliah          | Nilai     |");
                Console.WriteLine("+----+----------------------+----------------------+-----------+");
                for (int i = 0; i < nilaiUser.Count; i++)
                {
                    var n = nilaiUser[i];
                    Console.WriteLine($"| {i + 1,2} | {n.NamaMahasiswa,-20} | {n.MataKuliah,-20} | {n.NilaiAngka,5:F2}   |");
                }
                Console.WriteLine("+----+----------------------+----------------------+-----------+");
            }
            MainApp();
        }

        static void EditNilai()
        {
<<<<<<< HEAD

            var semuaNilai = LoadNilai();
            Console.Write("Masukkan nama mata kuliah: ");
            string mk = Console.ReadLine();

            // mencari nilai 
            var nilaiMahasiswa = semuaNilai.FirstOrDefault(n => n.Username == currentUser.Username && n.MataKuliah == mk);

            if (nilaiMahasiswa != null)
            {
                Console.WriteLine($"Nilai saat ini untuk mata kuliah {mk} adalah {nilaiMahasiswa.NilaiAngka}");
                Console.Write("Masukkan nilai baru (0-100: )");

                if (double.TryParse(Console.ReadLine(), out double nilaiBaru))
                {
                    // precondition
                    if (nilaiBaru < 0 || nilaiBaru > 100)
                    {
                        Console.WriteLine("Nilai tidak valid, nilai harys dalam rentang 0 - 100");
                    }
                    else
                    {
                        // update nilai
                        nilaiMahasiswa.NilaiAngka = nilaiBaru;
                        SaveNilai(semuaNilai);
                        Console.WriteLine("Nilai diperbarui");
=======
            Console.WriteLine("Edit Nilai");
            var semuaNilai = LoadNilai();
            var nilaiUser = semuaNilai
                .Where(n => n.Username == currentUser?.Username)
                .ToList();
            if (nilaiUser.Count == 0)
            {
                Console.WriteLine("Belum ada nilai yang dapat diedit.");
                MainApp();
                return;
            }
            Console.WriteLine("Daftar Nilai Anda:");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("| No | Nama Mahasiswa       | Mata Kuliah            | Nilai                   |");
            Console.WriteLine("---------------------------------------------------------------------------------");
            for (int i = 0; i < nilaiUser.Count; i++)
            {
                Console.WriteLine($"| {i + 1,2} | {nilaiUser[i].NamaMahasiswa,-20} | {nilaiUser[i].MataKuliah,-22} | {nilaiUser[i].NilaiAngka,5:F2}                  |");
            }
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.Write("Pilih nomor data yang ingin diedit: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= nilaiUser.Count)
            {
                var nilaiDipilih = nilaiUser[index - 1];
                Console.WriteLine($"Mengedit Nilai:");
                Console.WriteLine($"Nama Mahasiswa : {nilaiDipilih.NamaMahasiswa}");
                Console.WriteLine($"Mata Kuliah    : {nilaiDipilih.MataKuliah}");
                Console.WriteLine($"Nilai Saat Ini : {nilaiDipilih.NilaiAngka}");
                Console.Write("Masukkan nilai baru (0-100): ");
                if (double.TryParse(Console.ReadLine(), out double nilaiBaru))
                {
                    if (nilaiBaru < 0 || nilaiBaru > 100)
                    {
                        Console.WriteLine("❌ Nilai harus berada dalam rentang 0 - 100.");
                    }
                    else
                    {
                        var target = semuaNilai.Find(n =>
                            n.Username == currentUser?.Username &&
                            n.MataKuliah == nilaiDipilih.MataKuliah &&
                            n.NamaMahasiswa == nilaiDipilih.NamaMahasiswa);
                        if (target != null)
                        {
                            target.NilaiAngka = nilaiBaru;
                            SaveNilai(semuaNilai);
                            Console.WriteLine("✅ Nilai berhasil diperbarui.");
                        }
                        else
                        {
                            Console.WriteLine("❌ Data tidak ditemukan.");
                        }
>>>>>>> dbbf1be5d2b7d9381953cdff268a50d7d4ad4cd3
                    }
                }
                else
                {
<<<<<<< HEAD
                    Console.WriteLine("Inputan tidak valid");
=======
                    Console.WriteLine("❌ Input tidak valid.");
>>>>>>> dbbf1be5d2b7d9381953cdff268a50d7d4ad4cd3
                }
            }
            else
            {
<<<<<<< HEAD
                Console.WriteLine("Nilai mata kuliah tidak ditemukan ");
            }

            MainApp();
        }

        static void HapusNilai()
        {
            Console.WriteLine("Hapus Nilai");
=======
                Console.WriteLine("❌ Pilihan tidak valid.");
            }
>>>>>>> dbbf1be5d2b7d9381953cdff268a50d7d4ad4cd3
            MainApp();
        }

        static void HitungIPK()
        {
            Console.WriteLine("=== Hitung IPK ===");
            var semuaNilai = LoadNilai();

            var daftarMahasiswa = semuaNilai
                .Where(n => n.Username == currentUser?.Username)
                .GroupBy(n => n.NamaMahasiswa)
                .Select(g => g.Key)
                .ToList();

            if (!daftarMahasiswa.Any())
            {
                Console.WriteLine("Belum ada data mahasiswa.");
                MainApp();
                return;
            }

            Console.WriteLine("Pilih Nama Mahasiswa:");
            for (int i = 0; i < daftarMahasiswa.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {daftarMahasiswa[i]}");
            }
            Console.Write("Masukkan nomor mahasiswa: ");

            if (int.TryParse(Console.ReadLine(), out int pilihan) &&
                pilihan >= 1 && pilihan <= daftarMahasiswa.Count)
            {
                string namaMahasiswa = daftarMahasiswa[pilihan - 1];
                var nilaiMahasiswa = semuaNilai
                    .Where(n => n.NamaMahasiswa == namaMahasiswa && n.Username == currentUser?.Username)
                    .ToList();

                if (!nilaiMahasiswa.Any())
                {
                    Console.WriteLine("Mahasiswa tidak memiliki nilai.");
                    MainApp();
                    return;
                }

                double totalSkorIP = 0;

                foreach (var nilai in nilaiMahasiswa)
                {
                    double skorIP = 0;
                    if (nilai.NilaiAngka >= 80) skorIP = 4.0;
                    else if (nilai.NilaiAngka >= 70) skorIP = 3.0;
                    else if (nilai.NilaiAngka >= 60) skorIP = 2.0;
                    else if (nilai.NilaiAngka >= 50) skorIP = 1.0;
                    else skorIP = 0.0;

                    totalSkorIP += skorIP;
                }

                double ipk = totalSkorIP / nilaiMahasiswa.Count;

                Console.WriteLine($"\nMahasiswa: {namaMahasiswa}");
                Console.WriteLine($"Jumlah Mata Kuliah: {nilaiMahasiswa.Count}");
                Console.WriteLine($"Total Skor IP: {totalSkorIP:F2}");
                Console.WriteLine($"IPK: {ipk:F2}");
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid.");
            }

            MainApp();
        }

        static void TampilkanRangking()
        {
            Console.WriteLine("=== Leaderboard - Rangking Berdasarkan IPK ===");
            var semuaNilai = LoadNilai();


            var daftarMahasiswa = semuaNilai
                .Where(n => n.Username == currentUser?.Username)
                .GroupBy(n => n.NamaMahasiswa)
                .Select(g => g.Key)
                .ToList();

            if (!daftarMahasiswa.Any())
            {
                Console.WriteLine("Belum ada data mahasiswa.");
                MainApp();
                return;
            }

            var daftarIPK = new List<(string Nama, double IPK)>();

            foreach (var nama in daftarMahasiswa)
            {
                var nilaiMahasiswa = semuaNilai
                    .Where(n => n.NamaMahasiswa == nama && n.Username == currentUser?.Username)
                    .ToList();

                double totalSkorIP = 0;

                foreach (var nilai in nilaiMahasiswa)
                {
                    // ini bisa diubah ke table driven
                    double skorIP = 0;
                    if (nilai.NilaiAngka >= 80) skorIP = 4.0;
                    else if (nilai.NilaiAngka >= 70) skorIP = 3.0;
                    else if (nilai.NilaiAngka >= 60) skorIP = 2.0;
                    else if (nilai.NilaiAngka >= 50) skorIP = 1.0;
                    else skorIP = 0.0;

                    totalSkorIP += skorIP;
                }

                double ipk = totalSkorIP / nilaiMahasiswa.Count;

                daftarIPK.Add((nama, ipk));
            }


            daftarIPK = daftarIPK.OrderByDescending(x => x.IPK).ToList();

            Console.WriteLine("\nNo\tNama Mahasiswa\t\tIPK");
            Console.WriteLine("----------------------------------------");
            int no = 1;
            foreach (var item in daftarIPK)
            {
                Console.WriteLine($"{no++}\t{item.Nama,-20} \t{item.IPK:F2}");
            }

            MainApp();
        }

        static void HapusNilai()
        {
            var nilaiService = new JsonDataService<NilaiMahasiswa>(nilaiFilePath);
            var semuaNilai = nilaiService.Load()
                .Where(n => n.Username == currentUser?.Username)
                .ToList();
            if (!semuaNilai.Any())
            {
                Console.WriteLine("Belum ada nilai yang tercatat.");
                MainApp();
                return;
            }
            Console.WriteLine("Daftar Nilai Anda:");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("| No | Nama Mahasiswa       | Mata Kuliah            | Nilai                   |");
            Console.WriteLine("---------------------------------------------------------------------------------");
            for (int i = 0; i < semuaNilai.Count; i++)
            {
                Console.WriteLine($"| {i + 1,2} | {semuaNilai[i].NamaMahasiswa,-20} | {semuaNilai[i].MataKuliah,-22} | {semuaNilai[i].NilaiAngka,5:F2}                  |");
            }
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.Write("Pilih nomor data yang ingin dihapus: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= semuaNilai.Count)
            {
                var nilaiDipilih = semuaNilai[index - 1];
                Console.WriteLine($"Anda yakin ingin menghapus nilai berikut? (y/n)");
                Console.WriteLine($"Nama Mahasiswa : {nilaiDipilih.NamaMahasiswa}");
                Console.WriteLine($"Mata Kuliah    : {nilaiDipilih.MataKuliah}");
                Console.WriteLine($"Nilai          : {nilaiDipilih.NilaiAngka}");
                string konfirmasi = Console.ReadLine();
                if (konfirmasi?.ToLower() == "y")
                {
                    nilaiService.Remove(n =>
                        n.Username == currentUser?.Username &&
                        n.MataKuliah.Equals(nilaiDipilih.MataKuliah, StringComparison.OrdinalIgnoreCase) &&
                        n.NamaMahasiswa.Equals(nilaiDipilih.NamaMahasiswa, StringComparison.OrdinalIgnoreCase)
                    );
                    Console.WriteLine("Nilai berhasil dihapus.");
                }
                else
                {
                    Console.WriteLine("Penghapusan dibatalkan.");
                }
            }
            else
            {
                Console.WriteLine("❌ Pilihan tidak valid.");
            }
            MainApp();
        }

        static void Keluar()
        {
            Console.WriteLine("Anda Telah Keluar.");
        }

        static List<User> LoadUsers()
        {
            if (!File.Exists(filePath))
                return new List<User>();
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }


        static void SaveUsers(List<User> users)
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        static List<NilaiMahasiswa> LoadNilai()
        {
            if (!File.Exists(nilaiFilePath))
                return new List<NilaiMahasiswa>();
            string json = File.ReadAllText(nilaiFilePath);
            return JsonSerializer.Deserialize<List<NilaiMahasiswa>>(json) ?? new List<NilaiMahasiswa>();
        }

        static void SaveNilai(List<NilaiMahasiswa> daftarNilai)
        {
            string json = JsonSerializer.Serialize(daftarNilai, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(nilaiFilePath, json);
        }

        static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        static void ClearScreen()
        {
            Console.Clear();
        }
    }
}