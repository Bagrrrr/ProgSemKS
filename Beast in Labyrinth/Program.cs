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
            string[,] plan = new string[vyska,sirka];
            for (int i = 0; i < vyska; i++)
            {
                string lajna = Console.ReadLine();
                for (int j = 0; j < sirka; j++)
                {
                    plan[i, j] = lajna[j].ToString();
                }
            }
            bool y = true;
            for (int i = 0; i < 20; i++)
            {
                List<int> pozice = FindHim(plan,sirka,vyska);
                if (WallInFront(plan,sirka,vyska) == false && WallOnRight(plan, sirka, vyska) == true)
                {
                    GoForward(plan,sirka,vyska);
                }
                else if (WallInFront(plan, sirka, vyska) == true && WallOnRight(plan, sirka, vyska) == true)
                {
                    RotateLeft(plan, sirka, vyska);
                }
                else if (WallInFront(plan, sirka, vyska) == false && WallOnRight(plan, sirka, vyska) == false)
                {
                    if (y == true)
                        {
                        RotateRight(plan, sirka, vyska);
                        y = false;
                        }
                    else
                    {
                        GoForward(plan, sirka, vyska);
                        y = true;
                    }
                }
                else if (WallInFront(plan, sirka, vyska) == true && WallOnRight(plan, sirka, vyska) == false)
                {
                    RotateRight (plan, sirka, vyska);
                    y = false;
                }
                else
                {
                    Console.WriteLine("problem");
                }
                PrintPlan(plan);
            }


        }
        static List<int> FindHim(string[,] pole, int sirka, int vyska)
        {
            for (int j = 0; j < sirka; j++)
            {
                for (int i = 0; i < vyska; i++)
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
            string rotace = Rotace(pole,sirka,vyska);
            List<int> pozice = FindHim(pole, sirka, vyska);
            if (rotace == "^") 
            {
                pole[pozice[0], pozice[1]] = "<";
                return pole;
            }
            else if (rotace == "<")
            {
                pole[pozice[0], pozice[1]] = "v";
                return pole;
            }
            else if (rotace == "v")
            {
                pole[pozice[0], pozice[1]] = ">";
                return pole;
            }
            else if (rotace == ">")
            {
                pole[pozice[0], pozice[1]] = "^";
                return pole;
            }
            else
            {
                Console.WriteLine("problem");
                return pole;
            }

        }
        static string[,] RotateRight(string[,] pole, int sirka, int vyska)
        {
            string rotace = Rotace(pole, sirka, vyska);
            List<int> pozice = FindHim(pole, sirka, vyska);
            if (rotace == "^")
            {
                pole[pozice[0], pozice[1]] = ">";
                return pole;
            }
            else if (rotace == ">")
            {
                pole[pozice[0], pozice[1]] = "v";
                return pole;
            }
            else if (rotace == "v")
            {
                pole[pozice[0], pozice[1]] = "<";
                return pole;
            }
            else if (rotace == "<")
            {
                pole[pozice[0], pozice[1]] = "^";
                return pole;
            }
            else
            {
                Console.WriteLine("problem");
                return pole;
            }

        }
        static string[,] GoForward(string[,] pole, int sirka, int vyska)
        {
            string rotace = Rotace(pole, sirka, vyska);
            List<int> pozice = FindHim(pole, sirka, vyska);
            if (rotace == "^")
            {
                pole[pozice[0], pozice[1]] = ".";
                pole[pozice[0] - 1, pozice[1]] = "^";
                return pole;
            }
            else if (rotace == "v")
            {
                pole[pozice[0], pozice[1]] = ".";
                pole[pozice[0] + 1, pozice[1]] = "v";
                return pole;
            }
            else if (rotace == ">")
            {
                pole[pozice[0], pozice[1]] = ".";
                pole[pozice[0], pozice[1] + 1] = ">";
                return pole;
            }
            else if (rotace == "<")
            {
                pole[pozice[0], pozice[1]] = ".";
                pole[pozice[0], pozice[1] - 1] = "<";
                return pole;
            }
            else
            {
                Console.WriteLine("problem");
                return pole;
            }
        }
        static string Rotace(string[,] pole, int sirka, int vyska)
        {
            List<int> pozice = FindHim(pole, sirka, vyska);
            return pole[pozice[0], pozice[1]];
        }
        static bool WallOnRight(string[,] pole, int sirka, int vyska)
        {
            List<int> pozice = FindHim(pole, sirka, vyska);
            string rotace = Rotace(pole, sirka, vyska);
            if (rotace == "^" && pole[pozice[0], pozice[1] + 1] == "X") { return true; }
            else if (rotace == ">" && pole[pozice[0] + 1, pozice[1]] == "X") { return true; }
            else if (rotace == "<" && pole[pozice[0] - 1, pozice[1]] == "X") { return true; }
            else if (rotace == "v" && pole[pozice[0], pozice[1] - 1] == "X") { return true; }
            return false;
        }
        static bool WallOnLeft(string[,] pole, int sirka, int vyska)
        {
            List<int> pozice = FindHim(pole, sirka, vyska);
            string rotace = Rotace(pole, sirka, vyska);
            if (rotace == "^" && pole[pozice[0], pozice[1] - 1] == "X") { return true; }
            else if (rotace == ">" && pole[pozice[0] - 1, pozice[1]] == "X") { return true; }
            else if (rotace == "<" && pole[pozice[0] + 1, pozice[1]] == "X") { return true; }
            else if (rotace == "v" && pole[pozice[0], pozice[1] + 1] == "X") { return true; }
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
        static void PrintPlan(string[,] pole)
        {
            int rowLength = pole.GetLength(0);
            int colLength = pole.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", pole[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }

    }
}
