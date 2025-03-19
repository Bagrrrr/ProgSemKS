using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine(CheckColumn(board, 2, 2, position));
            Console.ReadLine(); 
        }

        public static bool CheckRow(int[,] dvaDpole, int pocetNaVyhru, int hrac, int[] hranaPozice)
        {
            int CheckedRow = hranaPozice[0];
            int InARow = 0;
            for (int i = 0; i < dvaDpole.GetLength(1); i++)
            {
                if (dvaDpole[CheckedRow,i] == hrac)
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
                if (dvaDpole[i,CheckedColumn] == hrac)
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
        /*
        public bool CheckDiagonal(int[,] dvaDpole, int pocetNaVyhru, int hrac, int[] hranaPozice)
        {

        }




        public bool Check(int[,] dvaDpole, int pocetNaVyhru, int hrac, int[] hranaPozice)
        {
            return CheckDiagonal(dvaDpole, pocetNaVyhru, hrac, hranaPozice) || CheckRow(dvaDpole, pocetNaVyhru, hrac, hranaPozice) || CheckColumn(dvaDpole, pocetNaVyhru, hrac, hranaPozice)
        }
        */
    }
}
