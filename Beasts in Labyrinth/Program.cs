using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Beasts_in_Labyrinth
{

    internal class Program
    {
        public class Beast
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public string Symbol { get; set; }
            public bool Lost { get; set; } = true;
        }
        static void Main(string[] args)
        {
            int sirka = Convert.ToInt16(Console.ReadLine());
            int vyska = Convert.ToInt16(Console.ReadLine());
            string[,] plan = new string[vyska, sirka];
            List<Beast> beasts = new List<Beast>();

            for (int i = 0; i < vyska; i++)
            {
                string lajna = Console.ReadLine();
                for (int j = 0; j < sirka; j++)
                {
                    plan[i, j] = lajna[j].ToString();
                    if ("<^>v".Contains(plan[i, j]))
                    {
                        beasts.Add(new Beast { Row = i, Col = j, Symbol = plan[i, j] });
                    }
                }
            }


            for (int i = 0; i < 20; i++)
            {
                foreach (Beast b in beasts)
                {
                    
                    bool frontWall = IsWall(plan, GetFrontRow(b), GetFrontCol(b));
                    bool rightWall = IsWall(plan, GetRightRow(b), GetRightCol(b));

                    
                    if (frontWall == false && rightWall == true)
                    {
                        GoForward(plan, b);
                    }
                    
                    else if (frontWall == true && rightWall == true)
                    {
                        RotateBeast(b, "left");
                    }
                    
                    else if (frontWall == false && rightWall == false)
                    {
                        if (b.Lost == true)
                        {
                            RotateBeast(b, "right");
                            b.Lost = false;
                        }
                        else
                        {
                            GoForward(plan, b);
                            b.Lost = true;
                        }
                    }
                    
                    else if (frontWall == true && rightWall == false)
                    {
                        RotateBeast(b, "right");
                        b.Lost = false;
                    }

                    
                    plan[b.Row, b.Col] = b.Symbol;
                }

                PrintPlan(plan);
            }
        }
        static int GetFrontRow(Beast b)
        {
            if (b.Symbol == "^") return b.Row - 1;
            if (b.Symbol == "v") return b.Row + 1;
            return b.Row;
        }

        static int GetFrontCol(Beast b)
        {
            if (b.Symbol == "<") return b.Col - 1;
            if (b.Symbol == ">") return b.Col + 1;
            return b.Col;
        }

        static int GetRightRow(Beast b)
        {
            if (b.Symbol == ">") return b.Row + 1;
            if (b.Symbol == "<") return b.Row - 1;
            return b.Row;
        }

        static int GetRightCol(Beast b)
        {
            if (b.Symbol == "^") return b.Col + 1;
            if (b.Symbol == "v") return b.Col - 1;
            return b.Col;
        }

        static bool IsWall(string[,] pole, int r, int c)
        {

            int maxRows = pole.GetLength(0); 
            int maxCols = pole.GetLength(1); 


            if (r < 0)
            {
                return true; 
            }
            if (r >= maxRows)
            {
                return true; 
            }


            if (c < 0)
            {
                return true;
            }
            if (c >= maxCols)
            {
                return true; 
            }

            
            if (pole[r, c] == "X")
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }

        static void GoForward(string[,] pole, Beast b)
        {
            int nextR = GetFrontRow(b);
            int nextC = GetFrontCol(b);

            pole[b.Row, b.Col] = "."; 
            b.Row = nextR;
            b.Col = nextC;
        }

        static void RotateBeast(Beast b, string direction)
        {
            string compass = "^>v<";
            int currentIndex = 0;

            for (int i = 0; i < 4; i++)
            {
                if (compass[i].ToString() == b.Symbol)
                {
                    currentIndex = i;
                    break;
                }
            }

            if (direction == "right")
            {
                currentIndex = (currentIndex + 1);
                if (currentIndex > 3) currentIndex = 0;
            }
            else
            {
                currentIndex = (currentIndex - 1);
                if (currentIndex < 0) currentIndex = 3;
            }

            b.Symbol = compass[currentIndex].ToString();
        }

        static void PrintPlan(string[,] pole)
        {
            Console.Clear();
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    Console.Write(pole[i, j] + " ");
                }
                Console.WriteLine();
            }
            System.Threading.Thread.Sleep(400);
        }
    }
}