using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace BackPackBackTracking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(@"Knapsack_testy.txt"))
            {
                for (int i = 0; i < 5; i++)
                {
                    sr.ReadLine();
                }
                while (!sr.EndOfStream)
                {
                    sr.ReadLine();
                    string ?profitValues = sr.ReadLine(); 
                    if (profitValues == null) break;
                    string ?weightsLine = sr.ReadLine();
                    string ?capacityStr = sr.ReadLine();
                    sr.ReadLine();
                    sr.ReadLine();
                    var values = profitValues.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse).ToArray();
                    var weights = weightsLine!.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse).ToArray();
                    int capacity = int.Parse(capacityStr!);
                    Backtrack(weights, values, capacity, 0, 0, 0, 0);





                }
            }
        }
        static void Backtrack(int[] weights, int[] values, int capacity, int index, int currentWeight, int currentValue, int maxValue)
        {
            int n = weights.Length;
            int bestValue = maxValue;
            List<int> bestChoice = new();
            var current = new List<int>();

            void Explore(int i, int rnWeight, int rnValue)
            {
                if (rnWeight > capacity) return;

                if (i == n)
                {
                    if (rnValue > bestValue)
                    {
                        bestValue = rnValue;
                        bestChoice = new List<int>(current);
                    }
                    return;
                }

                current.Add(i);
                Explore(i + 1, rnWeight + weights[i], rnValue + values[i]);
                current.RemoveAt(current.Count - 1);

                Explore(i + 1, rnWeight, rnValue);
            }

            Explore(index, currentWeight, currentValue);

            Console.WriteLine($"{bestValue}");
            Console.WriteLine(bestChoice.Count > 0 ? string.Join(", ", bestChoice.Select(i => (i + 1).ToString())) : "");
        }
    }
}