using System;
using System.Collections.Generic;
using System.Linq;

namespace HitungIPKRanking
{
    class Program
    {
        // Table-driven: konversi nilai huruf ke bobot
        static readonly Dictionary<string, double> gradeToPoint = new()
        {
            { "A", 4.0 },
            { "B", 3.0 },
            { "C", 2.0 },
            { "D", 1.0 },
            { "E", 0.0 }
        };

        // Data nilai mahasiswa (nama, list nilai [matkul, huruf])
        static List<Mahasiswa> mahasiswaList = new()
        {
            new Mahasiswa("Farid", new List<Nilai> {
                new("Matematika", "A"),
                new("Pemrograman", "B"),
                new("Statistika", "A"),
            }),
            new Mahasiswa("Ariana", new List<Nilai> {
                new("Matematika", "B"),
                new("Pemrograman", "B"),
                new("Statistika", "C"),
            }),
            new Mahasiswa("Rizky", new List<Nilai> {
                new("Matematika", "A"),
                new("Pemrograman", "A"),
                new("Statistika", "A"),
            })
        };

        static void Main(string[] args)
        {
            Console.WriteLine("=== PERHITUNGAN IPK & RANKING ===");

            foreach (var mhs in mahasiswaList)
            {
                mhs.IPK = HitungIPK(mhs.NilaiList);
            }

            // Urutkan berdasarkan IPK (descending)
            var ranking = mahasiswaList.OrderByDescending(m => m.IPK).ToList();

            // Tampilkan
            int posisi = 1;
            foreach (var mhs in ranking)
            {
                Console.WriteLine($"{posisi++}. {mhs.Nama} - IPK: {mhs.IPK:F2}");
            }
        }

        // Code reuse: fungsi menghitung IPK
        static double HitungIPK(List<Nilai> nilaiList)
        {
            double total = 0;
            foreach (var n in nilaiList)
            {
                if (gradeToPoint.TryGetValue(n.NilaiHuruf.ToUpper(), out double point))
                {
                    total += point;
                }
                else
                {
                    Console.WriteLine($"Nilai tidak valid: {n.NilaiHuruf}");
                }
            }

            return nilaiList.Count > 0 ? total / nilaiList.Count : 0;
        }
    }

    // Reusable class
    class Mahasiswa
    {
        public string Nama { get; set; }
        public List<Nilai> NilaiList { get; set; }
        public double IPK { get; set; }

        public Mahasiswa(string nama, List<Nilai> nilaiList)
        {
            Nama = nama;
            NilaiList = nilaiList;
        }
    }

    class Nilai
    {
        public string MataKuliah { get; set; }
        public string NilaiHuruf { get; set; }

        public Nilai(string matkul, string nilaiHuruf)
        {
            MataKuliah = matkul;
            NilaiHuruf = nilaiHuruf;
        }
    }
}
