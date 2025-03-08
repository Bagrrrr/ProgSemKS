using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GrafSouvislosti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] resultList = new int[26][];
            
            // 0a1b2c3d4e5f6g7h8i9j10k11l12m13n14o15p16q17r18s19t20u21v22w23x24y25z

            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            char[][] matrix = new char[words.Length][];
            int maxLength = 0;

            HashSet<char> charSet = new HashSet<char>();

            foreach (string word in words)
            {
                foreach (char c in word)
                {
                    charSet.Add(c);
                }
            }
            List<char> pismena = new List<char>(charSet);
            int vrcholCount = pismena.Count();
            int cols = 2;
            object[,] vrcholy = new object[vrcholCount,cols];

            for (int i = 0; i < vrcholCount; i++)
            {
                vrcholy[i, 0] = pismena[i];   // Original character
                vrcholy[i, 1] = 1;             // Extra value 1: Index
            }
            for (int i = 0; i < words.Length; i++)
            {
                matrix[i] = words[i].ToCharArray();
                if (matrix[i].Length > maxLength)
                {
                    maxLength = matrix[i].Length;
                }
            }

            int[,] vazby = new int[vrcholCount,vrcholCount];

            for (int i = maxLength; i > 0; i++)
            {
                List<string> stringyDelky = new List<string>();
                foreach (var str in words)
                {
                    if (str.Length == i)
                    {
                        stringyDelky.Add(str);
                    }
                }
                for (int j = 0; j < stringyDelky.Count-1; j++)
                {
                    bool Y = false; 
                    for (int k = 0; k < i - 1; k++)
                    {
                        if (stringyDelky[j][k] != stringyDelky[j+1][k])
                        {
                            Y = true;
                        }
                    }
                    if (Y == false)
                    {
                        if (stringyDelky[j][i-1] != stringyDelky[j + 1][i-1])
                        {
                            int x = 0;
                            int y = 0;
                            for (int l = 0; l < vrcholCount; l++)
                            {
                                if ((char)vrcholy[l, 0] == stringyDelky[j][i - 1])
                                {
                                    x = l;
                                }
                            }
                            for (int l = 0; l < vrcholCount; l++)
                            {
                                if ((char)vrcholy[l, 0] == stringyDelky[j+1][i - 1])
                                {
                                    y = l;
                                }
                            }
                            vazby[x, y] = 1;
                            vazby[y, x] = -1;
                        }
                    }
                }
            }





            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            Console.WriteLine(string.Join(", ", pismena));
            for (int i = 0; i < vrcholCount; i++) // Loop through rows
            {
                for (int j = 0; j < 2; j++) // Loop through columns
                {
                    Console.Write(vrcholy[i, j]); // Print with a tab between columns
                }
                Console.WriteLine(); // Move to the next line after each row
            }
            for (int i = 0; i < vrcholCount; i++)
            {
                for (int j = 0; j < vrcholCount; j++)
                {
                    Console.Write(vazby[i, j] + " ");  // Print each value with a space
                }
                Console.WriteLine();  // Move to the next line after printing each row
            }
            Console.ReadLine();

        }
    }
}
