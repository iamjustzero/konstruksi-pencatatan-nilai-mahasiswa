using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PencatatanNilaiMahasiswa
{
    public class Program
    {
        static string filePath = "users.json";
        static List<User> users = new List<User>();

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
                //int choice = Console.WriteLine();
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
            Console.WriteLine("(5) Tampilkan Rangking");
            Console.WriteLine("(6) Keluar");
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
                        HitungNilai();
                        break;
                    case 5:
                        TampilkanRangking();
                        break;
                    case 6:
                        Keluar();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Terjadi Kesalahan : " + e);
            }

        }

        static void InputNilai ()
        {
            Console.WriteLine("Input Nilai");
        }

        static void EditNilai()
        {
            Console.WriteLine("Edit Nilai");
        }

        static void HapusNilai()
        {
            Console.WriteLine("Hapus Nilai");
        }

        static void HitungNilai()
        {
            Console.WriteLine("Hitung Nilai");
        }

        static void TampilkanRangking()
        {
            Console.WriteLine("Tampilkan Rangking");
        }

        static void Keluar()
        {
            Console.WriteLine("Anda Telah Keluar.");
        }


        //

        static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
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
    }

    public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
