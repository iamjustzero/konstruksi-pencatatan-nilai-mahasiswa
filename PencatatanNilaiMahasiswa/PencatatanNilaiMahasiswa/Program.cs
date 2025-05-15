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
        public double NilaiAngka { get; set; }
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
                        InputNilai();
                        break;
                    case 2:
                        EditNilai();
                        break;
                    case 3:
                        HapusNilai();
                        break;
                    case 4:
                        HitungIPK();
                        break;
                    case 5:
                        LihatNilai();
                        break;
                    case 6:
                        TampilkanRangking();
                        break;
                    case 7:
                        Keluar();
                        break;
                    default:
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

            Console.Write("Masukkan nama mata kuliah: ");
            string mk = Console.ReadLine();

            Console.Write("Masukkan nilai angka (0-100): ");
            if (double.TryParse(Console.ReadLine(), out double nilaiAngka))
            {
                semuaNilai.Add(new NilaiMahasiswa
                {
                    Username = currentUser.Username,
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
            Console.WriteLine("Edit Nilai");
            MainApp();
        }

        static void HapusNilai()
        {
            Console.WriteLine("Hapus Nilai");
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
                    Console.WriteLine($"Mata Kuliah : {nilai.MataKuliah}, Nilai : {nilai.NilaiAngka}");
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
    }
}