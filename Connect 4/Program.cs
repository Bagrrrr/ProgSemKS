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
            int[,] board = new int[6, 7]{
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 1, 0 },
                { 2, 2, 2, 2, 2, 1, 0 }
            };
            int[] position = { 5, 3 };
            ConnectFour hra1 = new ConnectFour();
            Console.ReadLine();
        }
    }
    public class ConnectFour
    {
        public ConnectFour(int winNum, int columnNum, int rowNum, int playerAmount) 
        {
            this.winNum = winNum;
            board = new int[columnNum, rowNum];
            hraci = new Hrac[playerAmount];
        }
        int winNum; // datová položka
        int[,] board;
        Hrac[] hraci;
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
    }

}
