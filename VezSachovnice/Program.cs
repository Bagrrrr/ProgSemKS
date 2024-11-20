using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VezSachovnice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] prekazky = new char[8, 8];
            int[,] sachovnice = new int[10, 10];
            for (int i = 0; i < 8; i++)
            {

                string radekFull = Console.ReadLine();
                for (int x = 0; x < 8; x++)
                {
                    prekazky[i, x] = radekFull[x];
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (prekazky[i, x] == 'v')
                    {
                        sachovnice[i + 1, x + 1] = 0;
                    }
                    else if (prekazky[i, x] == 'c')
                    {
                        sachovnice[i + 1, x + 1] = 32;
                    }
                    else if (prekazky[i, x] == 'x')
                    {
                        sachovnice[i + 1, x + 1] = -10;
                    }
                    else if (prekazky[i, x] == '.')
                    {
                        sachovnice[i + 1, x + 1] = -1;
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (prekazky[i, x] == null)
                    {
                        sachovnice[i + 1, x + 1] = 0;
                    }
                }
            }
            while (true)
            {
                int x = 0;
                for (int i = 0; ; i++) {
            }
        }
    }
}
