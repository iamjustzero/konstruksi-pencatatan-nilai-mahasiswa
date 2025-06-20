using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeApp;

namespace GradeAppTest
{
    [TestClass]
    public class MahasiswaRepositoryTests
    {
        [TestInitialize]
        public void TestSetup()
        {
            if (File.Exists("mahasiswa.json"))
                File.Delete("mahasiswa.json");
        }

        [TestMethod]
        public void LoadData_ShouldReturnListOfMahasiswa()
        {
            // Act
            var result = MahasiswaRepository.LoadData();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Mahasiswa>));
        }

        [TestMethod]
        public void SaveData_ThenLoadData_ShouldReturnSameData()
        {
            // Arrange
            var originalData = new List<Mahasiswa>
            {
                new Mahasiswa
                {
                    NIM = "123",
                    Nama = "Siti",
                    DaftarNilai = new List<MataKuliah>
                    {
                        new MataKuliah { Nama_MK = "Matematika", Nilai = 90 },
                        new MataKuliah { Nama_MK = "Fisika", Nilai = 85 }
                    }
                }
            };

            // Act
            MahasiswaRepository.SaveData(originalData);
            var loadedData = MahasiswaRepository.LoadData();

            // Assert
            Assert.AreEqual(originalData.Count, loadedData.Count);
            Assert.AreEqual(originalData[0].NIM, loadedData[0].NIM);
            Assert.AreEqual(originalData[0].Nama, loadedData[0].Nama);
            Assert.AreEqual(originalData[0].DaftarNilai.Count, loadedData[0].DaftarNilai.Count);
            Assert.AreEqual(originalData[0].DaftarNilai[0].Nama_MK, loadedData[0].DaftarNilai[0].Nama_MK);
            Assert.AreEqual(originalData[0].DaftarNilai[0].Nilai, loadedData[0].DaftarNilai[0].Nilai);
        }
    }
}
