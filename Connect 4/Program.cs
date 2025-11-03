using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Connect_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectFour hra1 = new ConnectFour(4,7,6,4);
            hra1.Play();
            Console.ReadLine();
        }
    }
    public class ConnectFour
    {
        public ConnectFour(int winNum, int columnNum, int rowNum, int playerAmount) 
        {
            this.winNum = winNum;
            board = new int[rowNum, columnNum];
            hraci = new Hrac[playerAmount];
            hraciNum = playerAmount;
            List<string> symbols = new List<string> { "X", "O", "A", "B", "C", "D", "E", "F", "G", "H" };

            for (int i = 0; i < playerAmount; i++)
            {
                hraci[i] = new Hrac
                {
                    Jmeno = $"Player {i + 1}",
                    Symbol = symbols[i % symbols.Count],
                    Cislo = (i + 1).ToString()
                };
            }
        }
        int winNum;
        int[,] board;
        Hrac[] hraci;
        int hraciNum;

        public void Play()
        {
            int currentPlayer = 0;
            bool konecHry = false;
            while (!konecHry)
            {
                PrintBoard(board);
                Console.WriteLine($"{hraci[currentPlayer].Jmeno} na tahu");
                int column = GetColumn(board.GetLength(1), board);
                int row = PlacePiece(board, column, currentPlayer);
                int [] hrana = new int[] { row, column };
                if (Check(board, winNum, currentPlayer + 1, hrana))
                {
                    konecHry = true;
                    Console.Clear();
                    PrintBoard(board);
                    Console.WriteLine($"{hraci[currentPlayer].Jmeno} vyhrál!");
                }
                else if (IsFull(board))
                {
                    konecHry = true;
                    Console.Clear();
                    PrintBoard(board);
                    Console.WriteLine("Remíza!");
                }
                currentPlayer = (currentPlayer + 1) % hraciNum;
            }
        }
        public static int PlacePiece(int[,] board , int column, int player)
        {
            for (int i = board.GetLength(0) - 1; i >= 0; i--)
            {
                if (board[i, column] == 0)
                {
                    board[i, column] = player + 1;
                    return i;
                }
            }
            return -1;
        }
        public void PrintBoard(int[,] dvaDpole)
        {
            Console.Clear();
            for (int i = 0; i < dvaDpole.GetLength(0); i++)
            {
                for (int j = 0; j < dvaDpole.GetLength(1); j++)
                {
                    if (dvaDpole[i, j] == 0)
                    {
                        Console.Write(dvaDpole[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(hraci[dvaDpole[i, j] - 1].Symbol + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        public static int GetColumn(int columnAmount, int[,] board)
        {
            int column;
            while (true)
            {
                Console.Write("Zadej sloupec: ");
                if (int.TryParse(Console.ReadLine(), out column) && column > 0 && column <= columnAmount)
                {
                    if (board[0, column - 1] == 0)
                        return column - 1;
                }
                Console.WriteLine("Neplatný vstup");
            }
        }
        public static bool IsFull(int[,] dvaDpole)
        {
            for (int i = 0; i < dvaDpole.GetLength(0); i++)
            {
                for (int j = 0; j < dvaDpole.GetLength(1); j++)
                {
                    if (dvaDpole[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool CheckRow(int[,] dvaDpole, int pocetNaVyhru, int hrac, int[] hranaPozice)
        {
            int CheckedRow = hranaPozice[0];
            int InARow = 0;
            for (int i = 0; i < dvaDpole.GetLength(1); i++)
            {
                if (dvaDpole[CheckedRow, i] == hrac)
                {
                    InARow++;
                }
                else
                {
                    InARow = 0;
                }
                if (InARow == pocetNaVyhru)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckColumn(int[,] dvaDpole, int pocetNaVyhru, int hrac, int[] hranaPozice)
        {
            int CheckedColumn = hranaPozice[1];
            int InARow = 0;
            for (int i = 0; i < dvaDpole.GetLength(0); i++)
            {
                if (dvaDpole[i, CheckedColumn] == hrac)
                {
                    InARow++;
                }
                else
                {
                    InARow = 0;
                }
                if (InARow == pocetNaVyhru)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckDiagonalOne(int[,] dvaDpole, int pocetNaVyhru, int hrac, int[] hranaPozice)
        {
            int InARow = 0;
            int row = hranaPozice[0];
            int column = hranaPozice[1];
            while (row > 0 && column < dvaDpole.GetLength(1) - 1)
            {
                row--;
                column++;
            }
            while (row < dvaDpole.GetLength(0) && column >= 0)
            {
                if (dvaDpole[row, column] == hrac)
                {
                    InARow++;
                }
                else
                {
                    InARow = 0;
                }
                if (InARow == pocetNaVyhru)
                {
                    return true;
                }
                row++;
                column--;
            }
            return false;
        }
        public bool CheckDiagonalTwo(int[,] dvaDpole, int pocetNaVyhru, int hrac, int[] hranaPozice)
        {
            int InARow = 0;
            int row = hranaPozice[0];
            int column = hranaPozice[1];
            while (row > 0 && column > 0)
            {
                row--;
                column--;
            }
            while (row < dvaDpole.GetLength(0) && column < dvaDpole.GetLength(1))
            {
                if (dvaDpole[row, column] == hrac)
                {
                    InARow++;
                }
                else
                {
                    InARow = 0;
                }
                if (InARow == pocetNaVyhru)
                {
                    return true;
                }
                row++;
                column++;
            }
            return false;
        }
        public bool CheckDiagonal(int[,] dvaDpole, int pocetNaVyhru, int hrac, int[] hranaPozice)
        {
            return CheckDiagonalOne(dvaDpole, pocetNaVyhru, hrac, hranaPozice) || CheckDiagonalTwo(dvaDpole, pocetNaVyhru, hrac, hranaPozice);
        }
        public bool Check(int[,] dvaDpole, int pocetNaVyhru, int hrac, int[] hranaPozice)
        {
            return CheckDiagonal(dvaDpole, pocetNaVyhru, hrac, hranaPozice) || CheckRow(dvaDpole, pocetNaVyhru, hrac, hranaPozice) || CheckColumn(dvaDpole, pocetNaVyhru, hrac, hranaPozice);
        }
    }
    class Hrac
    {
        public string Jmeno;
        public string Symbol;
        public string Cislo;
    }

}
