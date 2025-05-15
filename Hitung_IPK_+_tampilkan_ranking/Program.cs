using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PencatatanNilaiMahasiswa
{
    // Kelas untuk menyimpan data pengguna
    public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }

    // Kelas untuk menyimpan data nilai mahasiswa
    public class NilaiMahasiswa
    {
        public string Username { get; set; }
        public string MataKuliah { get; set; }
        public double NilaiAngka { get; set; }
    }

    // Kelas utama untuk Main aplikasi
    public class Program6

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

        //Menu tampilan awal
        static void Welcome()
        {
            Console.Clear();
            Console.WriteLine("- - - Welcome - - -");
            Console.WriteLine("(1) Register");
            Console.WriteLine("(2) Login");
            Console.WriteLine("(3) Exit");
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
                else if (choice == 3)
                {
                    Keluar();
                }
                else
                {
                    Console.WriteLine("Input Tidak Valid, Masukkan dengan Benar!");
                    Welcome();
                    Console.Clear();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Terjadi Kesalahan masukkan dengan benar!: " + e);
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
                    BackToHome();
                    return;
                }

                users.Add(new User { Username = username, PasswordHash = HashPassword(password) });
                SaveUsers(users);

                Clearscreen();
                Console.WriteLine("\n[User berhasil terdaftar.]/n");
                Login();
                Clearscreen();
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
                    Console.WriteLine("Username atau password salah, Masukkan dengan Benar!");
                    Login();
                    BackToHome();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Terjadi kesalahan : " + e);
                Login();
            }
        }

        // menu mahasiswa
        static void MainApp()
        {
            Console.WriteLine("~ Pencatatan Nilai Mahasiswa ~");
            Console.WriteLine("(1) Input Nilai Mata Kuliah");
            Console.WriteLine("(2) Edit Nilai Mata Kuliah");
            Console.WriteLine("(3) Hapus Nilai Mata Kuliah");
            Console.WriteLine("(4) Hitung IPK");
            Console.WriteLine("(5) Tampilkan Rangking");
            Console.WriteLine("(6) Keluar");
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
                        TampilkanRangking();
                        break;
                    case 6:
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

        static void TampilkanRangking()
        {
            //TODO: ME @duriskifeb
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

        //clear screen bersihkan dengan yang sebelumnya
        static void Clearscreen()
        {
            Clearscreen(); 
        }

        //back to Home Welcome
        static void BackToHome()
        {
            Console.WriteLine("Tekan Enter untuk kembali ke menu utama...");
            Console.ReadLine();
            Welcome();
        }
    }
}