using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencatatanNilaiMahasiswa;
using System.Collections.Generic;

namespace TestApp
{
    [TestClass]
    public class NilaiTests
    {
        [TestMethod]
        public void ListNilaiMahasiswa_BisaDibuat()
        {
            // Arrange
            var listNilai = new List<NilaiMahasiswa>();

            // Act
            listNilai.Add(new NilaiMahasiswa
            {
                NamaMahasiswa = "Andi",
                MataKuliah = "Matematika",
                NilaiAngka = 85
            });

            // Assert
            Assert.AreEqual(1, listNilai.Count);
            Assert.AreEqual("Andi", listNilai[0].NamaMahasiswa);
            Assert.AreEqual("Matematika", listNilai[0].MataKuliah);
            Assert.AreEqual(85, listNilai[0].NilaiAngka);
        }
    }
}