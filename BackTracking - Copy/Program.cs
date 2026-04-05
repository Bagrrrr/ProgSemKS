using System;
using System.Collections.Generic;
using System.Linq;

namespace BackTracking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> hodnoty = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            if (!int.TryParse(Console.ReadLine(), out int suma))
            {
                Console.WriteLine("Invalid target sum input.");
                return;
            }

            // DEBUG: show what was parsed
            Console.WriteLine("Parsed hodnoty: " + string.Join(", ", hodnoty));
            Console.WriteLine("Parsed suma: " + suma);

            var solutions = FindAllWays(hodnoty, suma);
            if (solutions.Count == 0)
            {
                Console.WriteLine("No combinations found.");
            }
            else
            {
                foreach (var sol in solutions)
                    Console.WriteLine(string.Join(' ', sol));
            }
        }

        // rest of file unchanged...
        static void dfs(List<int> hodnoty, int suma, List<int> path, List<List<int>> allPaths, int start, int currentSum)
        {
            if (currentSum == suma)
            {
                allPaths.Add(new List<int>(path));
                return;
            }

            for (int i = start; i < hodnoty.Count; i++)
            {
                int value = hodnoty[i];

                if (currentSum + value > suma)
                    continue;

                path.Add(value);
                dfs(hodnoty, suma, path, allPaths, i + 1, currentSum + value);
                path.RemoveAt(path.Count - 1);
            }
        }
        public static List<List<int>> FindAllWays(List<int> hodnoty, int suma)
        {
            var path = new List<int>();
            var allPaths = new List<List<int>>();

            dfs(hodnoty, suma, path, allPaths, 0, 0);
            return allPaths;
        }
    }
}