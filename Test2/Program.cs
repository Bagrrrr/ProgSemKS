using System.Collections.Concurrent;
using System.Runtime.InteropServices.JavaScript;

namespace Test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pocetPr = Convert.ToInt32(Console.ReadLine());

            Pole[,] poleArray = new Pole[8, 8];
                for (int i = 0; i < 8; i++) // tvorba sachovnice
            {
                for (int j = 0; j < 8; j++)
                {
                    poleArray[i, j] = new Pole(i, j);
                }
            }
            for (int i = 0; i < pocetPr; i++)  // tvorba bloku
            {
                string[] blokk = new string[2];
                blokk = Console.ReadLine().Split(' ');
                int[] blokcoords = new int[2];
                for (int j = 0; j < 2; j++)
                {
                    blokcoords[j] = Convert.ToInt32(blokk[j]);
                }
                poleArray[blokcoords[0], blokcoords[1]].jePrekazka = true;
            }
            string[] blok = new string[2];      // cil a pak start, nechtel jsem to resit dele takze takhle je to naprosto krucialni
            blok = Console.ReadLine().Split(' ');
            int[] cilcoords = new int[2];
            for (int j = 0; j < 2; j++)
            {
                cilcoords[j] = Convert.ToInt32(blok[j]);
            }
            poleArray[cilcoords[0], cilcoords[1]].jeCil = true;
            blok = Console.ReadLine().Split(' ');
            int[] startcoords = new int[2];
            for (int j = 0; j < 2; j++)
            {
                startcoords[j] = Convert.ToInt32(blok[j]);
            }

            Pole startpole = poleArray[startcoords[0], startcoords[1]];  // zacatecik s frontou
            startpole.vzdalenostOdStartu = 0;
            startpole.jeNavstiveno = true;
            Queue<Pole> fronta = new Queue<Pole>();
            fronta.Enqueue(startpole);


            while (fronta.Count > 0)  // krouzkuju v bfs
              
            {
                Pole CurrentPole = fronta.Dequeue();
                if (CurrentPole.jeCil)
                {
                    Console.WriteLine(CurrentPole.vzdalenostOdStartu);
                    return;
                }

                int x = CurrentPole.x;
                int y = CurrentPole.y;


                if (x + 2 < 8 && y + 1 < 8)  // naprosto kriticka rada if statementu pro pohyb kone na sousedy
                {
                    if (!poleArray[x + 2, y + 1].jeNavstiveno && !poleArray[x + 2, y + 1].jePrekazka)
                    {
                        poleArray[x + 2, y + 1].vzdalenostOdStartu = CurrentPole.vzdalenostOdStartu + 1;
                        poleArray[x + 2, y + 1].jeNavstiveno = true;
                        fronta.Enqueue(poleArray[x + 2, y + 1]);
                    }
                }
                if (x + 2 < 8 && y - 1 >= 0)
                {
                    if (!poleArray[x + 2, y - 1].jeNavstiveno && !poleArray[x + 2, y - 1].jePrekazka)
                    {
                        poleArray[x + 2, y - 1].vzdalenostOdStartu = CurrentPole.vzdalenostOdStartu + 1;
                        poleArray[x + 2, y - 1].jeNavstiveno = true;
                        fronta.Enqueue(poleArray[x + 2, y - 1]);
                    }
                }
                if (x - 2 >= 0 && y + 1 < 8)
                {
                    if (!poleArray[x - 2, y + 1].jeNavstiveno && !poleArray[x - 2, y + 1].jePrekazka)
                    {
                        poleArray[x - 2, y + 1].vzdalenostOdStartu = CurrentPole.vzdalenostOdStartu + 1;
                        poleArray[x - 2, y + 1].jeNavstiveno = true;
                        fronta.Enqueue(poleArray[x - 2, y + 1]);
                    }
                }
                if (x - 2 >= 0 && y - 1 >= 0)
                {
                    if (!poleArray[x - 2, y - 1].jeNavstiveno && !poleArray[x - 2, y - 1].jePrekazka)
                    {
                        poleArray[x - 2, y - 1].vzdalenostOdStartu = CurrentPole.vzdalenostOdStartu + 1;
                        poleArray[x - 2, y - 1].jeNavstiveno = true;
                        fronta.Enqueue(poleArray[x - 2, y - 1]);
                    }
                }
                if (x + 1 < 8 && y + 2 < 8)
                {
                    if (!poleArray[x + 1, y + 2].jeNavstiveno && !poleArray[x + 1, y + 2].jePrekazka)
                    {
                        poleArray[x + 1, y + 2].vzdalenostOdStartu = CurrentPole.vzdalenostOdStartu + 1;
                        poleArray[x + 1, y + 2].jeNavstiveno = true;
                        fronta.Enqueue(poleArray[x + 1, y + 2]);
                    }
                }
                if (x + 1 < 8 && y - 2 >= 0)
                {
                    if (!poleArray[x + 1, y - 2].jeNavstiveno && !poleArray[x + 1, y - 2].jePrekazka)
                    {
                        poleArray[x + 1, y - 2].vzdalenostOdStartu = CurrentPole.vzdalenostOdStartu + 1;
                        poleArray[x + 1, y - 2].jeNavstiveno = true;
                        fronta.Enqueue(poleArray[x + 1, y - 2]);
                    }
                }
                if (x - 1 >= 0 && y + 2 < 8)
                {
                    if (!poleArray[x - 1, y + 2].jeNavstiveno && !poleArray[x - 1, y + 2].jePrekazka)
                    {
                        poleArray[x - 1, y + 2].vzdalenostOdStartu = CurrentPole.vzdalenostOdStartu + 1;
                        poleArray[x - 1, y + 2].jeNavstiveno = true;
                        fronta.Enqueue(poleArray[x - 1, y + 2]);
                    }
                }
                if (x - 1 >= 0 && y - 2 >= 0)
                {
                    if (!poleArray[x - 1, y - 2].jeNavstiveno && !poleArray[x - 1, y - 2].jePrekazka)
                    {
                        poleArray[x - 1, y - 2].vzdalenostOdStartu = CurrentPole.vzdalenostOdStartu + 1;
                        poleArray[x - 1, y - 2].jeNavstiveno = true;
                        fronta.Enqueue(poleArray[x - 1, y - 2]);
                    }
                }
            }

            Console.WriteLine("Do cíle se koněm nelze dostat.");
        }

        class Pole       //naprosto prvotridni a unikatni trida co si zaslouzi potlesk
        {
            public bool jeCil { get; set; }
            public bool jePrekazka { get; set; }

            public bool jeNavstiveno { get; set; }

            public int vzdalenostOdStartu { get; set; }
            public int x { get; set; }
            public int y { get; set; }

            public Pole(int x, int y)  // muj prvni konstruktor, jsem na sebe hrdy
            {
                this.x = x;
                this.y = y;

            }

        }

    }
}
