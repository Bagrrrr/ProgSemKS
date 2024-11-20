using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hledac2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            List<int>[] kamaradi = new List<int>[n + 1];
            for (int x = 0; x < n + 1; x++)
            {
                kamaradi[x] = new List<int>();
            }
            string[] pratelstvi = Console.ReadLine().Split(' ');
            foreach (string x in pratelstvi)
            {
                string[] spoj = x.Split('-');
                int i1 = Int32.Parse(spoj[0]);
                int i2 = Int32.Parse(spoj[1]);
                kamaradi[i1].Add(i2);
                kamaradi[i2].Add(i1);
            }
            string[] startcil = Console.ReadLine().Split(' ');
            int start = Int32.Parse(startcil[0]);
            int cil = Int32.Parse(startcil[1]);
            List<int> projite = new List<int>();
            List<int[]> cesty = new List<int[]>();
            projite.Add(start);
            cesty.Add(new int[start]);
            int last = 0;
            foreach (int x in kamaradi[start])
            {
                projite.Add(x);
                int[] cesta = new int[2];
                cesta[0] = start;
                cesta[1] = x;
                if (cesta[0] != cesta[1])
                {
                    cesty.Add(cesta);
                }
            }
            int num = 2;
            while (num < n + 1)                                                                                     //O(n)
            {
                int pocetCest = cesty.Count;
                for (int i = 0; i < pocetCest; i++)                                                                 //O(n2)
                {
                    if (cesty[i].Length == num)
                    {
                        last = cesty[i].Last();
                        for (int j = 0; j < kamaradi[last].Count; j++)                                              // CASOVA SLOZITOST = O(n3)
                        {
                            int[] cesta = cesty[i].Concat(new int[] { kamaradi[last][j] }).ToArray();
                            if (!projite.Contains(cesta[cesta.Length - 1]))
                            {
                                cesty.Add(cesta);
                                projite.Add(cesta.Last());
                            }
                        }
                    }

                }
                for (int i = 0; i < cesty.Count; i++)
                {
                    last = cesty[i].Last();
                    if (last == cil)
                    {
                        int[] retizek = cesty[i];
                        foreach (int x in retizek)
                        {
                            Console.Write(x);
                            Console.Write(" ");
                        }
                        goto End;
                    }
                }
                num = num + 1;

            }
            Console.WriteLine("neexistuje");
            End:
                Console.ReadLine();
                    
            
        }
    }
}
