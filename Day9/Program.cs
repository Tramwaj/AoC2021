using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines("Data9.txt").Select(x => x.ToCharArray().Select(x => (int)(x - 48)).ToArray()).ToArray();
            List<int> x = GetLowPoints(data);
        }
        public static List<int> GetLowPoints(int[][] arr)
        {
            List<int> LowPointsValues = new();
            List<(int, int)> LowPointsCoordinates = new();
            List<int> BasinSizes = new();
            int maxi = arr.Length;
            int maxj = arr[0].Length;
            for (int i = 0; i < maxi; i++)
            {
                for (int j = 0; j < maxj; j++)
                {
                    bool isLowPoint = true;
                    if (i != 0 && arr[i - 1][j] <= arr[i][j]) isLowPoint = false;
                    if (j != 0 && arr[i][j - 1] <= arr[i][j]) isLowPoint = false;
                    if (i != maxi - 1 && arr[i + 1][j] <= arr[i][j]) isLowPoint = false;
                    if (j != maxj - 1 && arr[i][j + 1] <= arr[i][j]) isLowPoint = false;
                    if (isLowPoint == true)
                    {
                        Console.Write($"[{i}][{j}]:{arr[i][j]}");
                        Console.WriteLine();
                        LowPointsValues.Add(arr[i][j]);
                        LowPointsCoordinates.Add((i, j));
                    }
                }
            }
            List<(int,int)> currentBasinCoords;
            List<int> BiggestBasins = new();
            foreach (var coord in LowPointsCoordinates)
            {
                currentBasinCoords = new();
                ExploreBasin(coord);
                int size = currentBasinCoords.Distinct().Count();
                Console.WriteLine($"Basin: {size}");
                BiggestBasins.Add(size);
                if (BiggestBasins.Count > 3) BiggestBasins.Remove(BiggestBasins.Min());
            }
            Console.WriteLine($"Product of 3 largest basin sizes: {BiggestBasins[0]*BiggestBasins[1]*BiggestBasins[2]}");
            void ExploreBasin((int x, int y) coord)
            {
                currentBasinCoords.Add((coord.x, coord.y));
                int i = coord.x;
                int j = coord.y;
                if (i != 0 && arr[i - 1][j] != 9 && arr[i - 1][j] > arr[i][j]) {  ExploreBasin((i - 1, j)); }
                if (j != 0 && arr[i][j - 1] != 9 && arr[i][j - 1] > arr[i][j]) {  ExploreBasin((i, j - 1)); }
                if (i != maxi - 1 && arr[i + 1][j] != 9 && arr[i + 1][j] > arr[i][j]) {  ExploreBasin((i + 1, j)); }
                if (j != maxj - 1 && arr[i][j + 1] != 9 && arr[i][j + 1] > arr[i][j]) { ; ExploreBasin((i, j + 1)); }

            }

            Console.WriteLine($"Sum: {LowPointsValues.Sum(x => x + 1)}");
            return LowPointsValues;
        }
    }
}
