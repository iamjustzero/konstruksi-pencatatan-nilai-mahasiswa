using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeApp; // pastikan namespace ini sesuai dengan namespace pada MahasiswaRepository dan Mahasiswa

namespace GradeAppTest
{
    [TestClass]
    public class MahasiswaRepositoryTests
    {
        [TestMethod]
        public void LoadData_ShouldReturnListOfMahasiswa()
        {
            // Act
            var result = MahasiswaRepository.LoadData();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Mahasiswa>));
        }
    }
}
