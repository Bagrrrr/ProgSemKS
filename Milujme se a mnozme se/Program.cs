using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Milujme_se_a_mnozme_se
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            int[,] zeny = Read(n);
            int[,] muzi = Read(n);
            int[] dvojice = new int[n];
            for (int i = 0; i < n; i++)
            {
                dvojice[i] = zeny[0, i];
            }

            for (int i = 0; i < n; i++)
            {
                int[] muzichoice = new int[n];
                for (int k = 0; k < n; k++)
                {
                    if (muzi[i,k] == dvojice[k]) // nvm
                        
                    {
                        muzichoice[k]
                    }
                }
            }
            
            
        }
       static int[,] Read(int n)
        {
            int[,] matice = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] lajna = Console.ReadLine().Split(' ');

                for (int j = 0; j < n; j++)
                {
                    matice[i, j] = Int32.Parse(lajna[j]);
                }
            }
            return matice;
        }
    }
}
