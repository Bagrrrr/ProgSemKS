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

            hodnoty.Sort();

            if (!int.TryParse(Console.ReadLine(), out int suma))
            {
                Console.WriteLine("Zadej integer");
                return;
            }



            var solutions = FindAllWays(hodnoty, suma);
            if (solutions.Count == 0)
                Console.WriteLine("0");
            else
                foreach (var sol in solutions)
                    Console.WriteLine(string.Join(' ', sol));
        }

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
                    break;

                path.Add(value);
                dfs(hodnoty, suma, path, allPaths, i, currentSum + value);
                path.RemoveAt(path.Count - 1);
            }
        }

        public static List<List<int>> FindAllWays(List<int> hodnoty, int suma)
        {
            var path = new List<int>();
            var allPaths = new List<List<int>>();

            dfs(hodnoty, suma, path, allPaths, 0, 0);
            foreach (var p in allPaths)
                p.Reverse();
            allPaths.Reverse();
            return allPaths;
        }
    }
}
