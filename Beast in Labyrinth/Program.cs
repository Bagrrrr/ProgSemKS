using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Beast_in_Labyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sirka = Convert.ToInt16(Console.ReadLine());
            int vyska = Convert.ToInt16(Console.ReadLine());
            string[,] plan = new string[sirka,vyska];
            for (int i = 0; i < vyska; i++)
            {
                string lajna = Console.ReadLine();
                for (int j = 0; j < sirka; j++)
                {
                    plan[i, j] = lajna[j].ToString();
                }
            }
            for (int i = 0; i < 20; i++)
            {
                List<int> pozice = FindHim(plan,sirka,vyska);
                if (WallInFront(plan,sirka,vyska) == true && WallInFront(plan, sirka, vyska) == true)
                {
                    RotateLeft(plan,sirka,vyska);
                }
            }


        }
        static List<int> FindHim(string[,] pole, int sirka, int vyska)
        {
            for (int i = 0; i < sirka; i++)
            {
                for (int j = 0; j < vyska; j++)
                {
                    if (pole[i,j] == "<" || pole[i, j] == "^" || pole[i, j] == ">" || pole[i, j] == "v")
                    {
                        return new List<int> {i , j};
                        
                    }
                }
            }
            return null;
        }
        static string[,] RotateLeft(string[,] pole, int sirka, int vyska)
        {

        }
        static string Rotace(string[,] pole, int sirka, int vyska)
        {
            List<int> pozice = FindHim(pole, sirka, vyska);
            return pole[pozice[0], pozice[1]];
        }
        static bool WallOnSide(string[,] pole, int sirka, int vyska)
        {
            List<int> pozice = FindHim(pole, sirka, vyska);
            string rotace = Rotace(pole, sirka, vyska);
            if (rotace == "^" && pole[pozice[0], pozice[1] + 1] == "X") { return true; }
            else if (rotace == ">" && pole[pozice[0] + 1, pozice[1]] == "X") { return true; }
            else if (rotace == "<" && pole[pozice[0] - 1, pozice[1]] == "X") { return true; }
            else if (rotace == "v" && pole[pozice[0], pozice[1] - 1] == "X") { return true; }
            return false;
        }
        static bool WallInFront(string[,] pole, int sirka, int vyska)
        {
            List<int> pozice = FindHim(pole, sirka, vyska);
            string rotace = Rotace(pole, sirka, vyska);
            if (rotace == "^" && pole[pozice[0] - 1, pozice[1]] == "X") { return true; }
            else if (rotace == ">" && pole[pozice[0], pozice[1] + 1] == "X") { return true; }
            else if (rotace == "<" && pole[pozice[0], pozice[1] - 1] == "X") { return true; }
            else if (rotace == "v" && pole[pozice[0] + 1, pozice[1]] == "X") { return true; }
            return false;
        }

    }
}
