using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            string locatie = @"C:\Users\tim.vercauteren\Documents\Sudokus\";
            try
            {
                int teken;
                using (var lezer = new StreamReader(locatie + "SU_Plaintext.txt"))
                {
                    while ((teken = lezer.Read()) != -1)
                    {
                        Console.Write((char)teken);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
