using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PencatatanNilaiMahasiswa
{
    internal class Try
    {
        static void Main(string[] args)
        {
            Welcome();
        }

        static void Welcome()
        {
            Console.WriteLine("- - - Welcome - - -");
            Console.WriteLine("(1)Register");
            Console.WriteLine("(2)Login");
            //int choose = Console.ReadLine();
            int choose = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(choose);
        }
    }
}