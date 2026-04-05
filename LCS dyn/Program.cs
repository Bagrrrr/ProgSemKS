using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace nejdelsi_posloupnost
{
    internal class Program
    {
        static List<int> LoadSequence(string line)
        {
            return line
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToList();
        }

        static List<int> SolveSequence(List<int> sequence)
        {
            int n = sequence.Count;
            int[] lengths = new int[n];
            int[] predecessors = new int[n];

            for (int i = 0; i < n; i++)
            {
                lengths[i] = 1;
                predecessors[i] = -1;
            }

            int maxLength = 1;
            int maxIndex = 0;

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (sequence[j] < sequence[i] && lengths[j] + 1 > lengths[i])
                    {
                        lengths[i] = lengths[j] + 1;
                        predecessors[i] = j;
                    }
                }
                if (lengths[i] > maxLength)
                {
                    maxLength = lengths[i];
                    maxIndex = i;
                }
            }

            var lis = new List<int>();
            for (int i = maxIndex; i >= 0; i = predecessors[i])
            {
                lis.Add(sequence[i]);
                if (predecessors[i] == -1)
                    break;
            }
            lis.Reverse();
            return lis;
        }

        static void Main(string[] args)
        {
            var path = @"..\..\..\vstupy.txt";

            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        Console.WriteLine("prázdná posloupnost");
                        Console.WriteLine();
                        continue;
                    }

                    var sequence = LoadSequence(line);
                    var longestSequence = SolveSequence(sequence);

                    if (longestSequence.Count == 0)
                    {
                        Console.WriteLine("prázdná posloupnost");
                    }
                    else
                    {
                        Console.WriteLine(string.Join(" ", longestSequence));
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}