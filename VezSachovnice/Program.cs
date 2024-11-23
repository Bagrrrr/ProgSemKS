using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
                        sachovnice[i + 1, x + 1] = 1;
                    }
                    else if (prekazky[i, x] == 'c')
                    {
                        sachovnice[i + 1, x + 1] = 32;
                    }
                    else if (prekazky[i, x] == 'x')
                    {
                        sachovnice[i + 1, x + 1] = 0;
                    }
                    else if (prekazky[i, x] == '.')
                    {
                        sachovnice[i + 1, x + 1] = -1;
                    }
                }
            }
            int tah = 1;
            while (true)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (sachovnice[i, j] == tah)
                        {
                            for (int s = 1; s < 10; s++)
                            {
                                if (sachovnice[i, j + s] == -1)
                                {
                                    sachovnice[i, j + s] = tah + 1;
                                }
                                else if (sachovnice[i, j + s] == 32)
                                {
                                    Console.WriteLine(tah);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    break;
                                }

                            }
                            for (int s = 1; s < 10; s++)
                            {
                                if (sachovnice[i, j - s] == -1)
                                {
                                    sachovnice[i, j - s] = tah + 1;
                                }
                                else if (sachovnice[i, j - s] == 32)
                                {
                                    Console.WriteLine(tah);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    break;
                                }

                            }
                            for (int s = 1; s < 10; s++)
                            {
                                if (sachovnice[i + s, j] == -1)
                                {
                                    sachovnice[i + s, j] = tah + 1;
                                }
                                else if (sachovnice[i + s, j] == 32)
                                {
                                    Console.WriteLine(tah);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    break;
                                }
                            }
                            for (int s = 1; s < 10; s++)
                            {
                                if (sachovnice[i - s, j] == -1)
                                {
                                    sachovnice[i - s, j] = tah + 1;
                                }
                                else if (sachovnice[i - s, j] == 32)
                                {
                                    Console.WriteLine(tah);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                tah = tah + 1;
                if (tah > 32)
                {
                    Console.WriteLine (-1);
                    Console.ReadLine();
                }
            }
        }
    }
}
