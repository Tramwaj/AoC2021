using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace D13
{
    class Day13
    {
        static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory;
            //path = path + @"/testdata13.txt";
            path = path + @"/data13.txt";

            var data = File.ReadAllLines(path);
            int maxX, maxY;

            List<(int x, int y)> dots = new();
            List<(string axis, int number)> folds;

            dots = data.Where(x => x.Contains(","))
                       .Select(x => x.Split(",").Select(x => int.Parse(x)))
                       .Select(x => x.ToList())
                       .Select(z => (z.First(), z.Last()))
                       .ToList();
            folds = data.Where(x => x.Contains("fold"))
                        .Select(x => x.Split(' ').Last())
                        .Select(x => x.Split('='))
                        .Select(x => (x.First(), int.Parse(x.Last())))
                        .ToList();
            foreach (var fold in folds)
            {
                dots = fold.axis == "y" ? FoldHorizontally(dots, fold.number) : FoldVertically(dots, fold.number);
            }
            maxX = dots.Max(x => x.x+1);
            maxY = dots.Max(y => y.y+1);
            char[,] instructions = new char[maxX, maxY];
            foreach (var dot in dots)
            {
                instructions[dot.x, dot.y] = 'X';
            }
            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    Console.Write(instructions[i, j]=='X'?'X':'-');
                }
                Console.WriteLine();
            }
        }
        private static List<(int x, int y)> FoldHorizontally(List<(int x, int y)> dots, int lineNo)
        {
            
            return dots.Select(coords => (coords.x,coords.y > lineNo ? lineNo - (coords.y - lineNo) : coords.y )).Distinct().ToList();
            //return dots.ToList();
        }
        private static List<(int x, int y)> FoldVertically(List<(int x, int y)> dots, int columnNo)
        {
            return dots.Select(coords => ( coords.x > columnNo ? columnNo- (coords.x - columnNo) : coords.x,coords.y)).Distinct().ToList();
        }
    }
}
