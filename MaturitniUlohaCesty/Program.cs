using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturitniUlohaCesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string count = Console.ReadLine();
            string[] counts = count.Split(' ');
            try
            {
                int citiesTry = Int32.Parse(counts[0]);
                int roadTry = Int32.Parse(counts[1]);
            }
            catch (FormatException)
            {

                Console.WriteLine("Invalid input");
                return;
            }
            int cityCount = Int32.Parse(counts[0]);
            int roadCount = Int32.Parse(counts[1]);
            if (cityCount < 0 || roadCount < 0) 
            {
                Console.WriteLine("Invalid input");
                return; 
            }
            if (counts.Count() > 2)
            {
                Console.WriteLine( "Invalid input");
                return;
            }

            int[,] roadMap = new int[cityCount, cityCount];
            int[,] priceMap = new int[cityCount, cityCount];
            for (int i = 0; i < roadCount; i++)
            {
                string[] road = Console.ReadLine().Split();
                try
                {
                    int a = Int32.Parse(counts[0]);
                    int b = Int32.Parse(counts[1]);
                    int c = Int32.Parse(counts[2]);
                    int d = Int32.Parse(counts[3]);
                }
                catch (FormatException)
                {
                    Console.WriteLine(  "Invalid input");
                    return;
                }
                int cityOne = Int32.Parse(counts[0]);
                int cityTwo = Int32.Parse(counts[1]);
                int length = Int32.Parse(counts[2]);
                int fee = Int32.Parse(counts[3]);
                if (cityOne < 0 || cityTwo < 0 || length < 0 || fee < 0)
                {
                    Console.WriteLine("Invalid input");
                    return;
                }
                if (cityOne > cityCount || cityTwo > cityCount || fee > 2)
                {
                    Console.WriteLine("Invalid input");
                    return;
                }
                if (road.Count() > 4)
                {
                    Console.WriteLine("Invalid input");
                    return;
                }
                roadMap[cityOne, cityTwo] = length;
                roadMap[cityTwo, cityOne] = length;
                priceMap[cityOne, cityTwo] = fee;
                priceMap[cityTwo, cityOne] = fee;
            }
            string[] goals = Console.ReadLine().Split();
            try
            {
                int a = Int32.Parse(goals[0]);
                int b = Int32.Parse(goals[1]);
            }
            catch (FormatException)
            {

                Console.WriteLine("Invalid input");
                return;
            }
            int startCity = Int32.Parse(goals[0]);
            int finishCity = Int32.Parse(goals[1]);
            int[,] statTable = new int[5, cityCount];

            for (int i = 0; i < cityCount + 1; i++)
            {

            }

        }
    }
}
