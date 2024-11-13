using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VyssiPrvocislo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(VyssiPrvocislo());
            Console.ReadLine();
        }
        static bool JePrvocislo(int Cislo)
        {
            for (int i = 2; i < Cislo; i++)
            {
                if (Cislo % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static int VyssiPrvocislo(int Hodnota)
        {
            int Cislo = Hodnota;
            while (1 < 2)
            {
                Cislo = Cislo + 1;
                if (JePrvocislo(Cislo))
                {
                    return Cislo;
                }
            }
        }
    }
}
