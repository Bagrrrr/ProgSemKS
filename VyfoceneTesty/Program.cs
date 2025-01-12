using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VyfoceneTesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int[]> graf = new List<int[]>();
            int matrixSize = 0;
            string line;
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                string[] input = line.Split(' '); // Split the input by spaces
                if (matrixSize == 0)
                {
                    matrixSize = input.Length; // The number of columns in the first row is the matrix size
                }
                if (graf.Count < matrixSize)
                {
                    int[] row = Array.ConvertAll(input, int.Parse);
                    graf.Add(row);
                }
                if (graf.Count == matrixSize)
                {
                    break;
                }

            }
            int[,] matrix = new int[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = graf[i][j];
                }
            }
            int[,] tabulka = new int[4, matrixSize];
            string[] jmena = Console.ReadLine().Split(';');
            string jmeno = Console.ReadLine();
            int position = Array.IndexOf(jmena, jmeno);

            for (int i = 0; i < matrixSize; i++)
            {
                tabulka[0, i] = i;
                tabulka[2, i] = -1;
                tabulka[3, i] = 0;
                if (i == position)
                {
                    tabulka[1, i] = 0;
                }
                else
                {
                    tabulka[1, i] = int.MaxValue;
                }
            }

            int[,] resultTable = new int[matrixSize, matrixSize];

            int zkoumatko = position;
            bool changed = true;
            while (changed)
            {
                changed = false;
                for (int i = 0; i < matrixSize; i++)
                {
                    if (matrix[zkoumatko,i] > -1)
                    {
                        if (tabulka[1,i] > tabulka[1,zkoumatko] + matrix[zkoumatko, i] && matrix[zkoumatko, i] != -1)
                        {
                            tabulka[1, i] = tabulka[1, zkoumatko] + matrix[zkoumatko, i];
                            tabulka[2, i] = zkoumatko;
                        }
                    }
                }
                tabulka[3, zkoumatko] = 1;
                int minPokus = int.MaxValue;
                for (int i = 0; i < matrixSize; i++)
                {
                    if (tabulka[3, i] == 0)
                    {
                        if (tabulka[1, i] < minPokus)
                        {
                            minPokus = tabulka[1, i];
                            zkoumatko = tabulka[0, i];
                            changed = true;
                        }
                    }
                }
            }
            for (int i = 0; i < matrixSize; i++)
            {
                if (tabulka[2, i] != -1)
                {
                    resultTable[tabulka[0, i], tabulka[2, i]] = 1;
                }
            }
            for (int i = 0; i < resultTable.GetLength(0); i++)
            {
                for (int j = 0; j < resultTable.GetLength(1); j++)
                {
                    Console.Write(resultTable[j, i] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
