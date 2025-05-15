using System;
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
        public string MataKuliah { get; set; }
        public string NamaMahasiswa { get; set; }
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
            return JsonSerializer.Deserialize<List<T>>(json);
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
        static User currentUser; 

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
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            var user = users.FirstOrDefault(u => u.Username == username);
            try
            {
                if (user != null && user.PasswordHash == HashPassword(password))
                {
                    currentUser = user;
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
            Console.WriteLine("Pilih : ");
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
            var semuaNilai = LoadNilai();
            Console.Write("Masukkan nama mahasiswa: ");
            string namaMahasiswa = Console.ReadLine();

            Console.Write("Masukkan nama mata kuliah: ");
            string mk = Console.ReadLine();


            Console.Write("Masukkan nilai angka (0-100): ");
            if (double.TryParse(Console.ReadLine(), out double nilaiAngka))
            {
                semuaNilai.Add(new NilaiMahasiswa
                {
                    Username = currentUser.Username,
                    NamaMahasiswa = namaMahasiswa,
                    MataKuliah = mk,
                    NilaiAngka = nilaiAngka
                });

                SaveNilai(semuaNilai);
                Console.WriteLine("Nilai berhasil disimpan.");
            }
            else
            {
                Console.WriteLine("Nilai tidak valid.");
            }

            MainApp();
        }

        static void EditNilai()
        {

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
                        Console.WriteLine("Nilai tidak valid, nilai harus dalam rentang 0 - 100");
                    }
                    else
                    {
                        // update nilai
                        nilaiMahasiswa.NilaiAngka = nilaiBaru;
                        SaveNilai(semuaNilai);
                        Console.WriteLine("Nilai diperbarui");
                    }
                }
                else
                {
                    Console.WriteLine("Inputan tidak valid");
                }
            }
            else
            {
                Console.WriteLine("Nilai mata kuliah tidak ditemukan ");
            }

            MainApp();
        }

        static void HapusNilai()
        {
            var nilaiService = new JsonDataService<NilaiMahasiswa>(nilaiFilePath);
            var semuaNilai = nilaiService.Load()
                .Where(n => n.Username == currentUser.Username)
                .ToList();

            if (!semuaNilai.Any())
            {
                Console.WriteLine("Belum ada nilai yang tercatat.");
                MainApp();
                return;
            }

            Console.WriteLine("Daftar Mata Kuliah Anda:");
            for (int i = 0; i < semuaNilai.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {semuaNilai[i].MataKuliah} - {semuaNilai[i].NilaiAngka}");
            }

            Console.Write("Pilih nomor yang ingin dihapus: ");
            if (int.TryParse(Console.ReadLine(), out int pilih) && pilih > 0 && pilih <= semuaNilai.Count)
            {
                var matkulDipilih = semuaNilai[pilih - 1].MataKuliah;

                nilaiService.Remove(n =>
                    n.Username == currentUser.Username &&
                    n.MataKuliah.Equals(matkulDipilih, StringComparison.OrdinalIgnoreCase)
                );

                Console.WriteLine("Nilai berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid.");
            }

            MainApp();
        }


        static void HitungIPK()
        {

        }

        static void LihatNilai ()
        {
            Console.WriteLine("Lihat Nilai");
            var semuaNilai = LoadNilai();

            var nilaiUser = semuaNilai.Where(n => n.Username == currentUser.Username).ToList();
            if (nilaiUser.Count == 0)
            {
                Console.WriteLine("Belum ada nilai yang tersimpan");
            } else
            {
                foreach (var nilai in nilaiUser)
                {
                    Console.WriteLine($"Nama Mahasiswa :{nilai.NamaMahasiswa} ,Mata Kuliah : {nilai.MataKuliah}, Nilai : {nilai.NilaiAngka}");
                }
            }

                MainApp();
        }

        static void TampilkanRangking()
        {
            Console.WriteLine("Tampilkan Rangking");
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
            return JsonSerializer.Deserialize<List<User>>(json);
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
            return JsonSerializer.Deserialize<List<NilaiMahasiswa>>(json);
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