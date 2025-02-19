using System;
using System.Collections.Generic;
using System.Linq;
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
            for (int i = 0; i < words.Length; i++)
            {
                matrix[i] = words[i].ToCharArray();
                if (matrix[i].Length > maxLength)
                {
                    maxLength = matrix[i].Length;
                }
            }
            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int x = 0; x < maxLength; x++)
                {

                }
            }

        }
    }
}
